using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.Reserva.EN;

namespace ESFE.Habitacion.BL.Service
{
    public interface IHabitacionService
    {
        Task<bool> Insertar(Reserva.EN.Habitacion modelo);
        Task<bool> Actualizar(Reserva.EN.Habitacion modelo);
        Task<bool> Eliminar(int id);
        Task<Reserva.EN.Habitacion> Obtener(int id);
        Task<IQueryable<Reserva.EN.Habitacion>> ObtenerTodos();
        Task<List<Reserva.EN.Habitacion>> ObtenerDisponibles(int capacidad, DateTime fechaInicio, DateTime fechaFin);
    }
}
