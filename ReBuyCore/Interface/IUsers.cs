using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using ReBuyModels;

namespace ReBuyCore.Interface
{
    public interface IUsers
    {
        Task<UploadResult> UploadImage(IFormFile image);
        Task<List<ProductModel>> GetAllUserLikesProduct(string Id);

        Task<List<ProductModel>> GetAllUserListingProduct(string Id);

        Task<List<ProductModel>> GetAllUserOrders(string Id);
    }
}
