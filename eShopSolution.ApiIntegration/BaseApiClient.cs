using EShopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public class BaseApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        protected BaseApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor,
                    IConfiguration configuration)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        protected async Task<TResponse> GetAsync<TResponse>(string url)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return (TResponse)JsonConvert.DeserializeObject(result, typeof(TResponse));

            return JsonConvert.DeserializeObject<TResponse>(result);
        }

        protected async Task<TResponse> PutAsync<TResponse>(string url, string json)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync(url, httpContent);

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TResponse>(result);

            return JsonConvert.DeserializeObject<TResponse>(result);
        }

        protected async Task<TResponse> PostAsync<TResponse>(string url, string json)
        {
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, httpContent);

            var result = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return JsonConvert.DeserializeObject<TResponse>(result);

            return JsonConvert.DeserializeObject<TResponse>(result);
        }

        //protected async Task<TResponse> DeleteAsync<TResponse>(string url)
        //{
        //    var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

        //    var client = _httpClientFactory.CreateClient();

        //    client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

        //    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

        //    var response = await client.DeleteAsync(url);

        //    var body = await response.Content.ReadAsStringAsync();

        //    if (response.IsSuccessStatusCode)
        //        return JsonConvert.DeserializeObject<TResponse>(body);

        //    return JsonConvert.DeserializeObject<TResponse>(body);
        //}

        protected async Task<bool> DeleteAsync(string url)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.DeleteAsync(url);

            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }

        protected async Task<List<T>> GetListAsync<T>(string url)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(url);

            var body = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
                return (List<T>)JsonConvert.DeserializeObject(body, typeof(List<T>));

            throw new Exception(body);
        }
    }
}