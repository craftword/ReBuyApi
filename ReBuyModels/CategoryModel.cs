using System;
using System.Collections.Generic;


namespace ReBuyModels
{
    public class CategoryModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;

        public ICollection<ProductModel> Products { get; set; }

    }
}
