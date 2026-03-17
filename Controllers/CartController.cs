using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
