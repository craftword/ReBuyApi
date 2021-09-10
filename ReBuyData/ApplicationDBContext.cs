using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReBuyModels;

namespace ReBuyData
{
    public class ApplicationDBContext : IdentityDbContext<UsersModel>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<OrdersModel> Orders { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        public DbSet<LikesModel> Likes { get; set; }
        public DbSet<ImagesModel> Images { get; set; }
        public DbSet<ListingModel> Listings { get; set; }

    }
}
