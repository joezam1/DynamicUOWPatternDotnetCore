using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Data.Models;
using project.Service.Services;
using project.Service.ViewModels;

namespace project.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShoppingController : ControllerBase
    {
        private readonly IShoppingService _shoppingService;
        public ShoppingController(IShoppingService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<int>> CreateShop(ShoppingViewModel sohppingViewModel)
        {
            var result= await _shoppingService.CreateNewShoppingStore(sohppingViewModel);
            return Ok(result);
        }
    }
}