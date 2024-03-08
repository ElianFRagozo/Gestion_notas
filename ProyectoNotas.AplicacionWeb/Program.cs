using Microsoft.EntityFrameworkCore;
using ProyectoNotas.BLL.Service;
using ProyectoNotas.DAL.DataContext;
using ProyectoNotas.DAL.Repositorio;
using ProyectoNotas.Models;
using System.Diagnostics.Contracts;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<NotasContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("cadenaSQL"));
});

builder.Services.AddScoped<IGenericRepository<Nota>, NotasRepository>();
builder.Services.AddScoped<INotasService, NotasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
