using eShopSolution.Data.Entities;
using eShopSolution.Data.Enum;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

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
                new Language() { Id = "vi", Name = "Tiếng Việt", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false });

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
                    LanguageId = "vi",
                    SeoAlias = "ao-nam",
                    SeoTitle = "Sản phẩm áo thời trang nam"
                },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId = 1,
                    Name = "Men shirt",
                    LanguageId = "en",
                    SeoAlias = "men-shirt",
                    SeoTitle = "Men's fashion shirt products"
                });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id = 3,
                    CategoryId = 2,
                    Name = "Áo nữ",
                    LanguageId = "vi",
                    SeoAlias = "ao-nu",
                    SeoTitle = "Sản phẩm áo thời trang nữ"
                },
                new CategoryTranslation()
                {
                    Id = 4,
                    CategoryId = 2,
                    Name = "Women shirt",
                    LanguageId = "en",
                    SeoAlias = "women-shirt",
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
                   LanguageId = "vi",
                   SeoAlias = "ao-so-mi-trang-nam",
                   SeoTitle = "Áo sơ mi trắng nam",
                   Details = "Áo sơ mi trắng nam",
                   Description = ""
               },
               new ProductTranslation()
               {
                   Id = 2,
                   ProductId = 1,
                   Name = "Mens white shirt",
                   LanguageId = "en",
                   SeoAlias = "mens-white-shirt",
                   SeoTitle = "Mens white shirt",
                   Details = "Mens white shirt",
                   Description = ""
               });

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 });

            // any guid
            var roleId = new Guid("38656D75-0611-4067-A546-B38E25A61E7D");

            var adminId = new Guid("F46133E9-22EE-46B0-890F-5C3E8CC5C258");

            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "ffqphuc@gmail.com",
                NormalizedEmail = "ffqphuc@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Zx@123456"),
                SecurityStamp = string.Empty,
                FirstName = "Phuc",
                LastName = "Nguyen",
                Dob = new DateTime(2021, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });

            modelBuilder.Entity<Slide>().HasData(
             new Slide() { Id = 1, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 1, Url = "#", Image = "/themes/images/carousel/1.png", Status = Status.Active },
             new Slide() { Id = 2, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 2, Url = "#", Image = "/themes/images/carousel/2.png", Status = Status.Active },
             new Slide() { Id = 3, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 3, Url = "#", Image = "/themes/images/carousel/3.png", Status = Status.Active },
             new Slide() { Id = 4, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 4, Url = "#", Image = "/themes/images/carousel/4.png", Status = Status.Active },
             new Slide() { Id = 5, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 5, Url = "#", Image = "/themes/images/carousel/5.png", Status = Status.Active },
             new Slide() { Id = 6, Name = "Second Thumbnail label", Description = "Cras justo odio, dapibus ac facilisis in, egestas eget quam. Donec id elit non mi porta gravida at eget metus. Nullam id dolor id nibh ultricies vehicula ut id elit.", SortOrder = 6, Url = "#", Image = "/themes/images/carousel/6.png", Status = Status.Active }
             );
        }
    }
}