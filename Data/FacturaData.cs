using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class FacturaData : IData<TbFactura>
    {
        private readonly DbProyectoInaContext _dbContext;

        public FacturaData(DbProyectoInaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> actualizarAsync(TbFactura entidad)
        {
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

        public async Task<bool> eliminarAsync(TbFactura entidad)
        {
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

        public async Task<TbFactura> guardarAsync(TbFactura entidad)
        {
            try
            {
                _dbContext.TbFacturas.Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<TbFactura> obtenerPorIdAsync(TbFactura entidad)
        {
            try
            {
                return await _dbContext.TbFacturas.Include("TbDetalleFacturas").Where(x => x.IdFactura == entidad.IdFactura && x.Estado == true)
                    .Include("TipoPagoNavigation").Where(X => X.Estado == true)
                    .Include("TipoVentaNavigation").Where(X => X.Estado == true).SingleOrDefaultAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TbFactura>> obtenerTodosAsync()
        {
            try
            {
                return await _dbContext.TbFacturas.Include("TbDetalleFacturas").Where(x => x.Estado == true)
                    .Include("TipoPagoNavigation").Where(X => X.Estado == true)
                    .Include("TipoVentaNavigation").Where(X => X.Estado == true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
