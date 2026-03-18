using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;
using Polifood.Models;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Student, Admin")]
    public class StoreController : Controller
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> GetAll() => Ok(await _storeService.GetAll());

        [HttpGet("{id}")]

        public async Task<IActionResult> getById(Guid id)
        {
            var store = await _storeService.getById(id);
            return store != null ? Ok(store) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Store newStore)
        {

            var createdStore = await _storeService.Create(newStore);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Store editedStore)
        {

            return await _storeService.Update(id, editedStore) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _storeService.ChangeStatus(id) ? Ok("Se ha cambiado el estado de la orden") : NotFound();
        }
    }
}
