using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Polifood.Models;

namespace Polifood.DAO
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Admin> Admin { get; set; }
        public DbSet<Student> Student { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // =========================
            // SEED DE ROLES
            // =========================

            string adminRoleId = "11111111-1111-1111-1111-111111111111";
            string studentRoleId = "22222222-2222-2222-2222-222222222222";
            string vendorRoleId = "33333333-3333-3333-3333-333333333333";

            builder.Entity<IdentityRole>().HasData(
         new IdentityRole
         {
             Id = adminRoleId,
             Name = "Admin",
             NormalizedName = "ADMIN",
             ConcurrencyStamp = "a1a1a1a1-1111-1111-1111-111111111111"
         },
         new IdentityRole
         {
             Id = studentRoleId,
             Name = "Student",
             NormalizedName = "STUDENT",
             ConcurrencyStamp = "b2b2b2b2-2222-2222-2222-222222222222"
         },
         new IdentityRole
         {
             Id = vendorRoleId,
             Name = "Vendor",
             NormalizedName = "VENDOR",
             ConcurrencyStamp = "c3c3c3c3-3333-3333-3333-333333333333"
         }
     );

            // =========================
            // SEED DE DATOS INICIALES
            // =========================

            var product1Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa1");
            var product2Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa2");

            builder.Entity<Product>().HasData(
                new Product
                {
                    product_id = product1Id,
                    product_name = "Hamburguesa Clásica",
                    product_price = 5000,
                    product_image = "jijijaja",
                    is_active = 1,
                    is_available = true,
                    product_description = "Hamburguesa con carne, queso y vegetales",
                    prepTimeMinutes = 15
                },
                new Product
                {
                    product_id = product2Id,
                    product_name = "Pizza Personal",
                    product_price = 4000,
                    product_image = "jiji",
                    is_active = 1,
                    is_available = true,
                    product_description = "Pizza individual de queso y pepperoni",
                    prepTimeMinutes = 20
                }
            );
        }
    }
}

