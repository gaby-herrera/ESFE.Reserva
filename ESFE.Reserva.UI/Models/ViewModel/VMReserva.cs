namespace ESFE.Reserva.UI.Models.ViewModel
{
    public class VMReserva
    {
        public int IdReserva { get; set; }

        public int IdEstadoR { get; set; }

        public int IdCliente { get; set; }

        public int IdHabitacion { get; set; }

        public DateTime FechaInicio { get; set; }

        public DateTime FechaFin { get; set; }

        public int IdTarifa { get; set; }
        public DateTime IdFechaFin { get; internal set; }
        public DateTime IdFechaInicio { get; internal set; }
    }
}
