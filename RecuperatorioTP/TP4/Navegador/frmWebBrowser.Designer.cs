namespace Navegador
{
    partial class frmWebBrowser
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
            this.btnIr = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tspbProgreso = new System.Windows.Forms.ToolStripProgressBar();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.rtxtHtmlCode = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.historialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostrarTodoElHistorialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.estadoBarra = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIr
            // 
            this.btnIr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIr.Location = new System.Drawing.Point(858, 25);
            this.btnIr.Name = "btnIr";
            this.btnIr.Size = new System.Drawing.Size(60, 20);
            this.btnIr.TabIndex = 0;
            this.btnIr.Text = "-->";
            this.btnIr.UseVisualStyleBackColor = true;
            this.btnIr.Click += new System.EventHandler(this.btnIr_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspbProgreso,
            this.estadoBarra});
            this.statusStrip.Location = new System.Drawing.Point(0, 392);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(918, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tspbProgreso
            // 
            this.tspbProgreso.Name = "tspbProgreso";
            this.tspbProgreso.Size = new System.Drawing.Size(100, 16);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(0, 26);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(852, 20);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.Tag = "Introduzca la dirección web";
            this.txtUrl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUrl_KeyDown);
            this.txtUrl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUrl_KeyUp);
            this.txtUrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtUrl_MouseDown);
            this.txtUrl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.txtUrl_MouseMove);
            // 
            // rtxtHtmlCode
            // 
            this.rtxtHtmlCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtxtHtmlCode.Enabled = false;
            this.rtxtHtmlCode.Location = new System.Drawing.Point(0, 52);
            this.rtxtHtmlCode.Name = "rtxtHtmlCode";
            this.rtxtHtmlCode.Size = new System.Drawing.Size(918, 337);
            this.rtxtHtmlCode.TabIndex = 3;
            this.rtxtHtmlCode.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historialToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(918, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // historialToolStripMenuItem
            // 
            this.historialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostrarTodoElHistorialToolStripMenuItem});
            this.historialToolStripMenuItem.Name = "historialToolStripMenuItem";
            this.historialToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.historialToolStripMenuItem.Text = "Historial";
            this.historialToolStripMenuItem.Click += new System.EventHandler(this.historialToolStripMenuItem_Click);
            // 
            // mostrarTodoElHistorialToolStripMenuItem
            // 
            this.mostrarTodoElHistorialToolStripMenuItem.Name = "mostrarTodoElHistorialToolStripMenuItem";
            this.mostrarTodoElHistorialToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.mostrarTodoElHistorialToolStripMenuItem.Text = "Mostrar todo el Historial";
            this.mostrarTodoElHistorialToolStripMenuItem.Click += new System.EventHandler(this.mostrarTodoElHistorialToolStripMenuItem_Click);
            // 
            // estadoBarra
            // 
            this.estadoBarra.Name = "estadoBarra";
            this.estadoBarra.Size = new System.Drawing.Size(0, 17);
            // 
            // frmWebBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 414);
            this.Controls.Add(this.rtxtHtmlCode);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnIr);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmWebBrowser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UTN Web Browser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmWebBrowser_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIr;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar tspbProgreso;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.RichTextBox rtxtHtmlCode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem historialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostrarTodoElHistorialToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel estadoBarra;
    }
}

