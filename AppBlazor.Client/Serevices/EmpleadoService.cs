using AppBlazor.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppBlazor.Client.Services
{
    public class EmpleadoService
    {
        private List<ListaEmpleadosCLS> lista;
        private List<SucursalEmpleadoCLS> sucursales;
        private List<DirectorCLS> directores;

        public EmpleadoService()
        {
            // Datos de ejemplo
            sucursales = new List<SucursalEmpleadoCLS>
            {
                new SucursalEmpleadoCLS { idsucursal = 1, nombresucursal = "Sucursal Central" },
                new SucursalEmpleadoCLS { idsucursal = 2, nombresucursal = "Sucursal Norte" }
            };

            directores = new List<DirectorCLS>
            {
                new DirectorCLS { iddirector = 1, nombredirector = "Juan Pérez" },
                new DirectorCLS { iddirector = 2, nombredirector = "María López" }
            };

            lista = new List<ListaEmpleadosCLS>
            {
                new ListaEmpleadosCLS { Num_Empl = 1, Nombre = "Carlos Gómez", sucursalEmpleado = "Sucursal Central", directorEmpleado = "Juan Pérez" },
                new ListaEmpleadosCLS { Num_Empl = 2, Nombre = "Ana Torres", sucursalEmpleado = "Sucursal Norte", directorEmpleado = "María López" }
            };
        }

        public List<ListaEmpleadosCLS> ListarEmpleados()
        {
            return lista;
        }

        public void EliminarEmpleado(int numEmpleado)
        {
            lista = lista.Where(e => e.Num_Empl != numEmpleado).ToList();
        }

        public EmpleadoCLS RecuperarEmpleadoPorId(int numEmpleado)
        {
            var obj = lista.FirstOrDefault(e => e.Num_Empl == numEmpleado);
            if (obj != null)
            {
                return new EmpleadoCLS
                {
                    Num_Empl = obj.Num_Empl,
                    Nombre = obj.Nombre,
                    Edad = 30, // valor de ejemplo
                    Cargo = "Empleado",
                    Fecha_contrato = DateTime.Today,
                    Cuota = "1000",
                    Ventas = "5000"
                };
            }
            return new EmpleadoCLS();
        }

        public void GuardarEmpleado(EmpleadoCLS oEmpleadoCLS)
        {
            int nuevoId = lista.Any() ? lista.Select(e => e.Num_Empl).Max() + 1 : 1;
            lista.Add(new ListaEmpleadosCLS
            {
                Num_Empl = nuevoId,
                Nombre = oEmpleadoCLS.Nombre,
                sucursalEmpleado = sucursales.FirstOrDefault()?.nombresucursal ?? "Sucursal no asignada",
                directorEmpleado = directores.FirstOrDefault()?.nombredirector ?? "Director no asignado"
            });
        }
    }
}
