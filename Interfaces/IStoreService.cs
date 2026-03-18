using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface IStoreService
    {
        Task<List<Store>> GetAll();
        Task<Store> getById(Guid id);

        Task<Store> Create(Store store);

        Task<bool> Update(Guid id, Store store);

        Task<bool> ChangeStatus(Guid id);
    }
}
