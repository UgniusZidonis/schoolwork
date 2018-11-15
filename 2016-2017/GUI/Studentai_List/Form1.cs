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

namespace Studentai_List
{
    public partial class Form1 : Form
    {
        const string CFin = "../../Studentai.txt";
        const string CFout = "../../output.txt";

        List<Studentas> stud;
        Pažymys[] pažymiai = new Pažymys[10] {
            new Pažymys(10, "Puikiai"),
            new Pažymys(9, "Labai gerai"),
            new Pažymys(8, "Gerai"),
            new Pažymys(7, "Vidutiniškai"),
            new Pažymys(6, "Patenkinamai"),
            new Pažymys(5, "Silpnai"),
            new Pažymys(4, "Nepatenkinamai"),
            new Pažymys(3, "Nepatenkinamai"),
            new Pažymys(2, "Nepatenkinamai"),
            new Pažymys(1, "Nepatenkinamai")
        };

        public Form1() {
            InitializeComponent();
            spausdintiToolStripMenuItem.Enabled = false;
            studentųSkaičiusToolStripMenuItem.Enabled = false;
            studentoĮvertinimaiToolStripMenuItem.Enabled = false;
            vidurkisToolStripMenuItem.Enabled = false;

            if (File.Exists(CFout))
                File.Delete(CFout);

            foreach (Pažymys paz in pažymiai)
                vertinimai.Items.Add(paz.grade + " " + paz.gradeWord);
        }

        /*private void įvesti_Click(object sender, EventArgs e) {
            richTextBox.LoadFile(CFin, RichTextBoxStreamType.PlainText);
            stud = SkaitytiStudKont(CFin);

            
            
        }

        private void spausdinti_Click(object sender, EventArgs e) {
            SpausdintiStudKont(CFout, stud, "Studentų sąrašas");
            //rezultatai.LoadFile(CFout, RichTextBoxStreamType.PlainText);
            vertinimai.SelectedIndex = 0;
        }*/

        /*private void skaičiuoti_Click(object sender, EventArgs e) {
            string ivestis = vertinimai.SelectedItem.ToString();
            string[] parts = ivestis.Split(' ');
            int pažymys = int.Parse(parts[0]);
            int kiekis = Kiekis(stud, pažymys);
            if (kiekis > 0)
                studSkaič.Text = "Studentų skaičius: " + kiekis.ToString();
            else
                studSkaič.Text = "Tokių studentų nėra";

        }

        private void rasti_Click(object sender, EventArgs e) {
            pavardėVardas.Text = "Pavardė ir vardas";
            string pavVrd = pavardėVardas.Text;
            int index = StudentoIndeksas(stud, pavVrd);
            if (index != -1) {
                Studentas s = stud[index];
                int pažymys = s.grade;
                pavardėVardas.Text = pavardėVardas.Text + " (pažymys: " + pažymys.ToString() + ")";
            }
            else
                pavardėVardas.Text = pavardėVardas.Text + " (Tokio studento nėra)";
        }

        private void baigti_Click(object sender, EventArgs e) {
            Close();
        }*/

        static List<Studentas> SkaitytiStudKont(string fv) {
            List<Studentas> StudentaiKont = new List<Studentas>();
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257))) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    string[] parts = line.Split(';');
                    string name = parts[0];
                    int grade = int.Parse(parts[1]);
                    string gender = parts[2].Trim();
                    Studentas studentas = new Studentas(name, grade, gender);
                    StudentaiKont.Add(studentas);
                }
            }

            return StudentaiKont;
        }

        static void SpausdintiStudKont(string fv, List<Studentas> StudentaiKont, string antraštė) {
            const string viršus =
                  "-----------------------------------\r\n"
                + " Nr. Pavardė ir vardas Pažymys \r\n"
                + "-----------------------------------";

            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.GetEncoding(1257))) {
                fr.WriteLine("\n " + antraštė);
                fr.WriteLine(viršus);

                for (int i = 0; i < StudentaiKont.Count(); i++) {
                    Studentas s = StudentaiKont[i];
                    fr.WriteLine("{0,3} {1}", i + 1, s);
                }

                fr.WriteLine("-----------------------------------");
            }
        }

        static int Kiekis(List<Studentas> StudentaiKont, int pažymys) {
            int kiek = 0;

            for (int i = 0; i < StudentaiKont.Count(); i++) {
                Studentas s = StudentaiKont[i];
                if (s.grade == pažymys)
                    kiek++;
            }

            return kiek;
        }

        static int StudentoIndeksas(List<Studentas> StudentaiKont, string name) {
            for (int i = 0; i < StudentaiKont.Count(); i++) {
                Studentas s = StudentaiKont[i];
                if (s.name == name)
                    return i;
            }

            return -1;
        }

        static double Vidurkis(List<Studentas> list, string gender) {
            int sum = 0;
            int count = 0;

            foreach (Studentas s in list) {
                if (s.gender == gender) {
                    
                    sum += s.grade;
                    count++;
                }
            }

            if (count != 0)
                return (double)sum / (double)count;
            else
                return -1;
        }

        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) {
                string fv = openFileDialog1.FileName;
                stud = SkaitytiStudKont(fv);

                richTextBox.LoadFile(fv, RichTextBoxStreamType.PlainText);
                //FormRichTextBox(fv);

                įvestiToolStripMenuItem.Enabled = false;
                spausdintiToolStripMenuItem.Enabled = true;
                studentųSkaičiusToolStripMenuItem.Enabled = true;
                studentoĮvertinimaiToolStripMenuItem.Enabled = true;
                vidurkisToolStripMenuItem.Enabled = true;

                dataGridView1.ColumnCount = 3;
                dataGridView1.Columns[0].Name = "Nr.";
                dataGridView1.Columns[0].Width = 40;
                dataGridView1.Columns[1].Name = "Pavardė ir vardas";
                dataGridView1.Columns[1].Width = 280;
                dataGridView1.Columns[2].Name = "Pažymys";
                dataGridView1.Columns[2].Width = 80;

                for (int i = 0; i < stud.Count; i++) {
                    Studentas s = stud[i];
                    dataGridView1.Rows.Add(i + 1, s.name, s.grade);
                }
            }
        }

        private void spausdintiToolStripMenuItem_Click(object sender, EventArgs e) {
            /*SpausdintiStudKont(CFout, stud, "Studentų sąrašas");
            rezultatai.LoadFile(CFout, RichTextBoxStreamType.PlainText);
            if (File.Exists(CFout))
                File.Delete(CFout);
            vertinimai.SelectedIndex = 0;*/

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Pasirinkite rezultatų failą";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK) {
                string fv = saveFileDialog1.FileName;

                if (File.Exists(CFout))
                    File.Delete(CFout);
                SpausdintiStudKont(fv, stud, "Studentų sąrašas");
            }
        }

        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e) {
            Close();
        }

        private void studentųSkaičiusToolStripMenuItem_Click(object sender, EventArgs e) {
            string ivestis = vertinimai.SelectedItem.ToString();
            string[] parts = ivestis.Split(' ');
            int pažymys = int.Parse(parts[0]);
            int kiekis = Kiekis(stud, pažymys);
            if (kiekis > 0)
                studSkaič.Text = "Studentų skaičius: " + kiekis.ToString();
            else
                studSkaič.Text = "Tokių studentų nėra";
        }

        private void studentoĮvertinimaiToolStripMenuItem_Click(object sender, EventArgs e) {
            string pavVrd = pavardėVardas.Text;
            int index = StudentoIndeksas(stud, pavVrd);
            if (index > -1) {
                Studentas s = stud[index];
                int pazymys = s.grade;
                MessageBox.Show(pavardėVardas.Text + " -> pažymys: " + pazymys.ToString());
            }
            else
                MessageBox.Show(pavardėVardas.Text + " -> tokio studento (-ės) nėra.");
        }

        private void užduotisToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("... ko tu čia landai?", "???");
        }

        private void nurodymaiVartotojuiToolStripMenuItem_Click(object sender, EventArgs e) {
            MessageBox.Show("... eik iš čia", "???");
        }

        private void pavardėVardas_TextChanged(object sender, EventArgs e) {

        }

        private void vyrųToolStripMenuItem_Click(object sender, EventArgs e) {
            double vidurkis = Vidurkis(stud, "vyras");
            if (vidurkis != -1)
                MessageBox.Show(String.Format("Vidurkis: {0}", vidurkis), "Vyrai");
            else
                MessageBox.Show("Sąraše vyrų nėra", "Klaida!");
        }

        private void moterųToolStripMenuItem_Click(object sender, EventArgs e) {
            double vidurkis = Vidurkis(stud, "moteris");
            if (vidurkis != -1)
                MessageBox.Show(String.Format("Vidurkis: {0}", vidurkis), "Moterys");
            else
                MessageBox.Show("Sąraše moterų nėra", "Klaida!");
        }

        private void FormRichTextBox(string fv) {
            using (StreamReader reader = new StreamReader(fv)) {
                string line;

                while ((line = reader.ReadLine()) != null) {
                    var parts = line.Split(';');

                    string output = String.Format("{0,19} {1,1} {2,7}", parts[0], parts[1], parts[2]);
                    richTextBox.AppendText(output + "/n/r");
                }
            }
        }
    }
}
