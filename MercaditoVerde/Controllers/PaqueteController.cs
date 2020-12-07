using MercaditoVerde.Handlers;
using MercaditoVerde.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace MercaditoVerde.Controllers
{
    public class PaqueteController : Controller
    {
        public ActionResult VerPaquetes()
        {
            PaqueteHandler paqueteAccess = new PaqueteHandler();
            List<PaqueteModel> paquetes = paqueteAccess.ObtenerTodos();
            ViewBag.paquetes = paquetes;
            return View();
        }
    }
}