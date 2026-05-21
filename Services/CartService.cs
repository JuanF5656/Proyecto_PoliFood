using Polifood.DAO;
using Polifood.Interfaces;
using Polifood.Models;
using Microsoft.EntityFrameworkCore;

namespace Polifood.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _context;

        public CartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Cart>> GetAll()
        {
            return await _context.Cart
                .Include(c => c.items)
                .Where(e => e.is_active == 1)
                .ToListAsync();
        }

        // ── Fix principal: siempre cargar items con Include ──────────────────
        public async Task<Cart> getById(Guid id)
        {
            return await _context.Cart
                .Include(c => c.items)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Cart> Create(Cart newCart)
        {
            _context.Cart.Add(newCart);
            await _context.SaveChangesAsync();
            return newCart;
        }

        public async Task<bool> Update(Guid id, Cart editCart)
        {
            var cartExist = await getById(id);
            if (cartExist == null) return false;

            cartExist.items = editCart.items;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeStatus(Guid id)
        {
            var existe = await getById(id);
            if (existe == null) return false;

            existe.is_active = existe.is_active == 1 ? 0 : 1;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> AddItem(Guid cartId, Guid product_id, int quantity)
        {
            var cart = await getById(cartId);
            if (cart == null) return false;

            var product = await _context.Product.FindAsync(product_id);
            if (product == null || !product.is_available) return false;

            var existingItem = cart.items.FirstOrDefault(i => i.ProductId == product_id);
            if (existingItem != null)
            {
                // El item ya existe — solo actualizamos cantidad
                existingItem.Quantity += quantity;
            }
            else
            {
                // Item nuevo — INSERT correcto gracias al Include
                cart.items.Add(new CartItem
                {
                    ProductId = product_id,
                    Quantity = quantity,
                    UnitPrice = product.product_price
                });
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveItem(Guid cartId, Guid productId)
        {
            var cart = await getById(cartId);
            if (cart == null) return false;

            var item = cart.items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null) return false;

            cart.items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateQuantity(Guid cartId, Guid productId, int quantity)
        {
            var cart = await getById(cartId);
            if (cart == null) return false;

            var item = cart.items.FirstOrDefault(i => i.ProductId == productId);
            if (item == null) return false;

            if (quantity <= 0)
                cart.items.Remove(item);
            else
                item.Quantity = quantity;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order> Checkout(Guid cartId)
        {
            var cart = await getById(cartId);
            if (cart == null || !cart.items.Any())
                throw new InvalidOperationException("Carrito vacio");

            var total = cart.items.Sum(i => i.UnitPrice * i.Quantity);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CartId = cart.Id,
                orderItems = cart.items.Select(i => new OrderItem
                {
                    product_id = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Subtotal = i.UnitPrice * i.Quantity
                }).ToList(),
                Total = total,
                status = OrderStatus.Received
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
    }
}