using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRT6017
{
    public class Korisnik
    {
        protected int id;
        protected string korisnickoIme;
        protected string lozinka;
        protected string ime;
        protected string prezime;

        public Korisnik(int id, string korisnickoIme, string lozinka, string ime, string prezime)
        {
            this.id = id;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.ime = ime;
            this.prezime = prezime;
        }

        public Korisnik(string korisnickoIme, string lozinka)
        {
            this.id = 0;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.ime = "";
            this.prezime = "";
        }

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set { korisnickoIme = value; }
        }

        public string Lozinka
        {
            get { return lozinka; }
            set { lozinka = value; }
        }

        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }

        public string Prezime
        {
            get { return prezime; }
            set { prezime = value; }
        }
    }

}
