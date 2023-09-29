namespace ESFE.Reserva.UI.Models.ViewModel
{
    public class MVReservaAdmin
    {
        public int IdReserva { get; set; }
        public string EstadoReserva { get; set; }
        public string Cliente { get; set; }
        public string Habitacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public decimal Precio { get; set; }
    }
}
