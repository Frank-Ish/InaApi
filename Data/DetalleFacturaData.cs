using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DetalleFacturaData : IData<TbDetalleFactura>
    {
        private readonly DbProyectoInaContext _dbContext;

        public DetalleFacturaData(DbProyectoInaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> actualizarAsync(TbDetalleFactura entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminarAsync(TbDetalleFactura entidad)
        {
            throw new NotImplementedException();
        }

        public Task<TbDetalleFactura> guardarAsync(TbDetalleFactura entidad)
        {
            throw new NotImplementedException();
        }

        public Task<TbDetalleFactura> obtenerPorIdAsync(TbDetalleFactura entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TbDetalleFactura>> obtenerTodosAsync()
        {
            try
            {
                return await _dbContext.TbDetalleFacturas.Include("IdFacturaNavigation").Where(x => x.Estado == true)
                    .Include("IdProductoNavigation").Where(X => X.Estado == true).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
