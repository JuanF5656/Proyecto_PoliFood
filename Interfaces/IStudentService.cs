using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> getAll();
        Task<Student> getById(Guid id);
        Task<Student> Create(Student student);
        Task<bool> Update(Guid id, Student student);

        Task<bool> ChangeStatus(Guid id);
    }
}
