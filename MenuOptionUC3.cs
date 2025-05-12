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
    public partial class MenuOptionUC3 : UserControl
    {

        public static DataGridView dataGridView1;
        private BindingSource bindingSource = new BindingSource();
        public static int selectedIdTima;
        public static string selectedIdSezone, selectedNazivLige;

        public static int poz, od, gs, gr, w, l, d;
        public MenuOptionUC3()
        {
            InitializeComponent();
            this.show();
        }




        private void show()
        {

            MenuOptionUC3.dataGridView1 = new DataGridView();
            MenuOptionUC3.dataGridView1.DataSource = bindingSource;




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
                InsertStatsForm form = new InsertStatsForm();
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
                  MenuOptionUC3.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

                MenuOptionUC3.selectedIdTima = Convert.ToInt32(MenuOptionUC3.dataGridView1.CurrentRow.Cells[0].Value);
                MenuOptionUC3.selectedNazivLige = Convert.ToString(MenuOptionUC3.dataGridView1.CurrentRow.Cells[1].Value);
                MenuOptionUC3.selectedIdSezone = Convert.ToString(MenuOptionUC3.dataGridView1.CurrentRow.Cells[2].Value);

                MenuOptionUC3.poz = Convert.ToInt32(MenuOptionUC3.dataGridView1.CurrentRow.Cells[3].Value);
                MenuOptionUC3.od = Convert.ToInt32(MenuOptionUC3.dataGridView1.CurrentRow.Cells[4].Value);
                MenuOptionUC3.w = Convert.ToInt32(MenuOptionUC3.dataGridView1.CurrentRow.Cells[5].Value);
                MenuOptionUC3.l = Convert.ToInt32(MenuOptionUC3.dataGridView1.CurrentRow.Cells[6].Value);
                MenuOptionUC3.d = Convert.ToInt32(MenuOptionUC3.dataGridView1.CurrentRow.Cells[7].Value);
                MenuOptionUC3.gs = Convert.ToInt32(MenuOptionUC3.dataGridView1.CurrentRow.Cells[9].Value);
                MenuOptionUC3.gr = Convert.ToInt32(MenuOptionUC3.dataGridView1.CurrentRow.Cells[10].Value);



                if (selectedRowCount > 0)
            {
                MessageBox.Show("Uspješno izabran red za ažuriranje");
                this.HideParentForm();
                UpdateStatsForm f1 = new UpdateStatsForm();
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
                  MenuOptionUC3.dataGridView1.Rows.GetRowCount(DataGridViewElementStates.Selected);

                MenuOptionUC3.selectedIdTima = Convert.ToInt32(MenuOptionUC3.dataGridView1.CurrentRow.Cells[0].Value);
                MenuOptionUC3.selectedNazivLige = Convert.ToString(MenuOptionUC3.dataGridView1.CurrentRow.Cells[1].Value);
                MenuOptionUC3.selectedIdSezone = Convert.ToString(MenuOptionUC3.dataGridView1.CurrentRow.Cells[2].Value);


                if (selectedRowCount > 0)
                {

                    //PlayersDAO.DeletePlayers();
                    StatisticsDAO.DeleteStatistics();
                }
                else
                {
                    MessageBox.Show("Izaberite red za brisanje");
                }



            };




            MenuOptionUC3.dataGridView1.Left = 50;
            MenuOptionUC3.dataGridView1.Top = 190;
            MenuOptionUC3.dataGridView1.Width = 544;
            MenuOptionUC3.dataGridView1.Height = 370;

            MenuOptionUC3.dataGridView1.EnableHeadersVisualStyles = false;
            MenuOptionUC3.dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = ThemeManager.BlueDgvHeader;
            MenuOptionUC3.dataGridView1.DefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);
            MenuOptionUC3.dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Arial", 10, FontStyle.Bold);

            MenuOptionUC3.dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            MenuOptionUC3.dataGridView1.DefaultCellStyle.ForeColor = Color.Black;

            MenuOptionUC3.dataGridView1.BorderStyle = BorderStyle.None;

            MenuOptionUC3.dataGridView1.DefaultCellStyle.BackColor = Color.White;
            MenuOptionUC3.dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = ThemeManager.BlueDgvAltRows;
            MenuOptionUC3.dataGridView1.BackgroundColor = ThemeManager.BlueDgvBack;



            MenuOptionUC3.dataGridView1.Font = new Font("Arial", 10, FontStyle.Regular);




            this.Controls.Add(MenuOptionUC3.dataGridView1);
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
