using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eShopSolution.ApiIntegration;
using eShopSolution.WebApp.Models;
using EShopSolution.Utilities.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eShopSolution.WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductApiClient _productApiClient;

        public CartController(IProductApiClient productApiClient)
        {
            _productApiClient = productApiClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddToCart(int id, string languageId)
        {
            var product = await _productApiClient.GetById(id, languageId);

            var session = HttpContext.Session.GetString(SystemConstants.CartSession);

            List<CartItemVm> currentCart = new List<CartItemVm>();

            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemVm>>(session);

            int quantity = 1;

            if (currentCart.Any(x => x.ProductId == id))
                quantity = currentCart.First(x => x.ProductId == id).Quantity + 1;

            var cartItem = new CartItemVm()
            {
                ProductId = id,
                Description = product.Description,
                Image = product.ThumbnailImage,
                Name = product.Name,
                Price = product.Price,
                Quantity = quantity
            };

            currentCart.Add(cartItem);

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));

            return Ok(currentCart);
        }

        [HttpGet]
        public IActionResult GetListItems()
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);

            List<CartItemVm> currentCart = new List<CartItemVm>();

            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemVm>>(session);

            return Ok(currentCart);
        }

        public IActionResult UpdateCart(int id, int quantity)
        {
            var session = HttpContext.Session.GetString(SystemConstants.CartSession);

            List<CartItemVm> currentCart = new List<CartItemVm>();

            if (session != null)
                currentCart = JsonConvert.DeserializeObject<List<CartItemVm>>(session);

            foreach (var item in currentCart)
            {
                if (item.ProductId == id)
                {
                    if (quantity == 0)
                    {
                        currentCart.Remove(item);
                        break;
                    }
                    item.Quantity = quantity;
                }
            }

            HttpContext.Session.SetString(SystemConstants.CartSession, JsonConvert.SerializeObject(currentCart));

            return Ok(currentCart);
        }
    }
}