using Microsoft.EntityFrameworkCore;
using systmHotel.BLL.Services;
using systmHotel.DAL.Context;
using systmHotel.DAL.IRepository;
using systmHotel.DAL.IRepositoryy;
using systmHotel.DAL.Repository;
using systmHotel.DAL.Repositoryy;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ClientService>();

builder.Services.AddDbContext<systHotelContext>(options=>options.UseSqlite("Data source=systmHotelDB.sql",b => b.MigrationsAssembly("systmHotel.DAL")));

builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();    

builder.Services.AddScoped<ServiceService>();

builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{

    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
