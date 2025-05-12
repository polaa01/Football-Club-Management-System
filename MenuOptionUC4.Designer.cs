namespace HCI_Fudbalski_Klub
{
    partial class MenuOptionUC4
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            jezik = new Label();
            tema = new Label();
            comboBox1 = new ComboBox();
            comboBox2 = new ComboBox();
            SuspendLayout();
            // 
            // jezik
            // 
            jezik.AutoSize = true;
            jezik.Location = new Point(78, 200);
            jezik.Name = "jezik";
            jezik.Size = new Size(49, 19);
            jezik.TabIndex = 0;
            jezik.Text = "Jezik";
            // 
            // tema
            // 
            tema.AutoSize = true;
            tema.Location = new Point(382, 200);
            tema.Name = "tema";
            tema.Size = new Size(50, 19);
            tema.TabIndex = 1;
            tema.Text = "Tema";
            // 
            // comboBox1
            // 
            comboBox1.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(166, 197);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 2;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBox2
            // 
            comboBox2.Font = new Font("Arial Narrow", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(449, 197);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(151, 28);
            comboBox2.TabIndex = 3;
            // 
            // MenuOptionUC4
            // 
            AutoScaleMode = AutoScaleMode.None;
            Controls.Add(comboBox2);
            Controls.Add(comboBox1);
            Controls.Add(tema);
            Controls.Add(jezik);
            Font = new Font("Arial", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "MenuOptionUC4";
            Size = new Size(693, 576);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label jezik;
        private Label tema;
        private ComboBox comboBox1;
        private ComboBox comboBox2;
    }
}
