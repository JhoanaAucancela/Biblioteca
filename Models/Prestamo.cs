using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models
{
    public class Prestamo : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha del préstamo es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Préstamo")]
        public DateTime Fecha_Prestamo { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "La fecha de devolución es obligatoria")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Devolución")]
        public DateTime Fecha_Devolucion { get; set; } = DateTime.Today.AddDays(15);

        //relacion entre la tabla Libro y Prestamo
        [Required(ErrorMessage = "El libro es obligatorio")]
        [Display(Name = "Libro")]
        public int LibroId { get; set; }
        public Libro Libro { get; set; }

        //relacion entre la tabla Socio y Prestamo
        [Required(ErrorMessage = "El socio es obligatorio")]
        [Display(Name = "Socio")]
        public int SocioId { get; set; }
        public Socio Socio { get; set; }

        // validación entre dos campos: la devolución debe ser posterior al préstamo
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Fecha_Devolucion <= Fecha_Prestamo)
            {
                yield return new ValidationResult(
                    "La fecha de devolución debe ser posterior a la fecha del préstamo",
                    new[] { nameof(Fecha_Devolucion) });
            }
        }
    }
}
