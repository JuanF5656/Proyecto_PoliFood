using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface IStudentService
    {
        Task<List<Student>> getAll();
        Task<Store?> getById(Guid id);
        Task<Student> Create(Student student);
        Task<bool> Update(Guid id, Store store);

        Task<bool> ChangeStatus(Guid id);
    }
}
