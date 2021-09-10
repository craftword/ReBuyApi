﻿using System;
using System.Collections.Generic;

namespace ReBuyModels
{
    public class ProductModel
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string Descriptions { get; set; }
        public string Maker { get; set; }
        public string Year { get; set; }
        public double Price { get; set; }
        public bool HasWarant { get; set; }
        public bool HasOriginalPack { get; set; }
        public DateTime Created_at { get; set; } = DateTime.Now;

        public CategoryModel Category { get; set; }

        public ICollection<OrdersModel> Orders { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<LikesModel> Likes { get; set; }
        public ICollection<ListingModel> Listings { get; set; }

        public ICollection<ImagesModel> Images { get; set; }
    }
}
