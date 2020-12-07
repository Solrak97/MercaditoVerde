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
        public byte[] imagen;

        public PaqueteModel(int id, string nombre, float precio, List<ProductoModel> productos)
        {
            this.precio = precio;
            this.nombre = nombre;
            this.id = id;
            this.productos = productos;

            foreach (ProductoModel producto in productos)
            {
                Debug.WriteLine(producto.precio);
                ahorro = (producto.precio * producto.cantidad) - precio; 
            }
        }

        public PaqueteModel()
        {

        }
    }
}