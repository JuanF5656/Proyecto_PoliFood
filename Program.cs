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

// =========================
// DB CONTEXT
// =========================
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// =========================
// IDENTITY
// =========================
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// =========================
// AUTHENTICATION JWT
// =========================
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

// =========================
// AUTHORIZATION
// =========================
builder.Services.AddAuthorization();

// =========================
// SERVICES
// =========================
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IStudentService, StudentService>();

// =========================
// CONTROLLERS + OPENAPI
// =========================
builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// =========================
// SEED ADMIN INICIAL
// =========================
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
    // Crear roles si no existen
    if (!await roleManager.RoleExistsAsync("Admin"))
        await roleManager.CreateAsync(new IdentityRole("Admin"));

    if (!await roleManager.RoleExistsAsync("Student"))
        await roleManager.CreateAsync(new IdentityRole("Student"));

    if (!await roleManager.RoleExistsAsync("Vendor"))
        await roleManager.CreateAsync(new IdentityRole("Vendor"));

    // Crear admin inicial si no existe
    var email = "admin@polifood.com";
    var user = await userManager.FindByEmailAsync(email);

    if (user == null)
    {
        user = new IdentityUser
        {
            UserName = email,
            Email = email,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, "Admin123*");

        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");

            var adminExiste = await dbContext.Admin.AnyAsync(a => a.IdentityUserId == user.Id);

            if (!adminExiste)
            {
                dbContext.Admin.Add(new Admin
                {
                    admin_id = Guid.Parse("11111111-1111-1111-1111-111111111112"),
                    name_admin = "Simon",
                    is_active = 1,
                    IdentityUserId = user.Id
                });

                await dbContext.SaveChangesAsync();
            }
        }
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();