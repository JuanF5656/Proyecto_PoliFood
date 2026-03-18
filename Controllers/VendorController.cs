using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;
using Polifood.Models;
using Polifood.Services;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles ="Admin")]
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
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => Ok(await _vendorService.GetAll());

        [HttpGet("{id}")]
        
        public async Task<IActionResult> getById(Guid id)
        {
            var vendor = await _vendorService.getById(id);
            return vendor != null ? Ok(vendor) : NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Vendor newVendor)
        {

            var createdVendor= await _vendorService.Create(newVendor);
            return CreatedAtAction(nameof(getById), new { id = createdVendor.vendor_id}, createdVendor);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Vendor editedVendor)
        {

            return await _vendorService.Update(id, editedVendor) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _vendorService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del administrador") : NotFound();
        }
    }
}
