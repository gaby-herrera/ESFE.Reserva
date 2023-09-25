using ESFE.Reserva.BL.Service;
using Microsoft.AspNetCore.Mvc;

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
            var lista = await _tipoHabitacionService.ObtenerTodos();
            return Ok(lista);
        }
    }
}
