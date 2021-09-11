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
    public interface IUser
    {
        Task<UploadResult> UploadImage(IFormFile image);
        Task<List<UsersModel>> GetAllUserLikesProduct(string Id);

        Task<List<UsersModel>> GetAllUserListingProduct(string Id);

        Task<List<UsersModel>> GetAllUserOrders(string Id);
    }
}
