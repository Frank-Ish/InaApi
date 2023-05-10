using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbFactura
{
    public int IdFactura { get; set; }

    public string IdCliente { get; set; } = null!;

    public int TipoVenta { get; set; }

    public int TipoPago { get; set; }

    public DateTime Fecha { get; set; }

    public bool Estado { get; set; }

    public virtual TbCliente IdClienteNavigation { get; set; } = null!;

    public virtual ICollection<TbDetalleFactura> TbDetalleFacturas { get; set; } = new List<TbDetalleFactura>();

    public virtual TbTipoPago TipoPagoNavigation { get; set; } = null!;

    public virtual TbTipoVentum TipoVentaNavigation { get; set; } = null!;
}
