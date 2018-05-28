using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.DataLayer.Abstract;
using SportsStore.DataLayer.Entities;

namespace SportsStore.DataLayer.Implementations
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EntityContext _context = new EntityContext();
        private IGenericRepository<Product> _productsGenericRepository;
        private IGenericRepository<ProductCategory> _categoriesGenericRepository;

        public IGenericRepository<Product> ProductRepository =>
            _productsGenericRepository ?? (_productsGenericRepository = new GenericRepository<Product>(_context));

        public IGenericRepository<ProductCategory> CategoryRepository =>
            _categoriesGenericRepository ?? (_categoriesGenericRepository = new GenericRepository<ProductCategory>(_context));

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
