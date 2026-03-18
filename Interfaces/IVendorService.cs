using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface IVendorService
    {
        Task<List<Vendor>> GetAll();
        Task<Vendor> getById(Guid id);

        Task<Vendor> Create(Vendor vendor);

        Task<bool> Update(Guid id, Vendor vendor);

        Task<bool> ChangeStatus(Guid id);
    }
}
