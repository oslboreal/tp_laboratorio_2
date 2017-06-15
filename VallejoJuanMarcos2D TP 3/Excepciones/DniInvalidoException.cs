using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class DniInvalidoException : System.Exception
    {
        private string mensajeBase;
        public DniInvalidoException() : base() { }
        public DniInvalidoException(Exception e) { }
        public DniInvalidoException(string message) : base(message) {  }
        public DniInvalidoException(string message, Exception e) : base(message, e) { }

        // Sobrecargamos los tres constructores de System.Exception para poder emplear sus usos.
    }
}
