using ESFE.Habitacion.BL.Service;
using ESFE.Reserva.BL.DTO;
using ESFE.Reserva.BL.Service;
using ESFE.Reserva.EN;
using ESFE.Reserva.UI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace ESFE.Reserva.UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IReservaService reservaService;

        public AdminController(IReservaService reservaService)
        {
            this.reservaService = reservaService;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> Reservas(string username, string password)
        {
            if(username == "admin" && password == "2023")
            {

                IQueryable<EN.Reserva> listaReservas = await reservaService.ObtenerTodos();
                List<MVReservaAdmin> reservas = listaReservas.Select(r => new MVReservaAdmin
                {
                    IdReserva = r.IdReserva,
                    EstadoReserva = r.IdEstadoRNavigation.Nombre, // Asumiendo que tienes una propiedad NombreEstado en EstadoR
                    Cliente = r.IdClienteNavigation.Nombre, // Asumiendo que tienes una propiedad NombreCompleto en Cliente
                    Habitacion = r.IdHabitacionNavigation.NumeroHabitacion.ToString(), // Asumiendo que tienes una propiedad NombreHabitacion en Habitacion
                    FechaInicio = r.FechaInicio,
                    FechaFin = r.FechaFin,
                    Precio = r.Precio
                }).ToList();

                return View(reservas);
            }
            else
            {
                return Unauthorized();
            }
        }



    }
}
