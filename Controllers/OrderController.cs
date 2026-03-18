using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => Ok(await _orderService.GetAll());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> getById(Guid id)
        {
            var order = await _orderService.getById(id);
            return order != null ? Ok(order) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Order newOrder)
        {

            var createdOrder = await _orderService.Create(newOrder);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Order editedOrder)
        {

            return await _orderService.Update(id, editedOrder) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _orderService.ChangeStatus(id) ? Ok("Se ha cambiado el estado de la orden") : NotFound();
        }

        [HttpPost("{id}/confirm-payment")]
        public async Task<IActionResult> ConfirmPayment(Guid id)
        {
            var success = await _orderService.ConfirmPayment(id);
            return success ? Ok("Payment confirmed (simulated)") : NotFound();
        }
    }
}

