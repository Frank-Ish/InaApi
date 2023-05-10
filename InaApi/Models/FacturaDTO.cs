namespace InaApi.Models
{
    public class FacturaDTO
    {
        public int IdFactura { get; set; }

        public string? IdCliente { get; set; }

        public int TipoVenta { get; set; }

        public int TipoPago { get; set; }

        public DateTime Fecha { get; set; }

        public bool Estado { get; set; }

        public List<DetalleFacturaDTO>? TbDetalleFacturas { get; set; }
    }
}
