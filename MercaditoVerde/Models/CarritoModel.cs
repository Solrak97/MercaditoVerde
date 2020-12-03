using System.Collections.Generic;

namespace MercaditoVerde.Models
{
    public class CarritoModel
    {
        public List<ProductoModel> compras;
        public float total;
        
        public CarritoModel()
        {
            compras = new List<ProductoModel>();    
        }
    }
}