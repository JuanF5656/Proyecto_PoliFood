
using Proyecto_PoliFood.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Proyecto_PoliFood.DAO
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Eventos> Events { get; set; }
        public DbSet<Boleta> Tickets { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
