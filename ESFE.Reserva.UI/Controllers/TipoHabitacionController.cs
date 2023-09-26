using ESFE.Reserva.BL.Service;
using Microsoft.AspNetCore.Mvc;
using ESFE.Reserva.UI.Models.ViewModel;
using ESFE.Reserva.EN;

namespace ESFE.Reserva.UI.Controllers
{
    public class TipoHabitacionController : Controller
    {
        private readonly ITipoHabitacionService _tipoHabitacionService;

        public TipoHabitacionController(ITipoHabitacionService tipoHabitacionService)
        {
            _tipoHabitacionService = tipoHabitacionService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<TipoHabitacion> lista = await _tipoHabitacionService.ObtenerTodos();

            List<VMTipoHabitacion> result = lista.Select(t => new VMTipoHabitacion()
            {
                IdTipoHabitacion = t.IdTipoHabitacion,
                Nombre = t.Nombre,
                Capacidad = t.Capacidad,
                Habitaciones = t.Habitacions.Select(h => new MVHabitacion()
                {
                    IdEstadoH = h.IdEstadoH,
                    NumeroHabitacion = h.NumeroHabitacion,
                    IdHabitacion = h.IdHabitacion,
                    IdTipoHabitacion = h.IdTipoHabitacion
                }).ToList(),
                Imgs = t.Imgs,
                Precio = t.Precio
            }).ToList();
            return Ok(result);
        }
    }
}
