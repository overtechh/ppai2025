using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using System.Linq;

namespace CierreOrdenApp
{
    public class GestorCierreOrdInspeccion
    {
        public List<OrdenInspeccion> BuscarOrdenesPendientes(List<OrdenInspeccion> todas)
        {
            return todas
                .Where(o => o.EsRealizada())
                .OrderByDescending(o => o.FechaFinalizacion)
                .ToList();
        }
    }
}

