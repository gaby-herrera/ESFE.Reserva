using Microsoft.EntityFrameworkCore;
using ESFE.Reserva.DAL.DataContext;
using ESFE.Reserva.DAL.Repositories;
using ESFE.Reserva.EN;
using ESFE.Reserva.BL.Service;
using ESFE.Habitacion.DAL.Repositories;
using ESFE.Habitacion.BL.Service;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DbHotelSystemContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("DbHotelContext"));
});

builder.Services.AddScoped<IGenericRepository<Reserva>, ReservaRepository>();
builder.Services.AddScoped<IGenericRepository<TipoHabitacion>, TipoHabitacionRepository>();
builder.Services.AddScoped<IGenericRepository<Habitacion>, HabitacionRepository>();
builder.Services.AddScoped<IReservaService, ReservaService>();
builder.Services.AddScoped<ITipoHabitacionService, TipoHabitacionService>();
builder.Services.AddScoped<IHabitacionService, HabitacionService>();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        options.JsonSerializerOptions.ReferenceHandler = null;
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
