using System;
using System.Collections.Generic;

namespace Entities;

public partial class TbUsuario
{
    public string Cedula { get; set; } = null!;

    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime? FechaIngreso { get; set; }

    public string Contrasena { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual TbRole IdRolNavigation { get; set; } = null!;
}
