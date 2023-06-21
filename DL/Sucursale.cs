using System;
using System.Collections.Generic;

namespace DL;

public partial class Sucursale
{
    public int IdSucursal { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public int? NumEmpleados { get; set; }

    public int? NumAutos { get; set; }

    public string? Imagen { get; set; }

    public int? IdEmpresa { get; set; }
    public string NombreEmpresa { get; set; }


    public virtual Empresa? IdEmpresaNavigation { get; set; }
}
