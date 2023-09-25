using ESFE.Reserva.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESFE.Reserva.BL.Service
{
    public class UsuarioService
    {
        private readonly IGenericRepository<Usuario> _UsuarioRepo;
        public UsuarioService(IGenericRepository<Usuario> UsuarioRepo)
        {
            _UsuarioRepo = UsuarioRepo;
        }
        public async Task<bool> Actualizar(Usuario modelo)
        {
            return await _UsuarioRepo.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _UsuarioRepo.Eliminar(id);
        }

        public async Task<bool> Insertar(Usuario modelo)
        {
            return await _UsuarioRepo.Insertar(modelo);
        }

        public async Task<Usuario> Obtener(int id)
        {
            return await _UsuarioRepo.Obtener(id);
        }

        public async Task<IQueryable<Usuario>> ObtenerTodos()
        {
            return await _UsuarioRepo.ObtenerTodos();
        }
    }
}

