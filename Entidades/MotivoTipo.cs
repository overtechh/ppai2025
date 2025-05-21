using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CierreOrdenApp.Entidades
{
    public class MotivoTipo
    {
        public string Descripcion { get; set; }
        public string Comentario { get; set; }

        public override string ToString()
        {
            return $"{Descripcion}: {Comentario}";
        }
    }
}
