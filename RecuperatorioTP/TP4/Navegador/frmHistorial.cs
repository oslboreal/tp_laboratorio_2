using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Navegador
{
    public partial class frmHistorial : Form
    {
        public const string ARCHIVO_HISTORIAL = "historico.dat";
        private List<string> datos;

        public frmHistorial()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Se encarga de cargar la lista luego de leer el archivo de texto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmHistorial_Load(object sender, EventArgs e)
        {
            Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
            archivos.leer(out datos);
            foreach(string temp in this.datos)
            {
                lstHistorial.Items.Add(temp);
            }
        }

        public bool agregarNuevaUrl(string param)
        {
            try
            {
                Archivos.Texto archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
                archivos.guardar(param);
                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Agregando nueva url error: " + e.Message);
            }
        }

    }
}
