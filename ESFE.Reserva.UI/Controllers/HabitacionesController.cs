using ESFE.Habitacion.BL.Service;
using ESFE.Reserva.BL.Service;
using ESFE.Reserva.EN;
using ESFE.Reserva.UI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ESFE.Reserva.UI.Controllers
{
    public class HabitacionesController : Controller
    {
        private readonly IHabitacionService _habitacionService;

        public HabitacionesController(IHabitacionService serv)
        {
            _habitacionService = serv;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Familiar()
        {
            return View();
        }

        public async Task<IActionResult> Lista()
        {
            IQueryable<EN.Habitacion> queryReservaSQL = await _habitacionService.ObtenerTodos();
            //List<VMReserva> lista = queryReservaSQL  
                //.Select(c => new VMReserva
                //{
                //    IdReserva = c.IdReserva,
                //    IdEstadoR = c.IdEstadoR,
                //    IdCliente = c.IdCliente,
                //    IdHabitacion = c.IdHabitacion,
                //    FechaInicio = c.FechaInicio,
                //    FechaFin = c.FechaFin,
                //    IdTarifa = c.IdTarifa

                //}).ToList();


            return StatusCode(StatusCodes.Status200OK, queryReservaSQL);
        }

        [HttpPost]
        public async Task<IActionResult> ObtenerDisponibles([FromBody] FiltroHabitacionesDisponibles filtro)
        {
            try
            {
                // Llamar al servicio para obtener las habitaciones disponibles
                var habitacionesDisponibles = await _habitacionService.ObtenerDisponibles(
                    filtro.Capacidad,
                    filtro.FechaInicio,
                    filtro.FechaFin
                );

                return Ok(habitacionesDisponibles);
            }
            catch (Exception ex)
            {
                return BadRequest($"Ocurrió un error: {ex.Message}");
            }
        }

        public class FiltroHabitacionesDisponibles
        {
            public int Capacidad { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFin { get; set; }
        }


    }
}
