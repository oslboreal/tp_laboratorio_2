using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// La clase Producto será abstracta, evitando que se instancien elementos de este tipo.
    /// </summary>
    public abstract class Producto//Se quita el sealed por abstract para que otras clases puedan heredar atributos o metodos
    {
        public enum EMarca//Los enumerados tienen que ser de tipo publico para poder utilizar
        {
            Serenisima, Campagnola, Arcor, Ilolay, Sancor, Pepsico
        }
        protected EMarca _marca;
        protected string _codigoDeBarras;
        protected ConsoleColor _colorPrimarioEmpaque;

        /// <summary>
        /// ReadOnly: Retornará la cantidad de ruedas del vehículo
        /// </summary>
        protected abstract short CantidadCalorias { get; }

        public Producto(string codigoDeBarras, EMarca marca, ConsoleColor color)
        {
            this._marca = marca;
            this._codigoDeBarras = codigoDeBarras;
            this._colorPrimarioEmpaque = color;
        }
        /// <summary>
        /// Publica todos los datos del Producto.
        /// </summary>
        /// <returns></returns>
        public virtual string Mostrar()
        {
            return " " + this._codigoDeBarras + " " + this._colorPrimarioEmpaque.ToString() + this._marca.ToString();
        }

        public static explicit operator string(Producto p)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("CODIGO DE BARRAS: {0}\r\n", p._codigoDeBarras);
            sb.AppendFormat("MARCA          : {0}\r\n", p._marca.ToString());
            sb.AppendFormat("COLOR EMPAQUE  : {0}\r\n", p._colorPrimarioEmpaque.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        /// <summary>
        /// Dos productos son iguales si comparten el mismo código de barras
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        /// 
        public static bool operator ==(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
        /// <summary>
        /// Dos productos son distintos si su código de barras es distinto
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Producto v1, Producto v2)
        {
            return (v1._codigoDeBarras == v2._codigoDeBarras);
        }
    }
}