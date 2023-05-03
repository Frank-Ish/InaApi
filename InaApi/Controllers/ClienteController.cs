using AutoMapper;
using Entities;
using InaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InaApi.Controllers
{


    [ApiController]
    [Route("api/cliente")]
    public class ClienteController : ControllerBase
    {
        private readonly IServices<TbCliente> _IClienteService;
        private readonly IServices<TbTipoCliente> _ITipoClienteService;
        private readonly IMapper _mapper;

        //Costructor
        public ClienteController(IServices<TbCliente> iClienteService, IMapper mapper, IServices<TbTipoCliente> iTipoClienteService)
        {
            _IClienteService = iClienteService;
            _mapper = mapper;
            _ITipoClienteService = iTipoClienteService;
        }

        /*----------------------------------------------------------------------------*/

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ClienteDTO>>> get()
        {
            try
            {
                List<ClienteDTO> listaResult = new List<ClienteDTO>();
                var lista = await _IClienteService.obtenerTodosAsync();

                foreach (var cliente in lista)
                {
                    var clienteDTO = _mapper.Map<ClienteDTO>(cliente);

                    listaResult.Add(clienteDTO);
                }
                if(lista.Count == 0)
                {
                    return NotFound(new { mensaje = "No existe el cliente con ese ID." });
                }

                return listaResult;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /*---------------------------------------------------------------------------*/

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ClienteDTO>> get(string id)
        {
            try
            {
                TbCliente cliente = new TbCliente();
                cliente.Cedula = id;

                cliente = await _IClienteService.obtenerPorIdAsync(cliente);

                if (cliente == null)
                {
                    return NotFound(new { mensaje = "No existe el cliente con ese ID." });
                }
                ClienteDTO cliDTO = _mapper.Map<ClienteDTO>(cliente);
                return Ok(cliDTO);

            }
            catch (Exception)
            {
                return BadRequest(new { mensaje = "Error al obtener el cliente." });
            }
        }

        /*-----------------------------------------------------------------------*/

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteDTO cliDTO)
        {
            try
            {
                TbCliente clienteEnt = new TbCliente();
                clienteEnt.Cedula = cliDTO.Cedula;

                clienteEnt = await _IClienteService.obtenerPorIdAsync(clienteEnt);

                if (clienteEnt != null)
                {
                    return NotFound(new { mensaje = "El cliente ya existe en la base de datos." });
                }

                TbTipoCliente tipoCliente = new TbTipoCliente();
                tipoCliente.Id = cliDTO.TipoCliente;
                tipoCliente = await _ITipoClienteService.obtenerPorIdAsync(tipoCliente);

                if (tipoCliente != null)
                {
                    return NotFound(new { mensaje = "El tipo de cliente no existe." });
                }

                TbCliente cliente =  _mapper.Map<TbCliente>(cliDTO);

                cliente = await _IClienteService.guardarAsync(cliente);

                return Ok(new {mensaje="Cliente guardado."});
            }
            catch (Exception)
            {
                return BadRequest(new { mensaje = "Error al obtener el cliente." });
            }
        }

  
        /*----------------------------------------------------------------------------------------*/

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(string id)
        {
            try
            {
                TbCliente clienteEnt = new TbCliente();

                clienteEnt.Cedula = id;

                clienteEnt = await _IClienteService.obtenerPorIdAsync(clienteEnt);

                if (clienteEnt == null)
                {
                    return NotFound(new { mensaje = "El cliente no existe" });
                }

               
                clienteEnt.Estado = false;
                

                //Validar datos de entrada.

                var res = _IClienteService.eliminarAsync(clienteEnt);

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

            /*----------------------------------------------------------------------------*/

        [HttpPatch("{id}")]
        public async Task<ActionResult> update(string id, [FromBody] ClienteDTO cliDTO)
        {
            try
            {
                TbCliente clienteEnt = new TbCliente();
                    
                clienteEnt.Cedula = id;

                clienteEnt = await _IClienteService.obtenerPorIdAsync(clienteEnt);

                if (clienteEnt == null)
                {
                    return NotFound(new { mensaje = "El cliente no existe" });
                }

                TbTipoCliente tipoCliente = new TbTipoCliente();
                tipoCliente.Id = cliDTO.TipoCliente;

                tipoCliente = await _ITipoClienteService.obtenerPorIdAsync(tipoCliente);

                if (tipoCliente == null)
                {
                return NotFound(new { mensaje = "El tipo de cliente no existe" });
                }

                clienteEnt = _mapper.Map<TbCliente>(cliDTO);
                clienteEnt.Cedula = id;
                clienteEnt.CedulaNavigation.Cedula = id;

                //Validar datos de entrada.

                var res = _IClienteService.actualizarAsync(clienteEnt);

                if (res.Result)
                {
                return Ok(new { mensaje = "Cliene actualizado" });
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
        }
    }

