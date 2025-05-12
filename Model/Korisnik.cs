using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace HCI_Fudbalski_Klub.Model
{
    public class Korisnik
    {
        public Korisnik() { }

        public Korisnik(int id)
        {
            Id = id;    
        }

        public Korisnik(int id, string ime, string prezime, string telefon, string username, string password, bool isAdmin)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            Username = username;
            Password = password;
            this.isAdmin = isAdmin;
        }

        public Korisnik(int id, string ime, string prezime, string telefon, string username, string password)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Telefon = telefon;
            Username = username;
            Password = password;
            //this.isAdmin = isAdmin;
        }
        public int Id { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }

        public String Telefon { get; set; }

        public String Username { get; set; }

        public String Password { get; set; }
        public bool isAdmin { get; set; }




    }
}
