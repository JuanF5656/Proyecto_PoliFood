using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Polifood.Models;


    public class AuthDbContext : IdentityDbContext
{
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
        : base(options) { }
    
        public DbSet<Admin> Admin { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Vendor> Vendors { get; set; }

}
