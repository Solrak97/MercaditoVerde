using System.Diagnostics;
using System.Web.Mvc;
using MercaditoVerde.Models;
using MercaditoVerde.Handlers;

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

            ProductoHandler accesoProducto = new ProductoHandler();
            ProductoModel producto = accesoProducto.Obtener(id);
            (Session["carrito"] as CarritoModel).compras.Add(producto);
            (Session["carrito"] as CarritoModel).total = 0;
            foreach (ProductoModel productoListado in (Session["carrito"] as CarritoModel).compras)
            {
                (Session["carrito"] as CarritoModel).total += productoListado.precio;
            }
        }

        public ActionResult VerCarrito()
        {
            GenerarCarrito();
            ViewBag.carrito = Session["Carrito"];
            return View();
        }
    }
}