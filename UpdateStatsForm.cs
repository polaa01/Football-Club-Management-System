using HCI_Fudbalski_Klub.DB;
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

namespace HCI_Fudbalski_Klub
{
    public partial class UpdateStatsForm : Form
    {
        public UpdateStatsForm()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(MenuOptionUC3.poz);
            textBox2.Text = Convert.ToString(MenuOptionUC3.od);
            textBox3.Text = Convert.ToString(MenuOptionUC3.w);
            textBox4.Text = Convert.ToString(MenuOptionUC3.l);
            textBox5.Text = Convert.ToString(MenuOptionUC3.d);
            textBox6.Text = Convert.ToString(MenuOptionUC3.gs);
            textBox7.Text = Convert.ToString(MenuOptionUC3.gr);

            button1.BackColor = ThemeManager.BlueInsertBtnColor;
            button1.Text = LanguageManager.rm.GetString("conf", LanguageManager.currentCulture);
            button1.ForeColor = Color.White;

            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;

            label1.Text = LanguageManager.rm.GetString("poz", LanguageManager.currentCulture);
            label2.Text = LanguageManager.rm.GetString("playedGames", LanguageManager.currentCulture);
            label3.Text = LanguageManager.rm.GetString("wins", LanguageManager.currentCulture);
            label4.Text = LanguageManager.rm.GetString("def", LanguageManager.currentCulture);
            label5.Text = LanguageManager.rm.GetString("draws", LanguageManager.currentCulture);
            label6.Text = LanguageManager.rm.GetString("gs", LanguageManager.currentCulture);
            label7.Text = LanguageManager.rm.GetString("gr", LanguageManager.currentCulture);


            ThemeManager.ApplyThemeToControl(this);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StatisticsDAO.conn.Open();


            MySqlCommand comm = StatisticsDAO.conn.CreateCommand();

            comm.CommandText = @"UPDATE `tim_liga_sezona` SET Pozicija = @poz, Odigrano = @odigrano, Pobjede = @w, 
Porazi = @l, Nerijeseno = @d, Bodovi = @points, Postignuto_Golova = @gs, Primljeno_Golova = @gr WHERE ID_Tima = @tim and 
Naziv_Lige = @liga and ID_Sezone = @sezona";

            comm.Parameters.AddWithValue("@tim", MenuOptionUC3.selectedIdTima);
            comm.Parameters.AddWithValue("@liga", MenuOptionUC3.selectedNazivLige);
            comm.Parameters.AddWithValue("@sezona", MenuOptionUC3.selectedIdSezone);

            comm.Parameters.AddWithValue("@poz", Int32.Parse(textBox1.Text));
            comm.Parameters.AddWithValue("@odigrano", Int32.Parse(textBox2.Text));
            comm.Parameters.AddWithValue("@w", Int32.Parse(textBox3.Text));
            comm.Parameters.AddWithValue("@l", Int32.Parse(textBox4.Text));
            comm.Parameters.AddWithValue("@d", Int32.Parse(textBox5.Text));
            comm.Parameters.AddWithValue("@gs", Int32.Parse(textBox6.Text));
            comm.Parameters.AddWithValue("@gr", Int32.Parse(textBox7.Text));

            int x = Int32.Parse(textBox3.Text);
            int y = Int32.Parse(textBox5.Text);

            comm.Parameters.AddWithValue("@points", 3*x+y);
         
          


            int res = comm.ExecuteNonQuery();
            if (res > 0)
            {
                MessageBox.Show("Uspjesno azurirano " + res + " redova");
            }
            else
            {
                MessageBox.Show("Greska prilikom azuriranja podataka u bazu");
            }

            this.Close();
            StatisticsDAO.conn.Close();
            StatisticsDAO.DisplayData();
        }
    }
}
