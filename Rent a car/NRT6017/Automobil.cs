using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NRT6017
{
    class Automobil
    {
        private int id;
        private string marka;
        private string model;
        private int godiste;
        private int kubikaza;
        private string pogon;
        private string vrstaMenjaca;
        private string karoserija;
        private string gorivo;
        private int brVrata;

        public Automobil(int id, string marka, string model, int godiste, int kubikaza, string pogon, string vrstaMenjaca, string karoserija, string gorivo, int brVrata)
        {
            this.id = id;
            this.marka = marka;
            this.model = model;
            this.godiste = godiste;
            this.kubikaza = kubikaza;
            this.pogon = pogon;
            this.vrstaMenjaca = vrstaMenjaca;
            this.karoserija = karoserija;
            this.gorivo = gorivo;
            this.brVrata = brVrata;
        }
        public Automobil()
        {
            this.id = 0;
            this.marka = "NEDEFINISANO";
            this.model = "NEDEFINISANO";
            this.godiste = 0;
            this.kubikaza = 0;
            this.pogon = "NEDEFINISANO";
            this.vrstaMenjaca = "NEDEFINISANO";
            this.karoserija = "NEDEFINISANO";
            this.gorivo = "NEDEFINISANO";
            this.brVrata = 0;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }
        public string Model
        {
            get { return model; }
            set { model = value; }
        }
        public int Godiste
        {
            get { return godiste; }
            set { godiste = value; }
        }
        public int Kubikaza
        {
            get { return kubikaza; }
            set { kubikaza = value; }
        }
        public string Pogon
        {
            get { return pogon; }
            set { pogon = value; }
        }
        public string VrstaMenjaca
        {
            get { return vrstaMenjaca; }
            set { vrstaMenjaca = value; }
        }
        public string Karoserija
        {
            get { return karoserija; }
            set { karoserija = value; }
        }
        public string Gorivo
        {
            get { return gorivo; }
            set { gorivo = value; }
        }
        public int BrVrata
        {
            get { return brVrata; }
            set { brVrata = value; }
        }

        public string ZaListu()
        {
            return "ID: "+ID + "  Marka: " + Marka + "  Model: " + Model + "  Godiste: " + Godiste + "  Kubikaza: " + Kubikaza + "  Pogon: " + Pogon + "  Vrsta menjaca: " + VrstaMenjaca + "  Karoserija: " + Karoserija + "  Gorivo: " + Gorivo + "  Broj vrata: " + BrVrata;
        }
        public string ZaRezervaciju()
        {
            return "ID: " + ID + "\nMarka: " + Marka + "\nModel: " + Model + "\nGodiste: " + Godiste + "\nKubikaza: " + Kubikaza + "\nPogon: " + Pogon + "\nVrsta menjaca: " + VrstaMenjaca + "\nKaroserija: " + Karoserija + "\nGorivo: " + Gorivo + "\nBroj vrata: " + BrVrata;
        }

    }
}
