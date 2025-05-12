using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub.Model
{
    public class TimLigaSezona
    {
        public TimLigaSezona() { }

        public TimLigaSezona(Tim tim, Liga liga, Sezona sezona, int pozicija, int odigrano, int pobjede, int porazi,
            int nerijeseno, int postignuto, int primljeno)
        {
            Tim = tim;
            Liga = liga;
            Sezona = sezona;
            Pozicija = pozicija;
            Odigrano = odigrano;
            Pobjede = pobjede;
            Porazi = porazi;
            Nerijeseno = nerijeseno;
            Postignuto = postignuto;
            Primljeno = primljeno;

        }

        public Tim Tim { get; set; }
        public Liga Liga { get; set; }

        public Sezona Sezona { get; set; }

        public int Pozicija { get; set; }

        public int Odigrano { get; set; }

        public int Pobjede { get; set; }
        public int Porazi { get; set; }
        public int Nerijeseno { get; set; }

        public int Postignuto { get; set; }

        public int Primljeno { get; set; }
    }
}
