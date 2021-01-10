using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static NRT6017.StatickeMetode;

namespace NRT6017
{
    public partial class frmRezervacija : Form
    {
        private Kupac izabraniKupac;
        private List<Automobil> automobili;
        private List<Automobil> automobiliKopija;
        private List<Ponuda> ponude;
        Automobil kreiranAutomobil;
        StreamWriter upis;


        public frmRezervacija(Kupac izabraniKupac)
        {
            this.izabraniKupac = izabraniKupac;
            InitializeComponent();
        }

        private void frmRezervacija_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            frmKupac kupac = new frmKupac(izabraniKupac);
            kupac.Show();
        }

        private void pretragaAutomobila(object sender, EventArgs e)
        {
            automobiliKopija =automobili.ToList<Automobil>();
            kreiranAutomobil = new Automobil();
            int selektovanIndeks = (sender as ComboBox).SelectedIndex;

            if (cbMarka.SelectedIndex > 0)
            {
                kreiranAutomobil.Marka = cbMarka.SelectedItem.ToString();
                for (int i = 0; i < automobiliKopija.Count; i++)
                {
                    if (automobiliKopija[i].Marka != kreiranAutomobil.Marka)
                    {
                        automobiliKopija.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                kreiranAutomobil.Marka = "NEDEFINISANO";
            }
            if (cbModel.SelectedIndex > 0)
            {
                kreiranAutomobil.Model = cbModel.SelectedItem.ToString();
                for (int i = 0; i < automobiliKopija.Count; i++)
                {
                    if (automobiliKopija[i].Model != kreiranAutomobil.Model)
                    {
                        automobiliKopija.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                kreiranAutomobil.Model = "NEDEFINISANO";
            }
            if (cbGodiste.SelectedIndex > 0)
            {

                kreiranAutomobil.Godiste = Int32.Parse(cbGodiste.SelectedItem.ToString());
                for (int i = 0; i < automobiliKopija.Count; i++)
                {
                    if (automobiliKopija[i].Godiste != kreiranAutomobil.Godiste)
                    {
                        automobiliKopija.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                kreiranAutomobil.Godiste = 0;
            }

            if (cbKubikaza.SelectedIndex > 0)
            {
                kreiranAutomobil.Kubikaza = Int32.Parse(cbKubikaza.SelectedItem.ToString());
                for (int i = 0; i < automobiliKopija.Count; i++)
                {
                    if (automobiliKopija[i].Kubikaza != kreiranAutomobil.Kubikaza)
                    {
                        automobiliKopija.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                kreiranAutomobil.Kubikaza = 0;
            }
            if (cbKaroserija.SelectedIndex > 0)
            {
                kreiranAutomobil.Karoserija = cbKaroserija.SelectedItem.ToString();
                for (int i = 0; i < automobiliKopija.Count; i++)
                {
                    if (automobiliKopija[i].Karoserija != kreiranAutomobil.Karoserija)
                    {
                        automobiliKopija.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                kreiranAutomobil.Karoserija = "NEDEFINISANO";
            }
            if (cbBrojVrata.SelectedIndex > 0)
            {

                kreiranAutomobil.BrVrata = Int32.Parse(cbBrojVrata.SelectedItem.ToString());
                for (int i = 0; i < automobiliKopija.Count; i++)
                {
                    if (automobiliKopija[i].BrVrata != kreiranAutomobil.BrVrata)
                    {
                        automobiliKopija.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                kreiranAutomobil.BrVrata = 0;
            }

            if (cbGorivo.SelectedIndex > 0)
            {
                kreiranAutomobil.Gorivo = cbGorivo.SelectedItem.ToString();
                for (int i = 0; i < automobiliKopija.Count; i++)
                {
                    if (automobiliKopija[i].Gorivo != kreiranAutomobil.Gorivo)
                    {
                        automobiliKopija.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                kreiranAutomobil.Gorivo = "NEDEFINISANO";
            }
            if (cbPogon.SelectedIndex > 0)
            {
                kreiranAutomobil.Pogon = cbPogon.SelectedItem.ToString();
                for (int i = 0; i < automobiliKopija.Count; i++)
                {
                    if (automobiliKopija[i].Pogon != kreiranAutomobil.Pogon)
                    {
                        automobiliKopija.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                kreiranAutomobil.Pogon = "NEDEFINISANO";
            }
            if (cbMenjac.SelectedIndex > 0)
            {
                kreiranAutomobil.VrstaMenjaca = cbMenjac.SelectedItem.ToString();
                for (int i = 0; i < automobiliKopija.Count; i++)
                {
                    if (automobiliKopija[i].VrstaMenjaca != kreiranAutomobil.VrstaMenjaca)
                    {
                        automobiliKopija.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                kreiranAutomobil.VrstaMenjaca = "NEDEFINISANO";
            }
            
            //MessageBox.Show(cbKaroserija.SelectedIndex.ToString());
            int[] niz=new int[9];

            niz[0] = cbMarka.SelectedIndex > 0 ? 1 : 0;
            niz[1] = cbModel.SelectedIndex > 0 ? 1 : 0;
            niz[2] = cbGodiste.SelectedIndex > 0 ? 1 : 0;
            niz[3] = cbKubikaza.SelectedIndex > 0 ? 1 : 0;
            niz[4] = cbKaroserija.SelectedIndex > 0 ? 1 : 0;
            niz[5] = cbBrojVrata.SelectedIndex > 0 ? 1 : 0;
            niz[6] = cbGorivo.SelectedIndex > 0 ? 1 : 0;
            niz[7] = cbPogon.SelectedIndex > 0 ? 1 : 0;
            niz[8] = cbMenjac.SelectedIndex > 0 ? 1 : 0;

            cbMarka.Items.Clear();
            cbModel.Items.Clear();
            cbGodiste.Items.Clear();
            cbKubikaza.Items.Clear();
            cbKaroserija.Items.Clear();
            cbBrojVrata.Items.Clear();
            cbGorivo.Items.Clear();
            cbPogon.Items.Clear();
            cbMenjac.Items.Clear();
            

            cbMarka.Items.Add("NEDEFINISANO");
            cbModel.Items.Add("NEDEFINISANO");
            cbGodiste.Items.Add("NEDEFINISANO");
            cbKubikaza.Items.Add("NEDEFINISANO");
            cbKaroserija.Items.Add("NEDEFINISANO");
            cbBrojVrata.Items.Add("NEDEFINISANO");
            cbGorivo.Items.Add("NEDEFINISANO");
            cbPogon.Items.Add("NEDEFINISANO");
            cbMenjac.Items.Add("NEDEFINISANO");

            foreach (Automobil automobil in automobiliKopija)
            {
                if (cbMarka.SelectedIndex <= 0) if (cbMarka.Items.Contains(automobil.Marka) == false) cbMarka.Items.Add(automobil.Marka);
                if (cbModel.SelectedIndex <= 0) if (cbModel.Items.Contains(automobil.Model) == false) cbModel.Items.Add(automobil.Model);
                if (cbGodiste.SelectedIndex <= 0) if (cbGodiste.Items.Contains(automobil.Godiste) == false) cbGodiste.Items.Add(automobil.Godiste);
                if (cbKubikaza.SelectedIndex <= 0) if (cbKubikaza.Items.Contains(automobil.Kubikaza) == false) cbKubikaza.Items.Add(automobil.Kubikaza);
                if (cbKaroserija.SelectedIndex <= 0) if (cbKaroserija.Items.Contains(automobil.Karoserija) == false) cbKaroserija.Items.Add(automobil.Karoserija);
                if (cbBrojVrata.SelectedIndex <= 0) if (cbBrojVrata.Items.Contains(automobil.BrVrata) == false) cbBrojVrata.Items.Add(automobil.BrVrata);
                if (cbGorivo.SelectedIndex <= 0) if (cbGorivo.Items.Contains(automobil.Gorivo) == false) cbGorivo.Items.Add(automobil.Gorivo);
                if (cbPogon.SelectedIndex <= 0) if (cbPogon.Items.Contains(automobil.Pogon) == false) cbPogon.Items.Add(automobil.Pogon);
                if (cbMenjac.SelectedIndex <= 0) if (cbMenjac.Items.Contains(automobil.VrstaMenjaca) == false) cbMenjac.Items.Add(automobil.VrstaMenjaca);
            }
            foreach (Control kontrola in this.Controls)
            {
                if (kontrola is ComboBox)
                    ((ComboBox)kontrola).SelectedIndexChanged -= new EventHandler(pretragaAutomobila);
            }            

            cbMarka.SelectedIndex = niz[0];
            cbModel.SelectedIndex = niz[1];
            cbGodiste.SelectedIndex = niz[2];
            cbKubikaza.SelectedIndex = niz[3];
            cbKaroserija.SelectedIndex = niz[4];
            cbBrojVrata.SelectedIndex = niz[5];
            cbGorivo.SelectedIndex = niz[6];
            cbPogon.SelectedIndex = niz[7];
            cbMenjac.SelectedIndex = niz[8];

            foreach (Control kontrola in this.Controls)
            {
                if (kontrola is ComboBox)
                    ((ComboBox)kontrola).SelectedIndexChanged += new EventHandler(pretragaAutomobila);
            }
            //MessageBox.Show(cbKaroserija.SelectedIndex.ToString());

            if (selektovanIndeks > 0)
            {
                (sender as ComboBox).SelectedIndexChanged -= pretragaAutomobila;
                (sender as ComboBox).SelectedIndex = 1;
                (sender as ComboBox).SelectedIndexChanged += pretragaAutomobila;
            }
            else
            {
                (sender as ComboBox).SelectedIndexChanged -= pretragaAutomobila;
                (sender as ComboBox).SelectedIndex = 0;
                (sender as ComboBox).SelectedIndexChanged += pretragaAutomobila;
            }  
        }        
        

        private void frmRezervacija_Load(object sender, EventArgs e)
        {            
            automobili = UcitajAutomobile();
            automobiliKopija = automobili;     
            
            cbMarka.Items.Add("NEDEFINISANO");
            cbModel.Items.Add("NEDEFINISANO");
            cbGodiste.Items.Add("NEDEFINISANO");
            cbKubikaza.Items.Add("NEDEFINISANO");
            cbKaroserija.Items.Add("NEDEFINISANO");
            cbBrojVrata.Items.Add("NEDEFINISANO");
            cbGorivo.Items.Add("NEDEFINISANO");
            cbPogon.Items.Add("NEDEFINISANO");
            cbMenjac.Items.Add("NEDEFINISANO");

            foreach (Automobil automobil in automobiliKopija)
            {
                if (cbMarka.SelectedIndex <= 0) if(cbMarka.Items.Contains(automobil.Marka)==false) cbMarka.Items.Add(automobil.Marka);
                if (cbModel.SelectedIndex <= 0) if (cbModel.Items.Contains(automobil.Model) == false) cbModel.Items.Add(automobil.Model);
                if (cbGodiste.SelectedIndex <= 0) if (cbGodiste.Items.Contains(automobil.Godiste) == false) cbGodiste.Items.Add(automobil.Godiste);
                if (cbKubikaza.SelectedIndex <= 0) if (cbKubikaza.Items.Contains(automobil.Kubikaza) == false) cbKubikaza.Items.Add(automobil.Kubikaza);
                if (cbKaroserija.SelectedIndex <= 0) if (cbKaroserija.Items.Contains(automobil.Karoserija) == false) cbKaroserija.Items.Add(automobil.Karoserija);
                if (cbBrojVrata.SelectedIndex <= 0) if (cbBrojVrata.Items.Contains(automobil.BrVrata) == false) cbBrojVrata.Items.Add(automobil.BrVrata);
                if (cbGorivo.SelectedIndex <= 0) if (cbGorivo.Items.Contains(automobil.Gorivo) == false) cbGorivo.Items.Add(automobil.Gorivo);
                if (cbPogon.SelectedIndex <= 0) if (cbPogon.Items.Contains(automobil.Pogon) == false) cbPogon.Items.Add(automobil.Pogon);
                if (cbMenjac.SelectedIndex <= 0) if (cbMenjac.Items.Contains(automobil.VrstaMenjaca) == false) cbMenjac.Items.Add(automobil.VrstaMenjaca);
            }
            
            foreach (Control kontrola in this.Controls)
            {
                if (kontrola is ComboBox)
                    ((ComboBox)kontrola).SelectedIndexChanged -= new EventHandler(pretragaAutomobila);
            }     

            cbMarka.SelectedIndex = 0;
            cbModel.SelectedIndex = 0;
            cbGodiste.SelectedIndex = 0;
            cbKubikaza.SelectedIndex = 0;
            cbKaroserija.SelectedIndex = 0;
            cbBrojVrata.SelectedIndex = 0;
            cbGorivo.SelectedIndex = 0;
            cbPogon.SelectedIndex = 0;
            cbMenjac.SelectedIndex = 0;

            foreach (Control kontrola in this.Controls)
            {
                if (kontrola is ComboBox)
                    ((ComboBox)kontrola).SelectedIndexChanged += new EventHandler(pretragaAutomobila);
            }
           

        }

        private void btnPDTOA_Click(object sender, EventArgs e)
        {
            ponude = new List<Ponuda>();
            //bool sviCbPopunjeni=true;
            /*foreach (Control kontrola in this.Controls)
            {
                if (kontrola is ComboBox)
                    if (((ComboBox)kontrola).SelectedIndex == 0)
                    {
                        sviCbPopunjeni = false;                        
                        break;
                    }                
            }*/

            if (automobiliKopija.Count == 1)
            {
                if (MessageBox.Show("Dovoljno ste suzili izbor automobila.\n" + automobiliKopija.ElementAt(0).ZaRezervaciju() + "\nUkoliko je ovo zeljeni automobil potvrdite i\nbiće vam prikazani moguci termini za rezervaciju.", "IZABRANI AUTOMOBIL", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    foreach (Control kontrola in this.Controls)
                    {
                        if (kontrola is ComboBox)
                            ((ComboBox)kontrola).SelectedIndex = 1;
                    }
                    ponude= ucitajPonudeZaOdredjeniAuto(automobiliKopija.ElementAt(0));
                    lbDostupniTermini.Items.Clear();
                    foreach (Ponuda ponuda in ponude)
                    {
                        lbDostupniTermini.Items.Add(ponuda.ZaPonudu());
                    }

                }
                else

                    MessageBox.Show("Odbijeno");

            }
            else
            {
                MessageBox.Show("Niste jednoznacno odredili automobil.\nPopunite preostala polja.");
                lbDostupniTermini.Items.Clear();
            }

        }

        private void btnRezervisi_Click(object sender, EventArgs e)
        {
            bool daLiJeUnutarPonude = false;
            float cena=0;

            if (automobiliKopija.Count == 1)
            {
                foreach (Ponuda ponuda in ponude) {

                    if (DaLiSuDatumiUnutarPonude(dtpDatumPreuzimanja.Value, dtpDatumVracanja.Value, ponuda.DatumOd, ponuda.DatumDo) == true)
                    {
                        daLiJeUnutarPonude = true;
                        cena = ponuda.Cena;
                        break;
                    }                   
                }
                if (daLiJeUnutarPonude == true)
                {
                    Rezervacija novaRezervacija = new Rezervacija(automobiliKopija.ElementAt(0).ID,izabraniKupac.ID,dtpDatumPreuzimanja.Value,dtpDatumVracanja.Value,cena);
                    
                    upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Rezervacija.txt", true);
                    upis.WriteLine(novaRezervacija.IdAutomobila + "?" + novaRezervacija.IdKupca + "?" + novaRezervacija.DatumOd + "?" + novaRezervacija.DatumDo + "?" + novaRezervacija.Cena);                    
                    upis.Flush();
                    upis.Close();                    
                    MessageBox.Show("Uspesno dodata nova rezervacija");
                    this.Close();
                }
                else                                    
                    MessageBox.Show("Izabrani datum nije u okviru bilo koje ponude!");                
            }
            else
            {
                MessageBox.Show("Niste jednoznacno odredili automobil.\nPopunite preostala polja.");
                lbDostupniTermini.Items.Clear();
            }
        }

        private void lbDostupniTermini_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpDatumPreuzimanja.Value = ponude.ElementAt(lbDostupniTermini.SelectedIndex).DatumOd;
            dtpDatumVracanja.Value = ponude.ElementAt(lbDostupniTermini.SelectedIndex).DatumDo;
        }

        private void dtpDatumPreuzimanja_ValueChanged(object sender, EventArgs e)
        {
            bool daLiJeUnutarPonude = false;
            float cena = 0;

            if (automobiliKopija.Count == 1)
            {
                foreach (Ponuda ponuda in ponude)
                {

                    if (DaLiSuDatumiUnutarPonude(dtpDatumPreuzimanja.Value, dtpDatumVracanja.Value, ponuda.DatumOd, ponuda.DatumDo) == true)
                    {
                        daLiJeUnutarPonude = true;
                        cena = ponuda.Cena;
                        break;
                    }
                }
                DateTime datumUzimanja = dtpDatumPreuzimanja.Value;
                DateTime datumVracanja = dtpDatumVracanja.Value;
                int brojacDana = 0;
                if (daLiJeUnutarPonude == true)
                {
                    while (DateTime.Compare(datumUzimanja,datumVracanja)<=0) {
                        brojacDana++;
                        datumUzimanja = datumUzimanja.AddDays(1);
                    }
                    tbxUkupnaCena.Text = (brojacDana*cena).ToString();
                }
                else
                    tbxUkupnaCena.Text = "-Nije u okviru ponude-";
            }
            else
            {
                MessageBox.Show("Niste jednoznacno odredili automobil.\nPopunite preostala polja.");                
            }
        }
    }
}
