using ESFE.Reserva.EN;
using ESFE.Reserva.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace ESFE.Reserva.BL.Service
{
    public class TipoHabitacionService : ITipoHabitacionService
    {
        private readonly IGenericRepository<TipoHabitacion> _TipoHabitacion;
        private readonly IGenericRepository<Reserva.EN.Habitacion> _HabitacionRepository;

        public TipoHabitacionService(IGenericRepository<TipoHabitacion> TipoHabitacionRepo, IGenericRepository<Reserva.EN.Habitacion> HabitacionRepository)
        {
            _TipoHabitacion = TipoHabitacionRepo;
            _HabitacionRepository = HabitacionRepository;
        }

        public async Task<TipoHabitacion> Obtener(int id)
        {
            return await _TipoHabitacion.Obtener(id);
        }

        public async Task<List<TipoHabitacion>> ObtenerTodos()
        {
            IQueryable<TipoHabitacion> queryTipoHabitacionSQL = await _TipoHabitacion.ObtenerTodos();
            var result = queryTipoHabitacionSQL.Include(t => t.Habitacions).ToList();
            return result;
        }
    }
}
