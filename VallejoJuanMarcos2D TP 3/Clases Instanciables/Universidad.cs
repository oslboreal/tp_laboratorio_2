using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Archivos;

namespace Clases_Instanciables
{


    [Serializable]public class Universidad
    {
        public enum EClases
        {
            Natacion, Pilates, Legislacion, Laboratorio, SPD, Programacion
        }

        // En estos atributos no puse el guion bajo (privado o protected) por que en el diagrama de clases
        // No lo tenían.
        #region Atributos y propiedades
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;

        public List<Alumno> Alumnos
        {
            get
            {
                return alumnos;
            }

            set
            {
                alumnos = value;
            }
        }

        public List<Jornada> Jornadas
        {
            get
            {
                return jornada;
            }

            set
            {
                jornada = value;
            }
        }

        public List<Profesor> Instructores
        {
            get
            {
                return profesores;
            }

            set
            {
                profesores = value;
            }
        }

        public Jornada this[int i]
        {
            get
            {
                Jornada aux = null;
                try
                {
                    int checkIndex = 0;
                    if (i >= this.Jornadas.Count) // Si el indice indicado es mayor a la cantidad de jornadas.
                    {
                        throw new Exception("[Excepcion] Error a la hora de buscar una jornada en la universidad, el indice es demasiado alto.");
                    }
                    else
                    {   // En caso de que el indice sea correcto, procedemos a buscar nuestra jornada.
                        foreach (Jornada temp in this.Jornadas)
                        {
                            if (checkIndex == i)
                            {
                                // Recore hasta que el indice coincida.
                                aux = temp;
                                break; // En caso de encontrar nuestra Jornada cortamos con el bloque iterativo foreach.
                            }
                            checkIndex++;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                // Aux sólo llegaría a Retornar en caso de que haya ingresado en el bloque del foreach
                // Caso contrario se generaría una excepción que sería capturada por el catch.
                return aux;
            }
            set
            {
                Jornada aux = null;
                try
                {
                    int checkIndex = 0;
                    if (i >= this.Jornadas.Count) // Si el indice indicado es mayor a la cantidad de jornadas.
                    {
                        throw new Exception("[Excepcion] Error a la hora de buscar una jornada en la universidad, el indice es demasiado alto.");
                    }
                    else
                    {   // En caso de que el indice sea correcto, procedemos a buscar nuestra jornada.
                        foreach (Jornada temp in this.Jornadas)
                        {
                            if (checkIndex == i)
                            {
                                // Recore hasta que el indice coincida.
                                aux = temp;
                                break; // En caso de encontrar nuestra Jornada cortamos con el bloque iterativo foreach.
                            }
                            checkIndex++; // En caso de no coincidir va a saltar el IF e incrementará el contador.
                        }
                        aux = value; // Para cuando la estructura repetitiva termine en Aux se va a encontrar la referencia a nuestra jornada.
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        #endregion
        #region Constructores
        public Universidad()
        {
            // Instanciamos todas las listas.
            this.alumnos = new List<Alumno>();
            this.profesores = new List<Profesor>();
            this.jornada = new List<Jornada>();
        }
        #endregion

        #region Métodos

        public override string ToString()
        {
            StringBuilder miCadena = new StringBuilder();
            miCadena.AppendLine(MostrarDatos(this));
            return miCadena.ToString();
        }

        private static string MostrarDatos(Universidad gim)
        {
            StringBuilder miCadena = new StringBuilder();
            foreach(Jornada temp in gim.Jornadas)
            {
                miCadena.AppendLine(temp.ToString());
            }
            return miCadena.ToString();
        }

        public static bool Guardar(Universidad gim)
        {
            try
            {
                bool bRet = false;
                Xml<Universidad> miXml = new Xml<Universidad>();
                bRet = miXml.guardar("Universidad.xml", gim);
                return bRet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArchivosException(e);
            }
            
        }

        public static Universidad Leer()
        {
            try
            {
                Universidad uRet;
                Xml<Universidad> lector = new Xml<Universidad>();
                lector.leer("Universidad.xml", out uRet);
                return uRet;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw new ArchivosException(e);
            }

        }

        #endregion

        #region Sobrecarga de Operadores
        public static bool operator ==(Universidad g, Alumno a)
        {
            bool bRet = false;
            foreach(Alumno temp in g.Alumnos)
            {
                if(temp == a)  // Si el alumno está en la universidad.
                {
                    bRet = true;
                    break;
                }
            }
            return bRet;
        }

        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            bool bRet = false;
            if (g.Instructores.Contains(i))
            {
                bRet = true;
            }
            return bRet;
        }

        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }

        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            try
            {
                foreach (Profesor temp in g.Instructores)
                {
                    if (temp == clase)
                    {
                        return temp;
                    }
                }
                // Solo llegará a lanzar la excepcion si no encontró un profesor.
                throw new SinProfesorException();
            } catch(SinProfesorException e)
            {
                throw new SinProfesorException();
            } catch(Exception e)
            {
                throw new Exception("[Exception] Error buscando un profesor que pueda dar la clase\nInfo: " + e.Message);
            }
        }

        public static Profesor operator !=(Universidad g, EClases clase)
        {
            return g == clase;
        }

        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            try
            {
                Universidad uRet = g;
                Profesor disponible = (g == clase); // Buscamos un profesor que pueda dar la clase.
                Jornada nueva = new Jornada(clase, disponible);
                foreach (Alumno temp in g.Alumnos)
                {
                    // Por cada alumno en la universidad.
                    if (nueva == temp)
                    {
                        // Si el alumno cursa la clase de la jornada.
                        nueva.Alumnos.Add(temp); // Agregamos el alumno a la clase.
                    }
                }
                uRet.Jornadas.Add(nueva);
                return uRet;
            }
            catch (SinProfesorException e)
            {
                throw new SinProfesorException();
            }
        }

        public static Universidad operator +(Universidad g, Profesor i)
        {
            Universidad gRet = g;
            try
            {
                if (gRet != i) // Si el profesor no se encuentra dando clases en la universidad.
                {
                    gRet.Instructores.Add(i); // Agregamos el profesor.
                }
                return gRet;
            }catch(Exception e)
            {
                throw new Exception("[Exception] Error agregando profesor a la universidad.\n" + e.Message);
            }
        }

        public static Universidad operator +(Universidad g, Alumno a)
        {
            Universidad gRet = g;
            try
            {
                if (gRet != a)
                {
                    // Si el alumno no esta en la Universidad.
                    gRet.Alumnos.Add(a);
                } else
                {
                    throw new AlumnoRepetidoException();
                }
                return gRet;
            }catch(AlumnoRepetidoException e)
            {
                throw new AlumnoRepetidoException();
            }
        }
        #endregion
    }
}
