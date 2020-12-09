using Microsoft.VisualStudio.TestTools.UnitTesting;
using MercaditoVerde.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using MercaditoVerde.Models;

namespace MercaditoVerde.Tests.Controllers
{

    [TestClass]
    public class CarritoControllerMock
    {

        public float CalcularTotal(CarritoModel carrito)
        {

            carrito.total = 0;
            foreach (KeyValuePair<int, ProductoModel> productoListado in carrito.compras)
            {
                carrito.total += productoListado.Value.precio * productoListado.Value.cantidad;
            }
            foreach (KeyValuePair<int, PaqueteModel> paqueteListado in carrito.paquetes)
            {
                carrito.total += paqueteListado.Value.precio * paqueteListado.Value.cantidad;
            }
            return carrito.total;
        }

        [TestMethod]
        public void CalcularTotal()
        {
            //Arrange
            CarritoModel carrito = new CarritoModel();
            for(int i = 0; i < 10; i++)
            {
                ProductoModel producto = new ProductoModel();
                producto.cantidad = 1;
                producto.precio = 100;
                carrito.compras.Add(i, producto);
            }

            //Act
            float total = CalcularTotal(carrito);

            //Result
            Assert.AreEqual(total, 1000);
        }
    }
}
