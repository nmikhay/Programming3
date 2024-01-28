using BookShop.Data;
using BookShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<BookShopContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()  // Add support for roles
    .AddEntityFrameworkStores<BookShopContext>();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapFallbackToPage("/HomePage");
});

async Task CreateRolesAndUsers(IServiceProvider serviceProvider)
{
    var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roleNames = { "Admin", "Customer" };
    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }

    var adminUser = new IdentityUser
    {
        UserName = "Admin",
        Email = "admin@bookshop.com",
    };

    string adminPassword = "Admin123!";

    var adminExists = await userManager.FindByNameAsync(adminUser.UserName);
    if (adminExists == null)
    {
        var result = await userManager.CreateAsync(adminUser, adminPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }

    var customerUser = new IdentityUser
    {
        UserName = "Customer",
        Email = "customer@bookshop.com",
    };

    string customerPassword = "Customer123!";

    var customerExists = await userManager.FindByNameAsync(customerUser.UserName);
    if (customerExists == null)
    {
        var result = await userManager.CreateAsync(customerUser, customerPassword);
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(customerUser, "Customer");
        }
    }
}

using var scope = app.Services.CreateScope();
await CreateRolesAndUsers(scope.ServiceProvider);

app.Run();




