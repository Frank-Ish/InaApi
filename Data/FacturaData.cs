using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
                var facturaDb = await _dbContext.TbDetalleFacturas.Where(f => f.IdFactura == entidad.IdFactura).AsNoTracking()
                    .ToListAsync();

                if (facturaDb != null)
                {
                    // Encuentra los detalles que deben ser eliminados
                    /*var detallesAEliminar = facturaDb.TbDetalleFacturas
                        .Where(d => !entidad.TbDetalleFacturas.Any(e => e.IdDetalleFactura == d.IdDetalleFactura))
                        .ToList();

                    // Elimina los detalles
                    _dbContext.TbDetalleFacturas.RemoveRange(detallesAEliminar);*/

                    // Actualiza los detalles existentes y agrega nuevos detalles
                    foreach (var detalle in entidad.TbDetalleFacturas)
                    {
                        if (detalle.IdDetalleFactura != 0)
                        {
                            _dbContext.Entry(detalle).State = EntityState.Modified;
                        }
                        else
                        {
                            _dbContext.Entry(detalle).State = EntityState.Added;
                        }
                    }

                    foreach (var detalledb in facturaDb)
                    {
  
                        if (entidad.TbDetalleFacturas.Where(e => e.IdDetalleFactura == detalledb.IdDetalleFactura).SingleOrDefault() == null)
                        {
                            _dbContext.Entry(entidad.TbDetalleFacturas.Where(e => e.IdDetalleFactura == detalledb.IdDetalleFactura).SingleOrDefault()).State = EntityState.Deleted;
                        }

                    }

                    // Actualiza la factura
                    _dbContext.Entry(entidad).State = EntityState.Modified;
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
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
                foreach (var detalle in entidad.TbDetalleFacturas)
                {
                    detalle.IdProductoNavigation = null;
                }   
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
                    .Include("TipoVentaNavigation").Where(X => X.Estado == true).AsNoTracking().SingleOrDefaultAsync();
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
