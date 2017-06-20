using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades_2017
{
    /// <summary>
    /// No podrá tener clases heredadas.
    /// </summary>
    /// 



    public class Changuito
    {
        List<Producto> _productos;
        int _espacioDisponible;
        public enum ETipo
        {
            Dulce, Leche, Snacks, Todos
        }

        #region "Constructores"
        private Changuito()
        {
            this._productos = new List<Producto>();
        }
        public Changuito(int espacioDisponible) : this()
        {
            this._espacioDisponible = espacioDisponible;
        }
        #endregion

        #region "Sobrecargas"
        /// <summary>
        /// Muestro la concecionaria y TODOS los Productos
        /// </summary>
        /// <returns></returns>
        public string ToString()
        {
            return Changuito.Mostrar(this, ETipo.Todos);
        }
        #endregion

        #region "Métodos"

        /// <summary>
        /// Expone los datos del elemento y su lista (incluidas sus herencias)
        /// SOLO del tipo requerido
        /// </summary>
        /// <param name="c">Elemento a exponer</param>
        /// <param name="ETipo">Tipos de ítems de la lista a mostrar</param>
        /// <returns></returns>
        public static string Mostrar(Changuito c, ETipo tipo) //quitar static
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Tenemos {0} lugares ocupados de un total de {1} disponibles", c._productos.Count, c._espacioDisponible);
            sb.AppendLine("");
            sb.AppendLine(c.VerProductos(tipo));
            return sb.ToString();
        }

        private string VerProductos(ETipo tipo)
        {
            StringBuilder miCadena = new StringBuilder();
            if(tipo == ETipo.Snacks)
            {
                foreach(Producto v in this._productos)
                {
                    if (v is Snacks)
                    {
                        miCadena.AppendLine(((Snacks)v).Mostrar());
                    }
                }
            }
            if (tipo == ETipo.Dulce)
            {
                foreach (Producto v in this._productos)
                {
                    if (v is Dulce)
                    {
                        miCadena.AppendLine(((Dulce)v).Mostrar());
                    }
                }
            }
            if (tipo == ETipo.Leche)
            {
                foreach (Producto v in this._productos)
                {
                    if (v is Leche)
                    {
                        miCadena.AppendLine(((Leche)v).Mostrar());
                    }
                }
            }
            if(tipo == ETipo.Todos)
            {
                foreach(Producto v in this._productos)
                {
                    if (v is Snacks)
                    {
                        miCadena.AppendLine(((Snacks)v).Mostrar());
                    }
                    else if (v is Dulce)
                    {
                        miCadena.AppendLine(((Dulce)v).Mostrar());
                    }
                    else if (v is Leche)
                    {
                        miCadena.AppendLine(((Leche)v).Mostrar());
                    }
                }
            }

            return miCadena.ToString();
        }

    
    #endregion

    #region "Operadores"
    /// <summary>
    /// Agregará un elemento a la lista
    /// </summary>
    /// <param name="c">Objeto donde se agregará el elemento</param>
    /// <param name="p">Objeto a agregar</param>
    /// <returns></returns>
    public static Changuito operator +(Changuito c, Producto p)
    {
        bool esta = false;
        Changuito changoTemp = c;
        if (c._espacioDisponible > c._productos.Count)
        {
            foreach (Producto v in changoTemp._productos)
            {
                if (v == p)
                {
                    esta = true; // Chequeamos que el elemento no esté en la lista.
                }
            }
            if (!esta)
            {
                changoTemp._productos.Add(p); // En caso de que no esté, agregamos el elemento a la lista.
            }
        }
        return changoTemp;
    }
    /// <summary>
    /// Quitará un elemento de la lista
    /// </summary>
    /// <param name="c">Objeto donde se quitará el elemento</param>
    /// <param name="p">Objeto a quitar</param>
    /// <returns></returns>
    public static Changuito operator -(Changuito c, Producto p)
    {
        bool esta = false;
        Changuito changoTemp = c;
        foreach (Producto v in changoTemp._productos)
        {
            if (v == p)
            {
                esta = true;
            }
        }
        if (esta)
        {
            changoTemp._productos.Remove(p); // Si el elemento existe lo removemos.
        }
        return changoTemp;
    }
    #endregion
    } // CLASS
} // NS
