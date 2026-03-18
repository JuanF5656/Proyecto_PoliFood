using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface ICartService
    {
        Task<List<Cart>> GetAll();
        Task<Cart> getById(Guid id);

        Task<Cart> Create(Cart cart);

        Task<bool> Update(Guid id, Cart cart);

        Task<bool> ChangeStatus(Guid id);


        Task<bool> AddItem(Guid cartId, Guid product_id, int quantity);
        Task<bool> RemoveItem(Guid cartId, Guid product_id);
        Task<bool> UpdateQuantity(Guid cartId, Guid product_id, int quantity);

        Task<Order> Checkout(Guid cartId);
    }
}
