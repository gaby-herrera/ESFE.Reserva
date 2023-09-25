using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.Reserva.EN;

namespace ESFE.Reserva.DAL.Repositories
{
    public class TipoHabitacion : IGenericRepository<TipoHabitacion>
    {
        public Task<TipoHabitacion> Obtener(int id)
        {
            throw new NotImplementedException();
        }
    }
}
