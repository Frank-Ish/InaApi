using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TipoVentaService : IServices<TbTipoVentum>
    {
        private readonly IData<TbTipoVentum> _tipoVentaData;

        public TipoVentaService(IData<TbTipoVentum> tipoVentaData)
        {
            _tipoVentaData = tipoVentaData;
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
            return await _tipoVentaData.obtenerPorIdAsync(entidad);
        }

        public Task<List<TbTipoVentum>> obtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
