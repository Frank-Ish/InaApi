using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class TipoClienteService : IServices<TbTipoCliente>
    {
        private readonly IData<TbTipoCliente> _tipoClienteData;

        public TipoClienteService(IData<TbTipoCliente> tipoClienteData)
        {
            _tipoClienteData = tipoClienteData;
        }

        public async Task<bool> actualizarAsync(TbTipoCliente entidad)
        {
            return await _tipoClienteData.actualizarAsync(entidad);
        }

        public async Task<bool> eliminarAsync(TbTipoCliente entidad)
        {
            return await _tipoClienteData.eliminarAsync(entidad);
        }

        public async Task<TbTipoCliente> guardarAsync(TbTipoCliente entidad)
        {
            return await _tipoClienteData.guardarAsync(entidad);
        }

        public async Task<TbTipoCliente> obtenerPorIdAsync(TbTipoCliente entidad)
        {
            return await _tipoClienteData.obtenerPorIdAsync(entidad);
        }

        public async Task<List<TbTipoCliente>> obtenerTodosAsync()
        {
            return await _tipoClienteData.obtenerTodosAsync();
        }
    }
}
