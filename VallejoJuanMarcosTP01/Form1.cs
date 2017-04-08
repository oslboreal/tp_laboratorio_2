using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VallejoJuanMarcosTP01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbOperacion.Text = "";
            txtNumero1.Text = "0";
            txtNumero2.Text = "0";
            cmbOperacion.Text = "+";
            lblResultado.Text = "0";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operador = Calculadora.validarOperador(cmbOperacion.Text);
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);

            lblResultado.Text = Calculadora.operar(numero1, numero2, operador).ToString();
            estado.Text = "Operación realizada con exito";
        }
    }
}
