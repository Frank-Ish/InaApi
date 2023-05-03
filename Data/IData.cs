using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IData<entity>
    {
        Task<List<entity>> obtenerTodosAsync();

        Task<entity> obtenerPorIdAsync(entity entidad);

        Task<entity> guardarAsync(entity entidad);

        Task<bool> actualizarAsync(entity entidad);

        Task<bool> eliminarAsync(entity entidad);
    }
}

