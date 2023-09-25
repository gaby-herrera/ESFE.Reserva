using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESFE.Reserva.DAL.Repositories;
using ESFE.Reserva.EN;
using Microsoft.EntityFrameworkCore;
using ESFE.Reserva.DAL;
using ESFE.Reserva.DAL.DataContext;

namespace ESFE.Reserva.DAL.Repositories
{
    public class ClienteRepository : IGenericRepository<Cliente>
    {
        private readonly DbHotelContext _dbContext;

        public ClienteRepository(DbHotelContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Actualizar(Cliente model)
        {
            _dbContext.Clientes.Update(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Eliminar(int id)
        {
            Cliente modelo = _dbContext.Clientes.First(c => c.IdCliente == id);
            _dbContext.Clientes.Remove(modelo);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Insertar(Cliente model)
        {
            _dbContext.Clientes.Add(model);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Cliente> Obtener(int id)
        {
            return await _dbContext.Clientes.FindAsync(id);
        }

        public async Task<IQueryable<Cliente>> ObtenerTodos()
        {
            IQueryable<Cliente> queryClienteSQL = _dbContext.Clientes;
            return queryClienteSQL;
        }

    }
}
