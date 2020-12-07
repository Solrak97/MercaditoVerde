using System.Web.Mvc;
using MercaditoVerde.Models;
using MercaditoVerde.Handlers;
using System.Collections.Generic;
using System.Diagnostics;

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

            CalcularTotal();
        }

        [HttpPost]
        public void AgregarPaquete(int id, int cantidad)
        {
            GenerarCarrito();

            if ((Session["carrito"] as CarritoModel).paquetes.ContainsKey(id))
            {
                (Session["carrito"] as CarritoModel).paquetes[id].cantidad += cantidad;
            }
            else
            {
                PaqueteHandler accesoPaquete = new PaqueteHandler();
                PaqueteModel paquete = accesoPaquete.Obtener(id);
                paquete.cantidad = cantidad;
                (Session["carrito"] as CarritoModel).paquetes.Add(id, paquete);
            }

            CalcularTotal();

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

        [HttpPost]
        public void EliminarPaquete(int id)
        {
            GenerarCarrito();
            if ((Session["carrito"] as CarritoModel).paquetes.ContainsKey(id))
            {
                PaqueteModel paquetes = (Session["carrito"] as CarritoModel).paquetes[id];
                CalcularTotal();
                (Session["carrito"] as CarritoModel).paquetes.Remove(id);
            }
        }

        public void CalcularTotal()
        {
            (Session["carrito"] as CarritoModel).total = 0;
            foreach (KeyValuePair<int, ProductoModel> productoListado in (Session["carrito"] as CarritoModel).compras)
            {
                (Session["carrito"] as CarritoModel).total += productoListado.Value.precio * productoListado.Value.cantidad;
            }
            foreach (KeyValuePair<int, PaqueteModel> paqueteListado in (Session["carrito"] as CarritoModel).paquetes)
            {
                (Session["carrito"] as CarritoModel).total += paqueteListado.Value.precio * paqueteListado.Value.cantidad;
            }

            CalcularAhorro();

        }

        public void CalcularAhorro() {
            (Session["carrito"] as CarritoModel).descuento = 0;
            foreach (KeyValuePair<int, PaqueteModel> paqueteListado in (Session["carrito"] as CarritoModel).paquetes)
            {
                (Session["carrito"] as CarritoModel).descuento += paqueteListado.Value.ahorro * paqueteListado.Value.cantidad;
            }
        }

        public ActionResult ConfirmarCompra()
        {
            return View();
        }


        public ActionResult ConfirmarCompra()
        {
            return View();
        }
    }
}