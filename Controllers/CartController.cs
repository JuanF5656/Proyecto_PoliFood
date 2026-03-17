using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
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

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => Ok(await _cartService.GetAll());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> getById(Guid id)
        {
            var cart = await _cartService.getById(id);
            return cart != null ? Ok(cart) : NotFound();

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Cart newCart)
        {

            var createdCart = await _cartService.Create(newCart);
            return CreatedAtAction(nameof(getById), new { id = createdCart.Id }, createdCart);
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Cart editedCart)
        {

            return await _cartService.Update(id, editedCart) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _cartService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del carrito") : NotFound();
        }
    }
}
