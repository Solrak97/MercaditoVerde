using System.Collections.Generic;

namespace MercaditoVerde.Models
{
    public class CarritoModel
    {
        public Dictionary<int, ProductoModel> compras;
        public float total;
        
        public CarritoModel()
        {
            compras = new Dictionary<int, ProductoModel>();    
        }
    }
}