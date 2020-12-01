namespace Mercadito_Verde.Models
{
    public class ProductoModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string tipoUnidad { get; set; }
        public float precio { get; set; }
        public int cantidad { get; set; }
    }
}