using eShopSolution.Data.Entities;
using eShopSolution.Data.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Data.Extensions
{
    public static class ModuleBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword page of eShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description page of eShopSolution" });

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                   Id = 1,
                   IsShowOnHome = true,
                   ParentId = null,
                   SortOrder = 1,
                   Status = Status.Active
               },
               new Category()
               {
                   Id = 2,
                   IsShowOnHome = true,
                   ParentId = null,
                   SortOrder = 2,
                   Status = Status.Active
               });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id = 1,
                    CategoryId = 1,
                    Name = "Áo nam",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-nam",
                    SeoDescription = "Sản phẩm áo thời trang nam",
                    SeoTitle = "Sản phẩm áo thời trang nam"
                },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Men shirt",
                    LanguageId = "en-US",
                    SeoAlias = "men-shirt",
                    SeoDescription = "Men's fashion shirt products",
                    SeoTitle = "Men's fashion shirt products"
                });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Áo nữ",
                    LanguageId = "vi-VN",
                    SeoAlias = "ao-nu",
                    SeoDescription = "Sản phẩm áo thời trang nữ",
                    SeoTitle = "Sản phẩm áo thời trang nữ"
                },
                new CategoryTranslation()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Women shirt",
                    LanguageId = "en-US",
                    SeoAlias = "women-shirt",
                    SeoDescription = "Women's fashion shirt products",
                    SeoTitle = "Womens's fashion shirt products"
                });

            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = 1,
                   DateCreated = DateTime.Now,
                   OriginalPrice = 100000,
                   Price = 200000,
                   Stock = 0,
                   ViewCount = 0
               });

            modelBuilder.Entity<ProductTranslation>().HasData(
               new ProductTranslation()
               {
                   Id = 1,
                   ProductId = 1,
                   Name = "Áo sơ mi trắng nam",
                   LanguageId = "vi-VN",
                   SeoAlias = "ao-so-mi-trang-nam",
                   SeoDescription = "Áo sơ mi trắng nam",
                   SeoTitle = "Áo sơ mi trắng nam",
                   Details = "Áo sơ mi trắng nam",
                   Description = ""
               },
               new ProductTranslation()
               {
                   Id = 2,
                   ProductId = 1,
                   Name = "Mens white shirt",
                   LanguageId = "en-US",
                   SeoAlias = "mens-white-shirt",
                   SeoDescription = "Mens white shirt",
                   SeoTitle = "Mens white shirt",
                   Details = "Mens white shirt",
                   Description = ""
               });

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 });
        }
    }
}
