using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ReBuyCore.Interface;
using ReBuyData;
using ReBuyModels;

namespace ReBuyCore.Services
{
    public class UserService : IUsers
    {
        private readonly ApplicationDBContext _dbContext;
        private readonly Cloudinary _cloudinary;

        public UserService(ApplicationDBContext dbContext, Cloudinary cloudinary)
        {
            _dbContext = dbContext;
            _cloudinary = cloudinary;
        }
        public async Task<List<ProductModel>> GetAllUserLikesProduct(string Id)
        {
            var products = await _dbContext.Users
                                 .Where(s => s.Id == Id)
                                 .Include(s => s.Likes)
                                    .ThenInclude(a => a.Product)
                                 .FirstOrDefaultAsync();
            var likes = products.Likes.Select(z => z.Product).ToList();
           
            return likes;
        }

        public async Task<List<ProductModel>> GetAllUserListingProduct(string Id)
        {
            var products = await _dbContext.Users
                                 .Where(s => s.Id == Id)
                                 .Include(s => s.Listings)
                                    .ThenInclude(a => a.Product)
                                 .FirstOrDefaultAsync();
            var listings = products.Listings.Select(z => z.Product).ToList();

            return listings;
        }

        public async Task<List<ProductModel>> GetAllUserOrders(string Id)
        {
            var orders = await _dbContext.Orders
                                 .Where(s => s.User.Id == Id)
                                 .Include(s => s.Product)                                    
                                 .ToListAsync();

            var products = orders.Select(x => x.Product).ToList();
            return products;
        }

        public async Task<UploadResult> UploadImage(IFormFile image)
        {
            IFormatProvider provider = CultureInfo.CreateSpecificCulture("en-US");

            var result = await _cloudinary.UploadAsync(new ImageUploadParams
            {
                File = new FileDescription(image.FileName, image.OpenReadStream()),
                Transformation = new Transformation().Crop("thumb").Gravity("face").Width(1000)
                                                        .Height(1000).Radius(40)
            }).ConfigureAwait(false);

            return result;
        }

       
    }
}
