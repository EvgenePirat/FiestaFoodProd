using System.Diagnostics;
using AutoMapper;
using Business.CustomExceptions;
using Business.Interfaces;
using Business.Models.Filter;
using Business.Models.Pagination;
using Business.Models.Products;
using CustomExceptions.BrandCustomExceptions;
using CustomExceptions.CategoryCustomExceptions;
using CustomExceptions.FileCustomExceptions;
using CustomExceptions.ProviderCustomExceptions;
using DataAccess.Interfaces;
using DataAccess.Utilities;
using Entities.Entities;
using FileStorageHandler.Interfaces;

namespace Business.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IDirectoryService _directoryService;
        private readonly IFileService _fileService;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper, IDirectoryService directoryService, IFileService fileService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _directoryService = directoryService;
            _fileService = fileService;
        }

        public async Task<ProductModel> AddProductAsync(AddProductModel model, CancellationToken ct)
        {
            var mappedModel = await CheckProductEntityExist(model, ct);

            // Initialize default defaultPath for product
            var defaultPath = await _directoryService.GetDefaultPathAsync(mappedModel, ct);
            // Create a folders by path
            await _directoryService.CreateFolderAsync(defaultPath, ct);

            mappedModel.PhotoPaths = defaultPath;
            _unitOfWork.ProductRepository.Add(mappedModel);

            await _unitOfWork.SaveAsync(ct);

            if (model.Files is not null && model.Files.Any())
                await _fileService.UploadFilesAsync(model.Files, defaultPath, ct);
            return _mapper.Map<ProductModel>(mappedModel);
        }

        /// <summary>
        /// Implementation business logic for get product with id
        /// </summary>
        /// <param name="id">Id for search in bd</param>
        /// <param name="ct">Cancellation token</param>
        /// <returns>Returns product if exist or throw exception</returns>
        /// <exception cref="ProductArgumentException">If product not found</exception>
        public async Task<ProductModel> GetProductByIdAsync(Guid id, CancellationToken ct)
        {
            var product = await _unitOfWork.ProductRepository.GetProductById(id, ct)
                          ?? throw new ProductArgumentException("Product with this id not found");
            var mappedProduct = _mapper.Map<ProductModel>(product);
            return mappedProduct;
        }

        public async Task<PagedProductModel> GetProductsByCategoryAsync(int categoryId, PaginationModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<PaginationDb>(model);
            var result = await _unitOfWork.ProductRepository.GetProductByCategory(categoryId, mappedModel, ct);

            return new PagedProductModel
            {
                Products = _mapper.Map<IEnumerable<ProductModel>>(result.Result),
                TotalPages = result.TotalPages,
            };
        }

        public async Task<PagedProductModel> GetFilteredProductsAsync(FilterModel filter, CancellationToken ct)
        {
            var mappedFilter = _mapper.Map<FilterState>(filter);
            var result = await _unitOfWork.ProductRepository.GetProductsByQueryAsync(mappedFilter, ct);
            
            return new PagedProductModel
            {
                Products = _mapper.Map<IEnumerable<ProductModel>>(result.Result),
                TotalPages = result.TotalPages
            };
        }

        public async Task<ProductModel> UpdateProductAsync(UpdateProductModel model, CancellationToken ct)
        {
            var productToUpdate = await CheckProductEntityExist(model, ct);
            var productName = productToUpdate.Name;
            var defaultPath = string.IsNullOrEmpty(productToUpdate.PhotoPaths)
                ? await _directoryService.GetDefaultPathAsync(productToUpdate, ct)
                : productToUpdate.PhotoPaths;

            if (productToUpdate.Name != model.Name)
            {
                await _directoryService.RenameFolderAsync(defaultPath, model.Name, ct);
                productToUpdate.Name = model.Name;

                // Get new default path for product
                defaultPath = await _directoryService.GetDefaultPathAsync(productToUpdate, ct);
                if (string.IsNullOrEmpty(defaultPath))
                    throw new DirectoryNotFoundException("Exception with directory (not found)");
                productToUpdate.PhotoPaths = defaultPath;
            }

            productToUpdate.Description = model.Description;
            productToUpdate.Price = model.Price;
            productToUpdate.CategoryId = model.CategoryId;
            productToUpdate.ProviderId = model.ProviderId;
            productToUpdate.BrandId = model.BrandId;

            try
            {
                _unitOfWork.ProductRepository.Update(productToUpdate);
                await _unitOfWork.SaveAsync(ct);
                if (model.Files is not null && model.Files.Any())
                    await _fileService.UploadFilesAsync(model.Files, defaultPath, ct);
            }
            catch
            {
                if (productToUpdate.Name != model.Name)
                    await _directoryService.RenameFolderAsync(defaultPath, productName, ct);
                throw new ProviderArgumentException("An error occurred while updating the product.");
            }

            return _mapper.Map<ProductModel>(productToUpdate);;
        }

        public async Task DeleteProductByIdAsync(Guid id, CancellationToken ct)
        {
            var product = await _unitOfWork.ProductRepository.GetProductById(id, ct)
                        ?? throw new ProductArgumentException("Product with this id not found");
            _unitOfWork.ProductRepository.Delete(product);

            await _directoryService.DeleteFolderByPathAsync(product.PhotoPaths, ct);

            await _unitOfWork.SaveAsync(ct);
        }

        private async Task<Product> CheckProductEntityExist(AddProductModel model, CancellationToken ct)
        {
            var mappedModel = _mapper.Map<Product>(model);

            if (model.ProviderId is not null)
                mappedModel.Provider = await _unitOfWork.ProviderRepository.GetByIdAsync((Guid)model.ProviderId, ct) ??
                                       throw new ProviderArgumentException($"Provider with this {model.ProviderId} not exist");

            if (model.BrandId is not null)
                mappedModel.Brand = await _unitOfWork.BrandRepository.GetById((Guid)model.BrandId, ct)
                                    ?? throw new BrandArgumentException($"Brand with this {model.BrandId} not exist");

            mappedModel.Category = await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId, ct)
                           ?? throw new CategoryArgumentException($"Category with this {model.CategoryId} not exist");

            return mappedModel;
        }

        private async Task<Product> CheckProductEntityExist(UpdateProductModel model, CancellationToken ct)
        {
            var product = await _unitOfWork.ProductRepository.GetProductById(model.Id, ct)
                                  ?? throw new ProductArgumentException("Product with this id not found");
            if (model.ProviderId is not null)
            {
                product.Provider = await _unitOfWork.ProviderRepository.GetByIdAsync((Guid)model.ProviderId, ct) ??
                                 throw new ProviderArgumentException($"Provider with this {model.ProviderId} not exist");
            }

            if (model.BrandId is not null)
            {
                product.Brand = await _unitOfWork.BrandRepository.GetById((Guid)model.BrandId, ct)
                              ?? throw new BrandArgumentException($"Brand with this {model.BrandId} not exist");
            }

            product.Category = await _unitOfWork.CategoryRepository.GetByIdAsync(model.CategoryId, ct)
                           ?? throw new CategoryArgumentException($"Category with this {model.CategoryId} not exist");

            return product;
        }
    }
}
