using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace HCI_Fudbalski_Klub
{
    public class LanguageManager
    {
        public static ResourceManager rm = rm = new ResourceManager("HCI_Fudbalski_Klub.Resources.Resource1", typeof(LanguageManager).Assembly);
        public static CultureInfo currentCulture = currentCulture = new CultureInfo("sr");

       public static CultureInfo CurrentCulture
        {
            get { return currentCulture; }
            set
            {
                currentCulture = value;
                ApplyLanguageToApplication();
            }
        }

            /*
        public static void SetLanguage(string cultureCode)
        {
            currentCulture = new CultureInfo(cultureCode);
        }
            */

         public static void ApplyLanguageToApplication()
        {
            Thread.CurrentThread.CurrentCulture = currentCulture;
            Thread.CurrentThread.CurrentUICulture = currentCulture;

            foreach(Form f in Application.OpenForms)
            {
                ApplyLanguageToControl(f);
            }


        }
        
        public static void ApplyLanguageToControl(Control control)
        {


            foreach (Control c in control.Controls)
            {
                string text = rm.GetString($"{c.Name}.Text", currentCulture);
                if (!string.IsNullOrEmpty(text))
                {
                    c.Text = text;
                }

                if(c.HasChildren)
                {
                    ApplyLanguageToControl(c);
                }
            }
            /*
            
            foreach (Control con in control.Controls)
            {
                if (con is Button button)
                {
                    // Example for the Insert button, using the "insert" key from the resource file
                    if (button.Name == "button5")
                    {
                        button.Text = rm.GetString("logout", currentCulture);  // "insert" is the key in the resource file
                    }
                    if (button.Name == "insert")
                    {
                        button.Text = rm.GetString("insert", currentCulture);
                    }

                    if (button.Name == "update")
                    {
                        button.Text = rm.GetString("insert", currentCulture);
                    }

                    if (button.Name == "delete")
                    {
                        button.Text = rm.GetString("insert", currentCulture);
                    }
                }

                if(con is Label lbl)
                {
                    if(lbl.Name == "jezik")
                    {
                        lbl.Text = rm.GetString("jezik", currentCulture);
                    }

                    if (lbl.Name == "tema")
                    {
                        lbl.Text = rm.GetString("tema", currentCulture);
                    }
                }

                ApplyLanguageToControl(con); //rekurzivno

            }
            */
        }


        /*
        public static void ApplyLanguage(Form form)
        {
            ApplyLanguageToControl(form);
        }

        public static void ApplyLanguage(UserControl userControl)
        {
            ApplyLanguageToControl(userControl);
        }
        */
    }

}
