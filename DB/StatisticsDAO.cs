using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub.DB
{
    public  class StatisticsDAO
    {

        public static MySqlConnection conn = new MySqlConnection(Form2.connString);

        public static void DisplayData()
        {
            StatisticsDAO.conn.Open();
            MySqlCommand comm = StatisticsDAO.conn.CreateCommand();
            comm.CommandText = @"select * from `tim_liga_sezona`";
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(comm);
            da.Fill(dt);
            MenuOptionUC3.dataGridView1.DataSource = dt;
            StatisticsDAO.conn.Close();
        }

        

        public static void DeleteStatistics()
        {
            StatisticsDAO.conn.Open();
            MySqlCommand cmd = StatisticsDAO.conn.CreateCommand();
            cmd.CommandText = "delete from `tim_liga_sezona` where ID_Tima = @id and Naziv_Lige = @liga and ID_Sezone = @sezona";

            //cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", MenuOptionUC3.selectedIdTima);
            cmd.Parameters.AddWithValue("@liga", MenuOptionUC3.selectedNazivLige);
            cmd.Parameters.AddWithValue("@sezona", MenuOptionUC3.selectedIdSezone);


            int res = cmd.ExecuteNonQuery();

            if (res > 0)
            {
                MessageBox.Show("Uspjesno obrisano " + res + " redova");
            }
            else
            {
                MessageBox.Show("Greska prilikom brisanja podataka iz baze");
            }

           
            StatisticsDAO.conn.Close();
            StatisticsDAO.DisplayData();
        }

    }
}
