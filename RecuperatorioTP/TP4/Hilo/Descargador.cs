using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using System.Net; // Avisar del espacio de nombre
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string html;
        private Uri direccion;

        public Descargador(Uri direccion)
        {
            this.direccion = direccion;
            this.html = "";
        }

        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();
                // Asignamos a los delegados del WebClient los métodos que van a manejar los evnts.
                cliente.DownloadProgressChanged += this.WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += this.WebClientDownloadCompleted;
                // Este es un método de descarga asíncrona que se encargará de ir lanzando los eventos.
                cliente.DownloadStringAsync(this.direccion, this.html);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // Creamos nuestro propio delegado - Parámetros: Sender y DownloadProgressChangedEventArg, donde obtendremos el Percent.
        public delegate void descargadorEstadoProgreso(int progresoDescarga);
        public event descargadorEstadoProgreso progresoModificado;
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Invocamos a el evento pasando el progreso como resultado, cada vez que sea invocado
            // Este va a llamar al método de cambio en el progreso del frmWebBrowser.
            this.progresoModificado(e.ProgressPercentage);
        }

        public delegate void descargadorEstadoCompleto(string content);
        public event descargadorEstadoCompleto descargaCompleta;
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            // Invocamos a el evento pasando el resultado como parametro.
            this.descargaCompleta(e.Result);
        }
    }
}
