using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_2017;

namespace TP_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Changuito changoDeCompras = new Changuito(5);

            Dulce c1 = new Dulce(Producto.EMarca.Sancor, "ASD012", ConsoleColor.Black);
            Dulce c2 = new Dulce(Producto.EMarca.Ilolay, "ASD913", ConsoleColor.Red);
            Leche m1 = new Leche(Producto.EMarca.Pepsico, "HJK789", ConsoleColor.White);
            Leche m2 = new Leche(Producto.EMarca.Serenisima, "IOP852", ConsoleColor.Blue, Leche.ETipo.Descremada);
            Snacks a1 = new Snacks(Producto.EMarca.Campagnola, "QWE968", ConsoleColor.Gray);
            Snacks a2 = new Snacks(Producto.EMarca.Arcor, "TYU426", ConsoleColor.DarkBlue);
            Snacks a3 = new Snacks(Producto.EMarca.Sancor, "IOP852", ConsoleColor.Green);

            // Agrego 6 ítems (los últimos 2 no deberían poder agregarse) y muestro
            changoDeCompras += c1;
            changoDeCompras += c2;
            changoDeCompras += m1;
            changoDeCompras += m2;
            changoDeCompras += a1;
            changoDeCompras += a2;
            changoDeCompras += a3;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<---------------------------------------------->");
            Console.ReadKey();
            Console.Clear();

            // Quito un item y muestro
            changoDeCompras -= c1;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<---------------------------------------------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Dulces
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Dulce));
            Console.WriteLine("<---------------------------------------------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Leches
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Leche));
            Console.WriteLine("<---------------------------------------------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Snacks
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Snacks));
            Console.WriteLine("<---------------------------------------------->");
            Console.ReadKey();
        }
    }
}
