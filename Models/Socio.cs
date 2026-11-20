using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Socio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del socio es obligatorio")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del socio es obligatorio")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 60 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "El correo del socio es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no es válido")]
        [StringLength(100, ErrorMessage = "El correo no puede superar 100 caracteres")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono del socio es obligatorio")]
        [StringLength(10, ErrorMessage = "El teléfono debe tener 10 dígitos")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "El teléfono debe tener 10 dígitos")]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        // propiedad calculada para mostrar en las listas (no se guarda en la BD)
        [Display(Name = "Socio")]
        public string NombreCompleto => $"{Nombre} {Apellido}";

        //relacion: un socio tiene muchos préstamos
        public ICollection<Prestamo> Prestamos { get; set; }
    }
}
