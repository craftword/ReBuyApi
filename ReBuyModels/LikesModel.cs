using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBuyModels
{
    public class LikesModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool IsLike { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public ProductModel Product { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public UsersModel User { get; set; }
    }
}
