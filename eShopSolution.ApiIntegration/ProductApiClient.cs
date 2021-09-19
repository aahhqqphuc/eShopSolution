﻿using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.Common;
using EShopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public class ProductApiClient : BaseApiClient, IProductApiClient
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;

        public ProductApiClient(IHttpClientFactory httpClientFactory,
                   IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
            : base(httpClientFactory, httpContextAccessor, configuration)
        {
            _httpContextAccessor = httpContextAccessor;
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PagedResult<ProductVm>> GetPagings(GetManageProductPagingRequest request)
        {
            var data = await GetAsync<PagedResult<ProductVm>>($"/api/products/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}&keyword={request.Keyword}&languageId={request.LanguageId}" +
                $"&categoryId={request.CategoryId}");

            return data;
        }

        public async Task<bool> CreateProduct(ProductCreateRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            var languageId = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.DefaultLanguageId);

            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var requestContent = new MultipartFormDataContent();

            if (request.ThumbnailImage != null)
            {
                byte[] data;

                using (var br = new BinaryReader(request.ThumbnailImage.OpenReadStream()))
                {
                    data = br.ReadBytes((int)request.ThumbnailImage.OpenReadStream().Length);
                }

                ByteArrayContent bytes = new ByteArrayContent(data);

                requestContent.Add(bytes, "thumbnailImage", request.ThumbnailImage.FileName);
            }

            requestContent.Add(new StringContent(request.Name), "name");

            requestContent.Add(new StringContent(request.Price.ToString()), "price");

            requestContent.Add(new StringContent(request.OriginalPrice.ToString()), "originalPrice");

            requestContent.Add(new StringContent(request.Stock.ToString()), "stock");

            requestContent.Add(new StringContent(request.Description), "description");

            requestContent.Add(new StringContent(request.Details), "details");

            requestContent.Add(new StringContent(request.SeoDescription), "seoDescription");

            requestContent.Add(new StringContent(request.SeoTitle), "seoTitle");

            requestContent.Add(new StringContent(request.SeoAlias), "seoAlias");

            requestContent.Add(new StringContent(languageId), "languageId");

            var response = await client.PostAsync($"/api/products/", requestContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<ApiResult<bool>> CategoryAssign(int id, CategoryAssignRequest request)
        {
            return await PutAsync<ApiResult<bool>>($"/api/products/{id}/categories", JsonConvert.SerializeObject(request));
        }

        public async Task<ProductVm> GetById(int id, string languageId)
        {
            return await GetAsync<ProductVm>($"/api/products/{id}/{languageId}");
        }

        public async Task<List<ProductVm>> GetFeaturedProducts(string languageId, int take)
        {
            var data = await GetListAsync<ProductVm>($"/api/products/featured/{languageId}/{take}");
            return data;
        }
    }
}