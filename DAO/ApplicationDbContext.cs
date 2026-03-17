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
            IdentityRole role;
            builder.Entity<IdentityRole>().HasData(
         role = new IdentityRole
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
            var adminUserId = "99999999-9999-9999-9999-999999999991";
            var studentUserId = "99999999-9999-9999-9999-999999999992";
            var vendorUserId = "99999999-9999-9999-9999-999999999993";

          
           
            var adminId =Guid.Parse("11111111-1111-1111-1111-111111111112");
            
            builder.Entity<Admin>().HasData(
                    new Admin
                {
                    admin_id = adminId,
                    name_admin = "Simon",
                    is_active = 1,
                    IdentityUserId = adminUserId

                }
               
                );

            // =========================
            // IDS FIJOS
            // =========================

            // Stores
            var store1Id = Guid.Parse("10000000-0000-0000-0000-000000000001");
            var store2Id = Guid.Parse("10000000-0000-0000-0000-000000000002");

            // Products
            var product1Id = Guid.Parse("20000000-0000-0000-0000-000000000001");
            var product2Id = Guid.Parse("20000000-0000-0000-0000-000000000002");
            var product3Id = Guid.Parse("20000000-0000-0000-0000-000000000003");
            var product4Id = Guid.Parse("20000000-0000-0000-0000-000000000004");
            var product5Id = Guid.Parse("20000000-0000-0000-0000-000000000005");
            var product6Id = Guid.Parse("20000000-0000-0000-0000-000000000006");
            var product7Id = Guid.Parse("20000000-0000-0000-0000-000000000007");
            var product8Id = Guid.Parse("20000000-0000-0000-0000-000000000008");
            var product9Id = Guid.Parse("20000000-0000-0000-0000-000000000009");
            var product10Id = Guid.Parse("20000000-0000-0000-0000-000000000010");
            var product11Id = Guid.Parse("20000000-0000-0000-0000-000000000011");
            var product12Id = Guid.Parse("20000000-0000-0000-0000-000000000012");

            // Orders
            var order1Id = Guid.Parse("30000000-0000-0000-0000-000000000001");
            var order2Id = Guid.Parse("30000000-0000-0000-0000-000000000002");
            var order3Id = Guid.Parse("30000000-0000-0000-0000-000000000003");
            var order4Id = Guid.Parse("30000000-0000-0000-0000-000000000004");
            var order5Id = Guid.Parse("30000000-0000-0000-0000-000000000005");
            var order6Id = Guid.Parse("30000000-0000-0000-0000-000000000006");
            var order7Id = Guid.Parse("30000000-0000-0000-0000-000000000007");
            var order8Id = Guid.Parse("30000000-0000-0000-0000-000000000008");
            var order9Id = Guid.Parse("30000000-0000-0000-0000-000000000009");
            var order10Id = Guid.Parse("30000000-0000-0000-0000-000000000010");
            var order11Id = Guid.Parse("30000000-0000-0000-0000-000000000011");
            var order12Id = Guid.Parse("30000000-0000-0000-0000-000000000012");
            var order13Id = Guid.Parse("30000000-0000-0000-0000-000000000013");
            var order14Id = Guid.Parse("30000000-0000-0000-0000-000000000014");
            var order15Id = Guid.Parse("30000000-0000-0000-0000-000000000015");
            var order16Id = Guid.Parse("30000000-0000-0000-0000-000000000016");
            var order17Id = Guid.Parse("30000000-0000-0000-0000-000000000017");
            var order18Id = Guid.Parse("30000000-0000-0000-0000-000000000018");
            var order19Id = Guid.Parse("30000000-0000-0000-0000-000000000019");
            var order20Id = Guid.Parse("30000000-0000-0000-0000-000000000020");

            // =========================
            // SEED DE PRODUCTS (12)
            // =========================
            builder.Entity<Product>().HasData(
                new Product { product_id = product1Id, product_name = "Hamburguesa Clásica", product_description = "Hamburguesa con carne, queso y vegetales", prepTimeMinutes = 15, product_price = 5000, product_image = "burger1.jpg", is_active = 1, is_available = true },
                new Product { product_id = product2Id, product_name = "Pizza Personal", product_description = "Pizza individual de queso y pepperoni", prepTimeMinutes = 20, product_price = 4000, product_image = "pizza1.jpg", is_active = 1, is_available = true },
                new Product { product_id = product3Id, product_name = "Perro Caliente", product_description = "Pan con salchicha, papitas y salsas", prepTimeMinutes = 10, product_price = 3500, product_image = "hotdog.jpg", is_active = 1, is_available = true },
                new Product { product_id = product4Id, product_name = "Tacos", product_description = "Tacos de carne con vegetales", prepTimeMinutes = 12, product_price = 4200, product_image = "tacos.jpg", is_active = 1, is_available = true },
                new Product { product_id = product5Id, product_name = "Burrito", product_description = "Burrito de pollo y arroz", prepTimeMinutes = 14, product_price = 4700, product_image = "burrito.jpg", is_active = 1, is_available = true },
                new Product { product_id = product6Id, product_name = "Nachos", product_description = "Nachos con queso y carne", prepTimeMinutes = 8, product_price = 3900, product_image = "nachos.jpg", is_active = 1, is_available = true },

                new Product { product_id = product7Id, product_name = "Ensalada César", product_description = "Ensalada fresca con pollo", prepTimeMinutes = 9, product_price = 4500, product_image = "salad.jpg", is_active = 1, is_available = true },
                new Product { product_id = product8Id, product_name = "Sándwich Mixto", product_description = "Jamón, queso y vegetales", prepTimeMinutes = 7, product_price = 3200, product_image = "sandwich.jpg", is_active = 1, is_available = true },
                new Product { product_id = product9Id, product_name = "Empanadas", product_description = "Empanadas rellenas de carne", prepTimeMinutes = 6, product_price = 2500, product_image = "empanadas.jpg", is_active = 1, is_available = true },
                new Product { product_id = product10Id, product_name = "Arepa Rellena", product_description = "Arepa con pollo y queso", prepTimeMinutes = 11, product_price = 3800, product_image = "arepa.jpg", is_active = 1, is_available = true },
                new Product { product_id = product11Id, product_name = "Lasaña", product_description = "Lasaña personal de carne", prepTimeMinutes = 18, product_price = 5200, product_image = "lasagna.jpg", is_active = 1, is_available = true },
                new Product { product_id = product12Id, product_name = "Brownie", product_description = "Postre de chocolate", prepTimeMinutes = 5, product_price = 2000, product_image = "brownie.jpg", is_active = 1, is_available = true }
            );

            // =========================
            // SEED DE STORES (2)
            // =========================
            builder.Entity<Store>().HasData(
                new Store
                {
                    store_id = store1Id,
                    store_name = "Polifood Central",
                    categories = "Fast Food",
                    is_active = 1,
                    product_id = product1Id
                },
                new Store
                {
                    store_id = store2Id,
                    store_name = "Polifood Express",
                    categories = "Snacks",
                    is_active = 1,
                    product_id = product7Id
                }
            );

            // =========================
            // SEED DE ORDERS (20)
            // =========================
            builder.Entity<Order>().HasData(
                new Order { Id = order1Id, status = OrderStatus.Received },
                new Order { Id = order2Id, status = OrderStatus.Received },
                new Order { Id = order3Id, status = OrderStatus.Received },
                new Order { Id = order4Id, status = OrderStatus.Received },
                new Order { Id = order5Id, status = OrderStatus.Received },
                new Order { Id = order6Id, status = OrderStatus.Received },
                new Order { Id = order7Id, status = OrderStatus.Received },
                new Order { Id = order8Id, status = OrderStatus.Received },
                new Order { Id = order9Id, status = OrderStatus.Preparing },
                new Order { Id = order10Id, status = OrderStatus.Preparing },
                new Order { Id = order11Id, status = OrderStatus.Preparing },
                new Order { Id = order12Id, status = OrderStatus.Preparing },
                new Order { Id = order13Id, status = OrderStatus.Ready },
                new Order { Id = order14Id, status = OrderStatus.Ready },
                new Order { Id = order15Id, status = OrderStatus.Ready },
                new Order { Id = order16Id, status = OrderStatus.Delivered },
                new Order { Id = order17Id, status = OrderStatus.Delivered },
                new Order { Id = order18Id, status = OrderStatus.Delivered },
                new Order { Id = order19Id, status = OrderStatus.Delivered },
                new Order { Id = order20Id, status = OrderStatus.Delivered }
            );

            // =========================
            // SEED DE ORDER ITEMS (40)
            // 2 por cada order
            // =========================
            builder.Entity<OrderItem>().HasData(
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000001"), OrderId = order1Id, product_id = product1Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000002"), OrderId = order1Id, product_id = product2Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000003"), OrderId = order2Id, product_id = product3Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000004"), OrderId = order2Id, product_id = product4Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000005"), OrderId = order3Id, product_id = product5Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000006"), OrderId = order3Id, product_id = product6Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000007"), OrderId = order4Id, product_id = product7Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000008"), OrderId = order4Id, product_id = product8Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000009"), OrderId = order5Id, product_id = product9Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000010"), OrderId = order5Id, product_id = product10Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000011"), OrderId = order6Id, product_id = product11Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000012"), OrderId = order6Id, product_id = product12Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000013"), OrderId = order7Id, product_id = product1Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000014"), OrderId = order7Id, product_id = product3Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000015"), OrderId = order8Id, product_id = product2Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000016"), OrderId = order8Id, product_id = product4Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000017"), OrderId = order9Id, product_id = product5Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000018"), OrderId = order9Id, product_id = product7Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000019"), OrderId = order10Id, product_id = product6Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000020"), OrderId = order10Id, product_id = product8Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000021"), OrderId = order11Id, product_id = product9Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000022"), OrderId = order11Id, product_id = product11Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000023"), OrderId = order12Id, product_id = product10Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000024"), OrderId = order12Id, product_id = product12Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000025"), OrderId = order13Id, product_id = product1Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000026"), OrderId = order13Id, product_id = product6Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000027"), OrderId = order14Id, product_id = product2Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000028"), OrderId = order14Id, product_id = product7Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000029"), OrderId = order15Id, product_id = product3Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000030"), OrderId = order15Id, product_id = product8Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000031"), OrderId = order16Id, product_id = product4Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000032"), OrderId = order16Id, product_id = product9Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000033"), OrderId = order17Id, product_id = product5Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000034"), OrderId = order17Id, product_id = product10Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000035"), OrderId = order18Id, product_id = product6Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000036"), OrderId = order18Id, product_id = product11Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000037"), OrderId = order19Id, product_id = product7Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000038"), OrderId = order19Id, product_id = product12Id, is_active = 1 },

                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000039"), OrderId = order20Id, product_id = product8Id, is_active = 1 },
                new OrderItem { orderItem_id = Guid.Parse("40000000-0000-0000-0000-000000000040"), OrderId = order20Id, product_id = product1Id, is_active = 1 }
            );
        }
    }
}

