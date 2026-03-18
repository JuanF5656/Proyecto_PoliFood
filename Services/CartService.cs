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
            return await _context.Cart.Where(e => e.is_active == 1).ToListAsync();
        }

        public async Task<Cart> getById(Guid id) => await _context.Cart.FindAsync(id);


        public async Task<Cart> Create(Cart newCart)
        {
            //Agregamos el registro a la lista
            _context.Cart.Add(newCart);
            await _context.SaveChangesAsync();
            return newCart;
        }

        public async Task<bool> Update(Guid id, Cart editCart)
        {
            //validar la existencia de un ente supremo
            var CartExist = await getById(id);
            if (CartExist == null) return false;

            CartExist.products = editCart.products;

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

        public async Task<bool> AddItem(Guid cartId, Guid product_id, int quantity)
        {
            var cart = await getById(cartId);
            if (cart == null) return false;

            var product = await _context.Products.FindAsync(product_id);
            if (product == null || !product.Available) return false;

            var existingItem = cart.Items.FirstOrDefault(i => i.product_id == product_id);
            if (existingItem != null)
                existingItem.Quantity += quantity;
            else
                cart.Items.Add(new CartItem { Product_id = product_id, Quantity = quantity, UnitPrice = product.Price });

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveItem(Guid cartId, Guid productId)
        {
            var cart = await GetById(cartId);
            if (cart == null) return false;

            var item = cart.Items.FirstOrDefault(i => i.product_id == productId);
            if (item == null) return false;

            cart.Items.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateQuantity(Guid cartId, Guid productId, int quantity)
        {
            var cart = await GetById(cartId);
            if (cart == null) return false;

            var item = cart.Items.FirstOrDefault(i => i.product_id == productId);
            if (item == null) return false;

            if (quantity <= 0) cart.Items.Remove(item);
            else item.Quantity = quantity;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Order> Checkout(Guid cartId)
        {
            var cart = await GetById(cartId);
            if (cart == null || !cart.Items.Any()) throw new InvalidOperationException("Carrito vacio");

            var total = cart.Items.Sum(i => i.UnitPrice * i.Quantity);

            var order = new Order
            {
                Id = Guid.NewGuid(),
                CartId = cart.Id,
                Items = cart.Items.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Quantity = i.Quantity,
                    UnitPrice = i.UnitPrice,
                    Subtotal = i.UnitPrice * i.Quantity
                }).ToList(),
                Total = total,
                Status = "Received"
            };

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }



    }
}
