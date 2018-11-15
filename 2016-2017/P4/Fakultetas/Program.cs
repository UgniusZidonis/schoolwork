using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Fakultetas
{
    class Studentas
    {
        private string pavardė,
                       vardas;
        private string grupė;
        private ArrayList pažymiai;

        public Studentas() {
            pavardė = "";
            vardas = "";
            grupė = "";
            pažymiai = new ArrayList();
        }

        public void Set(string pavardė, string vardas, string grupė, ArrayList paž) {
            this.pavardė = pavardė;
            this.vardas = vardas;
            this.grupė = grupė;
            foreach (int sk in paž)
                pažymiai.Add(sk);
        }

        public override string ToString() {
            string line;
            line = string.Format("{0,-12} {1,-9} {2,-7}", pavardė, vardas, grupė);
            foreach (int nr in pažymiai)
                line += string.Format("{0,3:d}", nr);
            return line;
        }

        public static bool operator !(Studentas c1) {
            foreach (int sk in c1.pažymiai) {
                if (sk < 9)
                    return true;
            }
            return false;
        }

        public static bool operator <=(Studentas st1, Studentas st2) {
            int p = string.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = string.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            int g = string.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            return g < 0 || (g == 0 && p < 0) || (g == 0 && p == 0 && v < 0);
        }

        public static bool operator >=(Studentas st1, Studentas st2)
        {
            int p = string.Compare(st1.pavardė, st2.pavardė, StringComparison.CurrentCulture);
            int v = string.Compare(st1.vardas, st2.vardas, StringComparison.CurrentCulture);
            int g = string.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            return g > 0 || (g == 0 && p > 0) || (g == 0 && p == 0 && v > 0);
        }


    }

    class Fakultetas
    {
        const int CMax = 100;
        private Studentas[] St;
        private int n;

        public Fakultetas() {
            n = 0;
            St = new Studentas[CMax];
        }

        public int get() { return n; }
        public Studentas get(int i) { return St[i]; }
        public void Set(Studentas ob) { St[n++] = ob; }
        public void Remove(Studentas ob) {
            for (int i = 0; i < n; i++) {
                if (ob == St[i]) {
                    for (int j = i; j < n - 1; j++) {
                        St[j] = St[j + 1];
                    }
                    n--;
                    break;
                        }
            }
        }
        public void Rikiuoti(){
            for (int i = 0; i < n - 1; i++) {
                Studentas min = St[i];
                int im = i;
                for (int j = i + 1; j < n; j++)
                    if (St[j] <= min)
                    {
                        min = St[j];
                        im = j;
                    }
                St[im] = St[i];
                St[i] = min;
            }
        }
    }

    class Program
    {
        const string CFin = "../../input.txt";
        const string CFout = "../../output.txt";

        static void Main(string[] args)
        {
            Fakultetas grupės = new Fakultetas();
            Fakultetas pirmūnai = new Fakultetas();
            Fakultetas trečias = grupės;
            if (File.Exists(CFout))
                File.Delete(CFout);

            ReadFromFile(ref grupės, CFin);
            grupės.Rikiuoti();
            WriteToFile(grupės, CFout, " Pradinis studentų sąrašas");

            FormNewArray(grupės, ref pirmūnai);
            if (pirmūnai.get() > 0)
                WriteToFile(pirmūnai, CFout, " Naujas studentų sąrašas");
            else
                using (var fr = File.AppendText(CFout))
                    fr.WriteLine("Tokių studentų nėra");

            RemoveStudents(ref trečias);
            if (trečias.get() > 0)
                WriteToFile(trečias, CFout, " Pakeistas pradinis sąrašas");
            else
                using (var fr = File.AppendText(CFout))
                    fr.WriteLine("Tokių studentų nėra");

                    /*---*/
                    Console.WriteLine("\nPrograma baigė darbą!");
        }

        static void ReadFromFile(ref Fakultetas grupė, string fv) {
            string pv, v, grp;
            ArrayList pz = new ArrayList();
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            foreach (string line in lines) {
                string[] parts = line.Split(';');
                pv = parts[0].Trim();
                v = parts[1].Trim();
                grp = parts[2].Trim();
                string[] lin = parts[3].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                pz.Clear();
                foreach (string l in lin) {
                    int aa = int.Parse(l);
                    pz.Add(aa);
                }
                Studentas stud = new Studentas();
                stud.Set(pv, v, grp, pz);
                grupė.Set(stud);
            }
        }

        static void WriteToFile(Fakultetas grupė, string fv, string header) {
            const string viršus = "------------------------------------------\r\n" +
                                  " Pavardė     Vardas     Grupė    Pažymiai \r\n" +
                                  "------------------------------------------";

            using (var fr = File.AppendText(fv)) {
                fr.WriteLine(header);
                fr.WriteLine(viršus);
                for (int i = 0; i < grupė.get(); i++)
                    fr.WriteLine("{0}", grupė.get(i).ToString());
                fr.WriteLine("------------------------------------------\r\n");
            }
        }

        static void FormNewArray(Fakultetas D, ref Fakultetas R) {
            for (int i = 0; i < D.get(); i++) {
                if (!!D.get(i))
                    R.Set(D.get(i));
            }
        }

        static void RemoveStudents(ref Fakultetas D) {
            for (int i = 0; i < D.get(); i++) {
                if (!D.get(i)) {
                    D.Remove(D.get(i));
                    i--;
                }
            }
        }
    }
}
