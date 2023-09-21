using ESFE.Reserva.BL.Service;
using ESFE.Reserva.UI.Models;
using ESFE.Reserva.UI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ESFE.Reserva.EN;

namespace ESFE.Reserva.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IReservaService _ReservaService;

        public HomeController(IReservaService reservaServ)
        {
            _ReservaService = reservaServ;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task <IActionResult> Lista()
        {
            IQueryable<EN.Reserva> queryReservaSQL = await _ReservaService.ObtenerTodos();
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


        [HttpPost]
        public async Task<IActionResult> Insertar([FromBody] VMReserva Modelo)
        {
            EN.Reserva NuevoModelo = new EN.Reserva
            {
                IdCliente = Modelo.IdCliente,
                IdHabitacion = Modelo.IdHabitacion,
                FechaInicio = Modelo.IdFechaInicio,
                FechaFin = Modelo.IdFechaFin,
                IdTarifa = Modelo.IdTarifa,
                IdEstadoR = Modelo.IdEstadoR,
            };
            bool respuesta = await _ReservaService.Insertar(NuevoModelo);
            return StatusCode(StatusCodes.Status200OK, new {valor
            = respuesta});
        }


        [HttpPut]
        public async Task<IActionResult> Actualizar([FromBody] VMReserva Modelo)
        {
            EN.Reserva NuevoModelo = new EN.Reserva()
            {
                IdCliente = Modelo.IdCliente,
                IdHabitacion = Modelo.IdHabitacion,
                FechaInicio = Modelo.IdFechaInicio,
                FechaFin = Modelo.IdFechaFin,
                IdTarifa = Modelo.IdTarifa,
                IdEstadoR = Modelo.IdEstadoR,
            };
            bool respuesta = await _ReservaService.Actualizar(NuevoModelo);
            return StatusCode(StatusCodes.Status200OK, new
            { valor  = respuesta  });
        }


        [HttpDelete]
        public async Task<IActionResult> Eliminar(int id)
        {
            bool respuesta = await _ReservaService.Eliminar(id);
            return StatusCode(StatusCodes.Status200OK, new
            { valor = respuesta });
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}