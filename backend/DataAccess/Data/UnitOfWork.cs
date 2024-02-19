﻿using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StContext _context;
        public UnitOfWork(StContext context)
        {
            _context = context;
        }

        private IDishRepository _dishRepository;
        public IDishRepository DishRepository =>
            _dishRepository ??= new DishRepository(_context);

        private ICategoryRepository _categoryRepository;
        public ICategoryRepository CategoryRepository => 
            _categoryRepository ??= new CategoryRepository(_context);

        private IUserRepository _userRepository;
        public IUserRepository UserRepository => 
            _userRepository ??= new UserRepository(_context);

        private ICustomerInfoRepository _CustomerInfoRepository;
        public ICustomerInfoRepository CustomerInfoRepository => 
            _CustomerInfoRepository ??= new CustomerInfoRepository(_context);

        private IOrderRepository _orderRepository;
        public IOrderRepository OrderRepository => 
            _orderRepository ??= new OrderRepository(_context);

        private IOrderDetailRepository _orderDetailRepository;
        public IOrderDetailRepository OrderDetailRepository => 
            _orderDetailRepository ??= new OrderDetailRepository(_context);

        public async Task SaveAsync(CancellationToken ct)
        {
            await _context.SaveChangesAsync(cancellationToken: ct);
        }

        public async Task<IDbContextTransaction> BeginTransactionDbContextAsync(CancellationToken ct)
        {
            return await _context.Database.BeginTransactionAsync(ct);
        }
    }
}
