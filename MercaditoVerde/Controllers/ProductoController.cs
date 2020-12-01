using System.Web.Mvc;
using MercaditoVerde.Models;
using MercaditoVerde.Handlers;
using System.Collections.Generic;
using System;

namespace MercaditoVerde.Controllers
{
    public class ProductoController : Controller
    {
        public ActionResult CrearProducto()
        {
            ProductoHandler accesoProductos = new ProductoHandler();
            ViewBag.categorias = accesoProductos.TraerCategorias();
            ViewBag.unidades = accesoProductos.TraerUnidades();
            return View();
        }

        [HttpPost]
        public ActionResult CrearProducto(ProductoModel nuevo)
        {
            ProductoHandler AccesoProducto = new ProductoHandler();
            AccesoProducto.Crear(nuevo);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult VerProductos()
        {
            ProductoHandler AccesoProductos = new ProductoHandler();
            List<ProductoModel> productos = AccesoProductos.ObtenerTodos();
            
            ViewBag.productos = productos;

            return View();
        }
    }
}