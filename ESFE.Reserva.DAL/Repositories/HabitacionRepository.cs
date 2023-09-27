using ESFE.Reserva.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.Reserva.EN;
using ESFE.Reserva.DAL.DataContext;
using Microsoft.EntityFrameworkCore;

namespace ESFE.Habitacion.DAL.Repositories
{
    public class HabitacionRepository : IGenericRepository<Reserva.EN.Habitacion>
    {
        private readonly DbHotelSystemContext _dbcontext;

        public HabitacionRepository(DbHotelSystemContext context)
        {
            _dbcontext = context;
        }

        public async Task<bool> Actualizar(Reserva.EN.Habitacion model)
        {
            _dbcontext.Habitacions.Update(model);
            await _dbcontext.SaveChangesAsync();
            return true;

        }

        public async Task<bool> Eliminar(int id)
        {
            Reserva.EN.Habitacion modelo = _dbcontext.Habitacions.First(c => c.IdHabitacion == id);
            _dbcontext.Habitacions.Remove(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Reserva.EN.Habitacion modelo)
        {
            _dbcontext.Habitacions.Add(modelo);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        public async Task<Reserva.EN.Habitacion> Obtener(int id)
        {
            return await _dbcontext.Habitacions.FindAsync(id);
        }

        public async Task<IQueryable<Reserva.EN.Habitacion>> ObtenerTodos()
        {
            IQueryable<Reserva.EN.Habitacion> IqueryReservaSQL = _dbcontext.Habitacions;
            return IqueryReservaSQL;
        }
    }
}
