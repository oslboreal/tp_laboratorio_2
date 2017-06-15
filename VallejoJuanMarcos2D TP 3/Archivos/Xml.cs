using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Excepciones;


namespace Archivos
{
    public class Xml<T> : IArchivo<T>
    {
        public bool guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextWriter writer = new StreamWriter(archivo); // Le pasamos la direccion de nuestro fichero.
                serializer.Serialize(writer, datos);
                writer.Close(); // Cerramos el stream.
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        public bool leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                TextReader reader = new StreamReader(archivo);
                datos = (T)serializer.Deserialize(reader);
                return true;
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            } 
        }
    }
}
