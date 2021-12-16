using System.ComponentModel.DataAnnotations;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductDeleteRequest
    {
        [Display(Name = "Id sản phẩm")]
        public int Id { get; set; }
    }
}