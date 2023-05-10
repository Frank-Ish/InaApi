using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TipoPagoService : IServices<TbTipoPago>
    {
        private readonly IData<TbTipoPago> _tipoPagoData;

        public TipoPagoService(IData<TbTipoPago> tipoPagoData)
        {
            _tipoPagoData = tipoPagoData;
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
            return await _tipoPagoData.obtenerPorIdAsync(entidad);
        }

        public Task<List<TbTipoPago>> obtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
