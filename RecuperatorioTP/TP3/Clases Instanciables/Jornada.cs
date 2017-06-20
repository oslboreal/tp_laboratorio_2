using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    [Serializable]public class Jornada
    {
        #region Atributos y propiedades
        private List<Alumno> _alumnos;
        private Universidad.EClases _clase;
        private Profesor _instructor;

        public List<Alumno> Alumnos
        {
            get
            {
                return _alumnos;
            }

            set
            {
                _alumnos = value;
            }
        }

        public Universidad.EClases Clase
        {
            get
            {
                return _clase;
            }

            set
            {
                _clase = value;
            }
        }

        public Profesor Instructor
        {
            get
            {
                return _instructor;
            }

            set
            {
                _instructor = value;
            }
        }

        #endregion
        #region Constructores
        private Jornada()
        {
            try
            { 
            this.Alumnos = new List<Alumno>(); // Inicializamos la Lista en el Constructor por defecto.
            } catch(Exception e)
            {
                throw new Exception("[Error] Error a la hora de inicializar a lista de alumnos en la jornada. \n" + e.Message);
            }
        }

        public Jornada(Universidad.EClases clase, Profesor instructor) : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion
        #region Metodos

        public static bool Guardar(Jornada jornada)
        {
            try
            {
                bool bRet = false;
                    Texto miTexto = new Texto();
                    bRet = miTexto.guardar("Jornada.txt", jornada.ToString());
                return bRet;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArchivosException(e);
            }
        }

        public static string Leer()
        {
            try
            {
                string sRet;
                Texto miTexto = new Texto(); // Instanciamos nuestro archivo de tipo texto.
                miTexto.leer("jornada.txt", out sRet);
                return sRet;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArchivosException(e);
            }
        }


        #endregion
        #region Sobrecarga de Operadores
        public static bool operator ==(Jornada j, Alumno a)
        {
            bool bRet = false;
            if (a == j.Clase) // Empleamos sobrecarga de Operador de Alumno.
            {
                // Si el alumno se encuentra en la clase retornamos true.
                bRet = true;
            }
            return bRet;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            Jornada jRet = j;
            bool addAlumn = true; 
            foreach(Alumno temp in j.Alumnos)
            {
                if(temp == a)
                {
                    addAlumn = false; // Si el alumno se encuentra en la clase, no lo agregamos.
                }
            }
            if (addAlumn) j.Alumnos.Add(a); // En caso de que el alumno no se encuentre en la clase, lo agrego.
            return jRet;
        }

        public override string ToString()
        {
            StringBuilder miCadena = new StringBuilder();
            miCadena.AppendLine("╔════════════════JORNADA═══════════════╗");
            miCadena.AppendLine("PROFESOR:");
            miCadena.AppendLine(this.Instructor.ToString());
            miCadena.AppendLine("ALUMNOS:");
            foreach (Alumno tmp in this.Alumnos)
            {
                miCadena.AppendLine(tmp.ToString());
            }
            miCadena.AppendLine("╚══════════════════════════════════════╝");
            return miCadena.ToString();
        }


        #endregion


    }
}
