using eShopSolution.ViewModels.Common;
using System.Collections.Generic;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }

        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
}