using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using Hilo;

namespace Navegador
{
    public partial class frmWebBrowser : Form
    {
        private const string ESCRIBA_AQUI = "Escriba aquí...";
        Archivos.Texto archivos;
        frmHistorial miHistorial;

        public frmWebBrowser()
        {
            InitializeComponent();
            miHistorial = new frmHistorial();
        }

        private void frmWebBrowser_Load(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = 0;  //This keeps the text
            this.txtUrl.SelectionLength = 0; //from being highlighted
            this.txtUrl.ForeColor = Color.Gray;
            this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;

            archivos = new Archivos.Texto(frmHistorial.ARCHIVO_HISTORIAL);
        }

        #region "Escriba aquí..."
        private void txtUrl_MouseMove(object sender, MouseEventArgs e)
        {
            Cursor.Current = Cursors.IBeam; //Without this the mouse pointer shows busy
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(frmWebBrowser.ESCRIBA_AQUI) == true)
            {
                this.txtUrl.Text = "";
                this.txtUrl.ForeColor = Color.Black;
            }
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.txtUrl.Text.Equals(null) == true || this.txtUrl.Text.Equals("") == true)
            {
                this.txtUrl.Text = frmWebBrowser.ESCRIBA_AQUI;
                this.txtUrl.ForeColor = Color.Gray;
            }
        }

        private void txtUrl_MouseDown(object sender, MouseEventArgs e)
        {
            this.txtUrl.SelectAll();
        }
        #endregion

        // Delegado de progreso de descarga.
        delegate void ProgresoDescargaCallback(int progreso);
        private void ProgresoDescarga(int progreso)
        {
            if (statusStrip.InvokeRequired)
            {
                ProgresoDescargaCallback d = new ProgresoDescargaCallback(ProgresoDescarga);
                this.Invoke(d, new object[] { progreso });
                estadoBarra.Text = progreso.ToString();
            }
            else
            {
                tspbProgreso.Value = progreso;
                estadoBarra.Text = progreso.ToString();
            }
        }
        delegate void FinDescargaCallback(string html);
        private void FinDescarga(string html)
        {
            if (rtxtHtmlCode.InvokeRequired)
            {
                FinDescargaCallback d = new FinDescargaCallback(FinDescarga);
                this.Invoke(d, new object[] { html });
                estadoBarra.Text = "Descarga finalizada.";
                
            }
            else
            {
                rtxtHtmlCode.Text = html;
            }
        }

        private void btnIr_Click(object sender, EventArgs e)
        {
            try
            {
                // Para evitar errores a la hora de Instanciar la URI.
                if (!txtUrl.Text.Contains("http://"))
                {
                    this.txtUrl.Text = "http://" + this.txtUrl.Text;
                } else
                // Agregamos la dirección a el historial.
                miHistorial.agregarNuevaUrl(txtUrl.Text);

                Uri direccion = new Uri(txtUrl.Text);
                Descargador miDescargador = new Descargador(direccion);
                // Tenemos instanciado nuestro cargador, antes de comenzar la descarga.
                // Debemos apuntar los delegados a los Métodos correspondientes.
                miDescargador.progresoModificado += this.ProgresoDescarga;
                miDescargador.descargaCompleta += this.FinDescarga;
                Thread hiloDescarga = new Thread(miDescargador.IniciarDescarga);
                hiloDescarga.Start();
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Ups!");
            }

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void mostrarTodoElHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            miHistorial.Show();
        }
    }
}
