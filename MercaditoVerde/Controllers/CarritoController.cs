using System.Diagnostics;
using System.Web.Mvc;
using MercaditoVerde.Models;

namespace MercaditoVerde.Controllers
{
    public class CarritoController : Controller
    {
        private void GenerarCarrito()
        {
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new CarritoModel();
            }
        }

        [HttpPost]
        public void AgregarProducto(int id, int cantidad)
        {
            Debug.WriteLine("id: " + id + " cantidad: " + cantidad);
            GenerarCarrito();



        }

        public ActionResult VerCarrito()
        {
            GenerarCarrito();
            ViewBag.carrito = Session["Carrito"];
            return View();
        }
    }
}