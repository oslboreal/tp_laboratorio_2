using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archivos
{
    public interface IArchivo<T>
    {
        bool guardar(T datos);
        bool leer(out List<T> datos);
    }
}
