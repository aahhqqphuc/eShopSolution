using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập giá bán")]
        [Display(Name = "Giá bán")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập giá gốc")]
        [Display(Name = "Giá gốc")]
        public decimal OriginalPrice { set; get; }

        [Display(Name = "Số lượng trong kho")]
        public int Stock { set; get; }

        [Display(Name = "Mô tả sản phẩm")]
        public string Description { set; get; }

        [Display(Name = "Thông tin chi tiết sản phẩm")]
        public string Details { set; get; }

        [Display(Name = "Tiêu đề SEO")]
        public string SeoTitle { set; get; }

        [Display(Name = "Tag SEO")]
        public string SeoAlias { get; set; }

        public string LanguageId { set; get; }

        [Display(Name = "Ảnh sản phẩm")]
        public IFormFile ThumbnailImage { get; set; }
    }
}