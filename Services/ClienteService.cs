using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClienteService : IServices<TbCliente>
    {
        private readonly IData<TbCliente> _clienteData;

        public ClienteService(IData<TbCliente> clienteData)
        {
            _clienteData = clienteData;
        }


        public Task<bool> actualizarAsync(TbCliente entidad)
        {
            return _clienteData.actualizarAsync(entidad);
        }

        public Task<bool> eliminarAsync(TbCliente entidad)
        {
            return _clienteData.eliminarAsync(entidad);
        }

        public Task<TbCliente> guardarAsync(TbCliente entidad)
        {
            return _clienteData.guardarAsync(entidad);
        }

        public Task<TbCliente> obtenerPorIdAsync(TbCliente entidad)
        {
            return _clienteData.obtenerPorIdAsync(entidad);
        }

        public async Task<List<TbCliente>> obtenerTodosAsync()
        {
            return await _clienteData.obtenerTodosAsync();
        }

    }
}
