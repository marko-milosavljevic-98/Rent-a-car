namespace NRT6017
{
    partial class frmRezervacija
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
            this.cbGodiste = new System.Windows.Forms.ComboBox();
            this.lblGodiste = new System.Windows.Forms.Label();
            this.cbModel = new System.Windows.Forms.ComboBox();
            this.lblModel = new System.Windows.Forms.Label();
            this.cbMarka = new System.Windows.Forms.ComboBox();
            this.lblMarka = new System.Windows.Forms.Label();
            this.cbBrojVrata = new System.Windows.Forms.ComboBox();
            this.lblBrojVrata = new System.Windows.Forms.Label();
            this.cbKaroserija = new System.Windows.Forms.ComboBox();
            this.lblKaroserija = new System.Windows.Forms.Label();
            this.cbKubikaza = new System.Windows.Forms.ComboBox();
            this.lblKubikaza = new System.Windows.Forms.Label();
            this.cbMenjac = new System.Windows.Forms.ComboBox();
            this.lblMenjac = new System.Windows.Forms.Label();
            this.cbPogon = new System.Windows.Forms.ComboBox();
            this.lblPogon = new System.Windows.Forms.Label();
            this.cbGorivo = new System.Windows.Forms.ComboBox();
            this.lblGorivo = new System.Windows.Forms.Label();
            this.btnPDTOA = new System.Windows.Forms.Button();
            this.lbDostupniTermini = new System.Windows.Forms.ListBox();
            this.lbDatumPreuzimanja = new System.Windows.Forms.Label();
            this.lbDatumVracanja = new System.Windows.Forms.Label();
            this.dtpDatumPreuzimanja = new System.Windows.Forms.DateTimePicker();
            this.dtpDatumVracanja = new System.Windows.Forms.DateTimePicker();
            this.lblUkupnaCena = new System.Windows.Forms.Label();
            this.tbxUkupnaCena = new System.Windows.Forms.TextBox();
            this.btnRezervisi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbGodiste
            // 
            this.cbGodiste.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbGodiste.FormattingEnabled = true;
            this.cbGodiste.Location = new System.Drawing.Point(12, 165);
            this.cbGodiste.Name = "cbGodiste";
            this.cbGodiste.Size = new System.Drawing.Size(200, 33);
            this.cbGodiste.TabIndex = 11;
            this.cbGodiste.SelectedIndexChanged += new System.EventHandler(this.pretragaAutomobila);
            // 
            // lblGodiste
            // 
            this.lblGodiste.AutoSize = true;
            this.lblGodiste.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGodiste.Location = new System.Drawing.Point(13, 137);
            this.lblGodiste.Name = "lblGodiste";
            this.lblGodiste.Size = new System.Drawing.Size(172, 25);
            this.lblGodiste.TabIndex = 10;
            this.lblGodiste.Text = "Odaberite godište:";
            // 
            // cbModel
            // 
            this.cbModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbModel.FormattingEnabled = true;
            this.cbModel.Location = new System.Drawing.Point(12, 101);
            this.cbModel.Name = "cbModel";
            this.cbModel.Size = new System.Drawing.Size(200, 33);
            this.cbModel.TabIndex = 9;
            this.cbModel.SelectedIndexChanged += new System.EventHandler(this.pretragaAutomobila);
            // 
            // lblModel
            // 
            this.lblModel.AutoSize = true;
            this.lblModel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblModel.Location = new System.Drawing.Point(13, 73);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(162, 25);
            this.lblModel.TabIndex = 8;
            this.lblModel.Text = "Odaberite model:";
            // 
            // cbMarka
            // 
            this.cbMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbMarka.FormattingEnabled = true;
            this.cbMarka.Location = new System.Drawing.Point(12, 37);
            this.cbMarka.Name = "cbMarka";
            this.cbMarka.Size = new System.Drawing.Size(200, 33);
            this.cbMarka.TabIndex = 7;
            this.cbMarka.SelectedIndexChanged += new System.EventHandler(this.pretragaAutomobila);
            // 
            // lblMarka
            // 
            this.lblMarka.AutoSize = true;
            this.lblMarka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMarka.Location = new System.Drawing.Point(13, 9);
            this.lblMarka.Name = "lblMarka";
            this.lblMarka.Size = new System.Drawing.Size(163, 25);
            this.lblMarka.TabIndex = 6;
            this.lblMarka.Text = "Odaberite marku:";
            // 
            // cbBrojVrata
            // 
            this.cbBrojVrata.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbBrojVrata.FormattingEnabled = true;
            this.cbBrojVrata.Location = new System.Drawing.Point(284, 165);
            this.cbBrojVrata.Name = "cbBrojVrata";
            this.cbBrojVrata.Size = new System.Drawing.Size(200, 33);
            this.cbBrojVrata.TabIndex = 17;
            this.cbBrojVrata.SelectedIndexChanged += new System.EventHandler(this.pretragaAutomobila);
            // 
            // lblBrojVrata
            // 
            this.lblBrojVrata.AutoSize = true;
            this.lblBrojVrata.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblBrojVrata.Location = new System.Drawing.Point(289, 137);
            this.lblBrojVrata.Name = "lblBrojVrata";
            this.lblBrojVrata.Size = new System.Drawing.Size(189, 25);
            this.lblBrojVrata.TabIndex = 16;
            this.lblBrojVrata.Text = "Odaberite broj vrata:";
            // 
            // cbKaroserija
            // 
            this.cbKaroserija.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbKaroserija.FormattingEnabled = true;
            this.cbKaroserija.Location = new System.Drawing.Point(284, 101);
            this.cbKaroserija.Name = "cbKaroserija";
            this.cbKaroserija.Size = new System.Drawing.Size(200, 33);
            this.cbKaroserija.TabIndex = 15;
            this.cbKaroserija.SelectedIndexChanged += new System.EventHandler(this.pretragaAutomobila);
            // 
            // lblKaroserija
            // 
            this.lblKaroserija.AutoSize = true;
            this.lblKaroserija.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKaroserija.Location = new System.Drawing.Point(289, 73);
            this.lblKaroserija.Name = "lblKaroserija";
            this.lblKaroserija.Size = new System.Drawing.Size(193, 25);
            this.lblKaroserija.TabIndex = 14;
            this.lblKaroserija.Text = "Odaberite karoseriju:";
            // 
            // cbKubikaza
            // 
            this.cbKubikaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbKubikaza.FormattingEnabled = true;
            this.cbKubikaza.Location = new System.Drawing.Point(284, 37);
            this.cbKubikaza.Name = "cbKubikaza";
            this.cbKubikaza.Size = new System.Drawing.Size(200, 33);
            this.cbKubikaza.TabIndex = 13;
            this.cbKubikaza.SelectedIndexChanged += new System.EventHandler(this.pretragaAutomobila);
            // 
            // lblKubikaza
            // 
            this.lblKubikaza.AutoSize = true;
            this.lblKubikaza.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblKubikaza.Location = new System.Drawing.Point(289, 9);
            this.lblKubikaza.Name = "lblKubikaza";
            this.lblKubikaza.Size = new System.Drawing.Size(187, 25);
            this.lblKubikaza.TabIndex = 12;
            this.lblKubikaza.Text = "Odaberite kubikažu:";
            // 
            // cbMenjac
            // 
            this.cbMenjac.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbMenjac.FormattingEnabled = true;
            this.cbMenjac.Location = new System.Drawing.Point(588, 165);
            this.cbMenjac.Name = "cbMenjac";
            this.cbMenjac.Size = new System.Drawing.Size(200, 33);
            this.cbMenjac.TabIndex = 23;
            this.cbMenjac.SelectedIndexChanged += new System.EventHandler(this.pretragaAutomobila);
            // 
            // lblMenjac
            // 
            this.lblMenjac.AutoSize = true;
            this.lblMenjac.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMenjac.Location = new System.Drawing.Point(593, 137);
            this.lblMenjac.Name = "lblMenjac";
            this.lblMenjac.Size = new System.Drawing.Size(172, 25);
            this.lblMenjac.TabIndex = 22;
            this.lblMenjac.Text = "Odaberite menjač:";
            // 
            // cbPogon
            // 
            this.cbPogon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPogon.FormattingEnabled = true;
            this.cbPogon.Location = new System.Drawing.Point(588, 101);
            this.cbPogon.Name = "cbPogon";
            this.cbPogon.Size = new System.Drawing.Size(200, 33);
            this.cbPogon.TabIndex = 21;
            this.cbPogon.SelectedIndexChanged += new System.EventHandler(this.pretragaAutomobila);
            // 
            // lblPogon
            // 
            this.lblPogon.AutoSize = true;
            this.lblPogon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPogon.Location = new System.Drawing.Point(593, 73);
            this.lblPogon.Name = "lblPogon";
            this.lblPogon.Size = new System.Drawing.Size(164, 25);
            this.lblPogon.TabIndex = 20;
            this.lblPogon.Text = "Odaberite pogon:";
            // 
            // cbGorivo
            // 
            this.cbGorivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbGorivo.FormattingEnabled = true;
            this.cbGorivo.Location = new System.Drawing.Point(588, 37);
            this.cbGorivo.Name = "cbGorivo";
            this.cbGorivo.Size = new System.Drawing.Size(200, 33);
            this.cbGorivo.TabIndex = 19;
            this.cbGorivo.SelectedIndexChanged += new System.EventHandler(this.pretragaAutomobila);
            // 
            // lblGorivo
            // 
            this.lblGorivo.AutoSize = true;
            this.lblGorivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblGorivo.Location = new System.Drawing.Point(593, 9);
            this.lblGorivo.Name = "lblGorivo";
            this.lblGorivo.Size = new System.Drawing.Size(162, 25);
            this.lblGorivo.TabIndex = 18;
            this.lblGorivo.Text = "Odaberite gorivo:";
            // 
            // btnPDTOA
            // 
            this.btnPDTOA.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPDTOA.Location = new System.Drawing.Point(12, 217);
            this.btnPDTOA.Name = "btnPDTOA";
            this.btnPDTOA.Size = new System.Drawing.Size(776, 45);
            this.btnPDTOA.TabIndex = 24;
            this.btnPDTOA.Text = "Prikaži dostupne termine odabranog automobila:\r\n";
            this.btnPDTOA.UseVisualStyleBackColor = true;
            this.btnPDTOA.Click += new System.EventHandler(this.btnPDTOA_Click);
            // 
            // lbDostupniTermini
            // 
            this.lbDostupniTermini.FormattingEnabled = true;
            this.lbDostupniTermini.Location = new System.Drawing.Point(12, 268);
            this.lbDostupniTermini.Name = "lbDostupniTermini";
            this.lbDostupniTermini.Size = new System.Drawing.Size(776, 147);
            this.lbDostupniTermini.TabIndex = 25;
            this.lbDostupniTermini.SelectedIndexChanged += new System.EventHandler(this.lbDostupniTermini_SelectedIndexChanged);
            // 
            // lbDatumPreuzimanja
            // 
            this.lbDatumPreuzimanja.AutoSize = true;
            this.lbDatumPreuzimanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbDatumPreuzimanja.Location = new System.Drawing.Point(13, 427);
            this.lbDatumPreuzimanja.Name = "lbDatumPreuzimanja";
            this.lbDatumPreuzimanja.Size = new System.Drawing.Size(274, 25);
            this.lbDatumPreuzimanja.TabIndex = 26;
            this.lbDatumPreuzimanja.Text = "Odaberite datum preuzimanja:";
            // 
            // lbDatumVracanja
            // 
            this.lbDatumVracanja.AutoSize = true;
            this.lbDatumVracanja.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbDatumVracanja.Location = new System.Drawing.Point(13, 478);
            this.lbDatumVracanja.Name = "lbDatumVracanja";
            this.lbDatumVracanja.Size = new System.Drawing.Size(242, 25);
            this.lbDatumVracanja.TabIndex = 27;
            this.lbDatumVracanja.Text = "Odaberite datum vraćanja:";
            // 
            // dtpDatumPreuzimanja
            // 
            this.dtpDatumPreuzimanja.Location = new System.Drawing.Point(18, 455);
            this.dtpDatumPreuzimanja.Name = "dtpDatumPreuzimanja";
            this.dtpDatumPreuzimanja.Size = new System.Drawing.Size(269, 20);
            this.dtpDatumPreuzimanja.TabIndex = 28;
            this.dtpDatumPreuzimanja.ValueChanged += new System.EventHandler(this.dtpDatumPreuzimanja_ValueChanged);
            // 
            // dtpDatumVracanja
            // 
            this.dtpDatumVracanja.Location = new System.Drawing.Point(18, 506);
            this.dtpDatumVracanja.Name = "dtpDatumVracanja";
            this.dtpDatumVracanja.Size = new System.Drawing.Size(269, 20);
            this.dtpDatumVracanja.TabIndex = 29;
            this.dtpDatumVracanja.ValueChanged += new System.EventHandler(this.dtpDatumPreuzimanja_ValueChanged);
            // 
            // lblUkupnaCena
            // 
            this.lblUkupnaCena.AutoSize = true;
            this.lblUkupnaCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblUkupnaCena.Location = new System.Drawing.Point(553, 447);
            this.lblUkupnaCena.Name = "lblUkupnaCena";
            this.lblUkupnaCena.Size = new System.Drawing.Size(233, 25);
            this.lblUkupnaCena.TabIndex = 30;
            this.lblUkupnaCena.Text = "Ukupna cena rezervacije:";
            // 
            // tbxUkupnaCena
            // 
            this.tbxUkupnaCena.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tbxUkupnaCena.Location = new System.Drawing.Point(558, 475);
            this.tbxUkupnaCena.Name = "tbxUkupnaCena";
            this.tbxUkupnaCena.ReadOnly = true;
            this.tbxUkupnaCena.Size = new System.Drawing.Size(228, 30);
            this.tbxUkupnaCena.TabIndex = 31;
            // 
            // btnRezervisi
            // 
            this.btnRezervisi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnRezervisi.Location = new System.Drawing.Point(12, 532);
            this.btnRezervisi.Name = "btnRezervisi";
            this.btnRezervisi.Size = new System.Drawing.Size(776, 45);
            this.btnRezervisi.TabIndex = 32;
            this.btnRezervisi.Text = "Rezerviši";
            this.btnRezervisi.UseVisualStyleBackColor = true;
            this.btnRezervisi.Click += new System.EventHandler(this.btnRezervisi_Click);
            // 
            // frmRezervacija
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 597);
            this.Controls.Add(this.btnRezervisi);
            this.Controls.Add(this.tbxUkupnaCena);
            this.Controls.Add(this.lblUkupnaCena);
            this.Controls.Add(this.dtpDatumVracanja);
            this.Controls.Add(this.dtpDatumPreuzimanja);
            this.Controls.Add(this.lbDatumVracanja);
            this.Controls.Add(this.lbDatumPreuzimanja);
            this.Controls.Add(this.lbDostupniTermini);
            this.Controls.Add(this.btnPDTOA);
            this.Controls.Add(this.cbMenjac);
            this.Controls.Add(this.lblMenjac);
            this.Controls.Add(this.cbPogon);
            this.Controls.Add(this.lblPogon);
            this.Controls.Add(this.cbGorivo);
            this.Controls.Add(this.lblGorivo);
            this.Controls.Add(this.cbBrojVrata);
            this.Controls.Add(this.lblBrojVrata);
            this.Controls.Add(this.cbKaroserija);
            this.Controls.Add(this.lblKaroserija);
            this.Controls.Add(this.cbKubikaza);
            this.Controls.Add(this.lblKubikaza);
            this.Controls.Add(this.cbGodiste);
            this.Controls.Add(this.lblGodiste);
            this.Controls.Add(this.cbModel);
            this.Controls.Add(this.lblModel);
            this.Controls.Add(this.cbMarka);
            this.Controls.Add(this.lblMarka);
            this.Name = "frmRezervacija";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rezervacija";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmRezervacija_FormClosed);
            this.Load += new System.EventHandler(this.frmRezervacija_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbGodiste;
        private System.Windows.Forms.Label lblGodiste;
        private System.Windows.Forms.ComboBox cbModel;
        private System.Windows.Forms.Label lblModel;
        private System.Windows.Forms.ComboBox cbMarka;
        private System.Windows.Forms.Label lblMarka;
        private System.Windows.Forms.ComboBox cbBrojVrata;
        private System.Windows.Forms.Label lblBrojVrata;
        private System.Windows.Forms.ComboBox cbKaroserija;
        private System.Windows.Forms.Label lblKaroserija;
        private System.Windows.Forms.ComboBox cbKubikaza;
        private System.Windows.Forms.Label lblKubikaza;
        private System.Windows.Forms.ComboBox cbMenjac;
        private System.Windows.Forms.Label lblMenjac;
        private System.Windows.Forms.ComboBox cbPogon;
        private System.Windows.Forms.Label lblPogon;
        private System.Windows.Forms.ComboBox cbGorivo;
        private System.Windows.Forms.Label lblGorivo;
        private System.Windows.Forms.Button btnPDTOA;
        private System.Windows.Forms.ListBox lbDostupniTermini;
        private System.Windows.Forms.Label lbDatumPreuzimanja;
        private System.Windows.Forms.Label lbDatumVracanja;
        private System.Windows.Forms.DateTimePicker dtpDatumPreuzimanja;
        private System.Windows.Forms.DateTimePicker dtpDatumVracanja;
        private System.Windows.Forms.Label lblUkupnaCena;
        private System.Windows.Forms.TextBox tbxUkupnaCena;
        private System.Windows.Forms.Button btnRezervisi;
    }
}