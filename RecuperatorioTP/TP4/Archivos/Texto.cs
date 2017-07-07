using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        private string _archivo;
        public Texto(string archivo)
        {
            this._archivo = archivo;
        }

        public bool guardar(string datos)
        {
            try
            {
                StreamWriter miWriter = new StreamWriter(this._archivo, true);
                miWriter.WriteLine(datos);
                miWriter.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ExcepcionesArchivos("File error: " + e.Message);
            }

        }

        public bool leer(out List<string> datos)
        {
            try
            {
                StreamReader miReader = new StreamReader(this._archivo);
                List<string> aux = new List<string>();
                string temporal;
                while (!miReader.EndOfStream)
                {
                    temporal = miReader.ReadLine();
                    aux.Add(temporal);
                }
                datos = aux;
                miReader.Close();
                return true;
            }
            catch (Exception e)
            {
                throw new ExcepcionesArchivos("File read error: " + e.Message);
            }          
        }
    }
}
