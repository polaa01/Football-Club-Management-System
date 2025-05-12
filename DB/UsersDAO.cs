using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using HCI_Fudbalski_Klub.Model;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace HCI_Fudbalski_Klub.DB
{
    public class UsersDAO
    {
        //private static string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
        public static MySqlConnection conn = new MySqlConnection(Form2.connString);

        public static void DisplayData() //metoda za prikaz reda u datagrid-u nakon CRUD operacija 
        { 
           
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = @"select * from `korisnik`";
            
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(dt);
            foreach (DataRow dRow in dt.Rows)
            {
                //dRow["Id_Korisnika"] = "***";
                dRow["Lozinka"] = "*****";
            }
            MenuOptionUC1.dataGridView1.DataSource = dt;
            conn.Close();

        }

        /*
        public static void string getLozinka(int id)
        {
            conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = @"select Lozinka from `korisnik` where Id_Korisnika = @id";
            conn.Close();
        }
        */


        public static void InsertUser(Korisnik k)
        {
           
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = @"INSERT INTO korisnik (Id_Korisnika, Ime, Prezime, Broj_telefona, Korisnicko_Ime,
                                    Lozinka, Is_Admin) VALUES(@Id, @Ime, @Prez, @Broj, @Kor, @Pass, @Status)";
            comm.Parameters.AddWithValue("@Id", k.Id);
            comm.Parameters.AddWithValue("@Ime", k.Ime);
            comm.Parameters.AddWithValue("@Prez", k.Prezime);
            comm.Parameters.AddWithValue("@Broj", k.Telefon);
            comm.Parameters.AddWithValue("@Kor", k.Username);
            comm.Parameters.AddWithValue("@Pass", k.Password);
            comm.Parameters.AddWithValue("@Status", k.isAdmin);

           int res = comm.ExecuteNonQuery();
            if(res>0)
            {
                MessageBox.Show("Uspjesno dodano " + res + " redova");
            }
            else
            {
                MessageBox.Show("Greska prilikom dodavanja podataka u bazu");
            }


            conn.Close();
            DisplayData();




        }

        public static void DeleteUsers()
        { 
                conn.Open();

                MySqlCommand comm = conn.CreateCommand();
       
                comm.CommandText = "delete from `korisnik` where Id_Korisnika = @id";
           
            comm.Parameters.AddWithValue("@id", MenuOptionUC1.selectedId);

                int res = comm.ExecuteNonQuery();
                if (res > 0)
                {
                    MessageBox.Show("Uspjesno obrisano " + res + " redova");
                }
                else
                {
                    MessageBox.Show("Greska prilikom brisanja podataka iz baze");
                }


                conn.Close();
                DisplayData();



        }




        public static List<Korisnik> ReadUsers()
        {
            List<Korisnik> list = new List<Korisnik>();
            MySqlConnection conn = new MySqlConnection(Form2.connString);
            conn.Open();


            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select * from `korisnik`";
            MySqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Korisnik()
                {
                    Id = reader.GetInt32(0),
                    Ime = reader.GetString(1),
                    Prezime = reader.GetString(2),
                    Telefon = reader.GetString(3),
                    Username = reader.GetString(4),
                    Password = reader.GetString(5),
                    isAdmin = reader.GetBoolean(6)

                });
            }
            reader.Close();
            conn.Close();
            
            return list;
        }

        public static void UpdateUsers(int id)
        {
            conn.Open();


            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = @"UPDATE `korisnik` SET Ime = @Ime, Prezime = @Prez, Broj_Telefona = @Broj,Korisnicko_Ime = @Kor, Lozinka = @Pass WHERE Id_Korisnika = @Id";

            Korisnik k = new Korisnik(MenuOptionUC1.selectedId);

            comm.Parameters.AddWithValue("@Id", id);
            comm.Parameters.AddWithValue("@Ime", k.Ime);
            comm.Parameters.AddWithValue("@Prez", k.Prezime);
            comm.Parameters.AddWithValue("@Broj", k.Telefon);
            comm.Parameters.AddWithValue("@Kor", k.Username);
            comm.Parameters.AddWithValue("@Pass", k.Password);


            int res = comm.ExecuteNonQuery();
            if (res > 0)
            {
                MessageBox.Show("Uspjesno azurirano " + res + " redova");
            }
            else
            {
                MessageBox.Show("Greska prilikom azuriranja podataka u bazu");
            }


            conn.Close();
            DisplayData();
        }


    }
}
