using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRT6017
{
    enum Tip { Glavni, NijeGlavni, NijeOdredjeno };

    class Administrator : Korisnik
    {
        protected Tip tip;

        public Administrator(int id, string korisnickoIme, string lozinka, string ime, string prezime,Tip tip) : base(id,korisnickoIme,lozinka,ime,prezime)
        {
            this.tip = tip;
            
        }

        public Tip Tip
        {
            get { return tip; }
            set { tip = value; }
        }

        public override string ToString()
        {
            return "ID: " + ID + " Korisnicko ime: " + KorisnickoIme + " Lozinka: " + Lozinka + " Ime: " + ime + " Prezime: " + Prezime + " Tip: " + Tip ;
        }

        public string MesBox()
        {
            return "ID: " + ID + " \nKorisnicko ime: " + KorisnickoIme + " \nLozinka: " + Lozinka + " \nIme: " + ime + " \nPrezime: " + Prezime + " \nTip: " + Tip;
        }
    }
}
