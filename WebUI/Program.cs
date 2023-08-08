using ApplicationCore.Interfaces;
using Infrastructure;
using Infrastructure.Logging;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NLog;
using WebUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddDbContext<MainContext>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSwaggerGen(v => v.SwaggerDoc("v1", new OpenApiInfo
{
    Title = "test eshop apis",
    Version = "v1"
}));


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
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint(
"/swagger/v1/swagger.json", "Test Eshop APIs"));

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action}/{id?}");
app.MapRazorPages();

app.Run();

