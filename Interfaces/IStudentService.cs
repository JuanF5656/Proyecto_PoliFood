using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> getAll();
        Task<Student> Create(Student student);
    }
}
