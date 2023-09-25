using ESFE.Reserva.DAL.DataContext;
using ESFE.Reserva.EN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Reserva.DAL.Repositories
{
    public class ReservaRepository : IGenericRepository<EN.Reserva>
    {
        public readonly DbHotelContext _dbcontext;

        public ReservaRepository(DbHotelContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Actualizar(EN.Reserva modelo)
        {
            _dbcontext.Reservas.Update(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Eliminar(int id)
        {
            EN.Reserva modelo = _dbcontext.Reservas.First(c => c.IdReserva == id);
            _dbcontext.Reservas.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(EN.Reserva modelo)
        {
            _dbcontext.Reservas.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<EN.Reserva> Obtener(int id)
        {
            return await _dbcontext.Reservas.FindAsync(id);
        }

        public async Task<IQueryable<EN.Reserva>> ObtenerTodos()
        {
            IQueryable<EN.Reserva> IqueryReservaSQL = _dbcontext.Reservas;
            return IqueryReservaSQL;
        }

    }
}
