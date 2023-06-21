using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Sucursal
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AgutierrezAgenciaAutosContext context = new DL.AgutierrezAgenciaAutosContext())
                {
                    var query = context.Sucursales.FromSqlRaw($"SucursalGetAll").ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Sucursal sucursal = new ML.Sucursal();
                            sucursal.IdSucursal = item.IdSucursal;
                            sucursal.Nombre = item.Nombre;
                            sucursal.Direccion = item.Direccion;
                            sucursal.NumEmpleados = item.NumEmpleados.ToString();
                            sucursal.NumAutos = item.NumAutos.Value;
                            sucursal.Imagen = item.Imagen;
                            sucursal.IdEmpresa = item.IdEmpresa.Value;
                            sucursal.Empresa = new ML.Empresa();
                            sucursal.Empresa.IdEmpresa = item.IdEmpresa.Value;
                            sucursal.Empresa.Nombre = item.NombreEmpresa;
                            result.Objects.Add(sucursal);
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
        public static ML.Result GetById(int IdSucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AgutierrezAgenciaAutosContext context = new DL.AgutierrezAgenciaAutosContext())
                {
                    var query = context.Sucursales.FromSqlRaw($"SucursalGetById {IdSucursal}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        ML.Sucursal sucursal = new ML.Sucursal();
                        sucursal.IdSucursal = query.IdSucursal;
                        sucursal.Nombre = query.Nombre;
                        sucursal.Direccion = query.Direccion;
                        sucursal.NumEmpleados = query.NumEmpleados.ToString();
                        sucursal.NumAutos = query.NumAutos.Value;
                        sucursal.Imagen = query.Imagen;
                        sucursal.IdEmpresa = query.IdEmpresa.Value;

                        sucursal.Empresa = new ML.Empresa();
                        sucursal.Empresa.IdEmpresa = query.IdEmpresa.Value;
                        sucursal.Empresa.Nombre = query.NombreEmpresa;
                        result.Object = sucursal;
                        result.Correct = true;
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
        public static ML.Result Add(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AgutierrezAgenciaAutosContext context = new DL.AgutierrezAgenciaAutosContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"SucursalAdd '{sucursal.Nombre}','{sucursal.Direccion}',{sucursal.NumEmpleados}, {sucursal.NumAutos}, '{sucursal.Imagen}', {sucursal.Empresa.IdEmpresa}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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
        public static ML.Result Update(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AgutierrezAgenciaAutosContext context = new DL.AgutierrezAgenciaAutosContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"SucursalUpdate {sucursal.IdSucursal},'{sucursal.Nombre}','{sucursal.Direccion}',{sucursal.NumEmpleados}, {sucursal.NumAutos}, '{sucursal.Imagen}', {sucursal.Empresa.IdEmpresa}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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
        public static ML.Result Delete(int IdSucursal)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.AgutierrezAgenciaAutosContext context = new DL.AgutierrezAgenciaAutosContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"SucursalDelete {IdSucursal}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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