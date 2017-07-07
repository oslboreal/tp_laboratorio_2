namespace Navegador
{
    partial class frmHistorial
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstHistorial = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lstHistorial
            // 
            this.lstHistorial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstHistorial.FormattingEnabled = true;
            this.lstHistorial.Location = new System.Drawing.Point(0, 0);
            this.lstHistorial.Name = "lstHistorial";
            this.lstHistorial.Size = new System.Drawing.Size(426, 395);
            this.lstHistorial.TabIndex = 0;
            // 
            // frmHistorial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 395);
            this.Controls.Add(this.lstHistorial);
            this.Name = "frmHistorial";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial";
            this.Load += new System.EventHandler(this.frmHistorial_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstHistorial;
    }
}