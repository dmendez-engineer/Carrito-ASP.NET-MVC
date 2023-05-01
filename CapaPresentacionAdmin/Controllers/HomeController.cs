using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocios;
namespace CapaPresentacionAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Usuarios()
        {
            return View();
        }
        [HttpGet]
        public JsonResult ListarUsuario()
        {
            List<Usuario> listaUsuario = new List<Usuario>();

            listaUsuario = new CN_Usuarios().Listar();
            // return Json(listaUsuario,JsonRequestBehavior.AllowGet);
            return Json(new { data = listaUsuario }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuario(Usuario obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.IdUsuario == 0)
            {
                resultado = new CN_Usuarios().InsertUsuario(obj, out mensaje);
            }
            else
            {
                 resultado = new CN_Usuarios().EditarUsuario(obj, out mensaje);
            }

            return Json(new { resultado = resultado,mensaje=mensaje }, JsonRequestBehavior.AllowGet);
        }
        public int EliminarUsuario(int id)
        {
            object resultado;
            string mensaje = string.Empty;
            resultado = new CN_Usuarios().EliminarUsuario(id, out mensaje);
            return 0;
        }
        public ActionResult PaginaTest()
        {
            ViewBag.Message = "Pagina de pruebas";
            return View();
        }
    }
}