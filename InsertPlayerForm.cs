using HCI_Fudbalski_Klub.DB;
using HCI_Fudbalski_Klub.Model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.IO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCI_Fudbalski_Klub
{
    public partial class InsertPlayerForm : Form
    {
        List<Sezona> sezone;
        List<Tim> timovi;

        string selectedSeasonID = "";
        string selectedTeamName = "";

        string selectedSeasonName = "";
        //int selectedTeamID = 0;

        public InsertPlayerForm()
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            //comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            LoadSeasonsInComboBox();
            LoadTeamsInComboBox();
            label3.ForeColor = Color.White; label2.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;
            label11.ForeColor = Color.White;
            label12.ForeColor = Color.White;
            label13.ForeColor = Color.White;

            label1.Text = LanguageManager.rm.GetString("jmb", LanguageManager.currentCulture);
            label2.Text = LanguageManager.rm.GetString("name", LanguageManager.currentCulture);
            label3.Text = LanguageManager.rm.GetString("surname", LanguageManager.currentCulture);
            label4.Text = LanguageManager.rm.GetString("broj", LanguageManager.currentCulture);
            label5.Text = LanguageManager.rm.GetString("visina", LanguageManager.currentCulture);
            label6.Text = LanguageManager.rm.GetString("poz", LanguageManager.currentCulture);
            label7.Text = LanguageManager.rm.GetString("played", LanguageManager.currentCulture);
            label8.Text = LanguageManager.rm.GetString("gol", LanguageManager.currentCulture);
            label9.Text = LanguageManager.rm.GetString("asist", LanguageManager.currentCulture);
            label10.Text = LanguageManager.rm.GetString("ugovorOd", LanguageManager.currentCulture);
            label11.Text = LanguageManager.rm.GetString("ugovorDo", LanguageManager.currentCulture);
            label12.Text = LanguageManager.rm.GetString("season", LanguageManager.currentCulture);
            label13.Text = LanguageManager.rm.GetString("team", LanguageManager.currentCulture);


            textBox1.PlaceholderText = LanguageManager.rm.GetString("jmb", LanguageManager.currentCulture);
            textBox2.PlaceholderText = LanguageManager.rm.GetString("name", LanguageManager.currentCulture);
            textBox3.PlaceholderText = LanguageManager.rm.GetString("surname", LanguageManager.currentCulture);
            textBox4.PlaceholderText = LanguageManager.rm.GetString("broj", LanguageManager.currentCulture);
            textBox5.PlaceholderText = LanguageManager.rm.GetString("visina", LanguageManager.currentCulture);
            textBox6.PlaceholderText = LanguageManager.rm.GetString("poz", LanguageManager.currentCulture);
            textBox7.PlaceholderText = LanguageManager.rm.GetString("played", LanguageManager.currentCulture);
            textBox8.PlaceholderText = LanguageManager.rm.GetString("gol", LanguageManager.currentCulture);
            textBox9.PlaceholderText = LanguageManager.rm.GetString("asist", LanguageManager.currentCulture);

            button1.BackColor = ThemeManager.BlueInsertBtnColor;
            button1.ForeColor = Color.White;
            button1.Text = LanguageManager.rm.GetString("conf", LanguageManager.currentCulture);
            ThemeManager.ApplyThemeToControl(this);
          
            //ovjde pozvati metode za ucitavanje timova i sezona, mozda
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private Tim GetSelectedTim()
        {
            return (Tim)listBox1.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string jmb = textBox1.Text;
            string ime = textBox2.Text;
            string prezime = textBox3.Text;
            int broj = Int32.Parse(textBox4.Text);
            int visina = Int32.Parse(textBox5.Text);
            string pozicija = textBox6.Text;
            int odigrao = Int32.Parse(textBox7.Text);
            int golovi = Int32.Parse(textBox8.Text);
            int asistencije = Int32.Parse(textBox9.Text);

            DateTime ugovorOdTemp = dateTimePicker1.Value;
            DateOnly ugovorOd = DateOnly.FromDateTime(ugovorOdTemp);


            DateTime ugovorDoTemp = dateTimePicker2.Value;
            DateOnly ugovorDo = DateOnly.FromDateTime(ugovorDoTemp);

            //comboBox1.DataSource = sezone;
            //comboBox1.DisplayMember = "Id_Sezone";
            //comboBox1.ValueMember = "Id_Sezone";

            Sezona s = null;
            Tim t = null;
            


            if (comboBox1.SelectedItem != null)
            {
                
                selectedSeasonID = comboBox1.SelectedValue.ToString();
                s = new Sezona(selectedSeasonID);
                
              //s.Id = selectedSeasonID;
            }

            


            if (listBox1.SelectedItem != null)
            {
                t = this.GetSelectedTim();

            }



            string formattedDate1 = ugovorOd.ToString("yyyy-MM-dd");
            string formattedDate2 = ugovorDo.ToString("yyyy-MM-dd");

            PlayersDAO.conn.Open();
            MySqlCommand cmd = new MySqlCommand("popuni_novi_roster1", PlayersDAO.conn);

            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@pJMB", textBox1.Text);
            cmd.Parameters.AddWithValue("@pIme", textBox2.Text);
            cmd.Parameters.AddWithValue("@pPrezime", textBox3.Text);
            cmd.Parameters.AddWithValue("@pBroj", Int32.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@pVisina", Int32.Parse(textBox5.Text));
            cmd.Parameters.AddWithValue("@pPozicija", textBox6.Text);
            cmd.Parameters.AddWithValue("@pOdigrao", Int32.Parse(textBox7.Text));
            cmd.Parameters.AddWithValue("@pGolovi", Int32.Parse(textBox8.Text));
            cmd.Parameters.AddWithValue("@pAsistencije", Int32.Parse(textBox9.Text));
            cmd.Parameters.AddWithValue("@pUgovorOd", formattedDate1);
            cmd.Parameters.AddWithValue("@pUgovorDo", formattedDate2);
            cmd.Parameters.AddWithValue("@pSezona", s.Id);
            cmd.Parameters.AddWithValue("@pIdTima", t.Id);




            
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                MessageBox.Show("Uspjesno dodano " + res + " redova");
            }
            else
            {
                MessageBox.Show("Greska prilikom dodavanja podataka u bazu");
            }

            PlayersDAO.conn.Close();
            this.Hide();
            PlayersDAO.DisplayData();

        }

        private  void LoadSeasonsInComboBox()
        {
            List<Sezona> list = new List<Sezona>();
            MySqlConnection conn = new MySqlConnection(Form2.connString);
            conn.Open();


            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select * from `sezona`";
            MySqlDataReader reader = comm.ExecuteReader();
            /*
            while (reader.Read())
            {
                list.Add(new Sezona()
                {
                    Id = reader.GetString(0),
                    Pocetak = DateOnly.FromDateTime(reader.GetDateTime(1)),
                    Kraj = DateOnly.FromDateTime(reader.GetDateTime(2))

                });
            }
            */

            using (reader)
            {
                DataTable seasonsTable = new DataTable();
                seasonsTable.Load(reader);


                comboBox1.ValueMember = "Id_Sezone";

                comboBox1.DisplayMember = "Id_Sezone";

                comboBox1.DataSource = seasonsTable;



            }

            reader.Close();
            conn.Close();

            //return list;
        }



        private void LoadTeamsInComboBox()
        {

            //MySqlConnection conn = new MySqlConnection(Form2.connString);
            /*
            conn.Open();


            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "select * from `tim`";
            MySqlDataReader reader = comm.ExecuteReader();

            timovi = new List<Tim>();

            while (reader.Read())
            {
                timovi.Add(new Tim()
                {
                    Id = reader.GetInt32("Id_Tima"),
                    Naziv = reader.GetString("NazivTima")
                   
                });
            }


            comboBox2.DisplayMember = "NazivTima";  // The 'Name' property of the Team class
            comboBox2.ValueMember = "Id_Tima";
            comboBox2.DataSource = timovi;



            
              ///POSEBAN DIO
                DataTable teamsTable = new DataTable();
                teamsTable.Load(reader);

                comboBox2.DataSource = teamsTable;

                comboBox2.DisplayMember = "NazivTima";

                comboBox2.ValueMember = "Id_Tima";
           








            reader.Close();
            conn.Close();

            */


            /*
            MySqlConnection conn = new MySqlConnection(Form2.connString);
            conn.Open();
            string strCmd = "select * from tim";
            MySqlCommand cmd = new MySqlCommand(strCmd, conn);
            MySqlDataAdapter da = new MySqlDataAdapter(strCmd, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            cmd.ExecuteNonQuery();
            conn.Close();

            //comboBox2.DisplayMember = "NazivTima";
            //comboBox2.ValueMember = "Id_Tima";
            //comboBox2.DataSource = ds;

            //comboBox2.Enabled = true;

            */



            //POKUSAJ ZA LISTBOX KOMPONENTOM

            MySqlConnection conn = new MySqlConnection(Form2.connString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT Id_Tima, NazivTima FROM tim";
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add(new Tim
                {
                    Id = reader.GetInt32(0),
                    Naziv = reader.GetString(1)

                });

            }

            

        

            reader.Close();
            conn.Close();

        }


    }
}
