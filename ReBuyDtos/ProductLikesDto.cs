using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBuyDtos
{
    public class ProductLikesDto
    {
        public string Name { get; set; }        
        public double Price { get; set; }
        public string Thumbnail { get; set; }
        public int NoOfViews { get; set; }
        public DateTime Created_at { get; set; }
    }
}
