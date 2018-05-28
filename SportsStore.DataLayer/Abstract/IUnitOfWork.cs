using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.DataLayer.Entities;

namespace SportsStore.DataLayer.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Product> ProductRepository { get; }
        IGenericRepository<ProductCategory> CategoryRepository { get; }

        void Save();
    }
}
