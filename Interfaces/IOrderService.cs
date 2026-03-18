using Polifood.Models;

namespace Polifood.Interfaces
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> getById(Guid id);

        Task<Order> Create(Order order);

        Task<bool> Update(Guid id, Order order);

        Task<bool> ChangeStatus(Guid id);

        Task<bool> ConfirmPayment(Guid orderId);

    }
}
