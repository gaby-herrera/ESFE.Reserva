using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Reserva.BL.Service
{
    public interface ITipoHabitacion
    {
        Task<IQueryable<EN.Reserva>> ObtenerTodos();
    }
}
