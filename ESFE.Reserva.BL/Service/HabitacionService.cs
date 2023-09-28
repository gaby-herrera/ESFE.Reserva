using ESFE.Reserva.BL.DTO;
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

        public async Task<HabitacionDTO> Obtener(int id)
        {
            Reserva.EN.Habitacion habitacion = await _habitacionRepository.Obtener(id);
            var tiposHabitaciones = await _tipoHabitacionRepository.ObtenerTodos();

            HabitacionDTO habitacionDto = new HabitacionDTO()
            {
                IdHabitacion = habitacion.IdHabitacion,
                IdEstadoH = habitacion.IdEstadoH,
                IdTipoHabitacion = habitacion.IdTipoHabitacion,
                NumeroHabitacion = habitacion.NumeroHabitacion,
                Tipo = tiposHabitaciones.FirstOrDefault(t => t.IdTipoHabitacion == habitacion.IdTipoHabitacion)
            };
            return habitacionDto;
        }

        public async Task<IQueryable<Reserva.EN.Habitacion>> ObtenerTodos()
        {
            var all = await _habitacionRepository.ObtenerTodos();
            var result = all.Include(h => h.Reservas);
            return result;
        }

        public async Task<List<HabitacionDTO>> ObtenerDisponibles(int capacidad, DateTime fechaInicio, DateTime fechaFin)
        {
            // Obtener Listas
            var tiposHabitaciones = await _tipoHabitacionRepository.ObtenerTodos();
            var habitaciones = await _habitacionRepository.ObtenerTodos();
            var reservas = await _reservaRepository.ObtenerTodos();

            IQueryable<Reserva.EN.Habitacion> habitacionesFiltradas = habitaciones;

            // Filtrar por capacidad si se proporciona el valor
            if (capacidad > 0) // si recibis una capacidad 
            {
                // Obtener ids de tipos de habitaciones con capacidad solicitada
                var tiposPermitidos = tiposHabitaciones // -->  [ 1, 2 ]
                    .Where(t => t.Capacidad >= capacidad)
                    .Select(t => t.IdTipoHabitacion)
                    .ToList();

                // Filtrar las habitaciones por tipos de habitaciones permitidos
                habitacionesFiltradas = habitacionesFiltradas
                    .Where(h => tiposPermitidos.Contains(h.IdTipoHabitacion));
            }

            // Filtrar por fechas si se proporcionan los valores
            if (fechaInicio != DateTime.MinValue && fechaFin != DateTime.MinValue)
            {
                // Obtener ids de reservas que se superponen con el rango de fechas especificado
                var reservasSuperpuestas = reservas
                    .Where(r => r.FechaInicio <= fechaFin && r.FechaFin >= fechaInicio)
                    .Select(r => r.IdHabitacion)
                    .ToList();

                // Filtrar las habitaciones disponibles excluyendo las reservas superpuestas
                habitacionesFiltradas = habitacionesFiltradas
                    .Where(h => !reservasSuperpuestas.Contains(h.IdHabitacion));
            } // 

            // Obtener habitaciones disponibles
            var habitacionesDisponibles = await habitacionesFiltradas.ToListAsync();

            // Mapear a HabitacionDTO de forma sincrónica
            var habitacionesDTO = habitacionesDisponibles.Select(h => new HabitacionDTO
            {
                IdHabitacion = h.IdHabitacion,
                IdEstadoH = h.IdEstadoH,
                IdTipoHabitacion = h.IdTipoHabitacion,
                NumeroHabitacion = h.NumeroHabitacion,
                Tipo = tiposHabitaciones.FirstOrDefault(t => t.IdTipoHabitacion == h.IdTipoHabitacion) // Asignar el tipo
            }).ToList();

            return habitacionesDTO;
        }

      
    }
}
