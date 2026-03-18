using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetAll();
        Task<OrderItem?> getById(Guid id);

        Task<OrderItem> Create(OrderItem orderItem);

        Task<bool> Update(Guid id, OrderItem orderItem);

        Task<bool> ChangeStatus(Guid id);
    }
}
