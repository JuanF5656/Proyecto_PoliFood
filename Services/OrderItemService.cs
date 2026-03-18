using Polifood.DAO;
using Polifood.Models;
using Polifood.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Polifood.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly ApplicationDbContext _context;

        public OrderItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderItem>> GetAll()
        {
            return await _context.OrderItem.Where(e => e.is_active == 1).ToListAsync();
        }

        public async Task<OrderItem> getById(Guid id) => await _context.OrderItem.FindAsync(id);


        public async Task<OrderItem> Create(OrderItem newOrderItem)
        {
            //Agregamos el registro a la lista
            _context.OrderItem.Add(newOrderItem);
            await _context.SaveChangesAsync();
            return newOrderItem;
        }

        public async Task<bool> Update(Guid id, OrderItem editOrderItem)
        {
            //validar la existencia de un ente supremo
            var orderItemExist = await getById(id);
            if (orderItemExist == null) return false;

            orderItemExist.order = editOrderItem.order;
            orderItemExist.product = editOrderItem.product;


            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeStatus(Guid id)
        {
            // Verificamos si existe o no el registro
            var existe = await getById(id);
            if (existe == null) return false;

            existe.is_active = existe.is_active == 1 ? 0 : 1;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
