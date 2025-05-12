using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HCI_Fudbalski_Klub
{
    public partial class MenuOptionUC4 : UserControl
    {
        public static event Action<string> LanguageChanged; //za intenacionalizaciju

        private ThemeManager manager;
        public MenuOptionUC4()
        {

            InitializeComponent();
            this.show();
            //comboBox1.SelectedIndex = 0; //podrazumijevano srpski 

            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged; //jezik

            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged; //tema

            ThemeManager.ApplyThemeToControl(this);
            LanguageManager.ApplyLanguageToControl(this);
            


        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            
            string selectedTheme = comboBox2.SelectedItem.ToString();
            ThemeManager.SetTheme(selectedTheme);
            Form2.SaveUserThemeToFile(Form1.currentUsername, selectedTheme);


            /*
            Form1.selectedThemeStatic = comboBox2.SelectedItem.ToString();
            ThemeManager.SetTheme(Form1.selectedThemeStatic);
            Form2.SaveUserThemeToFile(Form1.currentUsername, Form1.selectedThemeStatic);
            */



        }

        private void show()
        {
            comboBox1.Items.Add("Srpski");
            comboBox1.Items.Add("Engleski");

            jezik.Text = LanguageManager.rm.GetString("jezik", LanguageManager.currentCulture);
            tema.Text = LanguageManager.rm.GetString("tema", LanguageManager.currentCulture);

            jezik.ForeColor = Color.White;

            tema.ForeColor = Color.White;

            comboBox2.DataSource = Form2.GetAvailableThemes();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string language = comboBox1.SelectedItem.ToString();
            //LanguageChanged?.Invoke(language == "Engleski" ? "en-US" : "sr-RS");
            if (language == "Srpski")
            {
                LanguageManager.CurrentCulture = new System.Globalization.CultureInfo("sr");
            }
            else if (language == "Engleski")
            {
                LanguageManager.CurrentCulture = new System.Globalization.CultureInfo("en");
            }
            
            LanguageManager.ApplyLanguageToApplication();

            jezik.Text = LanguageManager.rm.GetString("jezik", LanguageManager.currentCulture);
            tema.Text = LanguageManager.rm.GetString("tema", LanguageManager.currentCulture);

            Form2 f2 = this.ParentForm as Form2;
            if (this.ParentForm != null)
            {
                //this.ParentForm.button1.Text = LanguageManager.rm.GetString("Button1_Text", LanguageManager.currentCulture);
                //parentForm.button2.Text = LanguageManager.rm.GetString("Button2_Text", LanguageManager.currentCulture);
                Button b1 = f2.retBtn1();
                b1.Text = LanguageManager.rm.GetString("users", LanguageManager.currentCulture);
                Button b2 = f2.retBtn2();
                b2.Text = LanguageManager.rm.GetString("players", LanguageManager.currentCulture);
                Button b3 = f2.retBtn3();
                b3.Text = LanguageManager.rm.GetString("stat", LanguageManager.currentCulture);
                Button b4 = f2.retBtn4();
                b4.Text = LanguageManager.rm.GetString("settings", LanguageManager.currentCulture);
                Button b5 = f2.retBtn5();
                b5.Text = LanguageManager.rm.GetString("logout", LanguageManager.currentCulture);

            }
        }
    }
}
