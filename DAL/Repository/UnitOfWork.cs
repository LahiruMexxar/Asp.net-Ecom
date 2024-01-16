using DAL.Data;
using DAL.Models;
using DAL.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _dbcontext;

        public IProductRepository Product { get; private set; }

        public UnitOfWork(AppDBContext dbcontext) 
        {
            _dbcontext = dbcontext;
            Product = new ProductRepository(dbcontext);
        }

        public void Dispose()
        {
           _dbcontext.Dispose();
        }

        public async Task SaveAsync()
        {
            await _dbcontext.SaveChangesAsync();
        }
    }
}
