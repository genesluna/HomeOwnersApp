using Microsoft.EntityFrameworkCore;
using HomeOwnersApp.Data;
using Microsoft.AspNetCore.Identity;
using HomeOwnersApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppDataContext") ?? throw new InvalidOperationException("Connection string 'AppDataContext' not found.")));

builder.Services.AddDbContext<AppAuthContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AppAuthContext") ?? throw new InvalidOperationException("Connection string 'AppAuthContext' not found.")));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<AppAuthContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

// Configuring simple passwords for dev purposes.
builder.Services.Configure<IdentityOptions>(opt =>
{
    opt.Password.RequiredUniqueChars = 0;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=HomeOwners}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
