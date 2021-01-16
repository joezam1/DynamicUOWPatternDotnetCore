using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Data.Models;
using project.Service.Services;


namespace project.Api.Controllers
{
    [Route("api/[controller]")]
     [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Store store)
        {
            var result= await _storeService.AddStoreAsync(store);
            return Ok(result);
        }
    }
}