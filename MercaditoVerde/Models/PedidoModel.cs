namespace MercaditoVerde.Models
{
    public class PedidoModel
    {
        public int pedido { get; set; }
        public DatosConfirmacionModel datos { get; set; }
        public CarritoModel carrito { get; set; }

        public PedidoModel(DatosConfirmacionModel datos, CarritoModel carrito)
        {
            this.datos = datos;
            this.carrito = carrito;
        }

        public PedidoModel()
        {

        }
    }
}