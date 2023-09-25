using ESFE.Reserva.EN;

namespace ESFE.Reserva.BL.Service
{
    public interface ITipoHabitacionService
    {
        public Task<IQueryable<TipoHabitacion>> ObtenerTodos();
    }
}