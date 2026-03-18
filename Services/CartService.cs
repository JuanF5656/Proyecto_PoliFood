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
    }
}
