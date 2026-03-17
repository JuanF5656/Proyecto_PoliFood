using Microsoft.AspNetCore.Mvc;
using Polifood.Interfaces;
using Polifood.Models;
using Polifood.Services;

namespace Polifood.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
    }
}
