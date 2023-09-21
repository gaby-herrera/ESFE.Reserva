using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.Reserva.EN;

namespace ESFE.Reserva.BL.Service
{
    public interface IReservaService
    {
        Task<bool> Insertar(EN.Reserva modelo);
        Task<bool> Actualizar(EN.Reserva modelo);
        Task<bool> Eliminar(int id);
        Task<EN.Reserva> Obtener(int id);
        Task<IQueryable<EN.Reserva>> ObtenerTodos();
    }
}
