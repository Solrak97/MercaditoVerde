using MercaditoVerde.Models;
using System.Collections.Generic;

namespace MercaditoVerde.Handlers
{
    public class ProductoHandler : Handler<ProductoModel>
    {
        public override void Crear(ProductoModel nuevo)
        {

        }

        public override ProductoModel Obtener(int id)
        {
            return new ProductoModel();
        }

        public override List<ProductoModel> ObtenerTodos()
        {
            return new List<ProductoModel>();
        }

        public override void Modificar(int id, ProductoModel Nuevo)
        {

        }

        public override void Borrar(int id)
        {

        }
    }
}