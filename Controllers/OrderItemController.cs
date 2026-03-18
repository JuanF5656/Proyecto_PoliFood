using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;
using Polifood.Models;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;

        public OrderItemController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize (Roles = "Admin")]
        public async Task<IActionResult> GetAll() => Ok(await _orderItemService.GetAll());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> getById(Guid id)
        {
            var orderItem = await _orderItemService.getById(id);
            return orderItem != null ? Ok(orderItem) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderItem newOrderItem)
        {

            var createdOrderItem = await _orderItemService.Create(newOrderItem);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] OrderItem editedOrderItem)
        {

            return await _orderItemService.Update(id, editedOrderItem) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _orderItemService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del item") : NotFound();
        }
    }
}

