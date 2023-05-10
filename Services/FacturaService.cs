using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FacturaService : IServices<TbFactura>
    {
        private readonly IData<TbFactura> _facturaData;

        public FacturaService(IData<TbFactura> facturaData)
        {
            _facturaData = facturaData;
        }

        public Task<bool> actualizarAsync(TbFactura entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminarAsync(TbFactura entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<TbFactura> guardarAsync(TbFactura entidad)
        {
            return await _facturaData.guardarAsync(entidad);
        }

        public async Task<TbFactura> obtenerPorIdAsync(TbFactura entidad)
        {
            return await _facturaData.obtenerPorIdAsync(entidad);
        }

        public async Task<List<TbFactura>> obtenerTodosAsync()
        {
            return await _facturaData.obtenerTodosAsync();
        }
    }
}
