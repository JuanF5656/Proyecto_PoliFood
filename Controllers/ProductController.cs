using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;
using Polifood.Models;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => Ok(await _productService.GetAll());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> getById(Guid id)
        {
            var product = await _productService.getById(id);
            return product != null ? Ok(product) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product newProduct)
        {

            var createdProduct = await _productService.Create(newProduct);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Product editedProduct)
        {

            return await _productService.Update(id, editedProduct) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _productService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del producto") : NotFound();
        }
    }
}
