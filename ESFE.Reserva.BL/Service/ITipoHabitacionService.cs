using ESFE.Reserva.EN;

namespace ESFE.Reserva.BL.Service
{
    public interface ITipoHabitacionService
    {
        Task<List<TipoHabitacion>> ObtenerTodos();
    }
}