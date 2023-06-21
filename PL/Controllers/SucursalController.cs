using Microsoft.AspNetCore.Mvc;

namespace PL.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult GetAll()
        {
            ML.Sucursal sucursal = new ML.Sucursal();
            sucursal.Empresa = new ML.Empresa();


            ML.Result result = BL.Sucursal.GetAll();
            if (result.Correct)
            {
                sucursal.Sucursales = result.Objects;
                return View(sucursal);
            }
            else
            {
                return View(sucursal);
            }
        }

        [HttpGet]
        public ActionResult Form(int? IdSucursal)

        {

            ML.Result resultSucursales = BL.Sucursal.GetAll();
            ML.Result resultEmpresas = BL.Empresa.GetAll();

            ML.Sucursal sucursal = new ML.Sucursal();
            sucursal.Empresa = new ML.Empresa();



            if (resultSucursales.Correct)
            {

                sucursal.Sucursales = resultSucursales.Objects;
                sucursal.Empresa.Empresas = resultEmpresas.Objects;
            }
            if (IdSucursal == null)
            {
                return View(sucursal);
            }
            else
            {

                ML.Result result = BL.Sucursal.GetById(IdSucursal.Value);


                if (result.Correct)
                {

                    sucursal = (ML.Sucursal)result.Object;
                    sucursal.Sucursales = resultSucursales.Objects;
                    sucursal.Empresa.Empresas = resultEmpresas.Objects;

                    return View(sucursal);
                }
                else
                {
                    return RedirectToAction("GetAll", "Sucursal");
                }
            }
        }
        [HttpPost]
        public ActionResult Form(ML.Sucursal sucursal)
        {
            ML.Result result = new ML.Result();
            ML.Result resultEmpresas = BL.Empresa.GetAll();
           

            if (sucursal.IdSucursal != null)
            {

                result = BL.Sucursal.Update(sucursal);
                sucursal.Empresa.Empresas = resultEmpresas.Objects;

            }
            else
            {
                result = BL.Sucursal.Add(sucursal);
                sucursal.Empresa.Empresas = resultEmpresas.Objects;


            }
            if (result.Correct)
            {
                return RedirectToAction("GetAll", "Sucursal");
            }
            else
            {
                return RedirectToAction("GetAll", "Sucursal");
            }
        }
        public IActionResult Delete(int IdSucursal)
        {
            ML.Sucursal sucursal = new ML.Sucursal();
            ML.Result result = BL.Sucursal.Delete(IdSucursal);
            if (result.Correct)
            {
                return RedirectToAction("GetAll", "Sucursal");
            }
            else
            {
                return RedirectToAction("GetAll", "Sucursal");
            }
        }


    }
}
