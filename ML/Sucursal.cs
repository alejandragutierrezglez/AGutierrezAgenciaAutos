using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Sucursal
    {
        public int? IdSucursal { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string NumEmpleados { get; set; }
        public int NumAutos { get; set; }
        public string Imagen { get; set; }
        public int IdEmpresa { get; set; }
        public ML.Empresa Empresa { get; set; }
        public List<object> Sucursales  { get; set; }
    }
}
