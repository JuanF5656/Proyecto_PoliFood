using Polifood.DAO;
using Polifood.Models;
using Polifood.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Polifood.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _context.Product.Where(e => e.is_active == 1).ToListAsync();
        }

        public async Task<Product> getById(Guid id) => await _context.Product.FindAsync(id);


        public async Task<Product> Create(Product newProduct)
        {
            //Agregamos el registro a la lista
            _context.Product.Add(newProduct);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<bool> Update(Guid id, Product editProduct)
        {
            //validar la existencia de un ente supremo
            var productExist = await getById(id);
            if (productExist == null) return false;

            productExist.product_name = editProduct.product_name;
            productExist.product_description = editProduct.product_description;
            productExist.product_price = editProduct.product_price;
            productExist.product_image = editProduct.product_image;
            productExist.is_available = editProduct.is_available;
            productExist.prepTimeMinutes = editProduct.prepTimeMinutes;

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
