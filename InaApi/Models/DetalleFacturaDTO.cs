namespace InaApi.Models
{
    public class DetalleFacturaDTO
    {
        public int IdDetalleFactura { get; set; }

        public int IdFactura { get; set; }

        public int IdProducto { get; set; }

        public int Cantidad { get; set; }

        public double Precio { get; set; }

        public bool Estado { get; set; }
    }
}
