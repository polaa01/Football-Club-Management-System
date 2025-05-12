using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub.Model
{
    public class Igrac
    {
        public Igrac() { }
        public Igrac(String jmb) {
            Jmb = jmb;
        }
        public Igrac(String jmb, String ime, String prezime, int broj, int visina)
        {
            Jmb=jmb;
            Ime=ime;   
            Prezime=prezime;
            Broj=broj;
            Visina=visina;
        }

       

        public String Jmb { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public int Broj { get; set; }
        public int Visina { get; set; }

    }
}
