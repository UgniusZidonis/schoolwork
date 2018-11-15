using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Butas__1_
{
    class Butas
    {
        private int numeris,
                    kambarių_skaičius;
        private double plotas,
                       kaina;
        private string tel_nr;

        public Butas(int numeris, double plotas, int kambarių_skaičius, double kaina, string tel_nr) {
            this.numeris = numeris;
            this.plotas = plotas;
            this.kambarių_skaičius = kambarių_skaičius;
            this.kaina = kaina;
            this.tel_nr = tel_nr;
        }

        public int getNumeris() { return numeris; }
        public double getPlotas() { return plotas; }
        public int getKambariai() { return kambarių_skaičius; }
        public double getKaina() { return kaina; }
        public string getTel() { return tel_nr; }
    }

    class Namas
    {
        private int CMaxi = 100;
        private Butas[] Butai;
        private int n;

        public Namas()
        {
            Butai = new Butas[CMaxi];
            n = 0;
        }

        public Butas getButas(int i) { return Butai[i]; }
        public int getButas() { return n; }
        public void setButas(Butas b) { Butai[n++] = b; }
    }

    class Program
    {
        const string CFin = "../../input.txt";
        const string CFout = "../../output.txt";

        static void Main(string[] args)
        {
            Namas namas = new Namas();
            int kamb;
            double kaina;

            ReadFromFile(CFin, ref namas, out kamb, out kaina);

            if (File.Exists(CFout))
                File.Delete(CFout);

            WriteToFile(CFout, namas);

            Namas tink = TinkamiButai(namas, kamb, kaina);

            WriteApplicable(tink);
        }

        static void ReadFromFile(string fv, ref Namas n, out int kamb, out double kaina) {
            using (StreamReader reader = new StreamReader(fv)) {
                string[] parts;
                string line = reader.ReadLine();

                parts = line.Split(';');
                kamb = int.Parse(parts[0]);
                kaina = double.Parse(parts[1]);

                while ((line = reader.ReadLine()) != null) {
                    parts = line.Split(';');

                    Butas b;
                    int numeris = int.Parse(parts[0]);
                    double plotas = double.Parse(parts[1]);
                    int kambariai = int.Parse(parts[2]);
                    double buto_kaina = double.Parse(parts[3]);
                    string tel_nr = parts[4];

                    b = new Butas(numeris, plotas, kambariai, buto_kaina, tel_nr);

                    n.setButas(b);
                }
            }
        }

        static void WriteToFile(string fv, Namas n) {
            const string viršus = "|-----------------------------------------------------------|\r\n" +
                                  "|         |        |           |             |              |\r\n" +
                                  "| Numeris | Plotas | Kambariai |  Kaina(EUR) |   Telefonas  |\r\n" +
                                  "|         | (km²)  |           |             |              |\r\n" +
                                  "|-----------------------------------------------------------|";

            using (var fr = File.AppendText(fv)) {
                fr.WriteLine(viršus);

                for (int i = 0; i < n.getButas(); i++) {
                    Butas b = n.getButas(i);
                    fr.WriteLine("|    {0,-4:d} | {1,6:f2} |     {2,-6:d}|  {3,10:f2} | {4} |", b.getNumeris(), b.getPlotas(), b.getKambariai(), b.getKaina(), b.getTel());
                }
                fr.WriteLine("-------------------------------------------------------------\r\n");
            }
        }

        static Namas TinkamiButai(Namas n, int kamb, double kaina) {
            Namas butai = new Namas();

            bool exists = false;
            for (int i = 0; i < n.getButas(); i++) {
                Butas b = n.getButas(i);

                if (b.getKambariai() == kamb && b.getKaina() <= kaina)
                {
                    exists = true;
                    butai.setButas(b);
                }
            }

            if (exists)
                return butai;
            else {
                butai.setButas(new Butas(-1, -1, -1, -1, ""));
                return butai;
            }
        }

        static void WriteApplicable(Namas n) {
            const string viršus = "|-----------------------------------------------------------|\r\n" +
                                  "|         |        |           |             |              |\r\n" +
                                  "| Numeris | Plotas | Kambariai |  Kaina(EUR) |   Telefonas  |\r\n" +
                                  "|         | (km²)  |           |             |              |\r\n" +
                                  "|-----------------------------------------------------------|";

            using (var fr = File.AppendText(CFout)) {
                if (n.getButas(0).getNumeris() == -1)
                    fr.WriteLine("Nėra tinkamų butų");
                else {
                    fr.WriteLine("" + viršus);
                    for (int i = 0; i < n.getButas(); i++) {
                        Butas b = n.getButas(i);

                        fr.WriteLine("|    {0,-4:d} | {1,6:f2} |     {2,-6:d}|  {3,10:f2} | {4} |", b.getNumeris(), b.getPlotas(), b.getKambariai(), b.getKaina(), b.getTel());
                    }

                    fr.WriteLine("-------------------------------------------------------------");
                }
            }
        }
    }
}
