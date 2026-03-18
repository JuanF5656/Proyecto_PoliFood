using Polifood.DAO;
using Polifood.Interfaces;
using Polifood.Models;
using Microsoft.EntityFrameworkCore;
namespace Polifood.Services
{
    public class VendorService : IVendorService
    {
        private readonly ApplicationDbContext _context;

        public VendorService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Vendor>> GetAll()
        {
            return await _context.Vendor.Where(e => e.is_active == 1).ToListAsync();
        }

        public async Task<Vendor> getById(Guid id) => await _context.Vendor.FindAsync(id);


        public async Task<Vendor> Create(Vendor newVendor)
        {
            //Agregamos el registro a la lista
            _context.Vendor.Add(newVendor);
            await _context.SaveChangesAsync();
            return newVendor;
        }

        public async Task<bool> Update(Guid id, Vendor editVendor)
        {
            //validar la existencia de un ente supremo
            var VendorExist = await getById(id);
            if (VendorExist == null) return false;

            VendorExist.vendor_name = editVendor.vendor_name;
            VendorExist.vendor_id = editVendor.vendor_id;
            VendorExist.IdentityUser = editVendor.IdentityUser;
            VendorExist.IdentityUserId = editVendor.IdentityUserId;
            VendorExist.store = editVendor.store;
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
