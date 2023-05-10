namespace InaApi.Models
{
    public class TipoPagoDTO
    {
        public int IdTipoPago { get; set; }

        public string Nombre { get; set; } = null!;

        public bool Estado { get; set; }
    }
}
