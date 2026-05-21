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
                    .ThenInclude(i => i.Product)  // ← también aquí
                .Where(e => e.is_active == 1)
                .ToListAsync();
        }

        // ── Fix principal: siempre cargar items con Include ──────────────────
        public async Task<Cart> getById(Guid id)
        {
            return await _context.Cart
                .Include(c => c.items)
                    .ThenInclude(i => i.Product)  // ← incluir el producto de cada item
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
                existingItem.Quantity += quantity;
                await _context.SaveChangesAsync();
            }
            else
            {
                // INSERT directo sin pasar por el change tracker del carrito
                var newItem = new CartItem
                {
                    Id = Guid.NewGuid(),
                    CartId = cartId,
                    ProductId = product_id,
                    Quantity = quantity,
                    UnitPrice = product.product_price
                };
                await _context.CartItem.AddAsync(newItem);
                await _context.SaveChangesAsync();
            }

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
            // Limpiar el change tracker para evitar conflictos con entidades del seed
            _context.ChangeTracker.Clear();

            var cart = await _context.Cart
                .Include(c => c.items)
                    .ThenInclude(i => i.Product)
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == cartId);

            if (cart == null || !cart.items.Any())
                throw new InvalidOperationException("Carrito vacio");

            var total = cart.items.Sum(i => i.UnitPrice * i.Quantity);
            var orderId = Guid.NewGuid();

            // 1. Insertar Order primero
            var order = new Order
            {
                Id = orderId,
                CartId = cart.Id,
                Total = total,
                status = OrderStatus.Received
            };

            _context.Order.Add(order);
            await _context.SaveChangesAsync();

            // 2. Insertar OrderItems después
            var orderItems = cart.items.Select(i => new OrderItem
            {
                orderItem_id = Guid.NewGuid(),
                OrderId = orderId,
                product_id = i.ProductId,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,
                Subtotal = i.UnitPrice * i.Quantity,
                is_active = 1
            }).ToList();

            await _context.OrderItem.AddRangeAsync(orderItems);
            await _context.SaveChangesAsync();

            order.orderItems = orderItems;
            return order;
        }
    }
}