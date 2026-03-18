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

        public async Task<Student> getById(Guid id) => await _context.Student.FindAsync(id);


        public async Task<Student> Create(Student newStudent)
        {
            //Agregamos el registro a la lista
            _context.Student.Add(newStudent);
            await _context.SaveChangesAsync();
            return newStudent;
        }

        public async Task<bool> Update(Guid id, Student editStudent)
        {
            //validar la existencia de un ente supremo
            var StudentExist = await getById(id);
            if (StudentExist == null) return false;

            StudentExist.student_id = editStudent.student_id;
            StudentExist.student_name = editStudent.student_name;
            StudentExist.student_id = editStudent.student_id;
            StudentExist.IdentityUserId = editStudent.IdentityUserId;
            StudentExist.IdentityUser = editStudent.IdentityUser;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeStatus(Guid id)
        {
            // Verificamos si existe o no el registro
            var existe = await getById(id);
            if (existe == null) return false;

            existe.is_active = existe.is_active == 1 ? 0 : 1;

            await _context.SaveChangesAsync();

            return true;
        }
    }

}
