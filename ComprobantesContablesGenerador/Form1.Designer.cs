namespace ComprobantesContablesGenerador
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nupCantidadComprobantes = new System.Windows.Forms.NumericUpDown();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnExaminarCuentas = new System.Windows.Forms.Button();
            this.txtCuentas = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParties = new System.Windows.Forms.TextBox();
            this.btnExaminarParties = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtComprobante = new System.Windows.Forms.TextBox();
            this.btnExaminarComprobante = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTiempoTotal = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.nupCantidadComprobantes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Comprobantes a generar";
            // 
            // nupCantidadComprobantes
            // 
            this.nupCantidadComprobantes.Location = new System.Drawing.Point(224, 13);
            this.nupCantidadComprobantes.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nupCantidadComprobantes.Name = "nupCantidadComprobantes";
            this.nupCantidadComprobantes.Size = new System.Drawing.Size(48, 20);
            this.nupCantidadComprobantes.TabIndex = 1;
            this.nupCantidadComprobantes.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(114, 239);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(146, 30);
            this.btnGenerar.TabIndex = 16;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnExaminarCuentas
            // 
            this.btnExaminarCuentas.Location = new System.Drawing.Point(280, 182);
            this.btnExaminarCuentas.Name = "btnExaminarCuentas";
            this.btnExaminarCuentas.Size = new System.Drawing.Size(83, 26);
            this.btnExaminarCuentas.TabIndex = 15;
            this.btnExaminarCuentas.Text = "Examinar...";
            this.btnExaminarCuentas.UseVisualStyleBackColor = true;
            this.btnExaminarCuentas.Click += new System.EventHandler(this.btnExaminarCuentas_Click);
            // 
            // txtCuentas
            // 
            this.txtCuentas.Location = new System.Drawing.Point(10, 188);
            this.txtCuentas.Name = "txtCuentas";
            this.txtCuentas.Size = new System.Drawing.Size(264, 20);
            this.txtCuentas.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Cargue el archivo de CUENTAS bien formado";
            // 
            // txtParties
            // 
            this.txtParties.Location = new System.Drawing.Point(10, 133);
            this.txtParties.Name = "txtParties";
            this.txtParties.Size = new System.Drawing.Size(264, 20);
            this.txtParties.TabIndex = 12;
            // 
            // btnExaminarParties
            // 
            this.btnExaminarParties.Location = new System.Drawing.Point(280, 129);
            this.btnExaminarParties.Name = "btnExaminarParties";
            this.btnExaminarParties.Size = new System.Drawing.Size(83, 24);
            this.btnExaminarParties.TabIndex = 11;
            this.btnExaminarParties.Text = "Examinar...";
            this.btnExaminarParties.UseVisualStyleBackColor = true;
            this.btnExaminarParties.Click += new System.EventHandler(this.btnExaminarParties_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(208, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cargue el archivo de PARTY bien formado";
            // 
            // txtComprobante
            // 
            this.txtComprobante.Location = new System.Drawing.Point(10, 82);
            this.txtComprobante.Name = "txtComprobante";
            this.txtComprobante.Size = new System.Drawing.Size(264, 20);
            this.txtComprobante.TabIndex = 19;
            // 
            // btnExaminarComprobante
            // 
            this.btnExaminarComprobante.Location = new System.Drawing.Point(280, 78);
            this.btnExaminarComprobante.Name = "btnExaminarComprobante";
            this.btnExaminarComprobante.Size = new System.Drawing.Size(83, 24);
            this.btnExaminarComprobante.TabIndex = 18;
            this.btnExaminarComprobante.Text = "Examinar...";
            this.btnExaminarComprobante.UseVisualStyleBackColor = true;
            this.btnExaminarComprobante.Click += new System.EventHandler(this.btnExaminarComprobante_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(235, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Cargue el archivo de Comprobante bien formado";
            // 
            // lblTiempoTotal
            // 
            this.lblTiempoTotal.AutoSize = true;
            this.lblTiempoTotal.Location = new System.Drawing.Point(12, 223);
            this.lblTiempoTotal.Name = "lblTiempoTotal";
            this.lblTiempoTotal.Size = new System.Drawing.Size(0, 13);
            this.lblTiempoTotal.TabIndex = 20;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 281);
            this.Controls.Add(this.lblTiempoTotal);
            this.Controls.Add(this.txtComprobante);
            this.Controls.Add(this.btnExaminarComprobante);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.btnExaminarCuentas);
            this.Controls.Add(this.txtCuentas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtParties);
            this.Controls.Add(this.btnExaminarParties);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nupCantidadComprobantes);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Generador de Comprobantes";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupCantidadComprobantes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupCantidadComprobantes;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExaminarCuentas;
        private System.Windows.Forms.TextBox txtCuentas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParties;
        private System.Windows.Forms.Button btnExaminarParties;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtComprobante;
        private System.Windows.Forms.Button btnExaminarComprobante;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTiempoTotal;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

