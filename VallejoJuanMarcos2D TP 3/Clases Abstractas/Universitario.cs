using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos y Propiedades
        protected int _legajo;
        #endregion

        #region Constructores

        public Universitario()
        {

        }


        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(nombre, apellido, dni, nacionalidad)
        {
            // Siendo que la mayoría de los datos corresponden a la Clase de tipo Persona
            // Empleamos el constructor base para ahorrar Código.
            this._legajo = legajo;
        }
        #endregion

        #region Métodos
        protected virtual string MostrarDatos()
        {
            try
            {
                StringBuilder miCadena = new StringBuilder();
                miCadena.Append(base.ToString()); // Empleamos el ToString() de la Clase base.
                miCadena.Append("Legajo: " + this._legajo.ToString()); // Añadimos la inormación del Universitario.
                return miCadena.ToString();
            }
            catch (Exception e)
            {
                throw new Exception("[Mostrar datos Universitario] Error al recopilar los datos del Universitario.\n" + e.Message);
            }
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            bool bRet = false;
            if(obj is Universitario) // Si el objeto es Universitario.
            {
                 if(this == ((Universitario)obj)) // Casteamos el Objeto para compararlo.
                {
                    // Si ambos Universitarios son iguales - Empleamos sobrecarga de operadores para reciclar código.
                    bRet = true;
                }
            }
            return bRet;
        }


        #endregion

        #region Sobrecarga de Operadores

        public static bool operator ==(Universitario a, Universitario b)
        {
            bool bRet = false;
            // Corroboramos que los DNI y los Legajos coincidan para cumplir la condición de Igualdad.
            if (a.DNI == b.DNI || a._legajo == b._legajo)
            {
                bRet = true;
            }

            return bRet;
        }

        public static bool operator !=(Universitario a, Universitario b)
        {   
            return !(a == b);
        }

        #endregion
    }
}
