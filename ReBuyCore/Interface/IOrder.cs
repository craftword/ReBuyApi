using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReBuyModels;

namespace ReBuyCore.Interface
{
    public interface IOrder
    {
        Task<OrdersModel> GetAOrderDetails(string Id);
        Task<bool> AddNewOrder(OrdersModel model);
    }
}
 