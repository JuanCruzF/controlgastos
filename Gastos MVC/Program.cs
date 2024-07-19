using Gastos_MVC.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Inyección de dependencia
//Estamos construyendo un objeto, del tipo GastosContext, podemos acceder desde todos los controladores
builder.Services.AddDbContext<GastosContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("GastosContext"));
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
    pattern: "{controller=ListadoDeGastos}/{action=Index}/{id?}");

app.Run();
