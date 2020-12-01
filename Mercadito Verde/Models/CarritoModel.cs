using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Mercadito_Verde.Models
{
    public class CarritoModel
    {
        public List<ProductoModel> listaCompras { get; set; }
        public List<PaqueteModel> listaDescuentos { get; set; }
        public float precioTotal { get; set; }
        public float precioDescuento { get; set; }
        public float montoahorrado { get; set; }
    }
}