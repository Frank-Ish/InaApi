using Entities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ClienteData : IData<TbCliente>
    {
        private readonly DbProyectoInaContext _dbContext;
        public ClienteData(DbProyectoInaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> actualizarAsync(TbCliente entidad)
        {
            //_dbContext.Entry(entidad).State = (Microsoft.EntityFrameworkCore.EntityState)EntityState.Modified;

            try
            {
                _dbContext.Entry(entidad).State = EntityState.Modified;
                _dbContext.Entry(entidad.CedulaNavigation).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            
        }
        
        public async Task<bool> eliminarAsync(TbCliente entidad)
        {
            //var cliente = await _dbContext.TbClientes.FindAsync(entidad.Cedula);
            try
            {
                _dbContext.Entry(entidad).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<TbCliente> guardarAsync(TbCliente entidad)
        {
            try
            {
                _dbContext.TbClientes.Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TbCliente> obtenerPorIdAsync(TbCliente entidad)

        {
            try
            {
              
                 return await _dbContext.TbClientes.Include("CedulaNavigation").Where(x => x.Cedula.Trim() == entidad.Cedula.Trim() && x.Estado == true).SingleOrDefaultAsync();
                
            }
            catch (Exception)
            {
                throw;
            }
    
        }

        public async Task<List<TbCliente>> obtenerTodosAsync()
        {
            try
            {
                using (var context = new DbProyectoInaContext())
                {
                    return await context.TbClientes.Include("CedulaNavigation").Where(x => x.Estado == true).ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
