using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class TipoPagoData : IData<TbTipoPago>
    {
        private readonly DbProyectoInaContext _dbContext;

        public TipoPagoData(DbProyectoInaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<bool> actualizarAsync(TbTipoPago entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminarAsync(TbTipoPago entidad)
        {
            throw new NotImplementedException();
        }

        public Task<TbTipoPago> guardarAsync(TbTipoPago entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<TbTipoPago> obtenerPorIdAsync(TbTipoPago entidad)
        {
            try
            {
                return await _dbContext.TbTipoPagos.FindAsync(entidad.IdTipoPago);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<TbTipoPago>> obtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
