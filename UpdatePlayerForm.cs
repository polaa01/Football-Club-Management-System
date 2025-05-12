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

namespace HCI_Fudbalski_Klub
{
    public partial class UpdatePlayerForm : Form
    {
        public UpdatePlayerForm()
        {
            InitializeComponent();
            textBox1.Text = Convert.ToString(MenuOptionUC2.odigrao);
            textBox2.Text = Convert.ToString(MenuOptionUC2.golovi);
            textBox3.Text = Convert.ToString(MenuOptionUC2.asistencije);
            this.BackColor = SystemColors.MenuHighlight;
            button1.Text = LanguageManager.rm.GetString("conf", LanguageManager.currentCulture);
            button1.BackColor = ThemeManager.BlueInsertBtnColor;
            button1.ForeColor = Color.White;
            label1.ForeColor = Color.White; 
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label1.Text = LanguageManager.rm.GetString("gol", LanguageManager.currentCulture);
            label2.Text = LanguageManager.rm.GetString("asist", LanguageManager.currentCulture);
            label3.Text = LanguageManager.rm.GetString("played", LanguageManager.currentCulture);
            ThemeManager.ApplyThemeToControl(this);
        }

        private void show()
        {
            int odigrao = Int32.Parse(textBox1.Text);
            int g = Int32.Parse(textBox2.Text);
            int a = Int32.Parse(textBox3.Text);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            PlayersDAO.conn.Open();


            MySqlCommand comm = PlayersDAO.conn.CreateCommand();

            comm.CommandText = @"UPDATE `igrac_tim_sezona` SET Odigrao = @pOdigrao, Golovi = @pGolovi, Asistencije = @pAsistencije WHERE IGRAC_JMB = @jmb";


            //IgracTimSezona igrac = new IgracTimSezona(new Igrac(jmb));

            comm.Parameters.AddWithValue("@jmb", MenuOptionUC2.selectedJMB);
            comm.Parameters.AddWithValue("@pOdigrao", Int32.Parse(textBox1.Text));
            comm.Parameters.AddWithValue("@pGolovi", Int32.Parse(textBox2.Text));
            comm.Parameters.AddWithValue("@pAsistencije", Int32.Parse(textBox3.Text));



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
            PlayersDAO.conn.Close();
            PlayersDAO.DisplayData();
        }
    }
}
