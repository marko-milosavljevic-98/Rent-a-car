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
    public partial class frmKupac : Form
    {
        private List<Rezervacija> rezervacije;
        private List<Rezervacija> rezervacijeKopija;
        Kupac izabraniKupac;
        StreamWriter upis;


        public frmKupac(Kupac izabraniKupac)
        {
            InitializeComponent();
            this.izabraniKupac = izabraniKupac;
        }

        private void FrmKupac_Load(object sender, EventArgs e)
        {            
            tbxKupac.Text = "IME: " + izabraniKupac.Ime + " PREZIME: " + izabraniKupac.Prezime + " KORISNIČKO IME: " + izabraniKupac.KorisnickoIme;
            ucitajRezervacijeZaKorisnika(izabraniKupac.ID);
        }

        private void ucitajRezervacijeZaKorisnika(int id) {
            rezervacije = ucitajRezervacije();
            rezervacijeKopija = new List<Rezervacija>();
            lbRezervacije.Items.Clear();            
                for (int i = 0; i < rezervacije.Count; i++)
                {
                    if (rezervacije[i].IdKupca == id)
                    {
                        rezervacijeKopija.Add(rezervacije[i]);
                    }
                }
                foreach (Rezervacija rezervacija in rezervacijeKopija)
                {
                    lbRezervacije.Items.Add(rezervacija.ZaListu());
                }
            }        

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRezervacija rezervacija = new frmRezervacija(izabraniKupac);
            rezervacija.Show();
        }

        private void frmKupac_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrijava forma = new frmPrijava();
            forma.Show();
        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (lbRezervacije.SelectedIndex != -1) {
                rezervacijeKopija.RemoveAt(lbRezervacije.SelectedIndex);
                for (int i = 0; i < rezervacije.Count; i++)
                {
                    if (rezervacije[i].IdKupca == izabraniKupac.ID)
                    {
                        //MessageBox.Show("Obrisan: " + rezervacije[i].ZaListu());
                        rezervacije.RemoveAt(i);
                        i--;
                    }
                }
                for (int i = 0; i < rezervacijeKopija.Count; i++)
                {
                    rezervacije.Add(rezervacijeKopija[i]);
                    //MessageBox.Show("Upisan: " + rezervacijeKopija[i].ZaListu());
                }
            }
            upis = new StreamWriter(@"..\..\Datoteke\Nalozi\Rezervacija.txt", false);

            for (int i = 0; i < rezervacije.Count; i++)
            {
                upis.WriteLine(rezervacije[i].IdAutomobila + "?" + rezervacije[i].IdKupca + "?" + rezervacije[i].DatumOd + "?" + rezervacije[i].DatumDo + "?" + rezervacije[i].Cena);
            }
            upis.Flush();
            upis.Close();
            lbRezervacije.Items.Clear();
            ucitajRezervacijeZaKorisnika(izabraniKupac.ID);              
            MessageBox.Show("Uspesno obrisana rezervacija");
        }
    }
}
