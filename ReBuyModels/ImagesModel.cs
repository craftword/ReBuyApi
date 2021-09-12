using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReBuyModels
{
    public class ImagesModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();        
        public string ImageUrl { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;
        [ForeignKey("Product")]
        public string ProductId { get; set; }
        public ProductModel Product { get; set; }
        
    }
}
