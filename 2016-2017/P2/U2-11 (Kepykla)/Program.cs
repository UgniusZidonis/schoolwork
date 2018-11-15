using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U2_11__Kepykla_
{
    class Duona
    {
        private string rūšis, miltųPav;
        private int svoris, prieaugis, rupumas, plotas;

        public Duona(string rūšis, string miltųPav, int rupumas, int svoris, int prieaugis, int plotas)
        {
            this.rūšis = rūšis;
            this.miltųPav = miltųPav;
            this.rupumas = rupumas;
            this.svoris = svoris;
            this.prieaugis = prieaugis;
            this.plotas = plotas;
        }

        public string getRūšis() { return rūšis; }
        public string getMiltųPav() { return miltųPav; }
        public int getSvoris() { return svoris; }
        public int getPrieaugis() { return prieaugis; }
        public int getRupumas() { return rupumas; }
        public int getPlotas() { return plotas; }
    }

    class Kepykla
    {
        private string Name;
        private int kiekis1, kiekis2, kiekis3, miltųTalpa;

        public Kepykla(string Name, int kiekis1, int kiekis2, int kiekis3, int miltųTalpa)
        {
            this.Name = Name;
            this.kiekis1 = kiekis1;
            this.kiekis2 = kiekis2;
            this.kiekis3 = kiekis3;
            this.miltųTalpa = miltųTalpa;
        }

        public string getName() { return Name; }
        public int getKiekis1() { return kiekis1; }
        public int getKiekis2() { return kiekis2; }
        public int getKiekis3() { return kiekis3; }
        public int getMiltųTalpa() { return miltųTalpa; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string kep_pav;
            int kiekis1, kiekis2, kiekis3;
            int milt;
            ReadKepykla(out kep_pav, out kiekis1, out kiekis2, out kiekis3, out milt);
            Kepykla kepykla = new Kepykla(kep_pav, kiekis1, kiekis2, kiekis3, milt);
            Console.Clear();

            Duona[] duonos = new Duona[3];
            string rūšis, milt_pav; int rupumas, svoris, prieaugis, plotas;
            ReadDuonos(out rūšis, out milt_pav, out rupumas, out svoris, out prieaugis, out plotas);
            duonos[0] = new Duona(rūšis, milt_pav, rupumas, svoris, prieaugis, plotas);
            Console.Clear();

            ReadDuonos(out rūšis, out milt_pav, out rupumas, out svoris, out prieaugis, out plotas);
            duonos[1] = new Duona(rūšis, milt_pav, rupumas, svoris, prieaugis, plotas);
            Console.Clear();

            ReadDuonos(out rūšis, out milt_pav, out rupumas, out svoris, out prieaugis, out plotas);
            duonos[2] = new Duona(rūšis, milt_pav, rupumas, svoris, prieaugis, plotas);
            Console.Clear();

            int[] plotai = new int[3];

            int count;
            SpausdintiNerupiausias(RastiNerupiausias(duonos, out count), count);
            SpausdintiDidžiausioPrieaugio(RastiDidžiausiąPrieaugį(duonos, out count), count);
            spausdintiPlotus(skaičiuotiPlotą(kepykla, duonos), duonos);
            spausdintiArTelpa(kepykla, reikiaMiltų(kepykla, duonos));

        }

        static Duona[] RastiNerupiausias(Duona[] d, out int count)
        {
            Duona nerupiausia = d[0];
            Duona[] nerupiausios = new Duona[d.Length];
            count = 0;

            for (int i = 0; i < d.Length; i++)
            {
                if (nerupiausia.getRupumas() > d[i].getRupumas())
                    nerupiausia = d[i];
            }

            for (int i = 0; i < d.Length; i++)
            {
                if (nerupiausia.getRupumas() == d[i].getRupumas())
                {
                    nerupiausios[count] = d[i];
                    count++;
                }
            }

            return nerupiausios;
        }

        static Duona[] RastiDidžiausiąPrieaugį(Duona[] d, out int count)
        {
            Duona prieaug = d[0];
            Duona[] didžPrieaug = new Duona[d.Length];
            count = 0;

            for (int i = 0; i < d.Length; i++)
            {
                if (prieaug.getPrieaugis() < d[i].getPrieaugis())
                    prieaug = d[i];
            }

            for (int i = 0; i < d.Length; i++) {
                if (d[i].getPrieaugis() == prieaug.getPrieaugis()) {
                    didžPrieaug[count] = d[i];
                    count++;
                }
            }

            return didžPrieaug;
        }

        static int[] skaičiuotiPlotą(Kepykla k, Duona[] d)
        {
            int[] p = new int[3];
            p[0] = k.getKiekis1() * d[0].getPlotas();
            p[1] = k.getKiekis2() * d[1].getPlotas();
            p[2] = k.getKiekis3() * d[2].getPlotas();

            return p;
        }

        static void spausdintiPlotus(int[] p, Duona[] d)
        {
            for (int i = 0; i < d.Length; i++)
            {
                Console.WriteLine("'{0}' rūšies duonai reikės {1,1:d} kvadratinių centimetrų lentynų talpos", d[i].getRūšis(), p[i]);
            }
        }

        static void spausdintiArTelpa(Kepykla k, double talpa)
        {
            if (k.getMiltųTalpa() >= talpa)
                Console.WriteLine("\nKepykloje '{0}' miltai telpa", k.getName());
            else
                Console.WriteLine("\n'{0}' kepykloje  miltai netelpa", k.getName());
        }

        static double reikiaMiltų(Kepykla k, Duona[] d)
        {
            double sum = 0;

            sum += (double)k.getKiekis1() * d[0].getSvoris();
            sum += (double)k.getKiekis2() * d[1].getSvoris();
            sum += (double)k.getKiekis3() * d[2].getSvoris();

            return sum;
        }

        static void ReadKepykla(out string pavadinimas, out int kiekis1, out int kiekis2, out int kiekis3, out int miltųTalpa)
        {
            Console.Write("Įveskite kepyklos pavadinimą: ");
            pavadinimas = Console.ReadLine();
            Console.Write("Įveskite pirmos duonos kepamą kiekį per naktį: ");
            kiekis1 = int.Parse(Console.ReadLine());
            Console.Write("Įveskite antros duonos kepamą kiekį per naktį: ");
            kiekis2 = int.Parse(Console.ReadLine());
            Console.Write("Įveskite trečios duonos kepamą kiekį per naktį: ");
            kiekis3 = int.Parse(Console.ReadLine());
            Console.Write("Įveskite miltų talpa kepykloje: ");
            miltųTalpa = int.Parse(Console.ReadLine());
        }

        static void ReadDuonos(out string rūšis, out string miltųPav, out int rupumas, out int svoris, out int prieaugis, out int plotas)
        {
            Console.Write("Įveskite duonos rūšį: ");
            rūšis = Console.ReadLine();
            Console.Write("Įveskite miltų pavadinima: ");
            miltųPav = Console.ReadLine();
            Console.Write("Įveskite duonos rupumą: ");
            rupumas = int.Parse(Console.ReadLine());
            Console.Write("Įveskite kepaliuko svorį: ");
            svoris = int.Parse(Console.ReadLine());
            Console.Write("Įveskite prieaugio kiekį procentais: ");
            prieaugis = int.Parse(Console.ReadLine());
            Console.Write("Įveskite kepaliuko užimamą plotą: ");
            plotas = int.Parse(Console.ReadLine());
        }

        static void SpausdintiNerupiausias(Duona[] d, int count)
        {
            if (count == 1)
            {
                Console.WriteLine("Nerupiausia duona: {0}", d[0].getRūšis());
            }
            else
            {
                Console.Write("Nerupiausios duonos: ");

                for (int i = 0; i < count; i++)
                {
                    if (i != 0)
                    Console.Write(d[i].getRūšis().ToLower());
                    else
                        Console.Write(d[i].getRūšis());

                    if (i < count - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
        }

        static void SpausdintiDidžiausioPrieaugio(Duona[] d, int count) {
            if (count == 1)
                Console.WriteLine("Didžiausio prieaugio duona: {0}", d[0].getRūšis());

            else {
                Console.Write("Didžiausio prieaugio duonos: ");
                for (int i = 0; i < count; i++) {
                    if (i != 0)
                        Console.Write(d[i].getRūšis().ToLower());
                    else
                        Console.Write(d[i].getRūšis());

                    if (i < count - 1)
                        Console.Write(", ");
                }
                Console.WriteLine();
            }
        }
    }
}