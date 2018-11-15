namespace Studentai_GUI
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
            this.rezultatai = new System.Windows.Forms.RichTextBox();
            this.pavardėVardas = new System.Windows.Forms.TextBox();
            this.rasti = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.įvesti = new System.Windows.Forms.Button();
            this.spausdinti = new System.Windows.Forms.Button();
            this.vertinimai = new System.Windows.Forms.ComboBox();
            this.skaičiuoti = new System.Windows.Forms.Button();
            this.baigti = new System.Windows.Forms.Button();
            this.studSkaič = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // rezultatai
            // 
            this.rezultatai.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rezultatai.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.rezultatai.Location = new System.Drawing.Point(13, 13);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(286, 182);
            this.rezultatai.TabIndex = 0;
            this.rezultatai.Text = "";
            // 
            // pavardėVardas
            // 
            this.pavardėVardas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pavardėVardas.Location = new System.Drawing.Point(13, 217);
            this.pavardėVardas.Name = "pavardėVardas";
            this.pavardėVardas.Size = new System.Drawing.Size(184, 20);
            this.pavardėVardas.TabIndex = 1;
            // 
            // rasti
            // 
            this.rasti.Cursor = System.Windows.Forms.Cursors.Default;
            this.rasti.Location = new System.Drawing.Point(203, 217);
            this.rasti.Name = "rasti";
            this.rasti.Size = new System.Drawing.Size(96, 20);
            this.rasti.TabIndex = 2;
            this.rasti.Text = "Rasti";
            this.rasti.UseVisualStyleBackColor = true;
            this.rasti.Click += new System.EventHandler(this.rasti_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 198);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Įveskite studento vardą ir pavardę";
            // 
            // įvesti
            // 
            this.įvesti.Location = new System.Drawing.Point(305, 13);
            this.įvesti.Name = "įvesti";
            this.įvesti.Size = new System.Drawing.Size(107, 30);
            this.įvesti.TabIndex = 4;
            this.įvesti.Text = "Įvesti";
            this.įvesti.UseVisualStyleBackColor = true;
            this.įvesti.Click += new System.EventHandler(this.įvesti_Click);
            // 
            // spausdinti
            // 
            this.spausdinti.Location = new System.Drawing.Point(305, 49);
            this.spausdinti.Name = "spausdinti";
            this.spausdinti.Size = new System.Drawing.Size(107, 30);
            this.spausdinti.TabIndex = 5;
            this.spausdinti.Text = "Spausdinti";
            this.spausdinti.UseVisualStyleBackColor = true;
            this.spausdinti.Click += new System.EventHandler(this.spausdinti_Click);
            // 
            // vertinimai
            // 
            this.vertinimai.FormattingEnabled = true;
            this.vertinimai.Location = new System.Drawing.Point(305, 85);
            this.vertinimai.Name = "vertinimai";
            this.vertinimai.Size = new System.Drawing.Size(106, 21);
            this.vertinimai.TabIndex = 6;
            this.vertinimai.Text = "Pasirinkite pažymį";
            // 
            // skaičiuoti
            // 
            this.skaičiuoti.Location = new System.Drawing.Point(305, 131);
            this.skaičiuoti.Name = "skaičiuoti";
            this.skaičiuoti.Size = new System.Drawing.Size(106, 64);
            this.skaičiuoti.TabIndex = 7;
            this.skaičiuoti.Text = "Skaičiuoti";
            this.skaičiuoti.UseVisualStyleBackColor = true;
            this.skaičiuoti.Click += new System.EventHandler(this.skaičiuoti_Click);
            // 
            // baigti
            // 
            this.baigti.Location = new System.Drawing.Point(305, 201);
            this.baigti.Name = "baigti";
            this.baigti.Size = new System.Drawing.Size(106, 36);
            this.baigti.TabIndex = 8;
            this.baigti.Text = "Baigti";
            this.baigti.UseVisualStyleBackColor = true;
            this.baigti.Click += new System.EventHandler(this.baigti_Click);
            // 
            // studSkaič
            // 
            this.studSkaič.AutoSize = true;
            this.studSkaič.Location = new System.Drawing.Point(305, 112);
            this.studSkaič.Name = "studSkaič";
            this.studSkaič.Size = new System.Drawing.Size(91, 13);
            this.studSkaič.TabIndex = 9;
            this.studSkaič.Text = "Studentų skaičius";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 249);
            this.Controls.Add(this.studSkaič);
            this.Controls.Add(this.baigti);
            this.Controls.Add(this.skaičiuoti);
            this.Controls.Add(this.vertinimai);
            this.Controls.Add(this.spausdinti);
            this.Controls.Add(this.įvesti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rasti);
            this.Controls.Add(this.pavardėVardas);
            this.Controls.Add(this.rezultatai);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rezultatai;
        private System.Windows.Forms.TextBox pavardėVardas;
        private System.Windows.Forms.Button rasti;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button įvesti;
        private System.Windows.Forms.Button spausdinti;
        private System.Windows.Forms.ComboBox vertinimai;
        private System.Windows.Forms.Button skaičiuoti;
        private System.Windows.Forms.Button baigti;
        private System.Windows.Forms.Label studSkaič;
    }
}

