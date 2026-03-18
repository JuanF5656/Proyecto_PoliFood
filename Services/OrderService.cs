using Polifood.DAO;
using Polifood.Models;
using Polifood.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Polifood.Services
{
    public class OrderService : IOrderService
    {
        private readonly ApplicationDbContext _context;

        public OrderService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context.Order.Where(e => e.isActive == 1).ToListAsync();
        }

        public async Task<Order> getById(Guid id) => await _context.Order.FindAsync(id);


        public async Task<Order> Create(Order newOrder)
        {
            //Agregamos el registro a la lista
            _context.Order.Add(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }

        public async Task<bool> Update(Guid id, Order editOrder)
        {
            //validar la existencia de un ente supremo
            var orderExist = await getById(id);
            if (orderExist == null) return false;

            orderExist.orderItems = editOrder.orderItems;
            orderExist.status = editOrder.status;


            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeStatus(Guid id)
        {
            // Verificamos si existe o no el registro
            var existe = await getById(id);
            if (existe == null) return false;

            existe.isActive = existe.isActive == 1 ? 0 : 1;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ConfirmPayment(Guid orderId)
        {
            var order = await _context.Order.FindAsync(orderId);
            if (order == null) return false;

            order.IsPaid = true;
            order.PaymentConfirmedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

    }
}
