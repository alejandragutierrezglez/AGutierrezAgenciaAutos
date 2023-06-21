using System;
using System.Collections.Generic;

namespace PL;

public partial class Empresa
{
    public int IdEmpresa { get; set; }

    public string? Nombre { get; set; }

    public string? Logo { get; set; }

    public virtual ICollection<Sucursale> Sucursales { get; set; } = new List<Sucursale>();
}
