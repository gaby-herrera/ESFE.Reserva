using ESFE.Reserva.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Reserva.BL.Service
{
    public class ReservaService : IReservaService
    {
        private readonly IGenericRepository<EN.Reserva> _ReservaRepo;
        public  ReservaService(IGenericRepository<EN.Reserva> ReservaRepo)
        {
            _ReservaRepo = ReservaRepo;
        }
        public async Task<bool> Actualizar(EN.Reserva modelo)
        {
            return await _ReservaRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _ReservaRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(EN.Reserva modelo)
        {
            return await _ReservaRepo.Insertar(modelo);
        }

        public async Task<EN.Reserva> Obtener(int id)
        {
            return await _ReservaRepo.Obtener(id);
        }

        public async Task<IQueryable<EN.Reserva>> ObtenerTodos()
        {
            return await _ReservaRepo.ObtenerTodos();
        }
    }
}
