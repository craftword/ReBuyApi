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
    public class OrderService : IOrder
    {
        private readonly ApplicationDBContext _dbContext;

        public OrderService(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> AddNewOrder(OrdersModel model)
        {
            try
            {
                await _dbContext.Orders.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            } 

        }

        public async Task<OrdersModel> GetAOrderDetails(string Id)
        {
            var order = await _dbContext.Orders
                                .Where(s => s.Id == Id)
                                .Include(x => x.Product)
                                .FirstOrDefaultAsync();
            return order;
        }
    }
}
