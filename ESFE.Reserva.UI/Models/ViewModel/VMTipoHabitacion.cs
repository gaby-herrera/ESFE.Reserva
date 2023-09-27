namespace ESFE.Reserva.UI.Models.ViewModel
{
    public class VMTipoHabitacion
    {
        public int IdTipoHabitacion { get; set; }

        public string Nombre { get; set; } = null!;

        public string? Imgs { get; set; }

        public int? Capacidad { get; set; }

        public decimal Precio { get; set; }

        public List<MVHabitacion> Habitaciones { get; set; }
    }
}
