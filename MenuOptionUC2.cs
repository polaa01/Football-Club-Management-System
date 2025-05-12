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
    public partial class MenuOptionUC2 : UserControl
    {

        public static DataGridView dataGridView3;
        private BindingSource bindingSource2 = new BindingSource();
        public static string selectedJMB;

        public static int odigrao, golovi, asistencije;
        
        public MenuOptionUC2()
        {
            InitializeComponent();
            this.show();
            label1.Text = LanguageManager.rm.GetString("searchBySeason", LanguageManager.currentCulture);
            textBox1.PlaceholderText = LanguageManager.rm.GetString("search", LanguageManager.currentCulture);
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            //ThemeManager.ApplyThemeRecursively(this, ThemeManager.currentTheme);
        }


        /*
        private void MenuOptionUC2_Load(object sender, EventArgs e)
        {
            PlayersDAO.DisplayData();
        }
        */

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView3.DataSource;
            bs.Filter = dataGridView3.Columns[12].HeaderText.ToString() + " LIKE '%" + textBox1.Text + "%'";
            dataGridView3.DataSource = bs.DataSource;

        }


        private void show()
        {

            
            MenuOptionUC2.dataGridView3 = new DataGridView();
            MenuOptionUC2.dataGridView3.DataSource = bindingSource2;
           

            //ucitavanje slike za insert
            Image img1 = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\insert.png");
            Button insertBtn = Form2.CreateButtonWithImage("Dodaj", img1, 150, 52);
            insertBtn.Name = "insert";
            insertBtn.Text = LanguageManager.rm.GetString("insert", LanguageManager.currentCulture);
            
            insertBtn.Font = new Font("Arial", 10, FontStyle.Bold);
            insertBtn.Location = new Point(50, 93);
            insertBtn.Cursor = Cursors.Hand;
            insertBtn.BackColor = ThemeManager.BlueInsertBtnColor;
            insertBtn.ForeColor = Color.White;

          

            insertBtn.FlatStyle = FlatStyle.Flat;
            insertBtn.FlatAppearance.BorderSize = 0;
            insertBtn.FlatAppearance.MouseOverBackColor = insertBtn.BackColor;
            insertBtn.BackColorChanged += (s, e) =>
            {
                insertBtn.FlatAppearance.MouseOverBackColor = insertBtn.BackColor;
            };


            insertBtn.Click += (sender, args) =>
            {

                this.Hide();
                InsertPlayerForm form = new InsertPlayerForm();
                form.FormClosed += (s, args) => this.Show();
                form.Show();
            };













            Image img2 = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\reload.png");
            Button updateBtn = Form2.CreateButtonWithImage("Ažuriraj", img2, 150, 52);
            updateBtn.Font = new Font("Arial", 10, FontStyle.Bold);
            updateBtn.Name = "update";
            updateBtn.Text = LanguageManager.rm.GetString("update", LanguageManager.currentCulture);
            //updateBtn.Text = "UPDATE";
            updateBtn.Location = new Point(247, 93);
            
            //updateBtn.Width = 140;
            //updateBtn.Height = 55;
            updateBtn.Cursor = Cursors.Hand;
            updateBtn.BackColor = ThemeManager.BlueInsertBtnColor;
            updateBtn.ForeColor = Color.White;

            updateBtn.FlatStyle = FlatStyle.Flat;
            updateBtn.FlatAppearance.BorderSize = 0;
            updateBtn.FlatAppearance.MouseOverBackColor = updateBtn.BackColor;
            updateBtn.BackColorChanged += (s, e) =>
            {
                updateBtn.FlatAppearance.MouseOverBackColor = updateBtn.BackColor;
            };


            updateBtn.Click += (sender, args) =>
            {
                int selectedRowCount =
                  MenuOptionUC2.dataGridView3.Rows.GetRowCount(DataGridViewElementStates.Selected);

                MenuOptionUC2.selectedJMB = Convert.ToString(dataGridView3.CurrentRow.Cells[0].Value);
                MenuOptionUC2.odigrao = Convert.ToInt32(dataGridView3.CurrentRow.Cells[6].Value);
                MenuOptionUC2.golovi = Convert.ToInt32(dataGridView3.CurrentRow.Cells[7].Value);
                MenuOptionUC2.asistencije = Convert.ToInt32(dataGridView3.CurrentRow.Cells[8].Value);

                if (selectedRowCount > 0)
                {
                    MessageBox.Show("Uspješno izabran red za ažuriranje");
                    this.HideParentForm();
                    UpdatePlayerForm f1 = new UpdatePlayerForm();
                    f1.FormClosed += (s, args) => this.ShowParentForm();
                    f1.Show();

                }
                else
                {
                    MessageBox.Show("Izaberite red za ažuriranje");
                }

            };






















            Image img3 = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\trash-bin.png");
            Button deleteBtn = Form2.CreateButtonWithImage("Briši", img3, 150, 52);
            deleteBtn.Font = new Font("Arial", 10, FontStyle.Bold);
            deleteBtn.Name = "delete";
            deleteBtn.Text = LanguageManager.rm.GetString("delete", LanguageManager.currentCulture);
            //deleteBtn.Text = "DELETE";
            deleteBtn.Location = new Point(444, 93);
            //deleteBtn.Width = 140;
            //deleteBtn.Height = 55;
            deleteBtn.Cursor = Cursors.Hand;
            deleteBtn.BackColor = ThemeManager.BlueInsertBtnColor;
            deleteBtn.ForeColor = Color.White;

            deleteBtn.FlatStyle = FlatStyle.Flat;
            deleteBtn.FlatAppearance.BorderSize = 0;
            deleteBtn.FlatAppearance.MouseOverBackColor = deleteBtn.BackColor;
            deleteBtn.BackColorChanged += (s, e) =>
            {
                deleteBtn.FlatAppearance.MouseOverBackColor = deleteBtn.BackColor;
            };

            deleteBtn.Click += (sender, args) =>
            {

                int selectedRowCount =
                  MenuOptionUC2.dataGridView3.Rows.GetRowCount(DataGridViewElementStates.Selected);

                MenuOptionUC2.selectedJMB = Convert.ToString(MenuOptionUC2.dataGridView3.CurrentRow.Cells[0].Value);
                

                if (selectedRowCount > 0)
                {
                    
                    PlayersDAO.DeletePlayers();
                }
                else
                {
                    MessageBox.Show("Izaberite red za brisanje");
                }



            };













            MenuOptionUC2.dataGridView3.EnableHeadersVisualStyles = false;
            MenuOptionUC2.dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.BlueDgvHeader;
            MenuOptionUC2.dataGridView3.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            MenuOptionUC2.dataGridView3.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            MenuOptionUC2.dataGridView3.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            MenuOptionUC2.dataGridView3.DefaultCellStyle.ForeColor = Color.Black;

            MenuOptionUC2.dataGridView3.BorderStyle = BorderStyle.None;

            MenuOptionUC2.dataGridView3.DefaultCellStyle.BackColor = Color.White;
            MenuOptionUC2.dataGridView3.AlternatingRowsDefaultCellStyle.BackColor = ThemeManager.BlueDgvAltRows;
            MenuOptionUC2.dataGridView3.BackgroundColor = ThemeManager.BlueDgvBack;


            MenuOptionUC2.dataGridView3.Left = 50;
            MenuOptionUC2.dataGridView3.Top = 190;
            MenuOptionUC2.dataGridView3.Width = 544;
            MenuOptionUC2.dataGridView3.Height = 370;








            MenuOptionUC2.dataGridView3.Font = new Font("Arial", 11, FontStyle.Regular);
            MenuOptionUC2.dataGridView3.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            MenuOptionUC2.dataGridView3.ColumnHeadersHeight = 30;
            MenuOptionUC2.dataGridView3.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            int fixedWidth = 160;

            foreach (DataGridViewColumn column in MenuOptionUC2.dataGridView3.Columns)
            {
                column.Width = fixedWidth;
                
            }
            
         

            

            this.Controls.Add(MenuOptionUC2.dataGridView3);
            this.Controls.Add(insertBtn);
            this.Controls.Add(updateBtn);
            this.Controls.Add(deleteBtn);
        }

        public void HideParentForm()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Hide();
            }
        }

        public void ShowParentForm()
        {
            if (this.ParentForm != null)
            {
                this.ParentForm.Show();
            }
        }

    }
}
