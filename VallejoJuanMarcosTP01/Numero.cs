using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallejoJuanMarcosTP01
{
    public class Numero
    {
        #region Propiedades
        double numero;
        #endregion

        #region Metodos
        public Numero()
        {
            this.numero = 0;
        }
        public Numero(double numero)
        {
            this.numero = numero;
        }
        public Numero(string numero)
        {
            setNumero(numero);
        }
        public double getNumero()
        {
            return this.numero;
        }
        private void setNumero(string numero)
        {
            this.numero = validarNumero(numero);
        }
        private double validarNumero(string numeroString)
        {
            double check = 0;
            double.TryParse(numeroString, out check);
            return check;
        }


        #endregion
    }
}
