using System.ComponentModel.DataAnnotations;

namespace AppBlazor.Entities
{
    public class LibroFormCLS
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El numero de empleado es obligatorio")]
        public int Num_Empl { get; set; }


        [Required (ErrorMessage = "El nombre es obligatorio")]
        [MaxLength (100, ErrorMessage = "La longitud maxima es 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(18, 100,ErrorMessage = "Mayor a 18 o menor a 100")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; } = null!;


        [Required]
        [CustomValidation(typeof(LibroFormCLS), nameof(ValidarFechaContrato))]
        public DateTime Fecha_contrato { get; set; }


        [Required(ErrorMessage = "La cuota es obligatorio")]
        [Range(1, int.MaxValue, ErrorMessage = "La cuota debe ser un valor numerico")]
        public string Cuota { get; set; } = null!;


        [Required(ErrorMessage = "Las ventas son obligatorias")]
        [Range(1, int.MaxValue, ErrorMessage = "Las ventas deben ser un valor numerico")]
        public string Ventas { get; set; } = null!;



        public static ValidationResult ValidarFechaContrato(DateTime fecha, ValidationContext context)
        {
            if (fecha > DateTime.Today)
            {
                return new ValidationResult("La fecha de contrato no puede ser posterior a la fecha actual.");
            }
            return ValidationResult.Success!;
        }
    }
}
