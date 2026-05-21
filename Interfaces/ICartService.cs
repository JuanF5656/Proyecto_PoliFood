using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface ICartService
    {
        Task<List<Cart>> GetAll();
        Task<List<Cart>> GetByUserId(string userId);  // ← nuevo
        Task<Cart> getById(Guid id);
        Task<Cart> Create(Cart newCart);
        Task<bool> Update(Guid id, Cart editCart);
        Task<bool> ChangeStatus(Guid id);
        Task<bool> AddItem(Guid cartId, Guid product_id, int quantity);
        Task<bool> RemoveItem(Guid cartId, Guid productId);
        Task<bool> UpdateQuantity(Guid cartId, Guid productId, int quantity);
        Task<Order> Checkout(Guid cartId);
    }
}