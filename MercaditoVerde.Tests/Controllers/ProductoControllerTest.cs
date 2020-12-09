using MercaditoVerde.Controllers;
using MercaditoVerde.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

public interface DBContext
{
    List<ProductoModel> ObtenerTodos();
}

public class ProductosControllerUsandoMoq : Controller
{
    public ActionResult VerProductos(DBContext dbContext)
    {
        DBContext AccesoProductos = dbContext;
        List<ProductoModel> productos = AccesoProductos.ObtenerTodos();

        ViewBag.productos = productos;

        return View();
    }
}


namespace MercaditoVerde.Tests.Controllers
{
    [TestClass]
    public class ProductoControllerMock
    {
        [TestMethod]
        public void VerProductos()
        {
            //Arrange
            Mock<DBContext> mockDBContext = new Mock<DBContext>();
            mockDBContext.Setup(t => t.ObtenerTodos()).Returns(new List<ProductoModel>());
            ProductosControllerUsandoMoq producto = new ProductosControllerUsandoMoq();

            //Act
            ActionResult vista = producto.VerProductos(mockDBContext.Object);

            //Result
            Assert.IsNotNull(vista);
        }
    }
}
