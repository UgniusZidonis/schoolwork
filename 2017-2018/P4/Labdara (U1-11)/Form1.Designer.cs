namespace Labdara__U1_11_
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
            this.infoGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCharityreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageConditionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moreForAdultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.whichHasMoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfShoesForKidsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.charitiesComboBox = new System.Windows.Forms.ComboBox();
            this.Show = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.selectCharityToAddTo = new System.Windows.Forms.ComboBox();
            this.addNewCharity = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.infoGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // infoGridView
            // 
            this.infoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.infoGridView.Location = new System.Drawing.Point(12, 56);
            this.infoGridView.Name = "infoGridView";
            this.infoGridView.Size = new System.Drawing.Size(386, 175);
            this.infoGridView.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(524, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCharityreadToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // newCharityreadToolStripMenuItem
            // 
            this.newCharityreadToolStripMenuItem.Name = "newCharityreadToolStripMenuItem";
            this.newCharityreadToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.newCharityreadToolStripMenuItem.Text = "New charity (read)";
            this.newCharityreadToolStripMenuItem.Click += new System.EventHandler(this.newCharityreadToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.averageConditionToolStripMenuItem});
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            // 
            // averageConditionToolStripMenuItem
            // 
            this.averageConditionToolStripMenuItem.Name = "averageConditionToolStripMenuItem";
            this.averageConditionToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.averageConditionToolStripMenuItem.Text = "Average condition shoes";
            this.averageConditionToolStripMenuItem.Click += new System.EventHandler(this.averageConditionToolStripMenuItem_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moreForAdultsToolStripMenuItem,
            this.formToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.actionsToolStripMenuItem.Text = "Tools";
            // 
            // moreForAdultsToolStripMenuItem
            // 
            this.moreForAdultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.whichHasMoreToolStripMenuItem});
            this.moreForAdultsToolStripMenuItem.Name = "moreForAdultsToolStripMenuItem";
            this.moreForAdultsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.moreForAdultsToolStripMenuItem.Text = "Adult shoes";
            // 
            // whichHasMoreToolStripMenuItem
            // 
            this.whichHasMoreToolStripMenuItem.Name = "whichHasMoreToolStripMenuItem";
            this.whichHasMoreToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.whichHasMoreToolStripMenuItem.Text = "Which has more";
            this.whichHasMoreToolStripMenuItem.Click += new System.EventHandler(this.whichHasMoreToolStripMenuItem_Click);
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listOfShoesForKidsToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.formToolStripMenuItem.Text = "Form";
            // 
            // listOfShoesForKidsToolStripMenuItem
            // 
            this.listOfShoesForKidsToolStripMenuItem.Name = "listOfShoesForKidsToolStripMenuItem";
            this.listOfShoesForKidsToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.listOfShoesForKidsToolStripMenuItem.Text = "List of shoes for kids";
            this.listOfShoesForKidsToolStripMenuItem.Click += new System.EventHandler(this.listOfShoesForKidsToolStripMenuItem_Click);
            // 
            // charitiesComboBox
            // 
            this.charitiesComboBox.FormattingEnabled = true;
            this.charitiesComboBox.Location = new System.Drawing.Point(404, 30);
            this.charitiesComboBox.Name = "charitiesComboBox";
            this.charitiesComboBox.Size = new System.Drawing.Size(108, 21);
            this.charitiesComboBox.TabIndex = 2;
            this.charitiesComboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Show
            // 
            this.Show.Location = new System.Drawing.Point(404, 56);
            this.Show.Name = "Show";
            this.Show.Size = new System.Drawing.Size(108, 50);
            this.Show.TabIndex = 3;
            this.Show.Text = "Show information";
            this.Show.UseVisualStyleBackColor = true;
            this.Show.Click += new System.EventHandler(this.Show_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Charity name";
            // 
            // selectCharityToAddTo
            // 
            this.selectCharityToAddTo.FormattingEnabled = true;
            this.selectCharityToAddTo.Location = new System.Drawing.Point(404, 148);
            this.selectCharityToAddTo.Name = "selectCharityToAddTo";
            this.selectCharityToAddTo.Size = new System.Drawing.Size(107, 21);
            this.selectCharityToAddTo.TabIndex = 5;
            // 
            // addNewCharity
            // 
            this.addNewCharity.Location = new System.Drawing.Point(403, 175);
            this.addNewCharity.Name = "addNewCharity";
            this.addNewCharity.Size = new System.Drawing.Size(108, 50);
            this.addNewCharity.TabIndex = 6;
            this.addNewCharity.Text = "Add";
            this.addNewCharity.UseVisualStyleBackColor = true;
            this.addNewCharity.Click += new System.EventHandler(this.addNewCharity_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox.Location = new System.Drawing.Point(13, 238);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(498, 191);
            this.textBox.TabIndex = 7;
            this.textBox.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 441);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.addNewCharity);
            this.Controls.Add(this.selectCharityToAddTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Show);
            this.Controls.Add(this.charitiesComboBox);
            this.Controls.Add(this.infoGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.infoGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView infoGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ComboBox charitiesComboBox;
        private System.Windows.Forms.Button Show;
        private System.Windows.Forms.ToolStripMenuItem moreForAdultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageConditionToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem whichHasMoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfShoesForKidsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCharityreadToolStripMenuItem;
        private System.Windows.Forms.ComboBox selectCharityToAddTo;
        private System.Windows.Forms.Button addNewCharity;
        private System.Windows.Forms.RichTextBox textBox;
    }
}

