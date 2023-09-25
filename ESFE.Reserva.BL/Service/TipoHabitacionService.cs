using ESFE.Reserva.EN;
using ESFE.Reserva.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Reserva.BL.Service
{
    public class TipoHabitacionService : ITipoHabitacionService
    {
        private readonly IGenericRepository<TipoHabitacion> _TipoHabitacion;
        public TipoHabitacionService(IGenericRepository<TipoHabitacion> TipoHabitacionRepo)
        {
            _TipoHabitacion = TipoHabitacionRepo;
        }
        public async Task<IQueryable<TipoHabitacion>> ObtenerTodos()
        {
            return await _TipoHabitacion.ObtenerTodos();
        }
    }
}
