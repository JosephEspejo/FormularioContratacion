using AppBlazor.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppBlazor.Client.Services
{
    public class SucursalService
    {
        private List<SucursalEmpleadoCLS> lista;

        public SucursalService()
        {
            lista = new List<SucursalEmpleadoCLS>
            {
                new SucursalEmpleadoCLS { idsucursal = 1, nombresucursal = "Sucursal Central" },
                new SucursalEmpleadoCLS { idsucursal = 2, nombresucursal = "Sucursal Norte" }
            };
        }

        public List<SucursalEmpleadoCLS> ListarSucursales()
        {
            return lista;
        }

        public int ObtenerIdSucursal(string nombreSucursal)
        {
            var obj = lista.FirstOrDefault(p => p.nombresucursal == nombreSucursal);
            return obj?.idsucursal ?? 0;
        }

        public string ObtenerNombreSucursal(int idSucursal)
        {
            var obj = lista.FirstOrDefault(p => p.idsucursal == idSucursal);
            return obj?.nombresucursal ?? string.Empty;
        }
    }
}
