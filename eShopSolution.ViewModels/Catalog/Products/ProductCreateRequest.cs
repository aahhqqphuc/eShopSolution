using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace eShopSolution.ViewModels.Catalog.Products
{
    public class ProductCreateRequest
    {
        [Required(ErrorMessage = "Bạn phải nhập tên sản phẩm")]
        [Display(Name = "Tên sản phẩm")]
        public string Name { get; set; }

        [Display(Name = "Giá")]
        public decimal Price { get; set; }

        [Display(Name = "Giá gốc")]
        public decimal OriginalPrice { set; get; }

        [Display(Name = "Số lượng tồn kho")]
        public int Stock { set; get; }

        [Display(Name = "Mô tả sản phẩm")]
        public string Description { set; get; }

        [Display(Name = "Thông tin chi tiết sản phẩm")]
        public string Details { set; get; }

        [Display(Name = "Mô tả SEO")]
        public string SeoDescription { set; get; }

        [Display(Name = "Tiêu đề SEO")]
        public string SeoTitle { set; get; }

        [Display(Name = "Bí danh SEO")]
        public string SeoAlias { get; set; }

        public string LanguageId { set; get; }

        [Display(Name = "Ảnh sản phẩm")]
        public IFormFile ThumbnailImage { get; set; }
    }
}