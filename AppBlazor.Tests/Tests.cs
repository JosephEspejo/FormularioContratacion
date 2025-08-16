using AppBlazor.Entities;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace AppBlazorD.Test
{
    public class LibroFormCLSTest
    {
        // Método auxiliar para validar el modelo
        private List<ValidationResult> ValidaModelo(object modelo)
        {
            var resultados = new List<ValidationResult>();
            var contexto = new ValidationContext(modelo, null, null);
            Validator.TryValidateObject(modelo, contexto, resultados, true);
            return resultados;
        }

        [Fact]
        public void ValidacionCamposVacios()
        {
            var libro = new LibroFormCLS();

            var errores = ValidaModelo(libro);

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El numero de empleado es obligatorio"));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El nombre es obligatorio"));
            //Assert.Contains(errores, e => e.ErrorMessage!.Contains("Mayor a 18 o menor a 100"));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("El cargo es obligatorio"));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La cuota es obligatorio"));
            Assert.Contains(errores, e => e.ErrorMessage!.Contains("Las ventas son obligatorias"));
        }

        [Fact]
        public void ValidacionCamposCorrectos()
        {
            var libro = new LibroFormCLS
            {
                Num_Empl = 1,
                Nombre = "Juan Perez",
                Edad = 25,
                Cargo = "Desarrollador",
                Fecha_contrato = DateTime.Today,
                Cuota = "1000",
                Ventas = "2000"
            };

            var errores = ValidaModelo(libro);

            Assert.Empty(errores);
        }

        [Fact]
        public void EdadMenorQue18()
        {
            var libro = new LibroFormCLS
            {
                Num_Empl = 1,
                Nombre = "Carlos",
                Edad = 15,        //Menor de 18
                Cargo = "Tester",
                Fecha_contrato = DateTime.Today,
                Cuota = "500",
                Ventas = "1000"
            };

            var errores = ValidaModelo(libro);

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("Mayor a 18 o menor a 100"));
        }

        [Fact]
        public void FechaContratoPosteriorAHoy()
        {
            var libro = new LibroFormCLS
            {
                Num_Empl = 1,
                Nombre = "Luis",
                Edad = 30,
                Cargo = "QA",
                Fecha_contrato = DateTime.Today.AddDays(10), // Fecha futura
                Cuota = "500",
                Ventas = "1000"
            };

            var errores = ValidaModelo(libro);

            Assert.Contains(errores, e => e.ErrorMessage!.Contains("La fecha de contrato no puede ser posterior a la fecha actual"));
        }
    }
}
