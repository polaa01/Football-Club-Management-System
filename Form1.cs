using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Windows.Forms;
namespace HCI_Fudbalski_Klub
{
    public partial class Form1 : Form
    {
        private ThemeManager manager;
        public static MySqlConnection conn = new MySqlConnection(Form2.connString);
        public static int Role;
        public static string currentUsername;
        public static string selectedThemeStatic;
        public Form1()
        {
            InitializeComponent();
            this.Name = "Form1";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void SetUserRole(string u, string p) //admin ili standardni korisnik
        {
            //int role = -1;
            Form1.conn.Open();
            MySqlCommand comm = conn.CreateCommand();
            comm.CommandText = @"select Is_Admin from `korisnik` where Korisnicko_Ime = @u and Lozinka = @p";
            comm.Parameters.AddWithValue("@u", u);
            comm.Parameters.AddWithValue("@p", p);

            object result = comm.ExecuteScalar();

            if (result != null)
            {
                Form1.Role = Convert.ToInt32(result); // 0 ili 1
            }
            else
            {
                Form1.Role = -1;
            }
            Form1.conn.Close();
            //return role;

        }

        private void login_Click(object sender, EventArgs e)
        {

            //AppContext.Context.SwitchForm("Form1", "Form2"); - primarni nacin, sada cemo isprobati nesto drugo
            Form2.LoadUserThemesFromFile();
            string s1 = username.Text;
            string s2 = password.Text;
            this.SetUserRole(s1, s2);

            if(Form1.Role != -1)
            {
                 //mozda je kritican dio koda u pitanju
                if (Form2.userThemes.ContainsKey(s1))
                {
                    Form1.selectedThemeStatic = Form2.userThemes[s1];

                    ThemeManager.SetTheme(Form1.selectedThemeStatic);
                   
                    //ThemeManager.ApplyThemeToControl(this);
                }
                Form1.currentUsername = s1;
                this.Hide();
                Form2 f2 = new Form2();
                f2.FormClosed += (s, args) => this.Show();
                f2.Show();
            }
            else
            {
                MessageBox.Show("Neispravni kredencijali");
                username.Clear();
                password.Clear();
            }

            



        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           Application.Exit();
        }
        
    }
}
