using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Fakultetas__2_
{
    class Studentas
    {
        private string pavardė,
        vardas;
        private string grupė;
        private double vidurkis;
        private ArrayList pažymiai;

        public Studentas()
        {
            pavardė = "";
            vardas = "";
            grupė = "";
            vidurkis = new double();
            pažymiai = new ArrayList();
        }

        public void Set(string pavardė, string vardas, string grupė, ArrayList paž)
        {
            this.pavardė = pavardė;
            this.vardas = vardas;
            this.grupė = grupė;
            foreach (int sk in paž)
                pažymiai.Add(sk);

            int sum = 0;
            foreach (int sk in pažymiai)
                sum += sk;

            vidurkis = (double)sum / (double)pažymiai.Count;
        }

        public string getGrupė() { return grupė; }
        public ArrayList getPažymiai() { return pažymiai; }

        public override string ToString()
        {
            string line;
            line = string.Format("{0,-12} {1,-9} {2,-7}", pavardė, vardas, grupė);
            foreach (int nr in pažymiai)
                line += string.Format("{0,3:d}", nr);
            return line;
        }

        public static bool operator !(Studentas c1)
        {
            foreach (int sk in c1.pažymiai)
            {
                if (sk < 9)
                    return true;
            }
            return false;
        }

        public static bool operator <=(Studentas st1, Studentas st2)
        {
            int v;
            if (st1.vidurkis > st2.vidurkis) v = -1; else if (st1.vidurkis == st2.vidurkis) v = 0; else v = 1;
            int g = string.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            return g < 0 || (g == 0 && v < 0);
        }

        public static bool operator >=(Studentas st1, Studentas st2)
        {
            int v;
            if (st1.vidurkis > st2.vidurkis) v = -1; else if (st1.vidurkis == st2.vidurkis) v = 0; else v = 1;
            int g = string.Compare(st1.grupė, st2.grupė, StringComparison.CurrentCulture);
            return g > 0 || (g == 0 && v > 0);
        }
    }

    class Fakultetas
    {
        const int CMax = 100;
        private Studentas[] St;
        private int n;

        public Fakultetas()
        {
            n = 0;
            St = new Studentas[CMax];
        }

        public int get() { return n; }
        public Studentas get(int i) { return St[i]; }
        public void Set(Studentas ob) { St[n++] = ob; }
        public void Remove(Studentas ob)
        {
            for (int i = 0; i < n; i++)
            {
                if (ob == St[i])
                {
                    for (int j = i; j < n - 1; j++)
                    {
                        St[j] = St[j + 1];
                    }
                    n--;
                    break;
                }
            }
        }
        public void Rikiuoti()
        {
            for (int i = 0; i < n - 1; i++)
            {
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
            Fakultetas pirma = new Fakultetas();
            Fakultetas antra = new Fakultetas();
            Fakultetas bendras = new Fakultetas();



            if (File.Exists(CFout))
                File.Delete(CFout);
            ReadFromFile(ref grupės, CFin);
            WriteToFile(grupės, CFout, "Pradinis studentų sąrašas");
            FormNewArray(grupės, ref pirma, "IF-1/8");
            FormNewArray(grupės, ref antra, "IF-1/9");

            if (GroupAverage(pirma) > GroupAverage(antra) || GroupAverage(pirma) == GroupAverage(antra))
            {
                MergeArray(pirma, ref bendras);
                MergeArray(antra, ref bendras);
            }
            else
            {
                MergeArray(antra, ref bendras);
                MergeArray(pirma, ref bendras);
            }
            bendras.Rikiuoti();

            WriteToFile(bendras, CFout, "Bendras surikiuotas studentų sąrašas");
            using (var fr = File.AppendText(CFout))
            {
                fr.WriteLine("IF-1/8 grupės vidurkis: {0,1:f2}", GroupAverage(pirma));
                fr.WriteLine("IF-1/9 grupės vidurkis: {0,1:f2}", GroupAverage(antra));
            }


        }

        static void ReadFromFile(ref Fakultetas grupė, string fv)
        {
            string pv, v, grp;
            ArrayList pz = new ArrayList();
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            foreach (string line in lines)
            {
                if (line.Contains(";"))
                {
                    string[] parts = line.Split(';');
                    pv = parts[0].Trim();
                    v = parts[1].Trim();
                    grp = parts[2].Trim();
                    string[] lin = parts[4].Trim().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    pz.Clear();
                    foreach (string l in lin)
                    {
                        int aa = int.Parse(l);
                        pz.Add(aa);
                    }
                    Studentas stud = new Studentas();
                    stud.Set(pv, v, grp, pz);
                    grupė.Set(stud);
                }
            }
        }

        static void WriteToFile(Fakultetas grupė, string fv, string header)
        {
            const string viršus = "------------------------------------------\r\n" +
                " Pavardė     Vardas     Grupė    Pažymiai \r\n" +
                "------------------------------------------";

            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine(header);
                fr.WriteLine(viršus);
                for (int i = 0; i < grupė.get(); i++)
                    fr.WriteLine("{0}", grupė.get(i).ToString());
                fr.WriteLine("Grupės vidurkis: {0,1:f1}", GroupAverage(grupė));
                fr.WriteLine("------------------------------------------\r\n");
            }
        }

        static void FormNewArray(Fakultetas D, ref Fakultetas R, string grupė)
        {
            for (int i = 0; i < D.get(); i++)
            {
                if (D.get(i).getGrupė() == grupė)
                    R.Set(D.get(i));
            }
        }

        static double GroupAverage(Fakultetas D)
        {
            double sum = 0;
            int n = D.get();
            double stSum;


            for (int i = 0; i < n; i++)
            {
                stSum = 0;
                foreach (int sk in D.get(i).getPažymiai())
                {
                    stSum += sk;
                }
                sum += (stSum / (double)D.get(i).getPažymiai().Count);
            }

            if (n > 0)
                return sum / (double)n;
            else
                return -1;
        }

        static void MergeArray(Fakultetas D, ref Fakultetas R)
        {
            for (int i = 0; i < D.get(); i++)
                R.Set(D.get(i));
        }
    }
}