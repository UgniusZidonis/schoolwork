namespace Studentai_List
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pavardėVardas = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.vertinimai = new System.Windows.Forms.ComboBox();
            this.studSkaič = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spausdintiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentųSkaičiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentoĮvertinimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vidurkisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vyrųToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moterųToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.užduotisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodymaiVartotojuiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pavardėVardas
            // 
            this.pavardėVardas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pavardėVardas.Location = new System.Drawing.Point(13, 243);
            this.pavardėVardas.Name = "pavardėVardas";
            this.pavardėVardas.Size = new System.Drawing.Size(184, 20);
            this.pavardėVardas.TabIndex = 1;
            this.pavardėVardas.TextChanged += new System.EventHandler(this.pavardėVardas_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 224);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Įveskite studento vardą ir pavardę";
            // 
            // vertinimai
            // 
            this.vertinimai.FormattingEnabled = true;
            this.vertinimai.Location = new System.Drawing.Point(373, 27);
            this.vertinimai.Name = "vertinimai";
            this.vertinimai.Size = new System.Drawing.Size(124, 21);
            this.vertinimai.TabIndex = 6;
            this.vertinimai.Text = "Pasirinkite pažymį";
            // 
            // studSkaič
            // 
            this.studSkaič.AutoSize = true;
            this.studSkaič.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.studSkaič.Location = new System.Drawing.Point(373, 51);
            this.studSkaič.Name = "studSkaič";
            this.studSkaič.Size = new System.Drawing.Size(91, 13);
            this.studSkaič.TabIndex = 9;
            this.studSkaič.Text = "Studentų skaičius";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(509, 24);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestiToolStripMenuItem,
            this.spausdintiToolStripMenuItem,
            this.baigtiToolStripMenuItem});
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // įvestiToolStripMenuItem
            // 
            this.įvestiToolStripMenuItem.Name = "įvestiToolStripMenuItem";
            this.įvestiToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.įvestiToolStripMenuItem.Text = "Įvesti";
            this.įvestiToolStripMenuItem.Click += new System.EventHandler(this.įvestiToolStripMenuItem_Click);
            // 
            // spausdintiToolStripMenuItem
            // 
            this.spausdintiToolStripMenuItem.Name = "spausdintiToolStripMenuItem";
            this.spausdintiToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.spausdintiToolStripMenuItem.Text = "Spausdinti";
            this.spausdintiToolStripMenuItem.Click += new System.EventHandler(this.spausdintiToolStripMenuItem_Click);
            // 
            // baigtiToolStripMenuItem
            // 
            this.baigtiToolStripMenuItem.Name = "baigtiToolStripMenuItem";
            this.baigtiToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.baigtiToolStripMenuItem.Text = "Baigti";
            this.baigtiToolStripMenuItem.Click += new System.EventHandler(this.baigtiToolStripMenuItem_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentųSkaičiusToolStripMenuItem,
            this.studentoĮvertinimaiToolStripMenuItem,
            this.vidurkisToolStripMenuItem});
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // studentųSkaičiusToolStripMenuItem
            // 
            this.studentųSkaičiusToolStripMenuItem.Name = "studentųSkaičiusToolStripMenuItem";
            this.studentųSkaičiusToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.studentųSkaičiusToolStripMenuItem.Text = "Studentų skaičius";
            this.studentųSkaičiusToolStripMenuItem.Click += new System.EventHandler(this.studentųSkaičiusToolStripMenuItem_Click);
            // 
            // studentoĮvertinimaiToolStripMenuItem
            // 
            this.studentoĮvertinimaiToolStripMenuItem.Name = "studentoĮvertinimaiToolStripMenuItem";
            this.studentoĮvertinimaiToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.studentoĮvertinimaiToolStripMenuItem.Text = "Studento įvertinimai";
            this.studentoĮvertinimaiToolStripMenuItem.Click += new System.EventHandler(this.studentoĮvertinimaiToolStripMenuItem_Click);
            // 
            // vidurkisToolStripMenuItem
            // 
            this.vidurkisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vyrųToolStripMenuItem,
            this.moterųToolStripMenuItem});
            this.vidurkisToolStripMenuItem.Name = "vidurkisToolStripMenuItem";
            this.vidurkisToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.vidurkisToolStripMenuItem.Text = "Vidurkis";
            // 
            // vyrųToolStripMenuItem
            // 
            this.vyrųToolStripMenuItem.Name = "vyrųToolStripMenuItem";
            this.vyrųToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.vyrųToolStripMenuItem.Text = "Vyrų";
            this.vyrųToolStripMenuItem.Click += new System.EventHandler(this.vyrųToolStripMenuItem_Click);
            // 
            // moterųToolStripMenuItem
            // 
            this.moterųToolStripMenuItem.Name = "moterųToolStripMenuItem";
            this.moterųToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.moterųToolStripMenuItem.Text = "Moterų";
            this.moterųToolStripMenuItem.Click += new System.EventHandler(this.moterųToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.užduotisToolStripMenuItem,
            this.nurodymaiVartotojuiToolStripMenuItem});
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // užduotisToolStripMenuItem
            // 
            this.užduotisToolStripMenuItem.Name = "užduotisToolStripMenuItem";
            this.užduotisToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.užduotisToolStripMenuItem.Text = "Užduotis";
            this.užduotisToolStripMenuItem.Click += new System.EventHandler(this.užduotisToolStripMenuItem_Click);
            // 
            // nurodymaiVartotojuiToolStripMenuItem
            // 
            this.nurodymaiVartotojuiToolStripMenuItem.Name = "nurodymaiVartotojuiToolStripMenuItem";
            this.nurodymaiVartotojuiToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.nurodymaiVartotojuiToolStripMenuItem.Text = "Nurodymai vartotojui";
            this.nurodymaiVartotojuiToolStripMenuItem.Click += new System.EventHandler(this.nurodymaiVartotojuiToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(12, 269);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(485, 189);
            this.dataGridView1.TabIndex = 11;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.InitialDirectory = "..\\\\..\\\\";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "..\\\\..\\\\";
            // 
            // richTextBox
            // 
            this.richTextBox.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.Location = new System.Drawing.Point(16, 27);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.Size = new System.Drawing.Size(351, 193);
            this.richTextBox.TabIndex = 12;
            this.richTextBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 470);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.studSkaič);
            this.Controls.Add(this.vertinimai);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pavardėVardas);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox pavardėVardas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox vertinimai;
        private System.Windows.Forms.Label studSkaič;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spausdintiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentųSkaičiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentoĮvertinimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem užduotisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nurodymaiVartotojuiToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem vidurkisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vyrųToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem moterųToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox;
    }
}

