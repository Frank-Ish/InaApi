using AutoMapper;
using Entities;
using InaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InaApi.Controllers
{
    [ApiController]
    [Route("api/cliente")]
    public class TipoClienteController : ControllerBase
    {
        private readonly IServices<TbTipoCliente> _ITipoClienteService;
        private readonly IMapper _mapper;

        public TipoClienteController(IServices<TbTipoCliente> iTipoClienteService, IMapper mapper)
        {
            _ITipoClienteService = iTipoClienteService;
            _mapper = mapper;
        }

        /*-------------------------------------------------------------------------------------------*/

        /*Buscar todos los tipos de clientes*/
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<TipoClienteDTO>>> get()
        {
            try
            {
                List<TipoClienteDTO> listaResult = new List<TipoClienteDTO>();
                var lista = await _ITipoClienteService.obtenerTodosAsync();

                foreach (var cliente in lista)
                {
                    var clienteDTO = _mapper.Map<TipoClienteDTO>(cliente);

                    listaResult.Add(clienteDTO);
                }
                if (lista.Count == 0)
                {
                    return NotFound(new { mensaje = "No existe un tipo de cliente con ese ID." });
                }

                return listaResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*-------------------------------------------------------------------------------------------*/

        /*Buscar por id*/
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TipoClienteDTO>> get(int id)
        {
            try
            {
                TbTipoCliente tipoCliente = new TbTipoCliente();
                tipoCliente.Id = id;

                tipoCliente = await _ITipoClienteService.obtenerPorIdAsync(tipoCliente);

                if (tipoCliente == null)
                {
                    return NotFound(new { mensaje = "No existe un tipo de cliente con ese ID." });
                }
                ClienteDTO cliDTO = _mapper.Map<ClienteDTO>(tipoCliente);
                return Ok(cliDTO);

            }
            catch (Exception)
            {
                return BadRequest(new { mensaje = "Error al obtener el tipo de cliente." });
            }
        }

        /*-------------------------------------------------------------------------------------------*/

        /*Buscar por id*/
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoClienteDTO cliDTO)
        {
            try
            {

                TbTipoCliente tipoClienteEnt = new TbTipoCliente();
                tipoClienteEnt.Id = cliDTO.Id;
                tipoClienteEnt = await _ITipoClienteService.obtenerPorIdAsync(tipoClienteEnt);

                if (tipoClienteEnt != null)
                {
                    return NotFound(new { mensaje = "El tipo de cliente no existe." });
                }

                TbTipoCliente tipoCliente = _mapper.Map<TbTipoCliente>(cliDTO);

                tipoCliente = await _ITipoClienteService.guardarAsync(tipoCliente);

                return Ok(new { mensaje = "Cliente guardado." });
            }
            catch (Exception)
            {
                return BadRequest(new { mensaje = "Error al obtener el cliente." });
            }
        }

        /*-------------------------------------------------------------------------------------------*/

        /*Actualizar tipo cliente por id*/
        [HttpPatch("{id}")]
        public async Task<ActionResult> update(int id, [FromBody] TipoClienteDTO cliDTO)
        {
            try
            {
                TbTipoCliente tipoClienteEnt = new TbTipoCliente();

                //tipoClienteEnt.Id = id;

                tipoClienteEnt = await _ITipoClienteService.obtenerPorIdAsync(tipoClienteEnt);


                if (tipoClienteEnt == null)
                {
                    return NotFound(new { mensaje = "El tipo de cliente no existe" });
                }

                //Validar datos de entrada.

                var res = _ITipoClienteService.actualizarAsync(tipoClienteEnt);

                if (res.Result)
                {
                    return Ok(new { mensaje = "El tipo de cliente fue actualizado" });
                }
                else
                {
                    return BadRequest(new { mensaje = "No se pudo modificar." });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        /*-------------------------------------------------------------------------------------------*/

        /*Eliminar una factura*/
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                TbTipoCliente tipoClienteEnt = new TbTipoCliente();

                tipoClienteEnt.Id = id;

                tipoClienteEnt = await _ITipoClienteService.obtenerPorIdAsync(tipoClienteEnt);

                if (tipoClienteEnt == null)
                {
                    return NotFound(new { mensaje = "El cliente no existe" });
                }


                tipoClienteEnt.Estado = false;


                //Validar datos de entrada.

                var res = _ITipoClienteService.eliminarAsync(tipoClienteEnt);

                if (res.Result)
                {
                    return Ok(new { mensaje = "Cliente eliminado." });
                }
                else
                {
                    return BadRequest(new { mensaje = "No se pudo eliminar." });
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
