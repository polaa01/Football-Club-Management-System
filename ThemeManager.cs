using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCI_Fudbalski_Klub
{

    public class ThemeManager
    {

        private Theme currentTheme;
        public static string selectedTheme;

        public event Action<Theme> OnThemeChanged;


        /*
        public  void SetTheme(string themeName)
        {
            if(ThemeManager.Themes.ContainsKey(themeName))
            {
                currentTheme = ThemeManager.Themes[themeName];
                OnThemeChanged?.Invoke(currentTheme);
            }
            
        }
        */
        public Theme GetCurrentTheme()
        {
            return currentTheme;
        }


        //PLAVA
        public static Color BlueInsertBtnColor = ColorTranslator.FromHtml("0x03346E");
        //public static Color BlueUpdateBtnColor = ColorTranslator.FromHtml("0x5b99c2");
        //public static Color BlueDeleteBtnColor = ColorTranslator.FromHtml("0x6eacda");
        public static Color BlueDgvHeader = ColorTranslator.FromHtml("0x7695FF");
        public static Color BlueDgvAltRows = ColorTranslator.FromHtml("0x9ddbff");
        public static Color BlueDgvBack = ColorTranslator.FromHtml("0xC4DAD2");


        //CRVENA
        public static Color RedInsertBtnColor = ColorTranslator.FromHtml("0xff0000");
        public static Color RedDgvHeader = ColorTranslator.FromHtml("0x7d0a0a");
        public static Color RedDgvAltRows = ColorTranslator.FromHtml("0xbf3131");
        public static Color RedDgvBack = ColorTranslator.FromHtml("0xC4DAD2");
        public static Color RedPanelColor = ColorTranslator.FromHtml("0xc40c0c");
        public static Color RedPanelMenuColor = ColorTranslator.FromHtml("0xc96868");




        //ZELENA
        public static Color GreenInsertBtnColor = ColorTranslator.FromHtml("0x6EC207");
        public static Color GreenDgvHeader = ColorTranslator.FromHtml("0x9cdba6");
        public static Color GreenDgvAltRows = ColorTranslator.FromHtml("0xdef9c4");
        public static Color GreenDgvBack = ColorTranslator.FromHtml("0xC4DAD2");
        public static Color GreenPanelColor = ColorTranslator.FromHtml("0xa2ca71");
        public static Color GreenPanelMenuColor = ColorTranslator.FromHtml("0xb4e380");



        public static Dictionary<string, Theme> Themes = new Dictionary<string, Theme>
        {
            {
                "Blue",
                new Theme
                {
                    Font = new Font("Arial", 10),
                    TextColor = Color.White,
                    PanelColor = SystemColors.MenuHighlight,
                    InsertButton = ThemeManager.BlueInsertBtnColor,
                    UpdateButton = ThemeManager.BlueInsertBtnColor,
                    DeleteButton = ThemeManager.BlueInsertBtnColor,
                    DgvHeader = ThemeManager.BlueDgvHeader,
                    DgvRowsBack = Color.White,
                    DgvAlternateRows = ThemeManager.BlueDgvAltRows,
                    DgvRowsFore = Color.Black,
                    DgvHeaderFore = Color.White,
                    PanelButton = Color.LightBlue,
                    DgvBackColor = ThemeManager.BlueDgvBack

                }
            },

            {
                "Red",
                new Theme
                {
                    Font = new Font("Helvetica", 10),
                    TextColor = Color.White,
                    PanelColor = ThemeManager.RedPanelColor,
                    InsertButton = ThemeManager.RedInsertBtnColor,
                    UpdateButton = ThemeManager.RedInsertBtnColor,
                    DeleteButton = ThemeManager.RedInsertBtnColor,
                    DgvHeader = ThemeManager.RedDgvHeader,
                    DgvRowsBack = Color.White,
                    DgvAlternateRows = ThemeManager.RedDgvAltRows,
                    DgvRowsFore = Color.Black,
                    DgvHeaderFore = Color.White,
                    PanelButton = ThemeManager.RedPanelMenuColor,
                    DgvBackColor = ThemeManager.RedDgvBack

                }
            },

            {
                "Green",
                new Theme
                {
                    Font = new Font("Geneve", 10),
                    TextColor = Color.White,
                    PanelColor = ThemeManager.GreenPanelColor,
                    InsertButton = ThemeManager.GreenInsertBtnColor,
                    UpdateButton = ThemeManager.GreenInsertBtnColor,
                    DeleteButton = ThemeManager.GreenInsertBtnColor,
                    DgvHeader = ThemeManager.GreenDgvHeader,
                    DgvRowsBack = Color.White,
                    DgvAlternateRows = ThemeManager.GreenDgvAltRows,
                    DgvRowsFore = Color.Black,
                    DgvHeaderFore = Color.White,
                    PanelButton = ThemeManager.GreenPanelMenuColor,
                    DgvBackColor = ThemeManager.GreenDgvBack
                }
            }



        };


        public static void SetTheme(string theme)
        {
            selectedTheme = theme;

            ApplyThemeToAllOpenForms();
        }

        public static void ApplyThemeToAllOpenForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                ApplyThemeToControl(form);
            }
        }

        public static void ApplyThemeToControl(Control control)
        {
            //control.Font = ThemeManager.Themes[selectedTheme].Font;
            //Theme th = ThemeManager.Themes[selectedTheme];
            //control.Font = th.Font;
           
            //dugme
            if (control is Button btn)
            {
                if(btn.Name == "login")
                {
                    btn.BackColor = Color.Crimson;
                    btn.ForeColor = Color.CornflowerBlue;
                }

                if (btn.Name == "panelBtn")
                {
                    if (selectedTheme == "Blue")
                    {
                        btn.Font = new Font("Arial", 10, FontStyle.Bold);
                        btn.BackColor = Color.LightBlue;

                    }
                    else if (selectedTheme == "Red")
                    {
                        btn.Font = new Font("Helvetica", 10, FontStyle.Bold);
                        btn.BackColor = ThemeManager.RedPanelMenuColor;
                    }
                    else if (selectedTheme == "Green")
                    {
                        btn.Font = new Font("Geneve", 10, FontStyle.Bold);
                        btn.BackColor = ThemeManager.GreenPanelMenuColor;
                    }
                }

                else
                {
                    if (selectedTheme == "Blue")
                    {
                        btn.Font = new Font("Arial", 9, FontStyle.Bold);
                        btn.BackColor = ThemeManager.BlueInsertBtnColor;

                    }
                    else if (selectedTheme == "Red")
                    {
                        btn.Font = new Font("Helvetica", 9, FontStyle.Bold);
                        btn.BackColor = ThemeManager.RedInsertBtnColor;
                    }
                    else if (selectedTheme == "Green")
                    {
                        btn.Font = new Font("Geneve", 9, FontStyle.Bold);
                        btn.BackColor = ThemeManager.GreenInsertBtnColor;
                    }
                }
            }

            //panel
            if (control is Panel pnl)
            {

                if (pnl.Name == "panel2" || pnl.Name == "panel3" || pnl.Name == "panel4" || pnl.Name == "panel5" || pnl.Name == "panel6")
                {
                    if (selectedTheme == "Blue")
                    {
                        pnl.Font = new Font("Arial", 10);
                        pnl.BackColor = Color.LightBlue;
                    }
                    else if (selectedTheme == "Red")
                    {
                        pnl.Font = new Font("Helvetica", 10);
                        pnl.BackColor = ThemeManager.RedPanelMenuColor;
                    }
                    else if (selectedTheme == "Green")
                    {
                        pnl.Font = new Font("Geneve", 10);
                        pnl.BackColor = ThemeManager.GreenPanelMenuColor;
                    }
                }

                else
                {
                    if (selectedTheme == "Blue")
                    {
                        pnl.Font = new Font("Arial", 10);
                        pnl.BackColor = SystemColors.MenuHighlight;
                    }
                    else if (selectedTheme == "Red")
                    {

                        pnl.Font = new Font("Helvetica", 10);
                        pnl.BackColor = ThemeManager.RedPanelColor;
                    }
                    else if (selectedTheme == "Green")
                    {
                        pnl.Font = new Font("Geneve", 10);
                        pnl.BackColor = ThemeManager.GreenPanelColor;
                    }
                }
            }

            if (control is Label lbl)
            {


                if (selectedTheme == "Blue")
                {
                    lbl.Font = new Font("Arial", 10, FontStyle.Bold);
                    lbl.ForeColor = Color.White;
                }
                else if (selectedTheme == "Red")
                {
                    lbl.Font = new Font("Helvetica", 10, FontStyle.Bold);
                    lbl.ForeColor = Color.White;
                }
                else if (selectedTheme == "Green")
                {
                    lbl.Font = new Font("Geneve", 10, FontStyle.Bold);
                    lbl.ForeColor = Color.White;
                }
            }

            if(control is DataGridView dgv)
            {
                if (selectedTheme == "Blue")
                {
                    dgv.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
                    dgv.Font = new Font("Arial", 10, FontStyle.Bold);
                    dgv.BackgroundColor = ThemeManager.BlueDgvBack;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = ThemeManager.BlueDgvAltRows;
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.Black;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.BlueDgvHeader;

                }
                else if (selectedTheme == "Red") 
                {
                    dgv.DefaultCellStyle.Font = new Font("Helvetica", 10, FontStyle.Bold);
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Helvetica", 10, FontStyle.Bold);
                    //dgv.Font = new Font("Helvetica", 10);
                    dgv.BackgroundColor = ThemeManager.RedDgvBack;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = ThemeManager.RedDgvAltRows;
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.Black;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.RedDgvHeader;
                }
                else if (selectedTheme == "Green")
                {
                    dgv.DefaultCellStyle.Font = new Font("Geneve", 10, FontStyle.Bold);
                    dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Geneve", 10, FontStyle.Bold);
                    dgv.BackgroundColor = ThemeManager.GreenDgvBack;
                    dgv.AlternatingRowsDefaultCellStyle.BackColor = ThemeManager.GreenDgvAltRows;
                    dgv.DefaultCellStyle.BackColor = Color.White;
                    dgv.DefaultCellStyle.ForeColor = Color.Black;
                    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                    dgv.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.GreenDgvHeader;
                }

            }

            if (control is UserControl uc)
            {
                if (selectedTheme == "Blue")
                {
                    uc.BackColor = SystemColors.MenuHighlight;

                }
                else if (selectedTheme == "Red")
                {
                    uc.BackColor = ThemeManager.RedPanelColor;
                }

                else if (selectedTheme == "Green")
                {
                    uc.BackColor = ThemeManager.GreenPanelColor;
                }
            }


                    








                

            



            if(control is ComboBox cb)
            {
                if (selectedTheme == "Blue")
                {
                    cb.Font = new Font("Arial", 9);
                }
                else if (selectedTheme == "Red")
                {
                    cb.Font = new Font("Helvetica", 9);
                }

                else if (selectedTheme == "Green")
                {
                    cb.Font = new Font("Geneve", 9);
                }
            }

            if (control is TextBox tb)
            {
                if (selectedTheme == "Blue")
                {
                    tb.Font = new Font("Arial", 9);
                }
                else if (selectedTheme == "Red")
                {
                    tb.Font = new Font("Helvetica", 9);
                }

                else if (selectedTheme == "Green")
                {
                    tb.Font = new Font("Geneve", 9);
                }
            }

            if(control is Form f1)
            {


                if (selectedTheme == "Blue")
                {
                    f1.BackColor = SystemColors.MenuHighlight;
                }
                else if (selectedTheme == "Red")
                {
                    
                    f1.BackColor = ThemeManager.RedPanelColor;
                   
                }

                else if (selectedTheme == "Green")
                {
                    
                    f1.BackColor = ThemeManager.GreenPanelColor;
                }
                if (control is Button Btn)
                {
                    if (Btn.Name == "panelBtn")
                    {
                        if (selectedTheme == "Blue")
                        {
                            Btn.Font = new Font("Arial", 10, FontStyle.Bold);
                            Btn.BackColor = Color.LightBlue;

                        }
                        else if (selectedTheme == "Red")
                        {
                            Btn.Font = new Font("Helvetica", 10, FontStyle.Bold);
                            Btn.BackColor = ThemeManager.RedPanelMenuColor;
                        }
                        else if (selectedTheme == "Green")
                        {
                            Btn.Font = new Font("Geneve", 10, FontStyle.Bold);
                            Btn.BackColor = ThemeManager.GreenPanelMenuColor;
                        }
                    }
                }

            }

          







            // Recursively apply to child controls
            foreach (Control childControl in control.Controls)
            {
                ApplyThemeToControl(childControl);
            }
        }

        public static void ApplyThemeToNewControl(Control control)
        {
            ApplyThemeToControl(control);
        }
















        /*
        public static void ApplyThemeToAllForms()
        {
            foreach (Form form in Application.OpenForms)
            {
                ApplyTheme(form);
            }
        }
        */

        /*
        public static void ApplyTheme(Control control)
        {
            //var theme = GetThemeByName(currentTheme);

            //ApplyThemeRecursively(control, theme);
        }*/


        /*
        public static void ApplyThemeRecursively(Control control, string theme)
        {

            if (theme == null || !ThemeManager.Themes.ContainsKey(theme))
            {
                MessageBox.Show("Nepostojeca tema!");
            }
            else
            {
                Theme selectedTheme = ThemeManager.Themes[theme];
                //control.BackColor = theme.BackgroundColor;
                control.ForeColor = selectedTheme.TextColor;
                control.Font = selectedTheme.Font;
                foreach (Control child in control.Controls)
                {
                    if (child is Button btn)
                    {
                        btn.BackColor = selectedTheme.InsertButton;
                    }
                    //ApplyThemeRecursively(child, theme);
                }
            }
                

            
        }
        */


    }
}
