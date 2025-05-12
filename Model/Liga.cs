using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub.Model
{
    public class Liga
    {
        public Liga() { }
        public Liga(string naziv, string drzava, int brojKlubova, int koeficijent) 
        {
            Naziv = naziv;
            Drzava = drzava;
            BrojKlubova = brojKlubova;
            Koeficijent = koeficijent;
        }

        public Liga(string naziv)
        {
            Naziv = naziv;
        }

        public string Naziv { get; set; }
        public string Drzava { get; set; }
        public int BrojKlubova { get; set; }
        public int Koeficijent {  get; set; }

        public override string ToString()
        {
            return $"{Naziv}";
        }



    }
}
