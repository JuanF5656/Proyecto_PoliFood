namespace Polifood.Interfaces
{
    public interface ICartService
    {
        Task<List<Cart>> GetAll();
        Task<Cart?> getById(Guid id);

        Task<Cart> Create(Cart cart);

        Task<bool> Update(Guid id, Cart cart);

        Task<bool> ChangeStatus(Guid id);
    }
}
