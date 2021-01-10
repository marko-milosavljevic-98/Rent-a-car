namespace NRT6017
{
    partial class frmKupac
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
            this.lblKupac = new System.Windows.Forms.Label();
            this.lbRezervacije = new System.Windows.Forms.ListBox();
            this.btnObrisi = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.lblTrenutneRezervacije = new System.Windows.Forms.Label();
            this.tbxKupac = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblKupac
            // 
            this.lblKupac.AutoSize = true;
            this.lblKupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKupac.Location = new System.Drawing.Point(133, 9);
            this.lblKupac.Name = "lblKupac";
            this.lblKupac.Size = new System.Drawing.Size(69, 25);
            this.lblKupac.TabIndex = 4;
            this.lblKupac.Text = "Kupac";
            // 
            // lbRezervacije
            // 
            this.lbRezervacije.FormattingEnabled = true;
            this.lbRezervacije.Location = new System.Drawing.Point(208, 42);
            this.lbRezervacije.Name = "lbRezervacije";
            this.lbRezervacije.Size = new System.Drawing.Size(580, 316);
            this.lbRezervacije.TabIndex = 6;
            // 
            // btnObrisi
            // 
            this.btnObrisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnObrisi.Location = new System.Drawing.Point(668, 364);
            this.btnObrisi.Name = "btnObrisi";
            this.btnObrisi.Size = new System.Drawing.Size(120, 34);
            this.btnObrisi.TabIndex = 29;
            this.btnObrisi.Text = "Obriši";
            this.btnObrisi.UseVisualStyleBackColor = true;
            this.btnObrisi.Click += new System.EventHandler(this.btnObrisi_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDodaj.Location = new System.Drawing.Point(426, 364);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(240, 34);
            this.btnDodaj.TabIndex = 28;
            this.btnDodaj.Text = "Nova rezervacija";
            this.btnDodaj.UseVisualStyleBackColor = true;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // lblTrenutneRezervacije
            // 
            this.lblTrenutneRezervacije.AutoSize = true;
            this.lblTrenutneRezervacije.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblTrenutneRezervacije.Location = new System.Drawing.Point(12, 42);
            this.lblTrenutneRezervacije.Name = "lblTrenutneRezervacije";
            this.lblTrenutneRezervacije.Size = new System.Drawing.Size(190, 25);
            this.lblTrenutneRezervacije.TabIndex = 30;
            this.lblTrenutneRezervacije.Text = "Trenutne rezervacije";
            // 
            // tbxKupac
            // 
            this.tbxKupac.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxKupac.Location = new System.Drawing.Point(208, 6);
            this.tbxKupac.Name = "tbxKupac";
            this.tbxKupac.ReadOnly = true;
            this.tbxKupac.Size = new System.Drawing.Size(580, 30);
            this.tbxKupac.TabIndex = 31;
            // 
            // frmKupac
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxKupac);
            this.Controls.Add(this.lblTrenutneRezervacije);
            this.Controls.Add(this.btnObrisi);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.lbRezervacije);
            this.Controls.Add(this.lblKupac);
            this.Name = "frmKupac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kupac";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmKupac_FormClosed);
            this.Load += new System.EventHandler(this.FrmKupac_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblKupac;
        private System.Windows.Forms.ListBox lbRezervacije;
        private System.Windows.Forms.Button btnObrisi;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Label lblTrenutneRezervacije;
        private System.Windows.Forms.TextBox tbxKupac;
    }
}