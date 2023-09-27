using ESFE.Reserva.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.Reserva.DAL;
using ESFE.Reserva.DAL.DataContext;

namespace ESFE.Reserva.DAL.Repositories
{
    public class TipoHabitacionRepository : IGenericRepository<TipoHabitacion>
    {
        private readonly DbHotelSystemContext _dbContext;

        public TipoHabitacionRepository(DbHotelSystemContext dbHotelContext)
        {
            _dbContext = dbHotelContext;
        }

        public Task<bool> Actualizar(TipoHabitacion model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insertar(TipoHabitacion model)
        {
            throw new NotImplementedException();
        }

        public async Task<TipoHabitacion> Obtener(int id)
        {
            return await _dbContext.TipoHabitacions.FindAsync(id);
        }

        public async Task<IQueryable<TipoHabitacion>> ObtenerTodos()
        {
            IQueryable<TipoHabitacion> queryTipoHabitacionSQL = _dbContext.TipoHabitacions;
            return queryTipoHabitacionSQL;
        }
    }
}
