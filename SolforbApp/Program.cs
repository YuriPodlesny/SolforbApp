using Microsoft.EntityFrameworkCore;
using SolforbApp.Domain.Core;
using SolforbApp.Domain.Interfaces;
using SolforbApp.Infrastructure.Data;
using SolforbApp.Infrastructure.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

var connection = builder.Configuration.GetConnectionString("SolforbDatabase");
builder.Services.AddDbContext<SolforbDbContext>(options =>
{
    options.UseSqlServer(connection);
});

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IOrderItemRepository, OrderItemRepository>();
builder.Services.AddScoped<IProviderRepository, ProviderRepository>();


// Add services to the container.
builder.Services.AddControllersWithViews();

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

//app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
