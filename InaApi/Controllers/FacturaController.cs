using AutoMapper;
using Entities;
using InaApi.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace InaApi.Controllers
{
    [ApiController]
    [Route("api/factura")]
    public class FacturaController : ControllerBase
    {
        private readonly IServices<TbFactura> _facturaService;
        private readonly IServices<TbDetalleFactura> _detalleService;
        private readonly IServices<TbCliente> _IClienteService;
        private readonly IServices<TbTipoVentum> _tipoVentaService;
        private readonly IServices<TbTipoPago> _tipoPagoService;
        private readonly IServices<TbProducto> _productoService;
        private readonly IMapper _mapper;

        public FacturaController(IServices<TbFactura> facturaService, IServices<TbDetalleFactura> detalleService, IServices<TbCliente> iClienteService, IServices<TbTipoVentum> tipoVentaService, IServices<TbTipoPago> tipoPagoService, IServices<TbProducto> productoService, IMapper mapper)
        {
            _facturaService = facturaService;
            _detalleService = detalleService;
            _IClienteService = iClienteService;
            _tipoVentaService = tipoVentaService;
            _tipoPagoService = tipoPagoService;
            _productoService = productoService;
            _mapper = mapper;
        }



        [HttpGet]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<FacturaDTO>>> get()
        {
            try
            {
                List<FacturaDTO> listaResult = new List<FacturaDTO>();
                var listaFacturas = await _facturaService.obtenerTodosAsync();

                List<DetalleFacturaDTO> listaResultDetalle = new List<DetalleFacturaDTO>();
                var listaDetalle = await _detalleService.obtenerTodosAsync();

                foreach (var detalle in listaDetalle)
                {
                    var detalleDTO = _mapper.Map<DetalleFacturaDTO>(detalle);
                    listaResultDetalle.Add(detalleDTO);
                }

                foreach (var factura in listaFacturas)
                {
                    var facturaDTO = _mapper.Map<FacturaDTO>(factura);

                    listaResult.Add(facturaDTO);
                }
                if (listaFacturas.Count == 0)
                {
                    return NotFound(new { mensaje = "No existe una factura con ese ID." });
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
        public async Task<ActionResult<FacturaDTO>> get(int id)
        {
            try
            {
                TbFactura factura = new TbFactura();
                factura.IdFactura = id;

                factura = await _facturaService.obtenerPorIdAsync(factura);

                if (factura == null)
                {
                    return NotFound(new { mensaje = "El numero de factura proporcionado no existe" });
                }
                FacturaDTO facturaDTO = _mapper.Map<FacturaDTO>(factura);
                return Ok(facturaDTO);
            }
            catch (Exception)
            {
                return BadRequest(new { mensaje = "Error al obtener la factura." });
            }
        }

        /*-------------------------------------------------------------------------------------------*/

        /*Crear una nueva factura*/
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] FacturaDTO facturaDTO)
        {
            try
            {
                TbFactura facturaEnt = new TbFactura();

                //TbDetalleFactura detalle = new TbDetalleFactura();
                

                TbCliente cliente = new TbCliente();
                cliente.Cedula = facturaDTO.IdCliente;
                cliente = await _IClienteService.obtenerPorIdAsync(cliente);

                TbTipoVentum venta = new TbTipoVentum();
                venta.IdTipoVenta = facturaDTO.TipoVenta;
                venta = await _tipoVentaService.obtenerPorIdAsync(venta);

                TbTipoPago pago = new TbTipoPago();
                pago.IdTipoPago = facturaDTO.TipoPago;
                pago = await _tipoPagoService.obtenerPorIdAsync(pago);

                
                
;
                if (cliente == null)
                {
                    return NotFound(new { mensaje = "El cliente no existe." });
                }
                if (venta == null)
                {
                    return NotFound(new { mensaje = "El tipo de venta no existe." });
                }
                if (pago == null)
                {
                    return NotFound(new { mensaje = "El tipo de pago no existe." });
                }

     

                foreach (DetalleFacturaDTO detalleDTO in facturaDTO.TbDetalleFacturas)
                {
                    TbProducto producto = new TbProducto();
                    producto.IdProducto = detalleDTO.IdProducto;
                    producto = await _productoService.obtenerPorIdAsync(producto);
                    if (producto.Stock < detalleDTO.Cantidad)
                    {
                        return NotFound(new { mensaje = "La cantidad que desar comprar exede nuestas unidades en stock." });
                    }
                }


                TbFactura factura = _mapper.Map<TbFactura>(facturaDTO);
                factura = await _facturaService.guardarAsync(factura);



                return Ok(new { mensaje = "Cliente guardado." });
            }
            catch (Exception)
            {
                return BadRequest(new { mensaje = "Error al obtener el cliente." });
            }
        }
    }
}
