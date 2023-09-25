using ESFE.Reserva.BL.Service;
using ESFE.Reserva.EN;
using ESFE.Reserva.UI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace ESFE.Reserva.UI.Controllers
{
    public class HabitacionesController : Controller
    {
        private readonly IReservaService _RerservaService;

        public HabitacionesController(IReservaService ReservaService)
        {
            _RerservaService = ReservaService;
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
            IQueryable<EN.Reserva> queryReservaSQL = await _RerservaService.ObtenerTodos();
            List<VMReserva> lista = queryReservaSQL  
                .Select(c => new VMReserva
                {
                    IdReserva = c.IdReserva,
                    IdEstadoR = c.IdEstadoR,
                    IdCliente = c.IdCliente,
                    IdHabitacion = c.IdHabitacion,
                    FechaInicio = c.FechaInicio,
                    FechaFin = c.FechaFin,
                    IdTarifa = c.IdTarifa

                }).ToList();


            return StatusCode(StatusCodes.Status200OK, lista);
        }
    }
}
