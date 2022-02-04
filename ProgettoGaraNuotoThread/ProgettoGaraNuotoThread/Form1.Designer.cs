namespace ProgettoGaraNuotoThread
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtA1 = new System.Windows.Forms.TextBox();
            this.txtA2 = new System.Windows.Forms.TextBox();
            this.txtA3 = new System.Windows.Forms.TextBox();
            this.txtA4 = new System.Windows.Forms.TextBox();
            this.lblAtleti = new System.Windows.Forms.Label();
            this.lblTurno = new System.Windows.Forms.Label();
            this.lblStato = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblEsito = new System.Windows.Forms.Label();
            this.lblEliminati = new System.Windows.Forms.Label();
            this.btnAvvia = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(24, 71);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(630, 630);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // txtA1
            // 
            this.txtA1.Location = new System.Drawing.Point(40, 40);
            this.txtA1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtA1.Name = "txtA1";
            this.txtA1.Size = new System.Drawing.Size(118, 23);
            this.txtA1.TabIndex = 1;
            // 
            // txtA2
            // 
            this.txtA2.Location = new System.Drawing.Point(203, 40);
            this.txtA2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtA2.Name = "txtA2";
            this.txtA2.Size = new System.Drawing.Size(110, 23);
            this.txtA2.TabIndex = 2;
            this.txtA2.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // txtA3
            // 
            this.txtA3.Location = new System.Drawing.Point(359, 40);
            this.txtA3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtA3.Name = "txtA3";
            this.txtA3.Size = new System.Drawing.Size(111, 23);
            this.txtA3.TabIndex = 3;
            // 
            // txtA4
            // 
            this.txtA4.Location = new System.Drawing.Point(510, 40);
            this.txtA4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtA4.Name = "txtA4";
            this.txtA4.Size = new System.Drawing.Size(119, 23);
            this.txtA4.TabIndex = 4;
            // 
            // lblAtleti
            // 
            this.lblAtleti.AutoSize = true;
            this.lblAtleti.Location = new System.Drawing.Point(897, 28);
            this.lblAtleti.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAtleti.Name = "lblAtleti";
            this.lblAtleti.Size = new System.Drawing.Size(69, 16);
            this.lblAtleti.TabIndex = 5;
            this.lblAtleti.Text = "[lblAtleti]";
            // 
            // lblTurno
            // 
            this.lblTurno.AutoSize = true;
            this.lblTurno.Location = new System.Drawing.Point(897, 495);
            this.lblTurno.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTurno.Name = "lblTurno";
            this.lblTurno.Size = new System.Drawing.Size(71, 16);
            this.lblTurno.TabIndex = 6;
            this.lblTurno.Text = "[lblTurno]";
            // 
            // lblStato
            // 
            this.lblStato.AutoSize = true;
            this.lblStato.Location = new System.Drawing.Point(897, 532);
            this.lblStato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStato.Name = "lblStato";
            this.lblStato.Size = new System.Drawing.Size(71, 16);
            this.lblStato.TabIndex = 7;
            this.lblStato.Text = "[lblStato]";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblEsito);
            this.groupBox1.Location = new System.Drawing.Point(901, 583);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(155, 179);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BATTERIA FINALISTI";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblEliminati);
            this.groupBox2.Location = new System.Drawing.Point(1084, 583);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(165, 179);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "ELIMINATI";
            // 
            // lblEsito
            // 
            this.lblEsito.AutoSize = true;
            this.lblEsito.Location = new System.Drawing.Point(8, 43);
            this.lblEsito.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEsito.Name = "lblEsito";
            this.lblEsito.Size = new System.Drawing.Size(66, 16);
            this.lblEsito.TabIndex = 10;
            this.lblEsito.Text = "[lblEsito]";
            // 
            // lblEliminati
            // 
            this.lblEliminati.AutoSize = true;
            this.lblEliminati.Location = new System.Drawing.Point(8, 43);
            this.lblEliminati.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEliminati.Name = "lblEliminati";
            this.lblEliminati.Size = new System.Drawing.Size(87, 16);
            this.lblEliminati.TabIndex = 11;
            this.lblEliminati.Text = "[lblEliminati]";
            // 
            // btnAvvia
            // 
            this.btnAvvia.Location = new System.Drawing.Point(1151, 28);
            this.btnAvvia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAvvia.Name = "btnAvvia";
            this.btnAvvia.Size = new System.Drawing.Size(156, 79);
            this.btnAvvia.TabIndex = 10;
            this.btnAvvia.Text = "AVVIA";
            this.btnAvvia.UseVisualStyleBackColor = true;
            this.btnAvvia.Click += new System.EventHandler(this.BtnAvvia_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1395, 924);
            this.Controls.Add(this.btnAvvia);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblStato);
            this.Controls.Add(this.lblTurno);
            this.Controls.Add(this.lblAtleti);
            this.Controls.Add(this.txtA4);
            this.Controls.Add(this.txtA3);
            this.Controls.Add(this.txtA2);
            this.Controls.Add(this.txtA1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtA1;
        private System.Windows.Forms.TextBox txtA2;
        private System.Windows.Forms.TextBox txtA3;
        private System.Windows.Forms.TextBox txtA4;
        private System.Windows.Forms.Label lblAtleti;
        private System.Windows.Forms.Label lblTurno;
        private System.Windows.Forms.Label lblStato;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEsito;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblEliminati;
        private System.Windows.Forms.Button btnAvvia;
    }
}

