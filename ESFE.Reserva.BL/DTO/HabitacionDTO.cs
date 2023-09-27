using ESFE.Reserva.EN;

namespace ESFE.Reserva.BL.DTO
{
    public class HabitacionDTO
    {
        public int IdHabitacion { get; set; }

        public short NumeroHabitacion { get; set; }

        public int IdTipoHabitacion { get; set; }

        public int IdEstadoH { get; set; }

        public TipoHabitacion Tipo { get; set; }
    }
}
