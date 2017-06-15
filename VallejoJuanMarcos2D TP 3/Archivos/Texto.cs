using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool guardar(string archivo, string dato)
        {
            try
            {
                StreamWriter writer = new StreamWriter(archivo, true); // Pasamos la ruta y el true para el Append.
                writer.WriteLine(dato); // Escribimos los datos en el fichero.
                writer.Close(); // Cerramos el Stream.
                return true; // En caso de que no haya tirado excepción alguna retorna, caso contrario cae al catch.
            } catch(Exception e)
            {
                throw new ArchivosException(e);
            }

        }

        public bool leer(string archivo, out string dato)
        {
            try
            {
                StreamReader reader = new StreamReader(archivo);
                dato = reader.ReadToEnd(); // Leemos todo el archivo y lo almacenamos en dato
                return true;
            }catch(Exception e)
            {
                dato = "";
                throw new ArchivosException(e);
            }

        }
    }
}
