using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace eShopSolution.ApiIntegration
{
    public class UserApiClient : BaseApiClient, IUserApiClient
    {
        public UserApiClient(IHttpClientFactory httpClientFactory, IHttpContextAccessor httpContextAccessor,
                     IConfiguration configuration) : base(httpClientFactory, httpContextAccessor, configuration)
        {
        }

        public async Task<ApiResult<string>> Authenticate(LoginRequest request)
        {
            return await PostAsync<ApiResult<string>>("/api/users/authenticate", JsonConvert.SerializeObject(request));
        }

        public async Task<ApiResult<bool>> RegisterUser(RegisterRequest request)
        {
            return await PostAsync<ApiResult<bool>>("/api/users", JsonConvert.SerializeObject(request));
        }

        public async Task<ApiResult<bool>> UpdateUser(Guid id, UserUpdateRequest request)
        {
            return await PutAsync<ApiResult<bool>>($"/api/users/{id}", JsonConvert.SerializeObject(request));
        }

        public async Task<ApiResult<UserVm>> GetById(Guid id)
        {
            return await GetAsync<ApiResult<UserVm>>($"/api/users/{id}");
        }

        public async Task<ApiResult<PagedResult<UserVm>>> GetUsersPagings(GetUserPagingRequest request)
        {
            return await GetAsync<ApiResult<PagedResult<UserVm>>>($"/api/users/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.Keyword}");
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            return await DeleteAsync<ApiResult<bool>>($"/api/users/{id}");
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            return await PutAsync<ApiResult<bool>>($"/api/users/{id}/roles", JsonConvert.SerializeObject(request));
        }
    }
}