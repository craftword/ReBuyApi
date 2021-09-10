using System;


namespace ReBuyModels
{
    public class ImagesModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();        
        public string ImageUrl { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;

        public ProductModel Product { get; set; }
    }
}
