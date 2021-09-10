using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBuyModels
{
    public class ListingModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public bool Unlist { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        public ProductModel Product { get; set; }
        public UsersModel User { get; set; }
    }
}
