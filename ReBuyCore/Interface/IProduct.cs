using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReBuyModels;

namespace ReBuyCore.Interface
{
    public interface IProduct
    {
        Task<ProductModel> GetAProductDetails(string Id);
        Task<List<ProductModel>> GetNewArrivalProducts();
        Task<List<ProductModel>> GetMostViewProducts();
    }
}
