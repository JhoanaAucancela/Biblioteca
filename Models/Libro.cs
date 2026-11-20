using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título del libro es obligatorio")]
        [StringLength(150, MinimumLength = 2, ErrorMessage = "El título debe tener entre 2 y 150 caracteres")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "El año de publicación es obligatorio")]
        [Range(1450, 2100, ErrorMessage = "El año de publicación debe estar entre 1450 y 2100")]
        [Display(Name = "Año de Publicación")]
        public int Anio_Publicacion { get; set; }

        //relacion entre la tabla Autor y Libro
        [Required(ErrorMessage = "El autor del libro es obligatorio")]
        [Display(Name = "Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        //relacion entre la tabla Categoria y Libro
        [Required(ErrorMessage = "La categoría del libro es obligatoria")]
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        //relacion: un libro tiene muchos préstamos
        public ICollection<Prestamo> Prestamos { get; set; }
    }
}
