using Microsoft.EntityFrameworkCore;
using SolforbApp.Domain.Interfaces;
using SolforbApp.Infrastructure.Data;
using SolforbApp.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("SolforbDatabase");
builder.Services.AddDbContext<SolforbDbContext>(options =>
{
    options.UseSqlServer(connection);
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
