using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public class ExcepcionesArchivos : Exception
    {
        public ExcepcionesArchivos(string mensaje) : base(mensaje)
        {

        }
    }
}
