using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Polifood.Models;


    public class ApplicationDbContext : IdentityDbContext
{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
    
        public DbSet<Admin> Admin { get; set; }
    public DbSet<Cart> Cart { get; set; }
    public DbSet<Order> Order { get; set; }
    public DbSet<OrderItem> OrderItem { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Store> Store { get; set; }
    public DbSet<Student> Student { get; set; }
    public DbSet<Vendor> Vendor { get; set; }

}
