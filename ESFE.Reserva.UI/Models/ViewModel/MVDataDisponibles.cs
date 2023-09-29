using ESFE.Reserva.BL.DTO;

namespace ESFE.Reserva.UI.Models.ViewModel
{
    public class MVDisponibles
    {
        public List<HabitacionDTO> HabitacionesDisponibles { get; set; }
        public DateTime FechaInicioReserva { get; set; }
        public DateTime FechaFinReserva { get; set; }
    }

}
