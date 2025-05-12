using HCI_Fudbalski_Klub.DB;
using HCI_Fudbalski_Klub.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HCI_Fudbalski_Klub
{
    public partial class InsertStatsForm : Form
    {
        public InsertStatsForm()
        {
            InitializeComponent();
            this.loadTeamsInLB();
            this.loadLeaguesInLB();
            this.loadSeasonsInLB();

            button1.BackColor = ThemeManager.BlueInsertBtnColor;
            button1.ForeColor = Color.White;
            button1.Text = LanguageManager.rm.GetString("conf", LanguageManager.currentCulture);

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label8.ForeColor = Color.White;
            label9.ForeColor = Color.White;
            label10.ForeColor = Color.White;

            label1.Text = LanguageManager.rm.GetString("team", LanguageManager.currentCulture);
            label2.Text = LanguageManager.rm.GetString("league", LanguageManager.currentCulture);
            label3.Text = LanguageManager.rm.GetString("season", LanguageManager.currentCulture);
            label4.Text = LanguageManager.rm.GetString("poz", LanguageManager.currentCulture);
            label5.Text = LanguageManager.rm.GetString("playedGames", LanguageManager.currentCulture);
            label6.Text = LanguageManager.rm.GetString("wins", LanguageManager.currentCulture);
            label7.Text = LanguageManager.rm.GetString("def", LanguageManager.currentCulture);
            label8.Text = LanguageManager.rm.GetString("draws", LanguageManager.currentCulture);
            label9.Text = LanguageManager.rm.GetString("gs", LanguageManager.currentCulture);
            label10.Text = LanguageManager.rm.GetString("gr", LanguageManager.currentCulture);

            textBox1.PlaceholderText = LanguageManager.rm.GetString("poz", LanguageManager.currentCulture);
            textBox2.PlaceholderText = LanguageManager.rm.GetString("playedGames", LanguageManager.currentCulture);
            textBox3.PlaceholderText = LanguageManager.rm.GetString("wins", LanguageManager.currentCulture);

            textBox4.PlaceholderText = LanguageManager.rm.GetString("def", LanguageManager.currentCulture);
            textBox5.PlaceholderText = LanguageManager.rm.GetString("draws", LanguageManager.currentCulture);
            textBox6.PlaceholderText = LanguageManager.rm.GetString("gs", LanguageManager.currentCulture);
            textBox7.PlaceholderText = LanguageManager.rm.GetString("gr", LanguageManager.currentCulture);



            ThemeManager.ApplyThemeToControl(this);
        }

        private int vratiBodove(int x, int y)
        {
            return 3 * x + y;
        }

        private Tim GetSelectedTeam()
        {
            return (Tim)listBox1.SelectedItem;
        }

        private Liga GetSelectedLeague()
        {
            return (Liga)listBox2.SelectedItem;
        }

        private Sezona GetSelectedSeason()
        {
            return (Sezona)listBox3.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Tim t = null;
            Sezona s = null;
            Liga l = null;

            if (listBox1.SelectedItem != null)
            {
                t = this.GetSelectedTeam();

            }

            if (listBox2.SelectedItem != null)
            {
                l = this.GetSelectedLeague();

            }

            if (listBox3.SelectedItem != null)
            {
                s = this.GetSelectedSeason();

            }


            StatisticsDAO.conn.Open();
            MySqlCommand cmd = StatisticsDAO.conn.CreateCommand();

            cmd.CommandText = @"insert into `tim_liga_sezona` (ID_Tima, Naziv_Lige, ID_Sezone, Pozicija, Odigrano, 
Pobjede, Porazi, Nerijeseno, Bodovi, Postignuto_Golova, Primljeno_Golova) values(@tim, @liga, @sezona, @poz, @odigrano, @w, 
@l, @d, @p, @gs, @gr)";

            cmd.Parameters.AddWithValue("@tim", t.Id);
            cmd.Parameters.AddWithValue("@liga", l.Naziv);
            cmd.Parameters.AddWithValue("@sezona", s.Id);



            cmd.Parameters.AddWithValue("@poz", Int32.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@odigrano", Int32.Parse(textBox2.Text));
            cmd.Parameters.AddWithValue("@w", Int32.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@l", Int32.Parse(textBox4.Text));
            cmd.Parameters.AddWithValue("@d", Int32.Parse(textBox5.Text));
            int x = Int32.Parse(textBox3.Text);
            int y = Int32.Parse(textBox5.Text);
            cmd.Parameters.AddWithValue("@p", this.vratiBodove(x, y));
            cmd.Parameters.AddWithValue("@gs", Int32.Parse(textBox6.Text));
            cmd.Parameters.AddWithValue("@gr", Int32.Parse(textBox7.Text));
            

            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                MessageBox.Show("Uspjesno dodano " + res + " redova");
            }
            else
            {
                MessageBox.Show("Greska prilikom dodavanja podataka u bazu");
            }

            StatisticsDAO.conn.Close();
            this.Hide();
            StatisticsDAO.DisplayData();
        }



        private void loadTeamsInLB() //ucitaj timove u listbox
        {
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


        private void loadSeasonsInLB() //ucitaj timove u listbox
        {
            MySqlConnection conn = new MySqlConnection(Form2.connString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT Id_Sezone FROM sezona";
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                listBox3.Items.Add(new Sezona
                {
                    Id = reader.GetString(0),
                    //Name = reader.GetString(1)

                });

            }

            reader.Close();
            conn.Close();

        }

        private void loadLeaguesInLB() //ucitaj timove u listbox
        {
            MySqlConnection conn = new MySqlConnection(Form2.connString);
            conn.Open();

            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = "SELECT Naziv FROM liga";
            MySqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                listBox2.Items.Add(new Liga
                {
                    Naziv = reader.GetString(0),
                    //Name = reader.GetString(1)

                });

            }

            reader.Close();
            conn.Close();

        }



    }
}
