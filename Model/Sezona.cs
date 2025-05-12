using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub.Model
{
    public class Sezona
    {
        public Sezona() { }

        public Sezona(string id, DateOnly pocetak, DateOnly kraj)
        {
            Id = id;
            Pocetak = pocetak;
            Kraj = kraj;
        }

        public Sezona(string id)
        {
            Id= id;
        }

        public string Id { get; set; }
        public DateOnly Pocetak { get; set; }
        public DateOnly Kraj { get; set; }

        public override string ToString()
        {
            return $"{Id}";
        }

    }
}
