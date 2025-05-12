using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub.Model
{
    public class IgracTimSezona
    {
        public IgracTimSezona() { }

        public IgracTimSezona(Igrac igrac, string pozicija, int odigrao, int golovi, int asistencije,
            DateOnly ugovorOd, DateOnly ugovorDo, Sezona sezona, Tim tim)
        {
            Igrac = igrac;
            Pozicija = pozicija;
            Odigrao = odigrao;
            Golovi = golovi;
            Asistencije = asistencije;
            UgovorOd = ugovorOd;
            UgovorDo = ugovorDo;
            Sezona = sezona;
            Tim = tim;
        }

        public IgracTimSezona(Igrac igrac, string pozicija, int odigrao, int golovi, int asistencije,
            DateOnly ugovorOd, DateOnly ugovorDo, string idSezone, int idTima)
        {
            Igrac = igrac;
            Pozicija = pozicija;
            Odigrao = odigrao;
            Golovi = golovi;
            Asistencije = asistencije;
            UgovorOd = ugovorOd;
            UgovorDo = ugovorDo;
            IdSezone = idSezone;
            IdTima = idTima;
        }

        public IgracTimSezona(Igrac i)
        {
            Igrac = i;
        }

        public Igrac Igrac { get; set; }
        public Tim Tim { get; set; }
        public Sezona Sezona { get; set; }  

        public string Pozicija { get; set; }

        public int Odigrao { get; set; }

        public int Golovi { get; set; }

        public int Asistencije { get; set; }
        public DateOnly UgovorOd { get; set; }

        public DateOnly UgovorDo { get; set; }

        public string IdSezone { get; set; }

        public int IdTima { get; set; }

    }
}
