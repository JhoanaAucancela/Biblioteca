using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre debe tener entre 3 y 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(200, ErrorMessage = "La descripción no puede superar 200 caracteres")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El estante es obligatorio")]
        [StringLength(10, ErrorMessage = "El estante no puede superar 10 caracteres")]
        [Display(Name = "Estante")]
        public string Estante { get; set; }

        [Display(Name = "¿Activa?")]
        public bool Activa { get; set; } = true;

        //relacion: una categoría tiene muchos libros
        public ICollection<Libro> Libros { get; set; }
    }
}
