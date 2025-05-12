using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using HCI_Fudbalski_Klub.Model;
using HCI_Fudbalski_Klub.DB;
using System.Configuration;
using System.Runtime.CompilerServices;
using System.Resources;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;


namespace HCI_Fudbalski_Klub
{
    public partial class Form2 : Form
    {

        //private ThemeManager themeManager = new ThemeManager();


        public static string connString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;

        private ResourceManager resourceManager;
        private CultureInfo cultureInfo;

        public static Panel panel7 = new Panel();

        public static Dictionary<string, string> userThemes = new Dictionary<string, string>();

        public static void SaveUserThemeToFile(string username, string theme)
        {
            userThemes[username] = theme;


            using (StreamWriter writer = new StreamWriter("userThemes.txt"))
            {
                foreach (var entry in userThemes)
                {
                    writer.WriteLine($"{entry.Key},{entry.Value}");
                }
            }
        }

        public static void LoadUserThemesFromFile()
        {
            if (File.Exists("userThemes.txt"))
            {
                // Clear current dictionary and load from file
                userThemes.Clear();

                using (StreamReader reader = new StreamReader("userThemes.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            userThemes[parts[0]] = parts[1]; // username, theme
                        }
                    }
                }
            }
        }


        public Form2()
        {
            InitializeComponent();
            this.Name = "Form2";


            Form2.panel7.BackColor = SystemColors.MenuHighlight;

            Form2.panel7.Width = 693;
            Form2.panel7.Height = 576;
            Form2.panel7.Top = 0;
            Form2.panel7.Left = 160;
            this.Controls.Add(panel7);

            ThemeManager.ApplyThemeToControl(this);
            LanguageManager.ApplyLanguageToApplication();


            //RADI
            this.show();
            this.Load += Form2_Load;


        }

        /*
        public void ApplyLanguage(string culture)
        {
            cultureInfo = new CultureInfo(culture);
            resourceManager = new ResourceManager("HCI_Fudbalski_Klub.Resources.Resource1", typeof(Form2).Assembly);

            // Apply language to specific controls manually
            button1.Text = resourceManager.GetString("users", cultureInfo);
            button2.Text = resourceManager.GetString("players", cultureInfo);
            button3.Text = resourceManager.GetString("stat", cultureInfo);
            button4.Text = resourceManager.GetString("settings", cultureInfo);
            button5.Text = resourceManager.GetString("logout", cultureInfo);

          
        }
        */

        public Button retBtn1()
        {
            return button1;
        }

        public Button retBtn2()
        {
            return button2;
        }

        public Button retBtn3()
        {
            return button3;
        }

        public Button retBtn4()
        {
            return button4;
        }

        public Button retBtn5()
        {
            return button5;
        }
        private void show()
        {

            button1.Name = "panelBtn";
            button1.Text = LanguageManager.rm.GetString("users", LanguageManager.currentCulture);
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            button1.BackColorChanged += (s, e) =>
            {
                button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            };

            button2.Name = "panelBtn";
            //var key2 = "players";
            button2.Text = LanguageManager.rm.GetString("players", LanguageManager.currentCulture);
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseOverBackColor = button2.BackColor;
            button2.BackColorChanged += (s, e) =>
            {
                button2.FlatAppearance.MouseOverBackColor = button2.BackColor;
            };

            button3.Name = "panelBtn";
            button3.Text = LanguageManager.rm.GetString("stat", LanguageManager.currentCulture);
            button3.FlatStyle = FlatStyle.Flat;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseOverBackColor = button3.BackColor;
            button3.BackColorChanged += (s, e) =>
            {
                button3.FlatAppearance.MouseOverBackColor = button3.BackColor;
            };

            button4.Name = "panelBtn";
            button4.Text = LanguageManager.rm.GetString("settings", LanguageManager.currentCulture);
            button4.FlatStyle = FlatStyle.Flat;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.MouseOverBackColor = button4.BackColor;
            button4.BackColorChanged += (s, e) =>
            {
                button4.FlatAppearance.MouseOverBackColor = button4.BackColor;
            };

            button5.Name = "panelBtn";
            button5.Text = LanguageManager.rm.GetString("logout", LanguageManager.currentCulture);
            button5.FlatStyle = FlatStyle.Flat;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatAppearance.MouseOverBackColor = button5.BackColor;
            button5.BackColorChanged += (s, e) =>
            {
                button5.FlatAppearance.MouseOverBackColor = button5.BackColor;
            };

        }





        public static List<string> GetAvailableThemes()
        {
            return ThemeManager.Themes.Keys.ToList();
        }






        private void MenuOptionUC1_OpenDialogRequested(object sender, EventArgs e)
        {
            var newForm = new InputForm();
            newForm.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ThemeManager.ApplyThemeToControl(this);
            LoadContent(new MenuOptionUC0());
        }



        /*
        private void SetColumnHeaders()
        {

            MenuOptionUC1.dataGridView1.Columns["Id_Korisnika"].HeaderText = "Id";
            MenuOptionUC1.dataGridView1.Columns["Broj_telefona"].HeaderText = "Broj telefona";
            MenuOptionUC1.dataGridView1.Columns["Korisnicko_Ime"].HeaderText = "Korisnicko ime";
            MenuOptionUC1.dataGridView1.Columns["Is_Admin"].HeaderText = "Status";
        }
        */



        public static void LoadContent(UserControl control)
        {
            panel7.Controls.Clear();
            control.Dock = DockStyle.Fill;
            panel7.Controls.Add(control);
            ThemeManager.ApplyThemeToControl(control);
            LanguageManager.ApplyLanguageToControl(control);
        }


        private void korisniciButton(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            //new Form1().Show();

            AppContext.Context.SwitchForm("Form2", "Form1");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Process.Start("https://www.fcbarcelona.com/en/");
        }

        private void label2_Click(object sender, EventArgs e)
        {
            AppContext.Context.SwitchForm("Form2", "Form3");
        }


        //STAVKA U MENIJU - KORISNICI
        private void showUsersLayout()
        {
            //boja zaglavlja: plava tema - 0x7695FF, boja redova - 0x9DBDFF
            DataGridView dataGridView1 = new DataGridView();
            dataGridView1.BorderStyle = BorderStyle.None;
            Color c1 = ColorTranslator.FromHtml("0xC4DAD2");
            Color c2 = ColorTranslator.FromHtml("0x7695FF");
            Color c3 = ColorTranslator.FromHtml("0x9ddbff");

            //dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            //dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;


            //dataGridView1.AllowUserToResizeColumns = true;
            //dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = c2;
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = c3;
            dataGridView1.BackgroundColor = c1;

            dataGridView1.Left = 50;
            dataGridView1.Top = 180;
            dataGridView1.Width = 544;
            dataGridView1.Height = 340;

            var col1 = new DataGridViewTextBoxColumn();
            var col2 = new DataGridViewTextBoxColumn();
            var col3 = new DataGridViewTextBoxColumn();

            col1.HeaderText = "Id";
            col2.HeaderText = "Korisnicko ime";
            col3.HeaderText = "Status";

            col1.ValueType = typeof(string);
            col2.ValueType = typeof(string);
            col3.ValueType = typeof(string);

            dataGridView1.Columns.Add(col1);
            dataGridView1.Columns.Add(col2);
            dataGridView1.Columns.Add(col3);

            dataGridView1.Font = new Font("Arial", 11, FontStyle.Regular);


            dataGridView1.Rows.Add("1", "Milan", "Admin");
            dataGridView1.Rows.Add("2", "Marko", "Standardni korisnik");
            dataGridView1.Rows.Add("3", "Marko", "Standardni korisnik");




            panel7.Controls.Add(dataGridView1);





            //dugmad
            Color plavaIns = ColorTranslator.FromHtml("0x03346E");
            Color plavaUpd = ColorTranslator.FromHtml("0x5b99c2");
            Color plavaDel = ColorTranslator.FromHtml("0x6eacda");

            /*
            Image img1 = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\insert.png");
            System.Windows.Forms.Button insertBtn = CreateButtonWithImage("Insert", img1, 150, 52);
            insertBtn.Name = "insert";
            insertBtn.Text = "Insert";
            insertBtn.Font = new Font("Arial", 10, FontStyle.Bold);
            insertBtn.Location = new Point(50, 78);
            //insertBtn.Width = 140;
            //insertBtn.Height = 55;
            insertBtn.Cursor = Cursors.Hand;
            insertBtn.BackColor = plavaIns;
            insertBtn.ForeColor = Color.White;

            //dodavanje slike na dugme pored teksta
            //insertBtn.Image = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\insert.png");
            //insertBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            //insertBtn.ImageAlign = ContentAlignment.MiddleRight;

            insertBtn.FlatStyle = FlatStyle.Flat;
            insertBtn.FlatAppearance.BorderSize = 0;
            insertBtn.FlatAppearance.MouseOverBackColor = insertBtn.BackColor;
            insertBtn.BackColorChanged += (s, e) =>
            {
                insertBtn.FlatAppearance.MouseOverBackColor = insertBtn.BackColor;
            };
            */


            /*
            Image img2 = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\reload.png");
            Button updateBtn = CreateButtonWithImage("Update", img2, 150, 52);
            updateBtn.Font = new Font("Arial", 10, FontStyle.Bold);
            updateBtn.Name = "update";
            //updateBtn.Text = "UPDATE";
            updateBtn.Location = new Point(247, 78);
            //updateBtn.Width = 140;
            //updateBtn.Height = 55;
            updateBtn.Cursor = Cursors.Hand;
            updateBtn.BackColor = plavaUpd;
            updateBtn.ForeColor = Color.White;

            updateBtn.FlatStyle = FlatStyle.Flat;
            updateBtn.FlatAppearance.BorderSize = 0;
            updateBtn.FlatAppearance.MouseOverBackColor = updateBtn.BackColor;
            updateBtn.BackColorChanged += (s, e) =>
            {
                updateBtn.FlatAppearance.MouseOverBackColor = updateBtn.BackColor;
            };
            */



            /*
            Image img3 = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\trash-bin.png");
            Button deleteBtn = CreateButtonWithImage("Delete", img3, 150, 52);
            deleteBtn.Font = new Font("Arial", 10, FontStyle.Bold);
            deleteBtn.Name = "delete";
            //deleteBtn.Text = "DELETE";
            deleteBtn.Location = new Point(444, 78);
            //deleteBtn.Width = 140;
            //deleteBtn.Height = 55;
            deleteBtn.Cursor = Cursors.Hand;
            deleteBtn.BackColor = plavaDel;
            deleteBtn.ForeColor = Color.White;

            deleteBtn.FlatStyle = FlatStyle.Flat;
            deleteBtn.FlatAppearance.BorderSize = 0;
            deleteBtn.FlatAppearance.MouseOverBackColor = deleteBtn.BackColor;
            deleteBtn.BackColorChanged += (s, e) =>
            {
                deleteBtn.FlatAppearance.MouseOverBackColor = deleteBtn.BackColor;
            };


            //dodavanje dugmadi na panel
            panel7.Controls.Add(insertBtn);
            panel7.Controls.Add(updateBtn);
            panel7.Controls.Add(deleteBtn);
            */


        }

        private void button1_Click(object sender, EventArgs e) //dugme za prikaz korisnika sistema
        {

            LoadContent(new MenuOptionUC1());
            UsersDAO.DisplayData();
            //List<Korisnik> list = UsersDAO.ReadUsers();
            //MenuOptionUC1.source.DataSource = list;
        }



        // Method to create a button with text and picture
        public static Button CreateButtonWithImage(string text, Image image, int width, int height)
        {
            // Create a new button
            Button button = new Button();
            button.Text = text;
            button.Width = width;
            button.Height = height;

            //logika za crtanje zaobljenih ivica
            button.Paint += (sender, e) =>
            {
                Button btn = sender as Button;
                Graphics gr = e.Graphics;

                gr.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                GraphicsPath path = new GraphicsPath();
                int radius = 20;
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(btn.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(btn.Width - radius, btn.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, btn.Height - radius, radius, radius, 90, 90);
                path.CloseAllFigures();

                //gr.FillPath(new SolidBrush(btn.BackColor), path);
                gr.DrawPath(new Pen(btn.BackColor, 2), path);


            };

            // Create a PictureBox to hold the image
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = image;
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;  // Stretch the image
            pictureBox.Width = height - 10;  // Adjust size to keep it square-like (modify as needed)
            pictureBox.Height = height - 10;

            // Position the PictureBox to the right of the button
            pictureBox.Location = new Point(button.Width - pictureBox.Width - 10, 5);  // Padding from the right

            // Add the PictureBox as a child of the button
            button.Controls.Add(pictureBox);

            // Position the text on the left side (you can adjust padding here)
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(10, 0, pictureBox.Width + 20, 0);  // Adjust the right padding to make space for the image

            return button;
        }






        //STAVKA U MENIJU - IGRACI
        private void showPlayersLayout()
        {



        }


        private void button2_Click(object sender, EventArgs e)
        {

            LoadContent(new MenuOptionUC2());
            PlayersDAO.DisplayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadContent(new MenuOptionUC3());
            StatisticsDAO.DisplayData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadContent(new MenuOptionUC4());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //tim
        }
    }
}
