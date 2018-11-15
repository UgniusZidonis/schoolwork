using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Labdara__U1_11_
{
    public partial class Form1 : Form
    {
        Charity newlyRead;
        List<Charity> charities;
        const string CFc1 = "../../labdara1.txt";
        const string CFc2 = "../../labdara2.txt";
        const string txtBox = "../../textbox.txt";

        public Form1() {
            InitializeComponent();
            if (File.Exists(txtBox))
                File.Delete(txtBox);
            selectCharityToAddTo.Enabled = false;
            addNewCharity.Enabled = false;

            charities = new List<Charity>();
            charities.Add(ReadCharityFromFile(CFc1));
            charities.Add(ReadCharityFromFile(CFc2));

            charitiesComboBox.Items.Add(charities[0].name);
            charitiesComboBox.Items.Add(charities[1].name);
            charitiesComboBox.SelectedIndex = 0;
        }

        private Charity ReadCharityFromFile(string fileDir) {
            
            using (StreamReader reader = new StreamReader(fileDir, Encoding.GetEncoding(1257))) {
                string name = reader.ReadLine();
                List<Shoe> shoes = ReadShoeFromFile(reader);

                Charity c = new Charity(name);
                foreach (var shoe in shoes)
                    c.Add(shoe);
                WriteToTextBox(c.ToString());
                c.WriteToFile(txtBox);
                return c;
            }
        }

        private List<Shoe> ReadShoeFromFile(StreamReader reader) {
            List<Shoe> shoes = new List<Shoe>();
            string line;

            while ((line = reader.ReadLine()) != null) {
                string[] parts = line.Split(';');
                string type, season, color, condition;
                int size;

                type = parts[0].Trim();
                season = parts[1].Trim();
                size = int.Parse(parts[2]);
                color = parts[3].Trim();
                condition = parts[4].Trim();

                Shoe s = new Shoe(type, season, size, color, condition);
                shoes.Add(s);
            }

            return shoes;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void Show_Click(object sender, EventArgs e) {
            int index = charitiesComboBox.SelectedIndex;


            label1.Text = charities[index].name;
            WriteToGrid(charities[index]);
        }

        private void whichHasMoreToolStripMenuItem_Click(object sender, EventArgs e) {
            int index = 0;

            if (charities[0].AdultShoeCount() > charities[1].AdultShoeCount())
                index = 0;
            else if (charities[0].AdultShoeCount() < charities[1].AdultShoeCount())
                index = 1;
            else
                index = -1;

            if (index != -1)
                MessageBox.Show(String.Format("{0}-oji turi daugiausiai suaugusiųjų batų", index + 1), "Suaugusiųjų batai");
            else
                MessageBox.Show("Abiejos labdaros turi po vienodą kiekį suaugusiųjų batų");
        }

        private void WriteToGrid(Charity c) {
            infoGridView.Rows.Clear();
            infoGridView.ColumnCount = 6;
            infoGridView.Columns[0].Name = "Nr.";
            infoGridView.Columns[0].Width = 25;
            infoGridView.Columns[1].Name = "Type";
            infoGridView.Columns[1].Width = 60;
            infoGridView.Columns[2].Name = "Season";
            infoGridView.Columns[2].Width = 70;
            infoGridView.Columns[3].Name = "Size";
            infoGridView.Columns[3].Width = 35;
            infoGridView.Columns[4].Name = "Color";
            infoGridView.Columns[4].Width = 60;
            infoGridView.Columns[5].Name = "Condition";
            infoGridView.Columns[5].Width = 80;

            int count = 1;
            for (var elem = c.GetFirst().GetNext(); elem.GetValue() != null; elem = elem.GetNext()) {
                Shoe s = elem.GetValue();
                infoGridView.Rows.Add(count++ , s.type, s.season, s.size.ToString(), s.color, s.condition);
            }
        }

        private void listOfShoesForKidsToolStripMenuItem_Click(object sender, EventArgs e) {
            int charityCount = charities.Count;

            for (int i = 0; i < charityCount; i++)
            {
                List<Shoe> kids = new List<Shoe>();
                for (var elem = charities[i].GetFirst().GetNext(); elem.GetValue() != null; elem = elem.GetNext())
                    if (elem.GetValue().type == "vaikiški")
                        kids.Add(elem.GetValue());


                var charity = new Charity(String.Format("{0} - vaikiški", charities[i].name));
                foreach (var shoe in kids)
                    charity.Add(shoe);
                charities.Add(charity);
                charitiesComboBox.Items.Add(charities[charities.Count - 1].name);

                WriteToTextBox("Batų tipas | Sezonas | Dydis | Būklė | Spalva");
                WriteToTextBox(charities[charities.Count - 1].ToString());
                charities[charities.Count - 1].WriteToFile(txtBox);
            }
        }

        private void averageConditionToolStripMenuItem_Click(object sender, EventArgs e) {
            for (int c = 2; c < charities.Count; c++)
            {
                charities[c].RemoveAverageCondition();

                WriteToTextBox(charities[c].ToString());
                charities[c].WriteToFile(txtBox);
            }
        }

        private void newCharityreadToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite naujos labdaros duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK) {
                string fv = openFileDialog1.FileName;
                newlyRead = ReadCharityFromFile(fv);
                selectCharityToAddTo.Enabled = true;
                addNewCharity.Enabled = true;

                for (int i = 2; i < charitiesComboBox.Items.Count; i++) {
                    selectCharityToAddTo.Items.Add(charitiesComboBox.Items[i]);
                }

                selectCharityToAddTo.SelectedIndex = 0;
            }
        }

        private void addNewCharity_Click(object sender, EventArgs e) {
            int charity = selectCharityToAddTo.SelectedIndex + 2;

            for (var elem = newlyRead.GetFirst().GetNext(); elem.GetValue() != null; elem = elem.GetNext())
                if (elem.GetValue().condition != "patenkinama")
                    charities[charity].Add(elem.GetValue());

            WriteToTextBox(charities[charity].ToString());
            charities[charity].WriteToFile(txtBox);
            addNewCharity.Enabled = false;
            selectCharityToAddTo.Enabled = false;
        }

        private void WriteToTextBox(string input) {
            textBox.AppendText(input + "\n");
        }
    }
}