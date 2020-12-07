using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MercaditoVerde.Models
{
    public class PaqueteModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string total { get; set; }
        public List<ProductoModel> productos { get; set; }
        public float precio;
        public float ahorro;
        public int cantidad;

        public PaqueteModel(int id, string nombre, float precio, List<ProductoModel> productos)
        {
            this.precio = precio;
            this.nombre = nombre;
            this.id = id;
            this.productos = productos;
            this.cantidad = 0;
        }

        public void autoSetAhorro()
        {
            foreach (ProductoModel producto in productos)
            {
                ahorro += (producto.precio * producto.cantidad);
            }
            ahorro -= precio;
        }
        public PaqueteModel()
        {

        }
    }
}