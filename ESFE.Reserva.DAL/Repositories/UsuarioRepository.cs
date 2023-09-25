using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Reserva.DAL.Repositories
{
    public class UsuarioRepository : IGenericRepository<Usuario>
    {
        public Task<bool> Actualizar(Usuario model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Insertar(Usuario model)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Obtener(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<Usuario>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }

    public class Usuario
    {
    }
}
