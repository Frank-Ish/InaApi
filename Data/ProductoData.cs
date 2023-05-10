using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ProductoData : IData<TbProducto>
    {
        private readonly DbProyectoInaContext _dbContext;
        public ProductoData(DbProyectoInaContext dbContext)
        {
            _dbContext = dbContext;
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
            try
            {
                return await _dbContext.TbProductos.FindAsync(entidad.IdProducto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<TbProducto>> obtenerTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
