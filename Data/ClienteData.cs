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

            var cliente = await _dbContext.TbClientes.FindAsync(entidad.Cedula);     
            if (cliente == null)
            {
                return false;
            }
            else
            {
                //Instaciamos persona y seteamos los datos para mandarlos a cliente


                /*TbPersona persona = new TbPersona();
                persona.Cedula = persona.Cedula;
                persona.Nombre = entidad.CedulaNavigation.Nombre;
                persona.Apellido1 = entidad.CedulaNavigation.Apellido1;
                persona.Apellido2 = entidad.CedulaNavigation.Apellido2;
                persona.FechaNac = entidad.CedulaNavigation.FechaNac;
                persona.Genero = entidad.CedulaNavigation.Genero;*/

                /*Error 1 si intento setear los datos de persona para setearlos a cliente, tengo dos problemas.
                    * Si seteo la cedula, me dice que no puede cambiar la cedula.
                    * Si lo paso sin la cedula, la cedula queda null por lo que no guardar los cambios.
                 *Error 2, si intento setear los datos directamente a cliente por medio de CedulaNavigation, 
                  me dice que la referencia del objeto no esta establecida como una intancia del objeto.
                */


                cliente.Estado = entidad.Estado;
                cliente.DescMax = entidad.DescMax;
                cliente.Foto = entidad.Foto;
                cliente.CedulaNavigation.Nombre = entidad.CedulaNavigation.Nombre;
                cliente.CedulaNavigation.Apellido1 = entidad.CedulaNavigation.Apellido1;
                cliente.CedulaNavigation.Apellido2 = entidad.CedulaNavigation.Apellido2;
                cliente.CedulaNavigation.FechaNac = entidad.CedulaNavigation.FechaNac;
                cliente.CedulaNavigation.Genero = entidad.CedulaNavigation.Genero;

                await _dbContext.SaveChangesAsync();
            }


            return true;
        }
        
        public async Task<bool> eliminarAsync(TbCliente entidad)
        {
            //var cliente = await _dbContext.TbClientes.FindAsync(entidad.Cedula);
            if (entidad == null)
            {
                return false;
            }
            else
            {
                entidad.Estado = false;
                await _dbContext.SaveChangesAsync();
                return true;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TbCliente> obtenerPorIdAsync(TbCliente entidad)

        {
            try
            {
              
                 return await _dbContext.TbClientes.Include("CedulaNavigation").Where(x => x.Cedula.Trim() == entidad.Cedula.Trim()).SingleOrDefaultAsync();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
    
        }

        public async Task<List<TbCliente>> obtenerTodosAsync()
        {
            try
            {
                using (var context = new DbProyectoInaContext())
                {
                    return await context.TbClientes.Include("CedulaNavigation").ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
