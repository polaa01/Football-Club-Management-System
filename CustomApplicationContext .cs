using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HCI_Fudbalski_Klub
{
    public class CustomApplicationContext: ApplicationContext
    {
        private Dictionary<string, Form> openForms;
        ThemeManager man;
        public CustomApplicationContext()
        {
            openForms = new Dictionary<string, Form>();
            ShowForm("Form1");
        }

        public void ShowForm(string formName)
        {
            Form form = null;

            switch (formName)
            {
                case "Form1":
                    form = new Form1();
                    break;
                case "Form2":
                    form = new Form2();
                    break;
                case "DialogForm":
                    form = new DialogForm();
                    break;
                    // Add cases for other forms here
            }

            if (form != null)
            {
                form.FormClosed += OnFormClosed;
                form.Show();
                openForms[formName] = form;
            }
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            Form closedForm = sender as Form;
            string formName = closedForm.Name;

            if (openForms.ContainsKey(formName))
            {
                openForms.Remove(formName);
            }

            /*
            if (openForms.Count == 0)
            {
                ExitThread(); // Exit the application when no forms are open
            }
            */
        }

        public void SwitchForm(string oldFormName, string newFormName)
        {
            if (openForms.ContainsKey(oldFormName))
            {
                openForms[oldFormName].Close();
            }

            ShowForm(newFormName);
        }
    }
}
