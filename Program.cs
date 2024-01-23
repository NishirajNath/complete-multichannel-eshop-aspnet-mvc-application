using eShop.Data;
using Microsoft.EntityFrameworkCore;
using eShop.Controllers;
using Microsoft.AspNetCore.Builder;
using eShop.Data.Services;
using Azure;
using Microsoft.AspNetCore.Mvc;
using eShop.Data.Cart;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add configuration from appsettings.json
builder.Configuration.AddJsonFile("appsettings.json", optional: false);



builder.Services.AddDbContext<AppDbContext>(options =>{
    // Retrieve the connection string from appsettings.json
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

    // UseSqlServer with the retrieved connection string
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IProductsService, productsService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

builder.Services.AddSession();

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

// seed database
AppDbInitializer.seed(app);

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}" );



app.Run();


