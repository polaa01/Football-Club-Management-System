using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub.Model
{
    public class Tim
    {
       

        public Tim() { }
        public Tim(int id, string naziv)
        {
            Id = id;
            Naziv = naziv;
        }

        public Tim(int id)
        {
            Id = id;
        }

        public Tim(string naziv)
        {
            Naziv = naziv;
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public override string ToString()
        {
            return $"{ Naziv }";
        }



    }
}
