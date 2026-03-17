using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="Admin,Vendor")]
    public class VendorController : Controller
    {
        private readonly IVendorService _vendorService;
        
        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
