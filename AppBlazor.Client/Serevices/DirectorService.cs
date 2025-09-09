using AppBlazor.Entities;
using System.Collections.Generic;
using System.Linq;

namespace AppBlazor.Client.Services
{
    public class DirectorService
    {
        private List<DirectorCLS> lista;

        public DirectorService()
        {
            lista = new List<DirectorCLS>
            {
                new DirectorCLS { iddirector = 1, nombredirector = "Juan Pérez" },
                new DirectorCLS { iddirector = 2, nombredirector = "María López" }
            };
        }

        public List<DirectorCLS> ListarDirectores()
        {
            return lista;
        }

        public int ObtenerIdDirector(string nombreDirector)
        {
            var obj = lista.FirstOrDefault(p => p.nombredirector == nombreDirector);
            return obj?.iddirector ?? 0;
        }

        public string ObtenerNombreDirector(int idDirector)
        {
            var obj = lista.FirstOrDefault(p => p.iddirector == idDirector);
            return obj?.nombredirector ?? string.Empty;
        }
    }
}
