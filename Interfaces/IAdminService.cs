using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface IAdminService
    {
        Task<List<Admin>> GetAll();
        Task<Admin> getById(Guid id);

        Task<Admin> Create(Admin admin);

        Task<bool> Update(Guid id, Admin admin);

        Task<bool> ChangeStatus(Guid id);
    }
}
