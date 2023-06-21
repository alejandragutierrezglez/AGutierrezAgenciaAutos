using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empresa
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AgutierrezAgenciaAutosContext context = new DL.AgutierrezAgenciaAutosContext())
                {
                    var query = context.Empresas.FromSqlRaw($"EmpresaGetAll").ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();
                            empresa.IdEmpresa = item.IdEmpresa;
                            empresa.Nombre = item.Nombre;
                            empresa.Logo = item.Logo;
                            result.Objects.Add(empresa);
                            result.Correct = true;
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
                result.Ex = Ex;
            }
            return result;

        }
    }
}
