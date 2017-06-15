using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{


    // Clase Alumno: sealed del tipo Universitario, no es posible heredarla.
    public sealed class Alumno : Universitario
    {
        public enum EEstadoCuenta
        {
            AlDia, Deudor, Becado
        }

        #region Atributos y propiedades.
        private Universidad.EClases _claseQueToma;
        private EEstadoCuenta _estadoCuenta;

        #endregion

        #region Constructores

        public Alumno()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta) : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        protected override string ParticiparEnClase()
        {
            StringBuilder miCadena = new StringBuilder();
            miCadena.AppendLine("TOMA CLASE DE " + this._claseQueToma.ToString());
            return miCadena.ToString();
        }

        protected override string MostrarDatos()
        {
            StringBuilder miCadena = new StringBuilder();
            miCadena.AppendLine(base.MostrarDatos()); // Traemos datos de la clase Padre.
            // Corroboramos el estado de la cuenta.
            if (this._estadoCuenta == EEstadoCuenta.AlDia)
            {
                miCadena.AppendLine("ESTADO DE CUENTA: Cuota al día");
            }
            else
            {
                miCadena.AppendLine("ESTADO DE CUENTA: Adeuda cuotas");
            }
            miCadena.AppendLine(this.ParticiparEnClase()); // Agregamos la clase en la que participa.
            return miCadena.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos(); // Hacemos públicos los Datos del alúmno debido a que MostrarDatos está protegido.
        }
        #endregion

        #region Sobrecarga de Operadores.

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            bool bRet = false;
            // Si la clase que toma es igual a b y el saldo no es Deudor.
            if(a._claseQueToma == clase && a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                bRet = true;
            }
            return bRet;
        }

        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            bool bRet = false;
            if(a != clase)
            {
                // Si el alumno posee un tipo de Clase diferente entonces son distintos.
                bRet = true;
            }
            return bRet;
        }

        #endregion

    }
}