namespace InaApi.Models
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; } = null!;

        public double PrecioVenta { get; set; }

        public int Stock { get; set; }

        public List<DetalleFacturaDTO>? TbDetalleFacturas { get; set; }
    }
}
