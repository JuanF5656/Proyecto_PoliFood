using Microsoft.EntityFrameworkCore;
using Polifood.DAO;
using Polifood.Interfaces;
using Polifood.Models;

namespace Polifood.Services
{
    
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Admin>> GetAll()
        {
            return await _context.Admin.Where(e => e.is_active == 1).ToListAsync();
        }

        public async Task<Admin> getById(Guid id) => await _context.Admin.FindAsync(id);


        public async Task<Admin> Create(Admin newClient)
        {
            //Agregamos el registro a la lista
            _context.Admin.Add(newClient);
            await _context.SaveChangesAsync();
            return newClient;
        }

        public async Task<bool> Update(Guid id, Admin editAdmin)
        {
            //validar la existencia de un ente supremo
            var AdminExist = await getById(id);
            if (AdminExist == null) return false;

            AdminExist.name_admin = editAdmin.name_admin;

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
