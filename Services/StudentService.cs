using Microsoft.EntityFrameworkCore;
using Polifood.Interfaces;
using Polifood.Models;
using Polifood.DAO;
namespace Polifood.Services
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _context;

        public StudentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Student>> getAll()
        {
            return await _context.Student.Where(e => e.is_active == 1).ToListAsync();
        }
        public async Task<Student> Create(Student newStudent)
        {
            //Agregamos el registro a la lista
            _context.Student.Add(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }
    }

}
