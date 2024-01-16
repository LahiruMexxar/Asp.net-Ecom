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
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly AppDBContext _dbContext;

        public ProductRepository(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
