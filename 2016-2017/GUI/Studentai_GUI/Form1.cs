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

namespace Studentai_GUI
{
    public partial class Form1 : Form
    {
        const string CFin = "../../Studentai.txt";
        const string CFout = "../../output.txt";

        Studentai stud;
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
            spausdinti.Enabled = false;
            skaičiuoti.Enabled = false;
            rasti.Enabled = false;

            if (File.Exists(CFout))
                File.Delete(CFout);

            foreach (Pažymys paz in pažymiai)
                vertinimai.Items.Add(paz.grade + " " + paz.gradeWord);
        }

        private void įvesti_Click(object sender, EventArgs e) {
            rezultatai.LoadFile(CFin, RichTextBoxStreamType.PlainText);
            stud = SkaitytiStudKont(CFin);

            įvesti.Enabled = false;
            spausdinti.Enabled = true;
            skaičiuoti.Enabled = true;
            rasti.Enabled = true;
        }

        private void spausdinti_Click(object sender, EventArgs e) {
            SpausdintiStudKont(CFout, stud, "Studentų sąrašas");
            rezultatai.LoadFile(CFout, RichTextBoxStreamType.PlainText);
            vertinimai.SelectedIndex = 0;
        }

        private void skaičiuoti_Click(object sender, EventArgs e) {
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
            //pavardėVardas.Text = "Pavardė ir vardas";
            string pavVrd = pavardėVardas.Text;
            int index = StudentoIndeksas(stud, pavVrd);
            if (index != -1) {
                Studentas s = stud.Get(index);
                int pažymys = s.grade;
                pavardėVardas.Text = pavardėVardas.Text + " (pažymys: " + pažymys.ToString() + ")";
            }
            else
                pavardėVardas.Text = pavardėVardas.Text + " (Tokio studento nėra)";
        }

        private void baigti_Click(object sender, EventArgs e) {
            Close();
        }

        static Studentai SkaitytiStudKont(string fv) {
            Studentai StudentaiKont = new Studentai();
            using (StreamReader reader = new StreamReader(fv, Encoding.GetEncoding(1257))) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    string[] parts = line.Split(';');
                    string name = parts[0];
                    int grade = int.Parse(parts[1]);
                    Studentas studentas = new Studentas(name, grade);
                    StudentaiKont.Set(studentas);
                }
            }

            return StudentaiKont;
        }

        static void SpausdintiStudKont(string fv, Studentai StudentaiKont, string antraštė) {
            const string viršus =
                  "-----------------------------------\r\n"
                + " Nr. Pavardė ir vardas Pažymys \r\n"
                + "-----------------------------------";

            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.GetEncoding(1257))) {
                fr.WriteLine("\n " + antraštė);
                fr.WriteLine(viršus);

                for (int i = 0; i < StudentaiKont.Get(); i++) {
                    Studentas s = StudentaiKont.Get(i);
                    fr.WriteLine("{0,3} {1}", i + 1, s);
                }

                fr.WriteLine("-----------------------------------");
            }
        }

        static int Kiekis(Studentai StudentaiKont, int pažymys) {
            int kiek = 0;

            for (int i = 0; i < StudentaiKont.Get(); i++) {
                Studentas s = StudentaiKont.Get(i);
                if (s.grade == pažymys)
                    kiek++;
            }

            return kiek;
        }

        static int StudentoIndeksas(Studentai StudentaiKont, string name) {
            for (int i = 0; i < StudentaiKont.Get(); i++) {
                Studentas s = StudentaiKont.Get(i);
                if (s.name == name)
                    return i;
            }

            return -1;
        }

    }
}
