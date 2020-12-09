using System.Collections.Generic;

namespace MercaditoVerde.Models
{
    public class CarritoModel
    {
        public Dictionary<int, ProductoModel> compras;
        public Dictionary<int, PaqueteModel> paquetes;

        public float descuento;
        public float total;
        
        public CarritoModel()
        {
            compras = new Dictionary<int, ProductoModel>();
            paquetes = new Dictionary<int, PaqueteModel>();
        }
    }
}