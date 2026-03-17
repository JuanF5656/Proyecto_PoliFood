using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
