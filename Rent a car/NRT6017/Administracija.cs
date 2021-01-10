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
using System.Drawing.Drawing2D;
using static NRT6017.StatickeMetode;

namespace NRT6017
{
    public partial class frmAdministracija : Form
    {
        FileInfo putanjaKorisnika = new FileInfo(@"..\..\Datoteke\Nalozi\Kupac.txt");
        FileInfo putanjaAdministratora = new FileInfo(@"..\..\Datoteke\Nalozi\Administrator.txt");
        FileInfo putanjaAutomobila = new FileInfo(@"..\..\Datoteke\Nalozi\Automobil.txt");
        //StreamReader citanje;
        StreamWriter upis;
        //private string red;
        //private string[] podaci;
        private char[] separator = { '?' };
        private List<Kupac> kupci;
        private List<Automobil> automobili;
        private List<Ponuda> ponude;
        private List<Rezervacija> rezervacije;
        private List<Rezervacija> rezervacijeKopija;

        public frmAdministracija()
        {
            InitializeComponent();
        }

        private void frmAdministracija_Load(object sender, EventArgs e)
        {
            lbKupci.Items.Clear();
            kupci = UcitajKupce();
            foreach (Kupac kupac in kupci)
            {
                lbKupci.Items.Add(kupac.ZaListu());
            }

            lbAutomobili.Items.Clear();
            automobili = UcitajAutomobile();
            foreach (Automobil auto in automobili)
            {
                lbAutomobili.Items.Add(auto.ZaListu());
            }

            lbPonudePonuda.Items.Clear();
            ponude = ucitajPonude();
            foreach (Ponuda ponuda in ponude)
            {
                lbPonudePonuda.Items.Add(ponuda.ZaListu());
            }

            cbIDPonuda.Items.Clear();
            cbIDPonuda.Text = "";
            foreach (Automobil auto in automobili)
            {
                cbIDPonuda.Items.Add(auto.ID);
            }

            cbIdAutomobilaRezervacije.Items.Clear();
            cbIdAutomobilaRezervacije.Text = "";
            foreach (Automobil auto in automobili)
            {
                cbIdAutomobilaRezervacije.Items.Add(auto.ID);
            }

            cbIdKupcaRezervacije.Items.Clear();
            cbIdKupcaRezervacije.Text = "";
            foreach (Kupac kupac in kupci)
            {
                cbIdKupcaRezervacije.Items.Add(kupac.ID);
            }


            
            lbRezervacijeRezervacije.Items.Clear();
            rezervacije = ucitajRezervacije();
            /*foreach (Rezervacija rezervacija in rezervacije)
            {
                lbRezervacijeRezervacije.Items.Add(rezervacija.ZaListu());
            }*/

            automobili = UcitajAutomobile();
            lbAutomobiliStatistika.Items.Clear();
            foreach (Automobil auto in automobili)
            {
                lbAutomobiliStatistika.Items.Add(auto.ZaListu());
            }







        }

        //Tab - Automobil

        public bool DaLiJePrazno(TabPage tab)
        {
            int indikator = 0;

            foreach (var kontrola in tab.Controls)
            {
                if (kontrola is TextBox)
                    if (((TextBox)kontrola).Text == "" && ((TextBox)kontrola).ReadOnly==false)
                    {
                        //((TextBox)kontrola).BackColor = Color.LightGray;
                        ((TextBox)kontrola).Click += Tbx_Click;
                        indikator--;
                    }
                    else if(((TextBox)kontrola).ReadOnly==false)
                        ((TextBox)kontrola).BackColor = Color.White;
            }
            if (indikator == 0)
            {
                return false;
            }
            else
            {
                MessageBox.Show("Popunite prazna polja");
                return true;
            }

        }

        public void Tbx_Click(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            tb.BackColor = DefaultBackColor;
        }

        public bool DaLiJeSlovo(TextBox tbx, string nazivPolja)
        {
            bool indikator = true;
            foreach (char karakter in tbx.Text)
            {
                if (!Char.IsLetter(karakter))
                {
                    indikator = false;
                }
            }
            if (indikator == false)
                MessageBox.Show("Dozvoljen je unos samo slova u polje za " + nazivPolja);
            return indikator;
        }

        public bool DaLiJeBrojIDuzina(TextBox tbx, int duzina, string nazivPolja)
        {
            bool indikator1 = true;
            bool indikator2 = true;
            int br = 0;
            foreach (char karakter in tbx.Text)
            {
                if (!Char.IsDigit(karakter))
                {
                    indikator1 = false;
                }
                br++;
            }
            if (indikator1 == false)
                MessageBox.Show("Dozvoljen je unos samo brojeva u polje za " + nazivPolja);
            if (br != 13)
            {
                MessageBox.Show(nazivPolja + " polje mora imati 13 brojeva");
                indikator2 = false;
            }
            if (indikator1 == true && indikator2 == true)
                return true;
            else
                return false;
        }

        public bool DaLiJeBroj(TextBox tbx, string nazivPolja)
        {
            bool indikator = true;
            foreach (char karakter in tbx.Text)
            {
                if (!Char.IsDigit(karakter))
                    indikator = false;
            }
            if (indikator == false)
                MessageBox.Show("Dozvoljen je unos samo brojeva u polje za " + nazivPolja);
            return indikator;
        }

        public bool DaLiSuSviTrue(params bool[] b)
        {
            int indikator = 0;
            for (int i = 0; i < b.Length; i++)
                if (b[i] == false)
                {
                    indikator--;
                }
            if (indikator == 0)
                return true;
            else
                return false;

            /*if (b[0] == true && b[1] == true && b[2] == true && b[3] == true && b[4] == true )
            {
                //MessageBox.Show("Obrisano");//Obrisati
                return true;
            }

            else
                return false;*/
        }

        private void BtnDodaj_Click(object sender, EventArgs e)
        {
            int noviID = SledeciDostupanID(automobili);

            if (DaLiJePrazno(tabAutomobil) == false)
            {
                if (DaLiSuSviTrue(DaLiJeBroj(tbxIDAuta, "ID"), DaLiJeSlovo(tbxMarka, "marka"), DaLiJeBroj(tbxGodiste, "godiste"), DaLiJeBroj(tbxKubikaza, "kubikaza"), DaLiJeSlovo(tbxMenjac, "menjac"), DaLiJeSlovo(tbxKaroserija, "karoserija"), DaLiJeSlovo(tbxGorivo, "gorivo"), DaLiJeBroj(tbxBrVrata, "broj vrata")) == true)
                {
                    Automobil noviAutomobil = new Automobil(noviID, tbxMarka.Text, tbxModel.Text, Convert.ToInt32(tbxGodiste.Text), Convert.ToInt32(tbxKubikaza.Text), tbxPogon.Text, tbxMenjac.Text, tbxKaroserija.Text, tbxGorivo.Text, Convert.ToInt32(tbxBrVrata.Text));
                    automobili.Add(noviAutomobil);
                    upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Automobil.txt", false);

                    foreach (Automobil automobil in automobili)
                    {
                        upis.WriteLine(automobil.ID + "?" + automobil.Marka + "?" + automobil.Model + "?" + automobil.Godiste + "?" + automobil.Kubikaza + "?" + automobil.Pogon + "?" + automobil.VrstaMenjaca + "?" + automobil.Karoserija + "?" + automobil.Gorivo + "?" + automobil.BrVrata);
                    }
                    upis.Flush();
                    upis.Close();
                    lbAutomobili.Items.Clear();
                    automobili = UcitajAutomobile();
                    foreach (Automobil auto in automobili)
                    {
                        lbAutomobili.Items.Add(auto.ZaListu());
                    }
                    IsprazniTextBoxove(tabAutomobil);
                    MessageBox.Show("Uspesno dodat novi automobil\nID za dodati auto je " + noviID);
                }
            }
        }

        private void btnIzmeni_Click(object sender, EventArgs e)
        {

            if (lbAutomobili.SelectedIndex != -1)
            {
                if (DaLiJePrazno(tabAutomobil) == false)
                {
                    if (DaLiSuSviTrue(DaLiJeBroj(tbxIDAuta, "ID"), DaLiJeSlovo(tbxMarka, "marka"), DaLiJeBroj(tbxGodiste, "godiste"), DaLiJeBroj(tbxKubikaza, "kubikaza"), DaLiJeSlovo(tbxMenjac, "menjac"), DaLiJeSlovo(tbxKaroserija, "karoserija"), DaLiJeSlovo(tbxGorivo, "gorivo"), DaLiJeBroj(tbxBrVrata, "broj vrata")) == true)
                    {
                        automobili.ElementAt(lbAutomobili.SelectedIndex).ID = Convert.ToInt32(tbxIDAuta.Text);
                        automobili.ElementAt(lbAutomobili.SelectedIndex).Marka = tbxMarka.Text;
                        automobili.ElementAt(lbAutomobili.SelectedIndex).Model = tbxModel.Text;
                        automobili.ElementAt(lbAutomobili.SelectedIndex).Godiste = Convert.ToInt32(tbxGodiste.Text);
                        automobili.ElementAt(lbAutomobili.SelectedIndex).Kubikaza = Convert.ToInt32(tbxKubikaza.Text);
                        automobili.ElementAt(lbAutomobili.SelectedIndex).Pogon = tbxPogon.Text;
                        automobili.ElementAt(lbAutomobili.SelectedIndex).VrstaMenjaca = tbxMenjac.Text;
                        automobili.ElementAt(lbAutomobili.SelectedIndex).Karoserija = tbxKaroserija.Text;
                        automobili.ElementAt(lbAutomobili.SelectedIndex).Gorivo = tbxGorivo.Text;
                        automobili.ElementAt(lbAutomobili.SelectedIndex).BrVrata = Convert.ToInt32(tbxBrVrata.Text);

                        upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Automobil.txt", false);

                        foreach (Automobil automobil in automobili)
                        {
                            upis.WriteLine(automobil.ID + "?" + automobil.Marka + "?" + automobil.Model + "?" + automobil.Godiste + "?" + automobil.Kubikaza + "?" + automobil.Pogon + "?" + automobil.VrstaMenjaca + "?" + automobil.Karoserija + "?" + automobil.Gorivo + "?" + automobil.BrVrata);
                        }
                        upis.Flush();
                        upis.Close();

                        lbAutomobili.Items.Clear();
                        automobili = UcitajAutomobile();
                        foreach (Automobil auto in automobili)
                        {
                            lbAutomobili.Items.Add(auto.ZaListu());
                        }
                        IsprazniTextBoxove(tabAutomobil);
                        MessageBox.Show("Uspesno izmenjen automobil");
                    }
                }
            }
            else
                MessageBox.Show("Nijedan auto nije selektovan");
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (lbAutomobili.SelectedIndex != -1)
            {
                automobili.RemoveAt(lbAutomobili.SelectedIndex);

                upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Automobil.txt", false);

                foreach (Automobil automobil in automobili)
                {
                    upis.WriteLine(automobil.ID + "?" + automobil.Marka + "?" + automobil.Model + "?" + automobil.Godiste + "?" + automobil.Kubikaza + "?" + automobil.Pogon + "?" + automobil.VrstaMenjaca + "?" + automobil.Karoserija + "?" + automobil.Gorivo + "?" + automobil.BrVrata);
                }
                upis.Flush();
                upis.Close();

                lbAutomobili.Items.Clear();
                automobili = UcitajAutomobile();
                foreach (Automobil auto in automobili)
                {
                    lbAutomobili.Items.Add(auto.ZaListu());
                }
                IsprazniTextBoxove(tabAutomobil);
                MessageBox.Show("Uspesno obrisan automobil");
            }
            else
                MessageBox.Show("Nijedan auto nije selektovan");
        }

        private void lbAutomobili_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAutomobili.SelectedIndex != -1)
            {
                tbxIDAuta.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).ID.ToString();
                tbxMarka.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).Marka.ToString();
                tbxModel.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).Model.ToString();
                tbxGodiste.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).Godiste.ToString();
                tbxKubikaza.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).Kubikaza.ToString();
                tbxPogon.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).Pogon.ToString();
                tbxMenjac.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).VrstaMenjaca.ToString();
                tbxKaroserija.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).Karoserija.ToString();
                tbxGorivo.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).Gorivo.ToString();
                tbxBrVrata.Text = automobili.ElementAt(lbAutomobili.SelectedIndex).BrVrata.ToString();
            }
        }

        //Tab - Kupac

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbKupci.SelectedIndex != -1)
            {
                tbxID.Text = kupci.ElementAt(lbKupci.SelectedIndex).ID.ToString();
                tbxIme.Text = kupci.ElementAt(lbKupci.SelectedIndex).Ime.ToString();
                tbxKorisnickoIme.Text = kupci.ElementAt(lbKupci.SelectedIndex).KorisnickoIme.ToString();
                tbxLozinka.Text = kupci.ElementAt(lbKupci.SelectedIndex).Lozinka.ToString();
                tbxPrezime.Text = kupci.ElementAt(lbKupci.SelectedIndex).Prezime.ToString();
                tbxJMBG.Text = kupci.ElementAt(lbKupci.SelectedIndex).Jmbg.ToString();
                tbxTelefon.Text = kupci.ElementAt(lbKupci.SelectedIndex).Telefon.ToString();
                dtpDatumRodjenja.Text = kupci.ElementAt(lbKupci.SelectedIndex).DatumRodjenja.ToString();
            }
        }

        private void btnDodajKupac_Click(object sender, EventArgs e)
        {
            int noviID = SledeciDostupanID(kupci);

            if (DaLiJePrazno(tabKupac) == false)
            {
                if (DaLiSuSviTrue(DaLiJeBroj(tbxID, "ID"), DaLiJeSlovo(tbxIme, "ime"), DaLiJeSlovo(tbxPrezime, "prezime"), DaLiJeBrojIDuzina(tbxJMBG, 13, "JMBG"), DaLiJeBroj(tbxTelefon, "telefon")) == true)
                {
                    Kupac noviKupac = new Kupac(noviID, tbxKorisnickoIme.Text, tbxLozinka.Text, tbxIme.Text, tbxPrezime.Text, tbxJMBG.Text, Convert.ToDateTime(dtpDatumRodjenja.Text), tbxTelefon.Text);
                    kupci.Add(noviKupac);
                    upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Kupac.txt", false);

                    foreach (Kupac kupac in kupci)
                    {
                        upis.WriteLine(kupac.ID + "?" + kupac.KorisnickoIme + "?" + kupac.Lozinka + "?" + kupac.Ime + "?" + kupac.Prezime + "?" + kupac.Jmbg + "?" + kupac.DatumRodjenja + "?" + kupac.Telefon);
                    }
                    upis.Flush();
                    upis.Close();
                    lbKupci.Items.Clear();
                    kupci = UcitajKupce();
                    foreach (Kupac kupac in kupci)
                        lbKupci.Items.Add(kupac.ZaListu());
                    IsprazniTextBoxove(tabKupac);
                    MessageBox.Show("Uspesno dodat novi kupac\nID za dodatog korisnika je " + noviID);
                }
            }
        }

        private void btnIzmeniKupac_Click(object sender, EventArgs e)
        {
            if (lbKupci.SelectedIndex != -1)
            {
                if (DaLiJePrazno(tabKupac) == false)
                {
                    if (DaLiSuSviTrue(DaLiJeBroj(tbxID, "ID"), DaLiJeSlovo(tbxIme, "ime"), DaLiJeSlovo(tbxPrezime, "prezime"), DaLiJeBrojIDuzina(tbxJMBG, 13, "JMBG"), DaLiJeBroj(tbxTelefon, "telefon")) == true)
                    {
                        kupci.ElementAt(lbKupci.SelectedIndex).ID = Convert.ToInt32(tbxID.Text);
                        kupci.ElementAt(lbKupci.SelectedIndex).Ime = tbxIme.Text;
                        kupci.ElementAt(lbKupci.SelectedIndex).Prezime = tbxPrezime.Text;
                        kupci.ElementAt(lbKupci.SelectedIndex).Jmbg = tbxJMBG.Text;
                        kupci.ElementAt(lbKupci.SelectedIndex).Telefon = tbxTelefon.Text;
                        kupci.ElementAt(lbKupci.SelectedIndex).DatumRodjenja = Convert.ToDateTime(dtpDatumRodjenja.Text);

                        upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Kupac.txt", false);

                        foreach (Kupac kupac in kupci)
                        {
                            upis.WriteLine(kupac.ID + "?" + kupac.KorisnickoIme + "?" + kupac.Lozinka + "?" + kupac.Ime + "?" + kupac.Prezime + "?" + kupac.Jmbg + "?" + kupac.DatumRodjenja + "?" + kupac.Telefon);
                        }
                        upis.Flush();
                        upis.Close();
                        lbKupci.Items.Clear();
                        kupci = UcitajKupce();
                        foreach (Kupac kupac in kupci)
                            lbKupci.Items.Add(kupac.ZaListu());
                        IsprazniTextBoxove(tabKupac);
                        MessageBox.Show("Uspesno izmenjen kupac");
                    }
                }

            }
            else
                MessageBox.Show("Nijedan kupac nije selektovan");

        }

        private void btnObrisiKupac_Click(object sender, EventArgs e)
        {
            if (lbKupci.SelectedIndex != -1)
            {
                kupci.RemoveAt(lbKupci.SelectedIndex);

                upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Kupac.txt", false);

                foreach (Kupac kupac in kupci)
                {
                    upis.WriteLine(kupac.ID + "?" + kupac.KorisnickoIme + "?" + kupac.Lozinka + "?" + kupac.Ime + "?" + kupac.Prezime + "?" + kupac.Jmbg + "?" + kupac.DatumRodjenja + "?" + kupac.Telefon);
                }
                upis.Flush();
                upis.Close();

                lbKupci.Items.Clear();
                kupci = UcitajKupce();
                foreach (Kupac kupac in kupci)
                    lbKupci.Items.Add(kupac.ZaListu());
                IsprazniTextBoxove(tabKupac);
                MessageBox.Show("Uspesno obrisan kupac");
            }
            else
                MessageBox.Show("Nijedan kupac nije selektovan");
        }

        //Tab - Ponuda

        public bool DaLiJeNull(ComboBox cb, string nazivPolja)
        {
            bool indikator = true;
            if (cb.SelectedIndex == -1)
            {
                indikator = false;
            }
            if (indikator == false)
                MessageBox.Show("Morate odabrati neku vrednost iz polja za " + nazivPolja);
            return indikator;
        }

        public bool DaLiJePrviManjiOdDrugogDatuma(DateTime prvi, DateTime drugi)
        {
            bool indikator = true;
            if (DateTime.Compare(prvi, drugi) <= 0)
            {
                indikator = true;
            }
            else
            {
                indikator = false;
                MessageBox.Show("Prvi datum mora biti pre drugog ");
            }

            return indikator;
        }

        private void btnDodajPonuda_Click(object sender, EventArgs e)
        {
            bool daLiSuSviUsloviIspunjeni = true;
            if (DaLiJePrazno(tabPonuda) == false)
            {
                if (DaLiSuSviTrue(DaLiJeNull(cbIDPonuda, "ID"), DaLiJeBroj(tbxCenaPonuda, "Cena po danu"), DaLiJePrviManjiOdDrugogDatuma(dtpDatumOdPonuda.Value, dtpDatumDoPonuda.Value)) == true)
                {
                    foreach (Ponuda ponuda in ponude)
                    {
                        if (ponuda.Id == Int32.Parse(cbIDPonuda.Text))
                        {
                            if (DaLiSeDatumiPreklapaju(DateTime.Parse(dtpDatumOdPonuda.Text), DateTime.Parse(dtpDatumDoPonuda.Text), ponuda.DatumOd, ponuda.DatumDo))
                            {
                                daLiSuSviUsloviIspunjeni = false;
                                break;
                            }
                        }
                    }
                    if (daLiSuSviUsloviIspunjeni == false)
                    {
                        MessageBox.Show("Datumi se preklapaju sa već postojećom ponudom!\nMorate promeniti datum");
                    }
                    else
                    {
                        Ponuda novaPonuda = new Ponuda(Int32.Parse(cbIDPonuda.Text), float.Parse(tbxCenaPonuda.Text), DateTime.Parse(dtpDatumOdPonuda.Text), DateTime.Parse(dtpDatumDoPonuda.Text));
                        ponude.Add(novaPonuda);
                        upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Ponuda.txt", false);

                        for (int i = 0; i < ponude.Count; i++)
                        {
                            upis.WriteLine(ponude[i].Id + "?" + ponude[i].Cena + "?" + ponude[i].DatumOd + "?" + ponude[i].DatumDo);
                        }
                        upis.Flush();
                        upis.Close();
                        lbPonudePonuda.Items.Clear();
                        ponude = ucitajPonude();
                        foreach (Ponuda ponuda in ponude)
                            lbPonudePonuda.Items.Add(ponuda.ZaListu());
                        IsprazniTextBoxove(tabPonuda);
                        cbIDPonuda.SelectedIndex = -1;
                        MessageBox.Show("Uspesno dodata nova ponuda");
                    }
                }
            }

        }

        private void lbPonudePonuda_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbPonudePonuda.SelectedIndex != -1)
            {
                cbIDPonuda.Text = ponude.ElementAt(lbPonudePonuda.SelectedIndex).Id.ToString();
                tbxCenaPonuda.Text = ponude.ElementAt(lbPonudePonuda.SelectedIndex).Cena.ToString();
                dtpDatumOdPonuda.Text = ponude.ElementAt(lbPonudePonuda.SelectedIndex).DatumOd.ToString();
                dtpDatumDoPonuda.Text = ponude.ElementAt(lbPonudePonuda.SelectedIndex).DatumDo.ToString();
            }
        }

        private void btnObrisiPonuda_Click(object sender, EventArgs e)
        {
            if (lbPonudePonuda.SelectedIndex != -1)
            {
                ponude.RemoveAt(lbPonudePonuda.SelectedIndex);

                upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Ponuda.txt", false);

                for (int i = 0; i < ponude.Count; i++)
                {
                    upis.WriteLine(ponude[i].Id + "?" + ponude[i].Cena + "?" + ponude[i].DatumOd + "?" + ponude[i].DatumDo);
                }
                upis.Flush();
                upis.Close();
                lbPonudePonuda.Items.Clear();
                ponude = ucitajPonude();
                foreach (Ponuda ponuda in ponude)
                    lbPonudePonuda.Items.Add(ponuda.ZaListu());
                IsprazniTextBoxove(tabPonuda);
                cbIDPonuda.SelectedIndex = -1;
                MessageBox.Show("Uspesno obrisana ponuda");
            }
            else
                MessageBox.Show("Nijedan kupac nije selektovan");
        }

        private void btnIzmeniPonuda_Click(object sender, EventArgs e)
        {
            bool daLiSuSviUsloviIspunjeni = true;
            if (lbPonudePonuda.SelectedIndex != -1)
            {
                if (DaLiJePrazno(tabPonuda) == false)
                {
                    if (DaLiSuSviTrue(DaLiJeNull(cbIDPonuda, "ID"), DaLiJeBroj(tbxTelefon, "telefon"), DaLiJePrviManjiOdDrugogDatuma(dtpDatumOdPonuda.Value, dtpDatumDoPonuda.Value)) == true)
                    {
                        foreach (Ponuda ponuda in ponude)
                        {
                            if (ponuda.Id == Int32.Parse(cbIDPonuda.Text) && lbPonudePonuda.SelectedIndex != ponude.IndexOf(ponuda))
                            {
                                if (DaLiSeDatumiPreklapaju(DateTime.Parse(dtpDatumOdPonuda.Text), DateTime.Parse(dtpDatumDoPonuda.Text), ponuda.DatumOd, ponuda.DatumDo))
                                {
                                    daLiSuSviUsloviIspunjeni = false;
                                    break;
                                }
                            }                            
                        }
                        if (daLiSuSviUsloviIspunjeni == false)
                        {
                            MessageBox.Show("Datumi se preklapaju sa već postojećom ponudom!\nMorate promeniti datum");
                        }
                        else
                        {
                            Ponuda novaPonuda = new Ponuda(Int32.Parse(cbIDPonuda.Text), float.Parse(tbxCenaPonuda.Text), DateTime.Parse(dtpDatumOdPonuda.Text), DateTime.Parse(dtpDatumDoPonuda.Text));
                            ponude.ElementAt(lbPonudePonuda.SelectedIndex).Id = novaPonuda.Id;
                            ponude.ElementAt(lbPonudePonuda.SelectedIndex).Cena = novaPonuda.Cena;
                            ponude.ElementAt(lbPonudePonuda.SelectedIndex).DatumOd = novaPonuda.DatumOd;
                            ponude.ElementAt(lbPonudePonuda.SelectedIndex).DatumDo = novaPonuda.DatumDo;

                            upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Ponuda.txt", false);

                            for (int i = 0; i < ponude.Count; i++)
                            {
                                upis.WriteLine(ponude[i].Id + "?" + ponude[i].Cena + "?" + ponude[i].DatumOd + "?" + ponude[i].DatumDo);
                            }
                            upis.Flush();
                            upis.Close();
                            lbPonudePonuda.Items.Clear();
                            ponude = ucitajPonude();
                            foreach (Ponuda ponuda in ponude)
                                lbPonudePonuda.Items.Add(ponuda.ZaListu());
                            IsprazniTextBoxove(tabPonuda);
                            cbIDPonuda.SelectedIndex = -1;
                            MessageBox.Show("Uspesno izmenjena ponuda");
                        }
                    }
                }
            }
            else
                MessageBox.Show("Nijedan kupac nije selektovan");
        }

        //Tab - Rezervacije

        private void btnDodajRezervacije_Click(object sender, EventArgs e)
        {
            bool daLiJeUnutarPonude = false;
            bool daLiSeNePreklapaSaDrugomRezervacijom = true;
            if (DaLiJePrazno(tabRezervacije) == false)
            {
                if (DaLiSuSviTrue(DaLiJeNull(cbIdAutomobilaRezervacije, "ID automobila"), DaLiJeNull(cbIdAutomobilaRezervacije, "ID kupca"), DaLiJeBroj(tbxCenaPoDanuRezervacije, "Cena po danu"), DaLiJePrviManjiOdDrugogDatuma(dtpDatumOdRezervacije.Value, dtpDatumDoRezervacije.Value)) == true)
                {
                    foreach (Ponuda ponuda in ponude)
                    {
                        daLiJeUnutarPonude = false;
                        
                        if (DaLiSuDatumiUnutarPonude(DateTime.Parse(dtpDatumOdRezervacije.Text), DateTime.Parse(dtpDatumDoRezervacije.Text), ponuda.DatumOd, ponuda.DatumDo) == true && Int32.Parse(cbIdAutomobilaRezervacije.Text) == ponuda.Id)
                        {                                                  
                            daLiJeUnutarPonude = true;
                            if (rezervacije.Count == 0)
                            {
                                daLiSeNePreklapaSaDrugomRezervacijom = true;
                            }
                            
                            foreach (Rezervacija rezervacija in rezervacije)
                            {
                                /*MessageBox.Show("Izabrano: " + DateTime.Parse(dtpDatumOdRezervacije.Text).ToString() + " - " + DateTime.Parse(dtpDatumDoRezervacije.Text).ToString() + 
                                                "\nRezervacija: " + rezervacija.DatumOd.ToString() + " - " + rezervacija.DatumDo.ToString() + 
                                                "\nID: " + rezervacija.IdAutomobila.ToString() + " - " + Int32.Parse(cbIdAutomobilaRezervacije.Text).ToString());*/
                                //MessageBox.Show((rezervacija.IdAutomobila == Int32.Parse(cbIdAutomobilaRezervacije.Text)).ToString() +" "+ DaLiSeDatumiPreklapaju(DateTime.Parse(dtpDatumOdRezervacije.Text), DateTime.Parse(dtpDatumDoRezervacije.Text), rezervacija.DatumOd, rezervacija.DatumDo) );
                                if (rezervacija.IdAutomobila == Int32.Parse(cbIdAutomobilaRezervacije.Text) && DaLiSeDatumiPreklapaju(DateTime.Parse(dtpDatumOdRezervacije.Text), DateTime.Parse(dtpDatumDoRezervacije.Text), rezervacija.DatumOd, rezervacija.DatumDo) == true)
                                {
                                    //MessageBox.Show("UIO");
                                    daLiSeNePreklapaSaDrugomRezervacijom = false;                                    
                                    break;                                    
                                }
                               // MessageBox.Show("daLiSeNePreklapaSaDrugomRezervacijom: "+ daLiSeNePreklapaSaDrugomRezervacijom.ToString());
                            }
                            if (daLiJeUnutarPonude == true /*&& daLiSeNePreklapaSaDrugomRezervacijom == true*/)
                                break;
                        }
                    }
                    //MessageBox.Show("Da li je unutar ponude: "+daLiJeUnutarPonude);
                    if (daLiJeUnutarPonude == true && daLiSeNePreklapaSaDrugomRezervacijom == true)
                    {
                        Rezervacija novaRezervacija = new Rezervacija(Int32.Parse(cbIdAutomobilaRezervacije.Text), Int32.Parse(cbIdKupcaRezervacije.Text), DateTime.Parse(dtpDatumOdRezervacije.Text), DateTime.Parse(dtpDatumDoRezervacije.Text), float.Parse(tbxCenaPoDanuRezervacije.Text));
                        rezervacije.Add(novaRezervacija);
                        upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Rezervacija.txt", false);

                        for (int i = 0; i < rezervacije.Count; i++)
                        {
                            upis.WriteLine(rezervacije[i].IdAutomobila + "?" + rezervacije[i].IdKupca + "?" + rezervacije[i].DatumOd + "?" + rezervacije[i].DatumDo + "?" + rezervacije[i].Cena);
                        }
                        upis.Flush();
                        upis.Close();
                        lbRezervacijeRezervacije.Items.Clear();
                        rezervacije = ucitajRezervacije();
                        foreach (Rezervacija rezervacija in rezervacije)
                            lbRezervacijeRezervacije.Items.Add(rezervacija.ZaListu());
                        IsprazniTextBoxove(tabRezervacije);
                        cbIdAutomobilaRezervacije.SelectedIndex = -1;
                        cbIdKupcaRezervacije.SelectedIndex = -1;
                        MessageBox.Show("Uspesno dodata nova rezervacija");
                    }
                    else
                    {
                        //MessageBox.Show("daLiJeUnutarPonude: "+ daLiJeUnutarPonude.ToString());
                        string greska = "";
                        if (daLiJeUnutarPonude == false)
                            greska += "Izabrani datum nije u okviru bilo koje ponude!\n";
                        if (daLiJeUnutarPonude == true && daLiSeNePreklapaSaDrugomRezervacijom == false)
                            greska += "Izabrani datum se poklapa sa vec postojecom rezervacijom\n";
                        MessageBox.Show(greska);
                    }
                }
            }
            
        }        

        private void cbIdKupcaRezervacije_SelectedIndexChanged(object sender, EventArgs e)
        {
            rezervacije = ucitajRezervacije();
            rezervacijeKopija = new List<Rezervacija>();
            lbRezervacijeRezervacije.Items.Clear();
            if (cbIdKupcaRezervacije.SelectedIndex >= 0)
             {
                 for (int i = 0; i < rezervacije.Count; i++)
                 {
                     if (rezervacije[i].IdKupca == Int32.Parse(cbIdKupcaRezervacije.Text))
                     {
                        rezervacijeKopija.Add(rezervacije[i]);                        
                     }
                 }
                /*for (int i = 0; i < rezervacije.Count; i++)
                {
                    if (rezervacije[i].IdKupca == Int32.Parse(cbIdKupcaRezervacije.Text))
                    {                       
                        rezervacije.RemoveAt(i);
                        i--;
                    }
                }*/
                foreach (Rezervacija rezervacija in rezervacijeKopija)
                 {
                     lbRezervacijeRezervacije.Items.Add(rezervacija.ZaListu());
                 }
            }
            /*MessageBox.Show(rezervacije[6].ZaListu());
            rezervacijeKopija.Add(new Rezervacija(1,1,DateTime.Parse("1.3.1998"), DateTime.Parse("1.3.1998"),14));
            MessageBox.Show(rezervacije[7].ZaListu());*/
        }

        private void btnIzmeniRezervacije_Click(object sender, EventArgs e)
        {
            bool daLiJeUnutarPonude = false;
            bool daLiSeNePreklapaSaDrugomRezervacijom = true;
            if (lbRezervacijeRezervacije.SelectedIndex != -1)
            {
                if (DaLiJePrazno(tabRezervacije) == false)
                {
                    if (DaLiSuSviTrue(DaLiJeNull(cbIdAutomobilaRezervacije, "ID automobila"), DaLiJeNull(cbIdKupcaRezervacije, "ID kupca"), DaLiJeCena(tbxCenaPoDanuRezervacije.Text, "Cena po danu"), DaLiJePrviManjiOdDrugogDatuma(dtpDatumOdRezervacije.Value, dtpDatumDoRezervacije.Value)) == true)
                    {
                        foreach (Ponuda ponuda in ponude)
                        {
                            daLiJeUnutarPonude = false;
                            if (DaLiSuDatumiUnutarPonude(DateTime.Parse(dtpDatumOdRezervacije.Text), DateTime.Parse(dtpDatumDoRezervacije.Text), ponuda.DatumOd, ponuda.DatumDo) == true && Int32.Parse(cbIdAutomobilaRezervacije.Text) == ponuda.Id)
                            {
                                daLiJeUnutarPonude = true;
                                if (rezervacije.Count == 0)
                                {
                                    daLiSeNePreklapaSaDrugomRezervacijom = true;
                                }

                                foreach (Rezervacija rezervacija in rezervacije)
                                {
                                    /*MessageBox.Show("Izabrano: " + DateTime.Parse(dtpDatumOdRezervacije.Text).ToString() + " - " + DateTime.Parse(dtpDatumDoRezervacije.Text).ToString() + 
                                                    "\nRezervacija: " + rezervacija.DatumOd.ToString() + " - " + rezervacija.DatumDo.ToString() + 
                                                    "\nID: " + rezervacija.IdAutomobila.ToString() + " - " + Int32.Parse(cbIdAutomobilaRezervacije.Text).ToString());*/
                                    //MessageBox.Show((rezervacija.IdAutomobila == Int32.Parse(cbIdAutomobilaRezervacije.Text)).ToString() +" "+ DaLiSeDatumiPreklapaju(DateTime.Parse(dtpDatumOdRezervacije.Text), DateTime.Parse(dtpDatumDoRezervacije.Text), rezervacija.DatumOd, rezervacija.DatumDo) );
                                    if (rezervacija.IdAutomobila == Int32.Parse(cbIdAutomobilaRezervacije.Text) && DaLiSeDatumiPreklapaju(DateTime.Parse(dtpDatumOdRezervacije.Text), DateTime.Parse(dtpDatumDoRezervacije.Text), rezervacija.DatumOd, rezervacija.DatumDo) == true && lbRezervacijeRezervacije.SelectedIndex != rezervacijeKopija.IndexOf(rezervacija))
                                    {
                                        //MessageBox.Show("UIO");
                                        daLiSeNePreklapaSaDrugomRezervacijom = false;
                                        break;
                                    }
                                    // MessageBox.Show("daLiSeNePreklapaSaDrugomRezervacijom: "+ daLiSeNePreklapaSaDrugomRezervacijom.ToString());
                                }
                                if (daLiJeUnutarPonude == true && daLiSeNePreklapaSaDrugomRezervacijom == true)
                                    break;
                            }
                        }
                        if (daLiJeUnutarPonude == true && daLiSeNePreklapaSaDrugomRezervacijom == true)
                        {
                            rezervacijeKopija.RemoveAt(lbRezervacijeRezervacije.SelectedIndex);
                            Rezervacija novaRezervacija = new Rezervacija(Int32.Parse(cbIdAutomobilaRezervacije.Text), Int32.Parse(cbIdKupcaRezervacije.Text), DateTime.Parse(dtpDatumOdRezervacije.Text), DateTime.Parse(dtpDatumDoRezervacije.Text), float.Parse(tbxCenaPoDanuRezervacije.Text));
                            rezervacijeKopija.Add(novaRezervacija);
                            for (int i = 0; i < rezervacije.Count; i++)
                            {
                                if (rezervacije[i].IdKupca == Int32.Parse(cbIdKupcaRezervacije.Text))
                                {
                                    //MessageBox.Show("Obrisan: " + rezervacije[i].ZaListu());
                                    rezervacije.RemoveAt(i);
                                    i--;
                                }
                            }
                            for (int i = 0; i < rezervacijeKopija.Count; i++)
                            {                                
                                rezervacije.Add(rezervacijeKopija[i]);                                
                            }

                            upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Rezervacija.txt", false);

                            for (int i = 0; i < rezervacije.Count; i++)
                            {
                                upis.WriteLine(rezervacije[i].IdAutomobila + "?" + rezervacije[i].IdKupca + "?" + rezervacije[i].DatumOd + "?" + rezervacije[i].DatumDo + "?" + rezervacije[i].Cena);
                            }
                            upis.Flush();
                            upis.Close();
                            lbRezervacijeRezervacije.Items.Clear();
                            rezervacije = ucitajRezervacije();
                            foreach (Rezervacija rezervacija in rezervacije)
                                lbRezervacijeRezervacije.Items.Add(rezervacija.ZaListu());
                            IsprazniTextBoxove(tabRezervacije);
                            cbIdAutomobilaRezervacije.SelectedIndex = -1;
                            cbIdKupcaRezervacije.SelectedIndex = -1;
                            MessageBox.Show("Uspesno izmenjena rezervacija");
                        }
                        else
                        {
                            //MessageBox.Show("daLiJeUnutarPonude: "+ daLiJeUnutarPonude.ToString());
                            string greska = "";
                            if (daLiJeUnutarPonude == false)
                                greska += "Izabrani datum nije u okviru bilo koje ponude!\n";
                            if (daLiJeUnutarPonude == true && daLiSeNePreklapaSaDrugomRezervacijom == false)
                                greska += "Izabrani datum se poklapa sa vec postojecom rezervacijom\n";
                            MessageBox.Show(greska);
                        }
                    }
                }
            }
            else
                MessageBox.Show("Nijedna rezervacija nije selektovana");
        }

        private void btnObrisiRezervacije_Click(object sender, EventArgs e)
        {
            if (lbRezervacijeRezervacije.SelectedIndex != -1)
            {
                rezervacije.RemoveAt(lbRezervacijeRezervacije.SelectedIndex);

                upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Rezervacija.txt", false);

                for (int i = 0; i < rezervacije.Count; i++)
                {
                    upis.WriteLine(rezervacije[i].IdAutomobila + "?" + rezervacije[i].IdKupca + "?" + rezervacije[i].DatumOd + "?" + rezervacije[i].DatumDo + "?" + rezervacije[i].Cena);
                }
                upis.Flush();
                upis.Close();
                lbRezervacijeRezervacije.Items.Clear();
                rezervacije = ucitajRezervacije();                
                IsprazniTextBoxove(tabRezervacije);
                cbIdKupcaRezervacije.SelectedIndex = -1;
                cbIdAutomobilaRezervacije.SelectedIndex = -1;
                MessageBox.Show("Uspesno obrisana rezervacija");
            }
            else
                MessageBox.Show("Nijedna rezervacija nije selektovana");
        }

        private void lbRezervacijeRezervacije_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbRezervacijeRezervacije.SelectedIndex != -1)
            {
                //MessageBox.Show("Kliknuo!");
                cbIdKupcaRezervacije.Text = rezervacijeKopija.ElementAt(lbRezervacijeRezervacije.SelectedIndex).IdKupca.ToString();
                cbIdAutomobilaRezervacije.Text = rezervacijeKopija.ElementAt(lbRezervacijeRezervacije.SelectedIndex).IdAutomobila.ToString();
                tbxCenaPoDanuRezervacije.Text = rezervacijeKopija.ElementAt(lbRezervacijeRezervacije.SelectedIndex).Cena.ToString();
                dtpDatumOdRezervacije.Text = rezervacijeKopija.ElementAt(lbRezervacijeRezervacije.SelectedIndex).DatumOd.ToString();
                dtpDatumDoRezervacije.Text = rezervacijeKopija.ElementAt(lbRezervacijeRezervacije.SelectedIndex).DatumDo.ToString();
            }
        }

        //Tab - Statistika

        private Automobil izabraniAutomobil;
        private void lbAutomobiliStatistika_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbAutomobiliStatistika.SelectedIndex != -1)
            {
                izabraniAutomobil = automobili[lbAutomobiliStatistika.SelectedIndex];
                //MessageBox.Show(izabraniAutomobil.ZaListu());  
                
            }
        }

        private int brojDanaUMesecu = 0;
        private int brojDanaUPonudi = 0;
        private int brojDanaJeRezervisan = 0;
        private int procenatPonuda;
        private int procenatRezervacija;
        private DateTime prviDan;
        private DateTime poslednjiDan;
        private void dtpMesecStatistika_ValueChanged(object sender, EventArgs e)
        {                               
            //MessageBox.Show("Prvi dan: "+prviDan.ToShortDateString()+"\nPoslednji dan: "+poslednjiDan.ToShortDateString());            
        }

        private void azurirajStatistiku()
        {
            brojDanaUPonudi = 0;
            brojDanaJeRezervisan = 0;

            if (lbAutomobiliStatistika.SelectedIndex != -1)
            {
                izabraniAutomobil = automobili[lbAutomobiliStatistika.SelectedIndex];
                foreach (Ponuda ponuda in ponude)
                {
                    if (izabraniAutomobil.ID == ponuda.Id)
                    {
                        if (DaLiSeDatumiPreklapaju(ponuda.DatumOd, ponuda.DatumDo, prviDan, poslednjiDan) == true)
                        {
                            DateTime pocetakPonude = ponuda.DatumOd;
                            while (DateTime.Compare(pocetakPonude, ponuda.DatumDo) <= 0)
                            {                               
                                if (pocetakPonude.Month == dtpMesecStatistika.Value.Month)
                                {
                                    brojDanaUPonudi++;
                                    //MessageBox.Show("Datum: "+ pocetakPonude + "   "+ponuda.DatumOd+"-" + ponuda.DatumDo);
                                }
                                pocetakPonude = pocetakPonude.AddDays(1);                                
                            }                            
                        }
                    }
                }
                foreach (Rezervacija rezervacija in rezervacije)
                {
                    if (izabraniAutomobil.ID == rezervacija.IdAutomobila)
                    {
                        if (DaLiSeDatumiPreklapaju(rezervacija.DatumOd, rezervacija.DatumDo, prviDan, poslednjiDan) == true) {
                            DateTime pocetakRezervacije = rezervacija.DatumOd;
                            while (DateTime.Compare(pocetakRezervacije, rezervacija.DatumDo) <= 0) {
                                if (pocetakRezervacije.Month == dtpMesecStatistika.Value.Month)
                                {
                                    brojDanaJeRezervisan++;
                                    //MessageBox.Show("Datum: " + pocetakRezervacije + "   " + rezervacija.DatumOd + "-" + rezervacija.DatumDo);
                                }
                                pocetakRezervacije = pocetakRezervacije.AddDays(1);
                            }
                        }
                    }
                }
            }
        }        

        private void btnIzracunajStatistikuStatistika_Click(object sender, EventArgs e)
        {
            brojDanaUMesecu = DateTime.DaysInMonth(dtpMesecStatistika.Value.Year, dtpMesecStatistika.Value.Month);
            prviDan = new DateTime(dtpMesecStatistika.Value.Year, dtpMesecStatistika.Value.Month, 1);
            poslednjiDan = new DateTime(dtpMesecStatistika.Value.Year, dtpMesecStatistika.Value.Month, brojDanaUMesecu);
            azurirajStatistiku();

            if (lbAutomobiliStatistika.SelectedIndex != -1)
            {
                tbxBrDanaUPonudi.Text = "U " + dtpMesecStatistika.Value.Month.ToString() + ". mesecu je u ponudi " + brojDanaUPonudi + " od " + brojDanaUMesecu + " dana ("+ 100/brojDanaUMesecu*brojDanaUPonudi+" %).";
                tbxBrDanaURezervaciji.Text = "U " + dtpMesecStatistika.Value.Month.ToString() + ". mesecu je rezervisan " + brojDanaJeRezervisan + " od " + brojDanaUMesecu + " dana ("+100/brojDanaUMesecu*brojDanaJeRezervisan+" %).";
                procenatPonuda = Convert.ToInt32(369f / brojDanaUMesecu * brojDanaUPonudi);
                procenatRezervacija = Convert.ToInt32(369f / brojDanaUMesecu * brojDanaJeRezervisan);
                this.tabStatistika.Invalidate();
            }
            else
            {
                MessageBox.Show("Nije selektovan nijedan automobil");
            }
        }

        private void tabStatistika_Paint(object sender, PaintEventArgs e)        {
            Brush cetkica = new SolidBrush(Color.LightGray);
            Graphics g = this.tabStatistika.CreateGraphics();
            g.DrawRectangle(new Pen(Color.Gray, 1), new Rectangle(8, 262, 370, 26));
            g.FillRectangle(cetkica, new Rectangle(9, 263, procenatPonuda, 25));
            g.DrawRectangle(new Pen(Color.Gray, 1), new Rectangle(404, 262, 370, 26));
            g.FillRectangle(cetkica, new Rectangle(405, 263, procenatRezervacija, 25));           
        }

        private void frmAdministracija_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrijava forma = new frmPrijava();
            forma.Show();
        }
    }
}
