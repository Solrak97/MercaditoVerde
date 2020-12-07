using MercaditoVerde.Handlers;
using System.Web.Mvc;

namespace MercaditoVerde.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult subNavbar()
        {
            ProductoHandler accesoProducto = new ProductoHandler();
            ViewBag.categorias = accesoProducto.TraerCategorias(); 
            return View();
        }
    }
}