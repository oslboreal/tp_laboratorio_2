using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallejoJuanMarcosTP01
{
    class Calculadora
    {
        public static double operar(Numero numero1, Numero numero2, string operador)
        {

            double dRet = 0;
            switch (operador)
            {
                case "+":
                    dRet = numero1.getNumero() + numero2.getNumero();
                    break;
                case "-":
                    dRet = numero1.getNumero() - numero2.getNumero();
                    break;
                case "*":
                    dRet = numero1.getNumero() * numero2.getNumero();
                    break;
                case "/":
                    if(numero2.getNumero() != 0) // Si el segundo operador es != de Cero
                    {
                        // Procedemos a operar
                        dRet = numero1.getNumero() / numero2.getNumero();
                    }
                    else
                    {
                        // Caso contrario para evitar error matematico
                        // Retornaremos cero.
                        dRet = 0;
                    }
                    
                    break;
                default:
                    break;
            }

            return dRet;
        }
        public static string validarOperador(string operador)
        {
            string sRet = operador;
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                sRet = "+"; // En caso de no ser ninguno de los operadores operamos con suma.
            }
            return sRet;
        }
    }
}
