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
        private readonly IMapper _mapper;

        //Costructor
        public ClienteController(IServices<TbCliente> iClienteService, IMapper mapper)
        {
            _IClienteService = iClienteService;
            _mapper = mapper;
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
                TbCliente cliente =  _mapper.Map<TbCliente>(cliDTO);

                cliente = await _IClienteService.guardarAsync(cliente);

                return Ok(new {mensaje="Cliente guardado."});
            }
            catch (Exception)
            {
                return BadRequest(new { mensaje = "Error al obtener el cliente." });
            }
        }

        /*-----------------------------------------------------------------------------------------*/

        [HttpPut("{id}")]
        public async Task<ActionResult> Put([FromBody] ClienteDTO cliDTO)
        {
            try
            {
                TbCliente cliente = _mapper.Map<TbCliente>(cliDTO);
                //cliente.Cedula = id;

                cliente = await _IClienteService.actualizarAsync(cliente);
                return Ok(new { mensaje = "Cliente actualizado." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /*----------------------------------------------------------------------------------------*/

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            try
            {
                TbCliente cliente = new TbCliente();
                cliente.Cedula = id;
                cliente = await _IClienteService.obtenerPorIdAsync(cliente);

                if (cliente == null)
                {
                    return false;
                    //return NotFound(new { mensaje = "No existe el cliente con ese ID." });
                }
                cliente = await _IClienteService.eliminarAsync(cliente);
                return true;
                //return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
                //return BadRequest(ex.Message);
            }
        }
    }
}
