using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CapaPresentacionAdmin.Controllers
{
    public class MantenimientoController : Controller
    {
        // GET: Mantenimiento
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Productos()
        {
            return View();
        }

        public ActionResult Categorias()
        {
            return View();
        }
        public ActionResult Marca()
        {
            return View();
        }
    }
}