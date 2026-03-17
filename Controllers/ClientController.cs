using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IVendorService _vendorService;
        
        public ClientController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
