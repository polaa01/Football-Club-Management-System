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

using HCI_Fudbalski_Klub.DB;
using Org.BouncyCastle.Crypto.Modes.Gcm;
using System.Diagnostics.Eventing.Reader;




namespace HCI_Fudbalski_Klub
{
    public partial class MenuOptionUC1 : UserControl
    {
        //static public event EventHandler OpenDialogRequested;

        Label ll1;
        TextBox filter;

        DialogForm d1;

        public static int selectedId;

        public static string ime, prezime, brojTel, korisnicko, lozinka;

        Button insertBtn, updateBtn, deleteBtn;
        public static DataGridView dataGridView1;
        public static BindingSource source = new BindingSource();

        List<Korisnik> list = new List<Korisnik>(); //lista korisnika
        public MenuOptionUC1()
        {
            InitializeComponent();
            show();

            filter.TextChanged += new EventHandler(filter_TextChanged);
            //ThemeManager.ApplyThemeRecursively(this, ThemeManager.currentTheme);
        }




        private void filter_TextChanged(object sender, EventArgs e)
        {

            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = dataGridView1.Columns[1].HeaderText.ToString() + " LIKE '%" + filter.Text + "%'";
            dataGridView1.DataSource = bs.DataSource;

        }



        private void show()
        {
            dataGridView1 = new DataGridView();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.DataSource = source;
            //dataGridView1.RowHeaderMouseClick += DataGridView1_RowHeaderMouseClick;
            dataGridView1.BorderStyle = BorderStyle.None;
            Color c1 = ColorTranslator.FromHtml("0xC4DAD2");
            Color c2 = ColorTranslator.FromHtml("0x7695FF");
            Color c3 = ColorTranslator.FromHtml("0x9ddbff");


            //labela
            ll1 = new Label();
            ll1.ForeColor = Color.White;
            ll1.Font = new Font("Arial", 10, FontStyle.Bold);
            ll1.Text = "Pretraži po imenu";
            ll1.Text = LanguageManager.rm.GetString("searchByName", LanguageManager.currentCulture);
            ll1.Left = 50;
            ll1.Top = 35;
            ll1.AutoSize = true;

            //textbox
            filter = new TextBox();
            filter.Font = new Font("Arial", 9);
            filter.Top = 32;
            filter.Left = 223;
            filter.Width = 174;
            filter.Multiline = true;
            filter.PlaceholderText = "Pretraži...";
            filter.PlaceholderText = LanguageManager.rm.GetString("search", LanguageManager.currentCulture);



            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.BlueDgvHeader;
            dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            dataGridView1.DefaultCellStyle.BackColor = Color.White;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ThemeManager.BlueDgvAltRows;
            dataGridView1.BackgroundColor = ThemeManager.BlueDgvBack;

            dataGridView1.Left = 50;
            dataGridView1.Top = 180;
            dataGridView1.Width = 544;
            dataGridView1.Height = 340;



            //dataGridView1.Font = new Font("Arial", 10, FontStyle.Regular);



            Color plavaIns = ColorTranslator.FromHtml("0x03346E");
            Color plavaUpd = ColorTranslator.FromHtml("0x5b99c2");
            Color plavaDel = ColorTranslator.FromHtml("0x6eacda");

            //ucitavanje slike za insert
            Image img1 = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\insert.png");
            this.insertBtn = Form2.CreateButtonWithImage("Dodaj", img1, 150, 52);
            insertBtn.Name = "insert";
            insertBtn.Text = LanguageManager.rm.GetString("insert", LanguageManager.currentCulture);
            //insertBtn.Text = "Insert";
            //insertBtn.Text = Resource1.insert;
            insertBtn.Font = new Font("Arial", 10, FontStyle.Bold);
            insertBtn.Location = new Point(50, 82);
            //insertBtn.Width = 140;
            //insertBtn.Height = 55;
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

            if (Form1.Role == 1)
            {
                insertBtn.Click += (sender, args) =>
                {

                    Form2.LoadContent(new InsertBtnKorisniciUserControl());
                };
            }

            else if (Form1.Role != 1)
            {
                insertBtn.Enabled = false;
            }





            Image img2 = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\reload.png");
            this.updateBtn = Form2.CreateButtonWithImage("Ažuriraj", img2, 150, 52);
            updateBtn.Font = new Font("Arial", 10, FontStyle.Bold);
            updateBtn.Name = "update";
            updateBtn.Text = LanguageManager.rm.GetString("update", LanguageManager.currentCulture);
            //updateBtn.Text = "UPDATE";
            updateBtn.Location = new Point(247, 82);
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


            if (Form1.Role == 1)
            {
                updateBtn.Click += (sender, args) =>
                {
                    int selectedRowCount =
                      dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

                    MenuOptionUC1.selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    MenuOptionUC1.ime = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    MenuOptionUC1.prezime = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    MenuOptionUC1.brojTel = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                    MenuOptionUC1.korisnicko = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                    MenuOptionUC1.lozinka = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);

                    //string pass = Convert.ToString(dataGridView1.CurrentRow.Cells);
                    if (selectedRowCount > 0)
                    {
                        MessageBox.Show("Uspješno izabran red za ažuriranje.");
                        this.HideParentForm();
                        UpdateUserForm f1 = new UpdateUserForm();
                        f1.FormClosed += (s, args) => this.ShowParentForm();
                        f1.Show();

                    }
                    else
                    {
                        MessageBox.Show("Izaberite red za ažuriranje");
                    }

                };

            }
            else if (Form1.Role != 1)
            {
                updateBtn.Enabled = false;
            }





            Image img3 = Image.FromFile("C:\\Users\\Korisnik\\Desktop\\Projekat_A-Fudbalski_klub\\HCI_Fudbalski_Klub\\Resources\\trash-bin.png");
            this.deleteBtn = Form2.CreateButtonWithImage("Briši", img3, 150, 52);
            deleteBtn.Font = new Font("Arial", 10, FontStyle.Bold);
            deleteBtn.Name = "delete";
            deleteBtn.Text = LanguageManager.rm.GetString("delete", LanguageManager.currentCulture);
            //deleteBtn.Text = "DELETE";
            deleteBtn.Location = new Point(444, 82);
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


            if (Form1.Role == 1)
            { 
                deleteBtn.Click += (sender, args) =>
                {

                    int selectedRowCount =
                      dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

                    MenuOptionUC1.selectedId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                    MenuOptionUC1.ime = Convert.ToString(dataGridView1.CurrentRow.Cells[1].Value);
                    MenuOptionUC1.prezime = Convert.ToString(dataGridView1.CurrentRow.Cells[2].Value);
                    MenuOptionUC1.brojTel = Convert.ToString(dataGridView1.CurrentRow.Cells[3].Value);
                    MenuOptionUC1.korisnicko = Convert.ToString(dataGridView1.CurrentRow.Cells[4].Value);
                    MenuOptionUC1.lozinka = Convert.ToString(dataGridView1.CurrentRow.Cells[5].Value);

                    if (selectedRowCount > 0)
                    {
                        //MessageBox.Show("Uspjesno izabran red");
                        UsersDAO.DeleteUsers();
                    }
                    else
                    {
                        MessageBox.Show("Izaberite red za brisanje");
                    }



                };

        }

            else if(Form1.Role != 1)
            {
               deleteBtn.Enabled = false;
            }

            dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);

            dataGridView1.ColumnHeadersHeight = 30;
            dataGridView1.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.False;

            int fixedWidth = 160;
            
            foreach(DataGridViewColumn column in  dataGridView1.Columns)
            {
                column.Width = fixedWidth;
                     /*TextRenderer.MeasureText(column.HeaderText, dataGridView1.Font).Width + 18;*/
            }
            
            

            this.Controls.Add(insertBtn);
            this.Controls.Add(updateBtn);
            this.Controls.Add(deleteBtn);


            this.Controls.Add(dataGridView1);
            this.Controls.Add(ll1);
            this.Controls.Add(filter);
        }

        /*private void insertBtn_Click (object sender, EventArgs e)
        {
            Form2.LoadContent(new InsertBtnKorisniciUserControl());
        }
        */

        public void HideParentForm()
        {
            if(this.ParentForm != null)
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




        private void InputForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MenuOptionUC1_Load(object sender, EventArgs e)
        {
            UsersDAO.DisplayData();
        }

        

        

    }
}
