using Microsoft.EntityFrameworkCore;
using Polifood.DAO;
using Polifood.Interfaces;
using Polifood.Models;

namespace Polifood.Services
{

    public class StoreService : IStoreService
    {
        private readonly ApplicationDbContext _context;

        public StoreService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Store>> GetAll()
        {
            return await _context.Store.Where(e => e.is_active == 1).ToListAsync();
        }

        public async Task<Store> getById(Guid id) => await _context.Store.FindAsync(id);


        public async Task<Store> Create(Store newClient)
        {
            //Agregamos el registro a la lista
            _context.Store.Add(newClient);
            await _context.SaveChangesAsync();
            return newClient;
        }

        public async Task<bool> Update(Guid id, Store editStore)
        {
            //validar la existencia de un ente supremo
            var StoreExist = await getById(id);
            if (StoreExist == null) return false;

            StoreExist.store_name = editStore.store_name;
            StoreExist.categories = editStore.categories; 
            StoreExist.product = editStore.product;

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
