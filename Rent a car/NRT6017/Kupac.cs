using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRT6017
{
    public class Kupac : Korisnik
    {

        protected string jmbg;
        protected DateTime datumRodjenja;
        protected string telefon;

        public Kupac(int id, string korisnickoIme, string lozinka, string ime, string prezime, string jmbg, DateTime datumRodjenja, string telefon) : base(id, korisnickoIme, lozinka, ime, prezime)
        {
            this.jmbg = jmbg;
            this.datumRodjenja = datumRodjenja;
            this.telefon = telefon;
        }

        public Kupac(string korisnickoIme, string lozinka) : base(korisnickoIme, lozinka)
        {
            this.jmbg = "";
            this.datumRodjenja = DateTime.Now;
            this.telefon = "";
        }

        public string Jmbg
        {
            get { return jmbg; }
            set { jmbg = value; }
        }

        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; }
        }

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }

        public override string ToString()
        {
            return "ID: "+ID+" Korisnicko ime: "+KorisnickoIme+" Lozinka: "+Lozinka+" Ime: "+ime+" Prezime: "+Prezime+" JMBG: "+Jmbg+" Datum rodjenja: "+DatumRodjenja+" Telefon: "+Telefon;
        }

        public string MesBox()
        {
            return "ID: " + ID + " \nKorisnicko ime: " + KorisnickoIme + " \nLozinka: " + Lozinka + " \nIme: " + ime + " \nPrezime: " + Prezime + " \nJMBG: " + Jmbg + " \nDatum rodjenja: " + DatumRodjenja + " \nTelefon: " + Telefon;
        }

        public string ZaListu()
        {
            return "ID: " + ID + "  Korisnicko ime: " + KorisnickoIme + "  Ime: " + Ime + "  Prezime: " + Prezime + "  DatumRodjenja: " + DatumRodjenja.ToShortDateString() + "  Telefon: " + Telefon;
        }
    }
}
