using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Excepciones;

namespace EntidadesAbstractas
{


    public abstract class Persona
    {
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }

        #region Atributos y Propiedades
        //Atributos.

        protected string _apellido;
        protected int _dni;
        protected ENacionalidad _nacionalidad;
        protected string _nombre;
        // Popiedades.
        public string Apellido
        {
            get
            {
                return this._apellido;
            }
            set
            {
                // Validamos el nombre y retornamos el mismo, caso contrario tira excepción para evitar la carga.
                this._apellido = ValidarNombreApellido(value);                
            }
        }

        public int DNI
        {
            get
            {
                return this._dni;
            }
            set
            {
                this._dni = value;
            }
        }

        public ENacionalidad Nacionalidad
        {
            get
            {
                return this._nacionalidad;
            }
            set
            {
                this._nacionalidad = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this._nombre;
            }
            set
            {
                // Validamos el nombre y retornamos el mismo, caso contrario tira excepción para evitar la carga.
                this._nombre = ValidarNombreApellido(value);
            }
        }
        public string StringToDNI
        {
            set
            {
                this.DNI = ValidarDni(this.Nacionalidad, value);
            }
        }

        #endregion

        #region Constructores

        public Persona()
        {
            
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.DNI = dni;
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad) : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }
            

        #endregion

        #region Métodos

        public override string ToString()
        {
            StringBuilder miCadena = new StringBuilder();
            miCadena.AppendLine("Nombre: " + this.Nombre + " - Apellido: " + this.Apellido);
            miCadena.AppendLine("DNI: " + DNI.ToString());
            miCadena.AppendLine("Nacionalidad: " + this.Nacionalidad.ToString());
            return miCadena.ToString();
        }

        protected int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            try
            {
                switch (nacionalidad)
                {
                    case ENacionalidad.Argentino:
                        // Si cumple con la condicion para ser argentino, vaya y pase.
                        if (dato >= 1 && dato <= 89999999)
                        {
                            return dato;
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("[DNI] Argentino posee DNI Inválido.");
                        }
                    case ENacionalidad.Extranjero:
                        // Si cumple con la condicion para ser Extranjero, vaya y pase.
                        if (!(dato >= 1 && dato <= 89999999))
                        {
                            return dato; // En caso de que el flujo haya continuado correctamente, no hay errores, retornamos.
                        }
                        else
                        {
                            throw new NacionalidadInvalidaException("[DNI] Extranjero posee DNI Inválido.");
                        }
                    default:
                            // En caso de no satifascer ninguna de las dos opciones, tenemos un problema.
                            throw new NacionalidadInvalidaException("[DNI] Problema al verificar DNI - Nacionalidad invalida.");
                }
            }
            catch (DniInvalidoException e)
            {
                throw new DniInvalidoException(e.Message); 
            }
            catch (NacionalidadInvalidaException e)
            {
                throw new NacionalidadInvalidaException(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("[Exception] Problema al validar el dni. " + e.Message, e);
            }
        }

        protected int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int datoParseado;
            bool validation;
            validation = int.TryParse(dato, out datoParseado);
            if (!validation)
                {
                    // Si tiene letras entonces el DNI es invalido.
                    throw new DniInvalidoException("[DniInvalidoException] El DNI Ingresado posee letras.");
                }
            // Una vez verificado que no tenga letras podemos llamar a el otro parse.
            return ValidarDni(nacionalidad, datoParseado);
                
         }

        protected string ValidarNombreApellido(string dato)
        {
            bool check = false;
            Regex Expresion = new Regex(@"[ A-Za-zäÄëËïÏöÖüÜáéíóúáéíóúÁÉÍÓÚÂÊÎÔÛâêîôûàèìòùÀÈÌÒÙ.-]+"); // Expresion regular a Evaluar.
            if (Expresion.IsMatch(dato))
            {
                // Cumple con la expresion regular.
                check = true;
            }
            if (check)
            {
                return dato; // Cumple las características.
            }
            else
            {
                throw new Exception("[Nombre-Apellido] Datos ingresado son inválidos.");
            }
        }

        #endregion

        #region Sobrecarga de Operadores

        #endregion


    }
}
