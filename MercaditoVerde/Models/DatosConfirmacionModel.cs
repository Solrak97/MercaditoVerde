using System.ComponentModel.DataAnnotations;

namespace MercaditoVerde.Models
{
    public class DatosConfirmacionModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Es necesario que ingrese su nombre")]
        [Display(Name = "Ingrese su nombre")]
        public string nombre { get; set; }

        [Required(ErrorMessage = "Es necesario que ingrese una direccion")]
        [Display(Name = "Escriba su direccion")]
        public string direccion { get; set; }

        [Required(ErrorMessage = "Es necesario que ingrese un numero de telefono")]
        [Display(Name = "Ingrese su numero de telefono")]
        public string telefono { get; set; }
    }
}