using ApiConciertos.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Polifood.DAO;
using Polifood.Interfaces;
using Polifood.Models;
using Polifood.Services;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});


builder.Services.AddAuthorization();


builder.Services.AddCors(options =>
{
    options.AddPolicy("FrontendPolicy", policy =>
    {
        policy
            .WithOrigins(
                "http://localhost:5173",   // Vite dev server (por defecto)
                "http://localhost:4173"    // Vite preview
            )
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});


builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IStoreService, StoreService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();


builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

    await dbContext.Database.MigrateAsync();
    await SeedUsersAndRoles(userManager, roleManager, dbContext);
}

static async Task SeedUsersAndRoles(
    UserManager<IdentityUser> userManager,
    RoleManager<IdentityRole> roleManager,
    ApplicationDbContext dbContext)
{
    // ── Roles ──────────────────────────────────────────────────────────────
    foreach (var role in new[] { "Admin", "Student", "Vendor" })
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }

    // ── Admin ──────────────────────────────────────────────────────────────
    await SeedAdmin(userManager, dbContext);

    // ── Student de prueba ──────────────────────────────────────────────────
    await SeedStudent(userManager, dbContext);

    // ── Vendor de prueba ───────────────────────────────────────────────────
    await SeedVendor(userManager, dbContext);
}

static async Task SeedAdmin(
    UserManager<IdentityUser> userManager,
    ApplicationDbContext dbContext)
{
    const string email = "admin@polifood.com";
    const string password = "Admin123*";

    if (await userManager.FindByEmailAsync(email) != null) return;

    var user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
    var result = await userManager.CreateAsync(user, password);

    if (!result.Succeeded) return;

    await userManager.AddToRoleAsync(user, "Admin");

    if (!await dbContext.Admin.AnyAsync(a => a.IdentityUserId == user.Id))
    {
        dbContext.Admin.Add(new Admin
        {
            admin_id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
            name_admin = "Admin Polifood",
            is_active = 1,
            IdentityUserId = user.Id
        });
        await dbContext.SaveChangesAsync();
    }
}

static async Task SeedStudent(
    UserManager<IdentityUser> userManager,
    ApplicationDbContext dbContext)
{
    const string email = "student@polifood.com";
    const string password = "Student123*";

    if (await userManager.FindByEmailAsync(email) != null) return;

    var user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
    var result = await userManager.CreateAsync(user, password);

    if (!result.Succeeded) return;

    await userManager.AddToRoleAsync(user, "Student");

    if (!await dbContext.Student.AnyAsync(s => s.IdentityUserId == user.Id))
    {
        dbContext.Student.Add(new Student
        {
            student_id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
            student_name = "Estudiante Polifood",
            is_active = 1,
            IdentityUserId = user.Id
        });
        await dbContext.SaveChangesAsync();
    }
}

static async Task SeedVendor(
    UserManager<IdentityUser> userManager,
    ApplicationDbContext dbContext)
{
    const string email = "vendor@polifood.com";
    const string password = "Vendor123*";

    if (await userManager.FindByEmailAsync(email) != null) return;

    var user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
    var result = await userManager.CreateAsync(user, password);

    if (!result.Succeeded) return;

    await userManager.AddToRoleAsync(user, "Vendor");

    if (!await dbContext.Vendor.AnyAsync(v => v.IdentityUserId == user.Id))
    {
        dbContext.Vendor.Add(new Vendor
        {
            vendor_id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
            vendor_name = "Vendedor Polifood",
            is_active = 1,
            IdentityUserId = user.Id
        });
        await dbContext.SaveChangesAsync();
    }
}

// =========================
// PIPELINE
// =========================
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseCors("FrontendPolicy");   // CORS debe ir antes de auth

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();