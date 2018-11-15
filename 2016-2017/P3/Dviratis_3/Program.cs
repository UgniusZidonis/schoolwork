using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dviratis_2
{
    class Dviratis
    {
        private string name;
        private int kiekis;
        private int metai;
        private double kaina;

        public Dviratis(string name, int kiekis, int metai, double kaina)
        {
            this.name = name;
            this.kiekis = kiekis;
            this.metai = metai;
            this.kaina = kaina;
        }

        public string getName() { return name; }
        public int getKiekis() { return kiekis; }
        public int getMetai() { return metai; }
        public double getKaina() { return kaina; }

        public void papildytiKiekį(int kiekis) { this.kiekis += kiekis; }
    }

    class Program
    {
        const int CFn = 100;
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const string CFin1 = "...\\...\\input1.txt";
            const string CFin2 = "...\\...\\input2.txt";
            const string CFout = "...\\...\\output.txt";

            Dviratis[] D1 = new Dviratis[CFn];
            string name1;
            int n1;
            Skaityti(CFin1, out name1, D1, out n1);
            Dviratis oldest1;
            Dviratis brangiausias1;

            Dviratis[] D2 = new Dviratis[CFn];
            string name2;
            int n2;
            Skaityti(CFin2, out name2, D2, out n2);
            Dviratis oldest2;
            Dviratis brangiausias2;

            Dviratis[] Dr = new Dviratis[CFn];
            int nr = 0;
            Formuoti(D1, n1, Dr, ref nr);
            Formuoti(D2, n2, Dr, ref nr);
            


            if (File.Exists(CFout))
                File.Delete(CFout);
            SpausdintiDuomenis(CFout, D1, n1, name1);
            SpausdintiDuomenis(CFout, D2, n2, name2);
            SpausdintiDuomenis(CFout, Dr, nr, "Bendras sąrašas");
            int D1_oldest = rastiSeniausioIndeksą(D1, n1);
            int D2_oldest = rastiSeniausioIndeksą(D2, n2);
            using (var fr = File.AppendText(CFout))
            {
                if (D1[D1_oldest].getMetai() < D2[D2_oldest].getMetai())
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte: {0}", name1);
                else if (D2[D2_oldest].getMetai() < D1[D1_oldest].getMetai())
                    fr.WriteLine("Seniausias dviratis yra nuomos punkte: {0}", name2);
                else
                    fr.WriteLine("Abu nuomos punktai turi vienodo senumo dviratį");
            }

            int D1_brang = rastiBrangiausioIndeksą(D1, n1);
            int D2_brang = rastiBrangiausioIndeksą(D2, n2);
            using (var fr = File.AppendText(CFout))
            {
                if (D1[D1_brang].getKaina() < D2[D2_brang].getKaina())
                    fr.WriteLine("Brangiausias dviratis yra nuomos punkte: {0}", name1);
                else if (D2[D2_brang].getKaina() < D1[D1_brang].getKaina())
                    fr.WriteLine("Brangiausias dviratis yra nuomos punkte: {0}", name2);
                else
                    fr.WriteLine("Abu nuomos punktai turi vienodo brangumo dviratį");
            }

            rastiSeniausią(D1, n1, out oldest1);
            rastiSeniausią(D2, n2, out oldest2);
            SpausdintiSeniausius(name1, name2, oldest1, oldest2);

            rastiBrangiausią(D1, n1, out brangiausias1);
            rastiBrangiausią(D2, n2, out brangiausias2);
            SpausdintiBrangiausius(name1, name2, brangiausias1, brangiausias2);

            rastiBendrus(D1, D2, n1, n2, out Dr, out nr);
            SpausdintiBendrus(Dr, nr);
            Dviratis brangiausias;
            rastiBrangiausią(Dr, nr, out brangiausias);
            Console.WriteLine("\nBrangiausio dviračio kaina: {0}", brangiausias.getKaina());

            /*---*/
            Console.WriteLine("\nPrograma baigė darbą!");
        }

        static void Skaityti(string fv, out string name, Dviratis[] D, out int n)
        {
            string bike_name;
            int kiekis;
            int metai;
            double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                name = reader.ReadLine();
                string[] parts;
                n = int.Parse(reader.ReadLine());
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    bike_name = parts[0];
                    kiekis = int.Parse(parts[1]);
                    metai = int.Parse(parts[2]);
                    kaina = double.Parse(parts[3]);
                    D[i] = new Dviratis(bike_name, kiekis, metai, kaina);
                }
            }
        }

        static void rastiSeniausią(Dviratis[] D, int n, out Dviratis oldest)
        {
            oldest = D[0];

            for (int i = 1; i < n; i++)
            {
                if (oldest.getMetai() > D[i].getMetai())
                    oldest = D[i];
            }
        }

        static void SpausdintiSeniausius(string station_name1, string station_name2, Dviratis d1, Dviratis d2)
        {
            if (d1.getMetai() < d2.getMetai())
                Console.WriteLine("Seniausias dviratis - {0} ({1,1:d}m.) - yra '{2}' nuomos punkte", d1.getName(), d1.getMetai(), station_name1);
            else if (d2.getMetai() < d1.getMetai())
                Console.WriteLine("Seniausias dviratis - {0} ({1,1:d}m.) - yra '{2}' nuomos punkte", d2.getName(), d2.getMetai(), station_name2);
            else
            {
                Console.WriteLine("Seniausi dviračiai:");
                Console.WriteLine("'{0}' nuomos punkte:            {1}, {2,1:d}m.", station_name1, d1.getName(), d1.getMetai());
                Console.WriteLine("'{0}' nuomos punkte:   {1}, {2,1:d}m.", station_name2, d2.getName(), d2.getMetai());
            }
        }

        static void rastiBrangiausią(Dviratis[] D, int n, out Dviratis brangiausias)
        {
            brangiausias = D[0];

            for (int i = 1; i < n; i++)
            {
                if (brangiausias.getKaina() < D[i].getKaina())
                    brangiausias = D[i];
            }
        }

        static void SpausdintiBrangiausius(string station_name1, string station_name2, Dviratis d1, Dviratis d2)
        {
            if (d1.getKaina() > d2.getKaina())
                Console.WriteLine("Brangiausias dviratis - {0} ({1,1:f2}EUR) - yra {2} nuomos punkte", d1.getName(), d1.getKaina(), station_name1);
            else if (d2.getKaina() > d1.getKaina())
                Console.WriteLine("Brangiausias dviratis - {0} ({1,1:f2}EUR) - yra {2} nuomos punkte", d2.getName(), d2.getKaina(), station_name2);
            else
            {
                Console.WriteLine("Brangiausi dviračiai:");
                Console.WriteLine("'{0}' nuomos punkte:           {1}, {2,1:f2}EUR", station_name1, d1.getName(), d1.getKaina());
                Console.WriteLine("'{0}' nuomos punkte:   {1}, {2,1:f2}EUR", station_name2, d2.getName(), d2.getKaina());
            }
        }

        static void rastiBendrus(Dviratis[] D1, Dviratis[] D2, int n1, int n2, out Dviratis[] Dr, out int kiek)
        {
            Dr = new Dviratis[CFn];
            kiek = 0;
            for (int i = 0; i < n1; i++)
            {
                Dviratis a = D1[i];
                for (int j = 0; j < n2; j++)
                {
                    Dviratis b = D2[j];

                    if (a.getName() == b.getName()/* && a.getMetai() == b.getMetai()*/)
                    {
                        Dr[kiek] = b;
                        kiek++;
                    }
                }
            }
        }

        static void SpausdintiBendrus(Dviratis[] d, int kiek)
        {
            if (kiek > 0)
            {
                Console.WriteLine("\nBendrų dviračių sąrašas:");
                for (int i = 0; i < kiek; i++)
                {
                    Console.WriteLine("{0} {1,1:d}", d[i].getName(), d[i].getMetai());
                }
            }
            else
                Console.WriteLine("\nBendrų dviračių nėra");
        }

        static void SpausdintiDuomenis(string fv, Dviratis[] D, int n, string pav)
        {
            const string virsus =
                  "|-----------------|------------|--------------|---------|\r\n"
                + "|   Pavadinimas   |   Kiekis   |  Pagaminimo  |  Kaina  |\r\n"
                + "|                 |            |     metai    |  (eurų) |\r\n"
                + "|-----------------|------------|--------------|---------|";

            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Nuomos firma: {0}", pav);
                fr.WriteLine(virsus);
                for (int i = 0; i < n; i++)
                {
                    Dviratis d = D[i];
                    fr.WriteLine("| {0,-15} | {1,8}   | {2,5:d}        | {3,7:f2} |", d.getName(), d.getKiekis(), d.getMetai(), d.getKaina());
                }
                fr.WriteLine("---------------------------------------------------------\n");
            }
        }

        static int rastiSeniausioIndeksą(Dviratis[] D, int n)
        {
            {
                int oldest = 0;

                for (int i = 1; i < n; i++)
                {
                    if (D[oldest].getMetai() > D[i].getMetai())
                        oldest = i;
                }

                return oldest;
            }
        }

        static int YraModelis(Dviratis[] D, int n, string pav, int metai)
        {
            for (int i = 0; i < n; i++)
                if (D[i].getName() == pav && D[i].getMetai() == metai)
                    return i;
            return -1;
        }

        static void Formuoti(Dviratis[] D, int n, Dviratis[] Dr, ref int nr)
        {
            for (int i = 0; i < n; i++)
            {
                int k = YraModelis(Dr, nr, D[i].getName(), D[i].getMetai());
                if (k >= 0)
                    Dr[k].papildytiKiekį(D[i].getKiekis());
                else {
                    Dr[nr] = D[i];
                    nr++;
                }
            }
        }

        static int rastiBrangiausioIndeksą(Dviratis[] D, int n) {
            int brang = 0;

            for (int i = 0; i < n; i++) {
                if (D[brang].getKaina() < D[i].getKaina())
                    brang = i;
            }
            return brang;
        } 
    }
}