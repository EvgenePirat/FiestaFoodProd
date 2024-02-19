﻿using Autofac;
using Business.Interfaces;
using Business.Services;
using DataAccess.Data;
using DataAccess.Interfaces;
using FileStorageHandler.Interfaces;
using FileStorageHandler.Services;

namespace Business.DependencyResolvers
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<BrandService>().As<IBrandService>();
            builder.RegisterType<ProviderService>().As<IProviderService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<CustomerInfoService>().As<ICustomerInfoService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<FileService>().As<IFileService>();
            builder.RegisterType<FileWriterService>().As<IFileWriteService>();
            builder.RegisterType<DirectoryService>().As<IDirectoryService>();
            builder.RegisterType<OrderService>().As<IOrderService>();
            builder.RegisterType<OrderDetailService>().As<IOrderDetailService>();
        }
    }
}
