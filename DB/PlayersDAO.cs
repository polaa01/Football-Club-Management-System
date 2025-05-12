using HCI_Fudbalski_Klub.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub.DB
{
    public class PlayersDAO
    {
        public static MySqlConnection conn = new MySqlConnection(Form2.connString);
        public static void DisplayData() //metoda za prikaz reda u datagrid-u nakon CRUD operacija 
        {
            PlayersDAO.conn.Open();
            MySqlCommand comm = PlayersDAO.conn.CreateCommand();
            comm.CommandText = @"select * from `roster_novi1`"; 
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(dt);
            MenuOptionUC2.dataGridView3.DataSource = dt;
            PlayersDAO.conn.Close();

        }

        public static void InsertPlayers(IgracTimSezona igracTimSezona)
        {
            
            
                PlayersDAO.conn.Open();
                MySqlCommand cmd = new MySqlCommand("popuni_novi_roster", PlayersDAO.conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("pJMB", igracTimSezona.Igrac.Jmb);
                cmd.Parameters.AddWithValue("pIme", igracTimSezona.Igrac.Ime);
                cmd.Parameters.AddWithValue("pPrezime", igracTimSezona.Igrac.Prezime);
                cmd.Parameters.AddWithValue("pBroj", igracTimSezona.Igrac.Broj);
                cmd.Parameters.AddWithValue("pVisina", igracTimSezona.Igrac.Visina);
                cmd.Parameters.AddWithValue("pPozicija", igracTimSezona.Pozicija);
                cmd.Parameters.AddWithValue("pOdigrao", igracTimSezona.Odigrao);
                cmd.Parameters.AddWithValue("pGolovi", igracTimSezona.Golovi);
                cmd.Parameters.AddWithValue("pAsistencije", igracTimSezona.Asistencije);
                cmd.Parameters.AddWithValue("pUgovorOd", igracTimSezona.UgovorOd);
                cmd.Parameters.AddWithValue("pUgovorDo", igracTimSezona.UgovorDo);
                cmd.Parameters.AddWithValue("pSezona", igracTimSezona.IdSezone);
                cmd.Parameters.AddWithValue("pIdTima", igracTimSezona.IdTima);
                
                


                cmd.ExecuteNonQuery();
                
                PlayersDAO.conn.Close();
           

        }

        public static void DeletePlayers()
        {
            PlayersDAO.conn.Open();
            MySqlCommand cmd = new MySqlCommand("obrisi_igraca_procedura1", PlayersDAO.conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pJMB", MenuOptionUC2.selectedJMB);


            int res = cmd.ExecuteNonQuery();
          
            if (res > 0)
            {
                MessageBox.Show("Uspjesno obrisano " + res + " redova");
            }
            else
            {
                MessageBox.Show("Greska prilikom brisanja podataka iz baze");
            }

            PlayersDAO.conn.Close();
            PlayersDAO.DisplayData();
        }


        public static void UpdatePlayers(string jmb)
        {
            conn.Open();


            MySqlCommand comm = conn.CreateCommand();

            comm.CommandText = @"UPDATE `igrac_tim_sezona` SET Odigrao = @pOdigrao, Golovi = @pGolovi, Asistencije = @pAsistencije WHERE IGRAC_JMB = @jmb";

           
            IgracTimSezona igrac = new IgracTimSezona(new Igrac(jmb));

            
            comm.Parameters.AddWithValue("@pOdigrao", igrac.Odigrao);
            comm.Parameters.AddWithValue("@pGolovi", igrac.Golovi);
            comm.Parameters.AddWithValue("@pAsistencije", igrac.Asistencije);



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
            PlayersDAO.DisplayData();
        }




    }
}
