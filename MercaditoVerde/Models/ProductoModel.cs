using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MercaditoVerde.Models
{
    public class ProductoModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Es necesario que ingrese un nombre para su producto")]
        [Display(Name = "Ingrese el nombre para su producto")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Es necesario que ingrese una imagen para su producto")]
        [Display(Name = "Seleccione una imagen para producto")]
        public HttpPostedFileBase imagen { get; set; }

        [Required(ErrorMessage = "Es necesario que ingrese una categoria para su producto")]
        [Display(Name = "Seleccione una categoria para su producto")]
        public string categoria { get; set; }

        [Required(ErrorMessage = "Es necesario que elija el tipo de unidad para su producto")]
        [Display(Name = "Seleccione el tipo de unidades para su producto")]
        public string tipoUnidad { get; set; }

        [Required(ErrorMessage = "Es necesario que indique el precio por unidad de su producto")]
        [Display(Name = "Ingrese el precio unitario de su producto")]
        public float precio { get; set; }

        [Required(ErrorMessage = "Debe elegir una cantidad de producto a comprar")]
        [Display(Name = "Ingrese la cantidad de unidades que desea comprar")]
        public int cantidad { get; set; }
    }
}