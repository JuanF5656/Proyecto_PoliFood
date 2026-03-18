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
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public async Task<IActionResult> GetAll() => Ok(await _studentService.getAll());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student newStudent)
        {

            var createdClient = await _studentService.Create(newStudent);
            return Ok(createdClient);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> getById(Guid id)
        {
            var student = await _studentService.getById(id);
            return student != null ? Ok(student) : NotFound();

        }

        [HttpPut]
        public async Task<IActionResult> Edit(Guid id, [FromBody] Student editedStudent)
        {

            return await _studentService.Update(id, editedStudent) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _studentService.ChangeStatus(id) ? Ok("Se ha cambiado el estado del estudiante") : NotFound();
        }
    }
}
