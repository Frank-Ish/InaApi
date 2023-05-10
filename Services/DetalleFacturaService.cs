using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DetalleFacturaService : IServices<TbDetalleFactura>
    {
        private readonly IData<TbDetalleFactura> _detalleData;

        public DetalleFacturaService(IData<TbDetalleFactura> detalleData)
        {
            _detalleData = detalleData;
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
            return await _detalleData.obtenerTodosAsync();
        }
    }
}
