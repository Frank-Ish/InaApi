using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TipoVentaData : IData<TbTipoVentum>
    {
        private readonly DbProyectoInaContext _dbContext;

        public TipoVentaData(DbProyectoInaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> actualizarAsync(TbTipoVentum entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminarAsync(TbTipoVentum entidad)
        {
            throw new NotImplementedException();
        }

        public Task<TbTipoVentum> guardarAsync(TbTipoVentum entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<TbTipoVentum> obtenerPorIdAsync(TbTipoVentum entidad)
        {
            try
            {
                return await _dbContext.TbTipoVenta.FindAsync(entidad.IdTipoVenta);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<TbTipoVentum>> obtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
