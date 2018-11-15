using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kepykla
{
    class Kepykla
    {
        private string kepykla;
        private string pav, miltai;
        private int rupumas, prieaugis;
        private double svoris;

        public Kepykla(string Kepyklos_pavadinimas, string kepinio_pavadinimas, string miltų_pavadinimas, int rupumas, int prieaugis, double svoris) {
            this.kepykla = Kepyklos_pavadinimas;
            this.pav = kepinio_pavadinimas;
            this.miltai = miltų_pavadinimas;
            this.rupumas = rupumas;
            this.prieaugis = prieaugis;
            this.svoris = svoris;
        }

        public string getKepykla() { return kepykla; }
        public string getName() { return pav; }
        public string getMiltai() { return miltai; }
        public int getRupumas() { return rupumas; }
        public int getPrieaugis() { return prieaugis; }
        public double getSvoris() { return svoris; }
    }

    class Program
    {
        const int CFn = 100;

        const string CFin1 = "../../input1.txt"; //Pirmos kepyklos duomenų failas
        const string CFin2 = "../../input2.txt"; //Antros kepyklos duomenų failas

        const string CFout = "../../output.txt"; //Atsakymų failas
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            

            

            Kepykla[] K1 = new Kepykla[CFn];
            int n1;
            int rupumas_count1;
            int prieaugis_count1;

            Kepykla[] K2 = new Kepykla[CFn];
            int n2;
            int rupumas_count2;
            int prieaugis_count2;

            Kepykla[] Bendras;
            int n;

            ReadFromFile(CFin1, K1, out n1);
            rupumas_count1 = SkaičiuotiNerupiausius(K1, n1);
            prieaugis_count1 = SkaičiuotiPrieaugius(K1, n1);

            ReadFromFile(CFin2, K2, out n2);
            rupumas_count2 = SkaičiuotiNerupiausius(K2, n2);
            prieaugis_count2 = SkaičiuotiPrieaugius(K2, n2);

            Bendras = VidutinioSvorioRinkinys(K1, K2, n1, n2, out n);

            if (File.Exists(CFout))
                File.Delete(CFout);

            //Pirmoji kepykla
            SpausdintiDuomenis(K1, n1);
            SpausdintiNerupiausius(K1, n1, rupumas_count1);
            SpausdintiPrieaugius(K1, n1, prieaugis_count1);

            //Antroji kepykla
            SpausdintiDuomenis(K2, n2);
            SpausdintiNerupiausius(K2, n2, rupumas_count2);
            SpausdintiPrieaugius(K2, n2, prieaugis_count2);


            SpausdintiKurDidžiausiasPrieaugis(K1, K2, n1, n2);

            SpausdintiBendrus(Bendras, n);

            /*---*/
            Console.WriteLine("\nPrograma baigė darbą!");
        }

        static void ReadFromFile(string fv, Kepykla[] K, out int n) {
            n = 0;
            string Kepykla;
            using (StreamReader reader = new StreamReader(fv)) {
                Kepykla = reader.ReadLine();
                string line;
                string[] parts;

                while ((line = reader.ReadLine()) != null) {
                    parts = line.Split(';');

                    K[n] = new Kepykla(Kepykla, parts[0], parts[1], int.Parse(parts[2]), int.Parse(parts[4]), double.Parse(parts[3]));
                    n++;
                }
            }
        }

        static void ReadFromConsole(Kepykla[] K, out int n) {
            string Kepykla;
            string kepinys, miltai;
            int rupumas, prieaugis;
            double svoris;

            Console.Write("Įveskite kepyklos pavadinimą: ");
            Kepykla = Console.ReadLine();
            Console.Write("Kiek kepinių kepama kepykloje: ");
            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++) {
                Console.Clear();

                Console.WriteLine("({0,1:d})", i + 1);
                Console.Write("Įveskite kepinio pavadinimą: ");
                kepinys = Console.ReadLine();
                Console.Write("Įveskite miltų rūšį: ");
                miltai = Console.ReadLine();
                Console.Write("Įveskite kepinio rupumą: ");
                rupumas = int.Parse(Console.ReadLine());
                Console.Write("Įveskite kepaliuko svorį: ");
                svoris = double.Parse(Console.ReadLine());
                Console.Write("Įveskite kepinio prieaugį: ");
                prieaugis = int.Parse(Console.ReadLine());

                K[i] = new Kepykla(Kepykla, kepinys, miltai, rupumas, prieaugis, svoris);
            }

            Console.Clear();
        }

        static void SpausdintiDuomenis(Kepykla[] K, int n) {
            const string viršus = "|-------------------------------------------------------------|\r\n" +
                                  "|                 |            |         |        |           |\r\n" +
                                  "|     Kepinys     |   Miltai   | Rupumas | Svoris | Prieaugis |\r\n" +
                                  "|                 |            |         |        |           |\r\n" +
                                  "|-------------------------------------------------------------|";

            using (var fr = File.AppendText(CFout)) {
                fr.WriteLine("{0}:", K[0].getKepykla());
                fr.WriteLine(viršus);

                for (int i = 0; i < n; i++) {
                    fr.WriteLine("|  {0,13}  | {1,10} |  {2,3:d}    |  {3,1:f2}  |  {4,4:d}     |", K[i].getName(), K[i].getMiltai(), K[i].getRupumas(), K[i].getSvoris(), K[i].getPrieaugis());
                }

                fr.WriteLine("---------------------------------------------------------------");
            }
        }

        static int MažiausiasRupumas(Kepykla[] K, int n) {
            int a = K[0].getRupumas();

            for (int i = 1; i < n; i++) {
                if (a > K[i].getRupumas())
                    a = K[i].getRupumas();
            }

            return a;
        }

        static int SkaičiuotiNerupiausius(Kepykla[] K, int n) {
            int count = 0;
            int rupumas = MažiausiasRupumas(K, n);

            for (int i = 0; i < n; i++) {
                if (K[i].getRupumas() == rupumas)
                    count++;
            }

            return count;
        }

        static void SpausdintiNerupiausius(Kepykla[] K, int n, int count) {
            int rupumas = MažiausiasRupumas(K, n);
            using (var fr = File.AppendText(CFout))
            {
                fr.Write("Nerupiausi kepiniai: ");
                for (int i = 0; i < n; i++)
                {
                    if (K[i].getRupumas() == rupumas)
                    {
                        if (count == 1)
                            fr.WriteLine("{0} ({1,1:d}).", K[i].getName(), K[i].getRupumas());
                        else
                            fr.Write("{0} ({1,1:d}), ", K[i].getName(), K[i].getRupumas());

                        count--;
                    }
                }
            }
        }

        static int DidžiausiasPrieaugis(Kepykla[] K, int n) {
            int a = K[0].getPrieaugis();

            for (int i = 1; i < n; i++) {
                if (a < K[i].getPrieaugis())
                    a = K[i].getPrieaugis();
            }

            return a;
        }

        static int SkaičiuotiPrieaugius(Kepykla[] K, int n) {
            int count = 0;
            int prieaugis = DidžiausiasPrieaugis(K, n);

            for (int i = 0; i < n; i++) {
                if (K[i].getPrieaugis() == prieaugis)
                    count++;
            }

            return count;
        }

        static void SpausdintiPrieaugius(Kepykla[] K, int n, int count) {
            int prieaugis = DidžiausiasPrieaugis(K, n);

            using (var fr = File.AppendText(CFout))
            {
                fr.Write("Didžiausio prieaugio kepiniai: ");
                for (int i = 0; i < n; i++)
                {
                    if (K[i].getPrieaugis() == prieaugis)
                    {
                        if (count == 1)
                            fr.WriteLine("{0} ({1,1:d}%).", K[i].getName(), K[i].getPrieaugis());
                        else
                            fr.Write("{0} ({1,1:d}%), ", K[i].getName(), K[i].getPrieaugis());

                        count--;
                    }
                }

                fr.WriteLine();
            }
        }

        static int RastiKurDidžiausiasPrieaugis(Kepykla[] K1, Kepykla[] K2, int n1, int n2) {
            int prieaugis1 = DidžiausiasPrieaugis(K1, n1);
            int prieaugis2 = DidžiausiasPrieaugis(K2, n2);

            if (prieaugis1 > prieaugis2)
                return 1;
            else if (prieaugis2 > prieaugis1)
                return 2;
            else
                return -1;
        }

        static void SpausdintiKurDidžiausiasPrieaugis(Kepykla[] K1, Kepykla[] K2, int n1, int n2)
        {
            int kur = RastiKurDidžiausiasPrieaugis(K1, K2, n1, n2);
            int prieaugis1 = DidžiausiasPrieaugis(K1, n1);
            int prieaugis2 = DidžiausiasPrieaugis(K2, n2);

            using (var fr = File.AppendText(CFout))
            {
                fr.Write("Didžiausio prieaugio kepinys yra ");

                if (kur != -1)
                {
                    if (kur == 1)
                        for (int i = 0; i < n1; i++)
                        {
                            if (K1[i].getPrieaugis() == prieaugis1)
                                fr.WriteLine("pirmoje kepykloje: {0}({1,1:d})", K1[i].getName(), K1[i].getPrieaugis());
                        }
                    if (kur == 2)
                        for (int i = 0; i < n2; i++)
                        {
                            if (K2[i].getPrieaugis() == prieaugis2)
                                fr.WriteLine("antroje kepykloje: {0}({1,1:d})", K2[i].getName(), K2[i].getPrieaugis());
                        }
                }
                else
                {
                    fr.WriteLine("abiejose kepyklose:");

                    for (int i = 0; i < n1; i++)
                    {
                        if (K1[i].getPrieaugis() == prieaugis1)
                            fr.WriteLine("Pirmoje: {0}({1,1:d})", K1[i].getName(), K1[i].getPrieaugis());
                    }

                    for (int i = 0; i < n2; i++)
                    {
                        if (K2[i].getPrieaugis() == prieaugis2)
                            fr.WriteLine("Antroje: {0}({1,1:d})", K2[i].getName(), K2[i].getPrieaugis());
                    }
                }
            }

        }

        static double VidutinisSvoris(Kepykla[] K1, int n1, Kepykla[] K2, int n2) {
            double svoris = 0;

            for (int i = 0; i < n1; i++)
                svoris += K1[i].getSvoris();

            for (int i = 0; i < n2; i++)
                svoris += K2[i].getSvoris();


            return svoris / ((double)n1 + (double)n2);
        }

        static int SkaičiuotiVidutinioSvorio(Kepykla[] K1, int n1, Kepykla[] K2, int n2) {
            int count = 0;
            double VidSvoris = VidutinisSvoris(K1, n1, K2, n2);

            for (int i = 0; i < n1; i++)
                if (K1[i].getSvoris() >= VidSvoris - VidSvoris / 10 && K1[i].getSvoris() <= VidSvoris + VidSvoris / 10)
                    count++;

            for (int i = 0; i < n2; i++)
                if (K2[i].getSvoris() >= VidSvoris - VidSvoris / 10 && K2[i].getSvoris() <= VidSvoris + VidSvoris / 10)
                    count++;

            return count;
        }

        static Kepykla[] VidutinioSvorioRinkinys(Kepykla[] K1, Kepykla[] K2, int n1, int n2, out int n) {
            int m = SkaičiuotiVidutinioSvorio(K1, n1, K2, n2);
            double VidSvoris = VidutinisSvoris(K1, n1, K2, n2);

            Kepykla[] K = new Kepykla[CFn];
            n = 0;

            for (int i = 0; i < n1; i++) {
                if (K1[i].getSvoris() >= VidSvoris - VidSvoris / 10 && K1[i].getSvoris() <= VidSvoris + VidSvoris / 10) {
                    K[n] = K1[i];
                    n++;
                }
            }

            for (int i = 0; i < n2; i++) {
                if (K2[i].getSvoris() >= VidSvoris - VidSvoris / 10 && K2[i].getSvoris() <= VidSvoris + VidSvoris / 10) {
                    K[n] = K2[i];
                    n++;
                }
            }

            

            return K;
        }

        static void SpausdintiBendrus(Kepykla[] K, int n) {
            const string viršus =
                "|------------------------------------------------------------------|\r\n" +
                "|                  |             |         |           |           |\r\n" +
                "|    Pavadinimas   |   Miltai    | Rupumas | Prieaugis |   Svoris  |\r\n" +
                "|                  |             |         |           |           |\r\n" +
                "|------------------------------------------------------------------|";

            using (var fr = File.AppendText(CFout)) {
                if (n != 0)
                {
                    fr.WriteLine(viršus);

                    for (int i = 0; i < n; i++)
                    {
                        fr.WriteLine("|   {0,12}   | {1,10}  |{2,5:d}    | {3,5:d}     | {4,7:f2}   |", K[i].getName(), K[i].getMiltai(), K[i].getRupumas(), K[i].getPrieaugis(), K[i].getSvoris());
                    }

                    fr.WriteLine("--------------------------------------------------------------------");
                }

                else
                    fr.WriteLine("Bendro sąrašo nėra");
            }
        }
    }
}
