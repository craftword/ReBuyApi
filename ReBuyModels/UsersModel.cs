using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ReBuyModels
{
    public class UsersModel : IdentityUser
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string State { get; set; }
        public string PublicId { get; set; }
        public bool IsActive { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;

        public ICollection<OrdersModel> Orders { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<LikesModel> Likes { get; set; }
        public ICollection<ListingModel> Listings { get; set; }

    }
}
