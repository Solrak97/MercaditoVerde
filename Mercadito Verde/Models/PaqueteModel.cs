using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Mercadito_Verde.Models
{
    public class PaqueteModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public List<ProductoModel> listaProductos { get; set; }
        public int cantidad { get; set; }
        public float precioBase { get; set; }
        public float descuento { get; set; }
        public float precioDescuento { get; set; }
    }
}