using HCI_Fudbalski_Klub.DB;
using HCI_Fudbalski_Klub.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace HCI_Fudbalski_Klub
{
    public partial class InsertBtnKorisniciUserControl : UserControl
    {
        public InsertBtnKorisniciUserControl()
        {
            InitializeComponent();
            button1.BackColor = ThemeManager.BlueInsertBtnColor;
            button1.ForeColor = Color.White;
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label6.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            //label8.ForeColor = Color.White;
            this.BackColor = SystemColors.MenuHighlight;
            ThemeManager.ApplyThemeToNewControl(this);
            show();


        }

        public static Font BoldFont(Font font)
        {
            if (font != null)
            {
                FontStyle fontStyle = font.Style;
                if ((fontStyle & FontStyle.Bold) == 0)
                {
                    fontStyle |= FontStyle.Bold;
                    font = new Font(font, fontStyle);
                }
            }
            return font;
        }

        private void show()
        {

            //dugme
            button1.Font = new Font("Arial", 10);
            button1.Text = LanguageManager.rm.GetString("conf", LanguageManager.currentCulture);
            button1.Font = BoldFont(button1.Font);
            button1.ForeColor = Color.White;
            //button1.BackColor = ThemeManager.BlueInsertBtnColor;
            button1.Cursor = Cursors.Hand;
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            button1.BackColorChanged += (s, e) =>
            {
                button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            };



            label1.Font = new Font("Arial", 10);
            label2.Font = new Font("Arial", 10);
            label3.Font = new Font("Arial", 10);
            label4.Font = new Font("Arial", 10);
            label5.Font = new Font("Arial", 10);
            label6.Font = new Font("Arial", 10);
            label7.Font = new Font("Arial", 10);

            //boldovanje labela
            label1.Font = BoldFont(label1.Font);
            label2.Font = BoldFont(label2.Font);
            label3.Font = BoldFont(label3.Font);
            label4.Font = BoldFont(label4.Font);
            label5.Font = BoldFont(label4.Font);
            label6.Font = BoldFont(label4.Font);
            label7.Font = BoldFont(label4.Font);

            //label1.Text = LanguageManager.rm.GetString("id", LanguageManager.currentCulture);
            label2.Text = LanguageManager.rm.GetString("name", LanguageManager.currentCulture);
            label3.Text = LanguageManager.rm.GetString("surname", LanguageManager.currentCulture);
            label4.Text = LanguageManager.rm.GetString("brtel", LanguageManager.currentCulture);
            label5.Text = LanguageManager.rm.GetString("username", LanguageManager.currentCulture);
            label6.Text = LanguageManager.rm.GetString("pass", LanguageManager.currentCulture);
            label7.Text = LanguageManager.rm.GetString("status", LanguageManager.currentCulture);
            //label1.Text = LanguageManager.rm.GetString("update", LanguageManager.currentCulture);

            textBox2.PlaceholderText = LanguageManager.rm.GetString("name", LanguageManager.currentCulture);
            textBox3.PlaceholderText = LanguageManager.rm.GetString("surname", LanguageManager.currentCulture);
            textBox4.PlaceholderText = LanguageManager.rm.GetString("brtel", LanguageManager.currentCulture);
            textBox5.PlaceholderText = LanguageManager.rm.GetString("username", LanguageManager.currentCulture);
            textBox6.PlaceholderText = LanguageManager.rm.GetString("pass", LanguageManager.currentCulture);
            //textBox7.Text = LanguageManager.rm.GetString("pass", LanguageManager.currentCulture);
            //textBox2.Text = LanguageManager.rm.GetString("status", LanguageManager.currentCulture);


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool flag = false;

            int id = Int32.Parse(textBox1.Text);
            string ime = textBox2.Text;
            string prezime = textBox3.Text;
            string broj = textBox4.Text;
            string username = textBox5.Text;
            string password = textBox6.Text;
            //string status = comboBox1.GetItemText(comboBox1.SelectedItem);
            var status = comboBox1.Text;
            if(String.Equals(status, "Admin"))
            {
                flag = true;
            }
            

            Korisnik k = new Korisnik(id, ime, prezime, broj, username, password, flag);
            UsersDAO.InsertUser(k);
            //this.Hide();

            UsersDAO.DisplayData();


        }
    }
}
