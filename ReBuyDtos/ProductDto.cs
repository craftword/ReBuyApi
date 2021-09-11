using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReBuyDtos
{
    public class ProductDto
    {
        public string Id { get; set; } 
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public string Maker { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }
        public bool HasWarant { get; set; }
        public bool HasOriginalPack { get; set; }
        public string Thumbnail { get; set; }
        public int NoOfViews { get; set; }
        public DateTime Created_at { get; set; } 
    }
}
