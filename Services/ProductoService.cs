using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductoService : IServices<TbProducto>
    {
        private readonly IData<TbProducto> _productoData;

        public ProductoService(IData<TbProducto> productoData)
        {
            _productoData = productoData;
        }

        public Task<bool> actualizarAsync(TbProducto entidad)
        {
            throw new NotImplementedException();
        }

        public Task<bool> eliminarAsync(TbProducto entidad)
        {
            throw new NotImplementedException();
        }

        public Task<TbProducto> guardarAsync(TbProducto entidad)
        {
            throw new NotImplementedException();
        }

        public async Task<TbProducto> obtenerPorIdAsync(TbProducto entidad)
        {
            return await _productoData.obtenerPorIdAsync(entidad);
        }

        public Task<List<TbProducto>> obtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
