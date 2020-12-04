using System.Diagnostics;
using System.Web.Mvc;
using MercaditoVerde.Models;
using MercaditoVerde.Handlers;
using System.Collections.Generic;

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

            if ((Session["carrito"] as CarritoModel).compras.ContainsKey(id))
            {
                (Session["carrito"] as CarritoModel).compras[id].cantidad += cantidad;
            }
            else
            {
                ProductoHandler accesoProducto = new ProductoHandler();
                ProductoModel producto = accesoProducto.Obtener(id);
                producto.cantidad = cantidad;
                (Session["carrito"] as CarritoModel).compras.Add(id, producto);
            }

            (Session["carrito"] as CarritoModel).total = 0;
            foreach (KeyValuePair<int, ProductoModel> productoListado in (Session["carrito"] as CarritoModel).compras)
            {
                if(productoListado.Value.cantidad == 0)
                {
                    (Session["carrito"] as CarritoModel).compras.Remove(id);
                }
                else
                {
                    (Session["carrito"] as CarritoModel).total += productoListado.Value.precio * productoListado.Value.cantidad;
                }
            }
        }

        public ActionResult VerCarrito()
        {
            GenerarCarrito();
            ViewBag.carrito = Session["Carrito"];
            return View();
        }

        [HttpPost]
        public void EliminarProducto(int id)
        {
            GenerarCarrito();
            if ((Session["carrito"] as CarritoModel).compras.ContainsKey(id))
            {
                ProductoModel producto = (Session["carrito"] as CarritoModel).compras[id];
                (Session["carrito"] as CarritoModel).total -= producto.precio * producto.cantidad;
                (Session["carrito"] as CarritoModel).compras.Remove(id);

            }
        }
    }
}