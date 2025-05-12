namespace HCI_Fudbalski_Klub
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            panel2 = new Panel();
            pictureBox2 = new PictureBox();
            button1 = new Button();
            panel1 = new Panel();
            panel6 = new Panel();
            pictureBox6 = new PictureBox();
            button5 = new Button();
            panel5 = new Panel();
            pictureBox11 = new PictureBox();
            button4 = new Button();
            panel4 = new Panel();
            pictureBox4 = new PictureBox();
            button3 = new Button();
            panel3 = new Panel();
            pictureBox3 = new PictureBox();
            button2 = new Button();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            panel1.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox11).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            SuspendLayout();
            // 
            // mySqlCommand1
            // 
            mySqlCommand1.CacheAge = 0;
            mySqlCommand1.Connection = null;
            mySqlCommand1.EnableCaching = false;
            mySqlCommand1.Transaction = null;
            // 
            // panel2
            // 
            panel2.BackColor = Color.LightBlue;
            panel2.Controls.Add(pictureBox2);
            panel2.Controls.Add(button1);
            panel2.Cursor = Cursors.Hand;
            panel2.Location = new Point(0, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(158, 90);
            panel2.TabIndex = 13;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.teamwork;
            pictureBox2.Location = new Point(58, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(48, 44);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.LightBlue;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(0, 44);
            button1.Name = "button1";
            button1.Size = new Size(158, 43);
            button1.TabIndex = 0;
            button1.Text = "Korisnici";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.MenuHighlight;
            panel1.Controls.Add(panel6);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(158, 585);
            panel1.TabIndex = 14;
            // 
            // panel6
            // 
            panel6.BackColor = Color.LightBlue;
            panel6.Controls.Add(pictureBox6);
            panel6.Controls.Add(button5);
            panel6.Cursor = Cursors.Hand;
            panel6.Location = new Point(0, 466);
            panel6.Name = "panel6";
            panel6.Size = new Size(158, 87);
            panel6.TabIndex = 17;
            // 
            // pictureBox6
            // 
            pictureBox6.Image = Properties.Resources.logout__1_;
            pictureBox6.Location = new Point(58, 0);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(48, 44);
            pictureBox6.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox6.TabIndex = 1;
            pictureBox6.TabStop = false;
            // 
            // button5
            // 
            button5.BackColor = Color.LightBlue;
            button5.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.ForeColor = Color.White;
            button5.Location = new Point(0, 44);
            button5.Name = "button5";
            button5.Size = new Size(158, 43);
            button5.TabIndex = 0;
            button5.Text = "Napusti";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // panel5
            // 
            panel5.BackColor = Color.LightBlue;
            panel5.Controls.Add(pictureBox11);
            panel5.Controls.Add(button4);
            panel5.Cursor = Cursors.Hand;
            panel5.Location = new Point(0, 348);
            panel5.Name = "panel5";
            panel5.Size = new Size(158, 87);
            panel5.TabIndex = 16;
            // 
            // pictureBox11
            // 
            pictureBox11.Image = (Image)resources.GetObject("pictureBox11.Image");
            pictureBox11.Location = new Point(58, 0);
            pictureBox11.Name = "pictureBox11";
            pictureBox11.Size = new Size(48, 45);
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.TabIndex = 2;
            pictureBox11.TabStop = false;
            // 
            // button4
            // 
            button4.BackColor = Color.LightBlue;
            button4.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(0, 44);
            button4.Name = "button4";
            button4.Size = new Size(158, 43);
            button4.TabIndex = 0;
            button4.Text = "Podešavanja";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.LightBlue;
            panel4.Controls.Add(pictureBox4);
            panel4.Controls.Add(button3);
            panel4.Cursor = Cursors.Hand;
            panel4.Location = new Point(0, 233);
            panel4.Name = "panel4";
            panel4.Size = new Size(158, 88);
            panel4.TabIndex = 15;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(58, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(48, 47);
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox4.TabIndex = 1;
            pictureBox4.TabStop = false;
            // 
            // button3
            // 
            button3.BackColor = Color.LightBlue;
            button3.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.White;
            button3.Location = new Point(0, 44);
            button3.Name = "button3";
            button3.Size = new Size(158, 44);
            button3.TabIndex = 0;
            button3.Text = "Statistike";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.LightBlue;
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(button2);
            panel3.Cursor = Cursors.Hand;
            panel3.Location = new Point(0, 120);
            panel3.Name = "panel3";
            panel3.Size = new Size(158, 87);
            panel3.TabIndex = 14;
            // 
            // pictureBox3
            // 
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(58, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(48, 44);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = Color.LightBlue;
            button2.Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(0, 44);
            button2.Name = "button2";
            button2.Size = new Size(158, 43);
            button2.TabIndex = 0;
            button2.Text = "Igrači";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(857, 585);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Početna";
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            panel1.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox11).EndInit();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private Panel panel2;
        private Button button1;
        private PictureBox pictureBox2;
        private Panel panel1;
        private Panel panel3;
        private PictureBox pictureBox3;
        private Button button2;
        private Panel panel6;
        private PictureBox pictureBox6;
        private Button button5;
        private Panel panel5;
        private Button button4;
        private Panel panel4;
        private PictureBox pictureBox4;
        private Button button3;
        private PictureBox pictureBox11;
    }
}