﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Products.Dtos.Manage
{
    public class ProductCreateRequest
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public decimal OriginalPrice { set; get; }

        public int Stock { set; get; }

        public string Description { set; get; }

        public string Details { set; get; }

        public string SeoDescription { set; get; }

        public string SeoTitle { set; get; }

        public string SeoAlias { get; set; }

        public string LanguageId { set; get; }
    }
}
