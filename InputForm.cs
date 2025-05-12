using HCI_Fudbalski_Klub.DB;
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
    public partial class InputForm : Form
    {
        public static int res;
        public InputForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string tekst = textBox1.Text;
             res = Int32.Parse(tekst);
            //MessageBox.Show("Id = " + res);
            UsersDAO.DeleteUsers();
            this.Close();

        }
    }
}
