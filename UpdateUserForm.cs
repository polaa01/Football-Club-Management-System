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
    public partial class UpdateUserForm : Form
    {
        public UpdateUserForm()
        {
            InitializeComponent();
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;

            label1.Text = LanguageManager.rm.GetString("name", LanguageManager.currentCulture);
            label2.Text = LanguageManager.rm.GetString("surname", LanguageManager.currentCulture);
            label3.Text = LanguageManager.rm.GetString("brtel", LanguageManager.currentCulture);
            label4.Text = LanguageManager.rm.GetString("username", LanguageManager.currentCulture);
            label5.Text = LanguageManager.rm.GetString("pass", LanguageManager.currentCulture);
            //label6.ForeColor = Color.White;
            button1.BackColor = ThemeManager.BlueInsertBtnColor;
            button1.ForeColor = Color.White;
            ThemeManager.ApplyThemeToControl(this);
            //ThemeManager.ApplyThemeToAllOpenForms();
            display();

        }

        private void display()
        {
            button1.BackColor = ThemeManager.BlueInsertBtnColor;
            ThemeManager.ApplyThemeToControl(button1 as Button); //kriticno
            button1.Text = LanguageManager.rm.GetString("conf", LanguageManager.currentCulture);
            /*
            Korisnik k = new Korisnik(MenuOptionUC1.selectedId);
            string ime = k.Ime;
            string prezime = k.Prezime;
            string brojTel = k.Telefon;
            string korisnickoIme = k.Username;
            string lozinka = k.Password;
            */

            textBox1.Text = MenuOptionUC1.ime;
            textBox2.Text = MenuOptionUC1.prezime;
            textBox3.Text = MenuOptionUC1.brojTel;
            textBox4.Text = MenuOptionUC1.korisnicko;
            textBox5.Text = MenuOptionUC1.lozinka;


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Korisnik k1 = new Korisnik(MenuOptionUC1.selectedId, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                textBox5.Text);

            /*
            k1.Ime = textBox1.Text;
            k1.Prezime = textBox2.Text;
            k1.Telefon = textBox3.Text;
            k1.Username = textBox4.Text;
            k1.Password = textBox5.Text;
            */

            MessageBox.Show(k1.Ime + " " + k1.Prezime + " " + k1.Telefon + " " + k1.Username + " " + k1.Password);
            //UsersDAO.UpdateUsers(k1.Id);
            //this.Close();

            UsersDAO.conn.Open();


            MySqlCommand comm = UsersDAO.conn.CreateCommand();

            comm.CommandText = @"UPDATE `korisnik` SET Ime = @Ime, Prezime = @Prez, Broj_Telefona = @Broj,Korisnicko_Ime = @Kor, Lozinka = @Pass WHERE Id_Korisnika = @Id";

            //Korisnik k = new Korisnik(MenuOptionUC1.selectedId);

            comm.Parameters.AddWithValue("@Id", MenuOptionUC1.selectedId);
            comm.Parameters.AddWithValue("@Ime", textBox1.Text);
            comm.Parameters.AddWithValue("@Prez", textBox2.Text);
            comm.Parameters.AddWithValue("@Broj", textBox3.Text);
            comm.Parameters.AddWithValue("@Kor", textBox4.Text);
            comm.Parameters.AddWithValue("@Pass", textBox5.Text);


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
            UsersDAO.conn.Close();
            UsersDAO.DisplayData();
        }
    }
}
