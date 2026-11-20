using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del autor es obligatorio")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 60 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido del autor es obligatorio")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 60 caracteres")]
        public string Apellido { get; set; }

        [Required(ErrorMessage = "La nacionalidad del autor es obligatoria")]
        [StringLength(40, ErrorMessage = "La nacionalidad no puede superar 40 caracteres")]
        public string Nacionalidad { get; set; }

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime Fecha_Nacimiento { get; set; }

        // propiedad calculada para mostrar en las listas (no se guarda en la BD)
        [Display(Name = "Autor")]
        public string NombreCompleto => $"{Nombre} {Apellido}";

        //relacion: un autor tiene muchos libros
        public ICollection<Libro> Libros { get; set; }
    }
}
