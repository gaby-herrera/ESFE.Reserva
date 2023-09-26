using ESFE.Reserva.BL.Service;
using ESFE.Reserva.DAL.Repositories;
using ESFE.Reserva.EN;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Habitacion.BL.Service
{
    public class HabitacionService : IHabitacionService
    {
        private readonly IGenericRepository<TipoHabitacion> _tipoHabitacionRepository;
        private readonly IGenericRepository<Reserva.EN.Habitacion> _habitacionRepository;
        private readonly IGenericRepository<Reserva.EN.Reserva> _reservaRepository;

        public HabitacionService(
            IGenericRepository<Reserva.EN.Habitacion> habitacionRepository,
            IGenericRepository<Reserva.EN.Reserva> reservaRepository,
            IGenericRepository<TipoHabitacion> tipoHabitacionRepositor
            )
        {
            _habitacionRepository = habitacionRepository;
            _reservaRepository = reservaRepository;
            _tipoHabitacionRepository = tipoHabitacionRepositor;
        }

        public async Task<bool> Actualizar(Reserva.EN.Habitacion modelo)
        {
            return await _habitacionRepository.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _habitacionRepository.Eliminar(id);
        }

        public async Task<bool> Insertar(Reserva.EN.Habitacion modelo)
        {
            return await _habitacionRepository.Insertar(modelo);
        }

        public async Task<Reserva.EN.Habitacion> Obtener(int id)
        {
            return await _habitacionRepository.Obtener(id);
        }

        public async Task<IQueryable<Reserva.EN.Habitacion>> ObtenerTodos()
        {
            var all = await _habitacionRepository.ObtenerTodos();
            var result = all.Include(h => h.Reservas);
            return result;
        }

        public async Task<List<Reserva.EN.Habitacion>> ObtenerDisponibles(int capacidad, DateTime fechaInicio, DateTime fechaFin)
        {
            // Obtener Listas
            var tiposHabitaciones = await _tipoHabitacionRepository.ObtenerTodos();
            var habitaciones = await _habitacionRepository.ObtenerTodos();
            var reservas = await _reservaRepository.ObtenerTodos();

            // Obtener ids reservas que se superponen con el rango de fechas especificado
            var reservasSuperpuestas = reservas
                .Where(r => r.FechaInicio <= fechaFin && r.FechaFin >= fechaInicio)
                .Select(r => r.IdHabitacion)
                .ToList();

            // Obtener ids de habitaciones con capacidad solicitada
            var tiposPermitidos = tiposHabitaciones
                .Where(t => t.Capacidad > capacidad)
                .Select(t => t.IdTipoHabitacion)
                .ToList();

            // Filtrar las habitaciones disponibles excluyendo las reservas superpuestas
            var habitacionesDisponibles = habitaciones
                .Where(h => tiposPermitidos.Contains(h.IdTipoHabitacion) && !reservasSuperpuestas.Contains(h.IdHabitacion))
                .ToList();


            return habitacionesDisponibles;
        }

    }
}
