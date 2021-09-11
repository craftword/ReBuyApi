using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReBuyCore.Interface;
using ReBuyData;
using ReBuyModels;

namespace ReBuyCore.Services
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDBContext _dbContext;

        public ProductService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;   
        }
        public async Task<ProductModel> GetAProductDetails(string Id)
        {
            var product = await _dbContext.Products
                                .Where(s => s.Id == Id)                               
                                .FirstOrDefaultAsync();
            return product;
        }

        public async Task<List<ProductModel>> GetNewArrivalProducts()
        {
            var product = await _dbContext.Products
                                .OrderByDescending(s => s.Created_at)
                                .Take(4)                                
                                .ToListAsync();
            return product;
        }

        public async Task<List<ProductModel>> GetRecentViewProducts()
        {
            var product = await _dbContext.Products                                
                               .OrderByDescending(s => s.Created_at)
                               .Take(4)
                               .ToListAsync();
            return product;
        }
    }
}
