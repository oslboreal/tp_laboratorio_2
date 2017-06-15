using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        #region Atributos y propiedades
        private Queue<Universidad.EClases> _clasesDelDia;
        static private Random _random;
        #endregion

        #region Constructores
        static Profesor()
        {
            Profesor._random = new Random(); // Instanciamos el miembro estático en el constructor estático.
        }

        public Profesor()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad) : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>(); // Inicializamos las clases del día.
            this._randomClases(); // Obtenemos las clases de nuestro profesor.
        }
        #endregion

        #region Metodos
        private void _randomClases()
        {
            try
            {
                int valor;
                Universidad.EClases aux;
                while (this._clasesDelDia.Count < 2)
                {
                    valor = Profesor._random.Next(0, 3); // Generamos un valor Aleatorio.
                    aux = (Universidad.EClases)Enum.ToObject(typeof(Universidad.EClases), valor);
                    this._clasesDelDia.Enqueue(aux); // Agregamos la clase a nuestra colección.
                }
            }
            catch (Exception e)
            {
                throw new Exception("[Excepción] Error generando clases a profesor./n" + e.Message);
            }
        }

        protected override string ParticiparEnClase()
        {
            StringBuilder miCadena = new StringBuilder();
            miCadena.AppendLine("CLASES DEL DÍA:");
            foreach (Universidad.EClases temp in this._clasesDelDia)
            {
                miCadena.AppendLine(temp.ToString());
            }
            return miCadena.ToString();
        }

        /// <summary>
        ///  VER.
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder miCadena = new StringBuilder();
            miCadena.AppendLine(base.MostrarDatos());
            miCadena.AppendLine(this.ParticiparEnClase());
            return miCadena.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Sobrecarga de operadores
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool bRet = false;
            foreach(Universidad.EClases temp in i._clasesDelDia)
            {
                if(temp == clase) // Si una de las clases es igual a clase.
                {
                    bRet = true;
                }
            }
            return bRet;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion
        
    }
}
