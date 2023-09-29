using ESFE.Habitacion.BL.Service;
using ESFE.Reserva.BL.DTO;
using ESFE.Reserva.BL.Service;
using ESFE.Reserva.EN;
using ESFE.Reserva.UI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ESFE.Reserva.UI.Controllers
{
    public class HabitacionesController : Controller
    {
        private readonly IHabitacionService _habitacionService;
        private readonly ITipoHabitacionService _tipoService;

        public HabitacionesController(IHabitacionService serv, ITipoHabitacionService tipo)
        {
            _habitacionService = serv;
            _tipoService = tipo;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Buscar()
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

        //Este es el de la URL DINAMICA
        [HttpGet]
        public async Task<IActionResult> Disponibles(int capacidad = 0, string fechaInicioStr = null, string fechaFinStr = null)
        {
            try
            {
                DateTime? fechaInicio = null;
                DateTime? fechaFin = null;

                //Verificar que las fechas no estén vacías
                if (!string.IsNullOrEmpty(fechaInicioStr) && !string.IsNullOrEmpty(fechaFinStr))
                {
                    if (DateTime.TryParse(fechaInicioStr, out var parsedFechaInicio) && DateTime.TryParse(fechaFinStr, out var parsedFechaFin))
                    {
                        fechaInicio = parsedFechaInicio;
                        fechaFin = parsedFechaFin;
                    }
                }

                List<HabitacionDTO> habitacionesDisponibles = await _habitacionService.ObtenerDisponibles(capacidad, fechaInicio ?? DateTime.MinValue, fechaFin ?? DateTime.MinValue);

               

                return View(habitacionesDisponibles);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }


        public async Task<IActionResult> Detalles(int id)
        {
            try
            {
                // Llamar al servicio para obtener la información de la habitación por su ID
                var habitacion = await _habitacionService.Obtener(id);

                if (habitacion == null)
                {
                    // Habitación no encontrada, puedes manejar esto de acuerdo a tus necesidades
                    return NotFound();
                }

                // Retornar la vista con la información de la habitación
                return View(habitacion);
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que pueda ocurrir
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
