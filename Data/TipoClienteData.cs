using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TipoClienteData : IData<TbTipoCliente>
    {
        private readonly DbProyectoInaContext _context;

        public TipoClienteData(DbProyectoInaContext context)
        {
            _context = context;
        }

        public async Task<bool> actualizarAsync(TbTipoCliente entidad)
        {
            try
            {
                _context.Entry(entidad).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> eliminarAsync(TbTipoCliente entidad)
        {
            try
            {
                _context.Entry(entidad).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TbTipoCliente> guardarAsync(TbTipoCliente entidad)
        {
            try
            {
                _context.TbTipoClientes.Add(entidad);
                await _context.SaveChangesAsync();
                return entidad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TbTipoCliente> obtenerPorIdAsync(TbTipoCliente entidad)
        {
            try
            {
                return await _context.TbTipoClientes.FindAsync(entidad.Id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TbTipoCliente>> obtenerTodosAsync()
        {
            try
            {
                using (var context = new DbProyectoInaContext())
                {
                    return await context.TbTipoClientes.Where(x => x.Estado == true).ToListAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
