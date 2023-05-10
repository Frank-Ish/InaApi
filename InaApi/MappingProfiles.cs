using AutoMapper;
using Entities;
using InaApi.Models;
using System.Linq;

namespace InaApi
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            //En el constructor vamos a definir todos los mapeos.

            CreateMap<TbCliente, ClienteDTO>().ForMember(d => d.Nombre, m => m.MapFrom(s => s.CedulaNavigation.Nombre))
                .ForMember(d => d.Apellido1, m => m.MapFrom(s => s.CedulaNavigation.Apellido1))
                .ForMember(d => d.Apellido2, m => m.MapFrom(s => s.CedulaNavigation.Apellido2))
                .ForMember(d => d.FechaNac, m => m.MapFrom(s => s.CedulaNavigation.FechaNac))
                .ForMember(d => d.Genero, m => m.MapFrom(s => s.CedulaNavigation.Genero))
                .ForMember(d => d.Cedula, m => m.MapFrom(s => s.CedulaNavigation.Cedula)).ReverseMap();

            CreateMap<TbFactura, FacturaDTO>().ForPath(d => d.IdCliente, m => m.MapFrom(s => s.IdCliente))
                .ForPath(d => d.TipoVenta, m => m.MapFrom(s => s.TipoVenta))
                .ForMember(d => d.TipoPago, m => m.MapFrom(s => s.TipoPago))
                .ForPath(d => d.Fecha, m => m.MapFrom(s => s.Fecha))
                .ForPath(d => d.Estado, m => m.MapFrom(s => s.Estado))
                .ForPath(d => d.TbDetalleFacturas, m => m.MapFrom(s => s.TbDetalleFacturas)).ReverseMap();

            CreateMap<TbDetalleFactura, DetalleFacturaDTO>().ForMember(d => d.IdFactura, m => m.MapFrom(s => s.IdFacturaNavigation.IdFactura))
                .ForMember(d => d.IdProducto, m => m.MapFrom(s => s.IdProductoNavigation.IdProducto))
                .ForPath(d => d.Cantidad, m => m.MapFrom(s => s.Cantidad))
                .ForPath(d => d.Precio, m => m.MapFrom(s => s.Precio))
                .ForPath(d => d.Estado, m => m.MapFrom(s => s.Estado)).ReverseMap();

            CreateMap<TbTipoVentum, TipoVentaDTO>().ForPath(d => d.IdTipoVenta, m => m.MapFrom(s => s.IdTipoVenta))
              .ForPath(d => d.Nombre, m => m.MapFrom(s => s.Nombre))
              .ForPath(d => d.Estado, m => m.MapFrom(s => s.Estado)).ReverseMap();

            CreateMap<TbTipoPago, TipoPagoDTO>().ForPath(d => d.IdTipoPago, m => m.MapFrom(s => s.IdTipoPago))
              .ForPath(d => d.Nombre, m => m.MapFrom(s => s.Nombre))
              .ForPath(d => d.Estado, m => m.MapFrom(s => s.Estado)).ReverseMap();

            CreateMap<TbProducto, ProductoDTO>().ForPath(d => d.IdProducto, m => m.MapFrom(s => s.IdProducto))
             .ForPath(d => d.Nombre, m => m.MapFrom(s => s.Nombre))
             .ForMember(d => d.PrecioVenta, m => m.MapFrom(s => s.PrecioVenta))
             .ForPath(d => d.Stock, m => m.MapFrom(s => s.Stock)).ReverseMap();
             //.ForPath(d => d.TbDetalleFacturas, m => m.MapFrom(s => s.TbDetalleFacturas))

            //CreateMap<TbDetalleFactura, DetalleFacturaDTO>().for

            /*CreateMap<ClienteDTO, TbCliente>();
            CreateMap<List<TbCliente>, List<ClienteDTO>>();
            CreateMap <List<ClienteDTO>, List<TbCliente>>();*/

        }
    }
}
