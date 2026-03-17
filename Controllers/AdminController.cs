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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => Ok(await _adminService.GetAll());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> getById(Guid id)
        {
            var admin = await _adminService.getById(id);
            return admin != null ? Ok(admin) : NotFound();
           
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Admin newAdmin)
        {

            var createdAdmin = await _adminService.Create(newAdmin);
            return CreatedAtAction(nameof(getById), new { id = createdAdmin.admin_id }, createdAdmin);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Admin editedAdmin)
        {

            return await _adminService.Update(id, editedAdmin) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _adminService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del administrador") : NotFound();
        }
    }
}
