using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbProducto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public double PrecioVenta { get; set; }

    public int Stock { get; set; }

    public virtual ICollection<TbDetalleFactura> TbDetalleFacturas { get; set; } = new List<TbDetalleFactura>();
}
