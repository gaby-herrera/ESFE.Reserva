using ESFE.Reserva.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Reserva.DAL.Repositories
{
    public class TipoHabitacionRepository : IGenericRepository<TipoHabitacion>
    {
        public Task<TipoHabitacion> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenericRepository<TipoHabitacion>.Actualizar(TipoHabitacion model)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenericRepository<TipoHabitacion>.Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        Task<bool> IGenericRepository<TipoHabitacion>.Insertar(TipoHabitacion model)
        {
            throw new NotImplementedException();
        }

        Task<TipoHabitacion> IGenericRepository<TipoHabitacion>.Obtener(int id)
        {
            throw new NotImplementedException();
        }

        Task<IQueryable<TipoHabitacion>> IGenericRepository<TipoHabitacion>.ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
