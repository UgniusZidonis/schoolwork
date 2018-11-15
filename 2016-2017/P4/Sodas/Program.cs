using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sodas
{
    class Obelis
    {
        private int kiek,
                    prieaug;
        private int koef1, koef2;

        public Obelis(int Pirmais_metais_užderėjusių_obuolių_kiekis, int Prieaugis, int Koeficentas1, int Koeficentas2) {
            this.kiek = Pirmais_metais_užderėjusių_obuolių_kiekis;
            this.prieaug = Prieaugis;
            this.koef1 = Koeficentas1;
            this.koef2 = Koeficentas2;
        }

        public override string ToString()
        {
            string line;
            line = string.Format("{0,5:d} {1,6:d} {2,5:d} {3,7:d}", kiek, prieaug, koef1, koef2);
            return line;
        }
        public int Dėsnis(int a, int b, double z) {
            if (Math.Sin(a * z) > 0.1)
            {
                double t = Math.Pow(Math.Sin(a * z) - 0.1, 0.5);
                int y = (int)Math.Floor(a - b * t + z * t * t);
                return y;
            }
            else
                return 0;
        }
        public void Obuoliai(int metai) {
            int z = kiek;
            int y;
            Console.WriteLine(" -----------------------");
            Console.WriteLine("  Metai Obuolių kiekis  ");
            Console.WriteLine(" -----------------------");

            for (int i = 0; i < metai; i++) {
                y = Dėsnis(koef1, koef2, z);
                if (y > 0)
                    Console.WriteLine("{0,5:d} {1,8:d}", i + 1, y);
                else
                    Console.WriteLine("{0,5:d}    nėra obuolių", i + 1);
                z += prieaug;
            }
            Console.WriteLine(" -----------------------\r\n");
        }
        //public int VisoObuolių()
    }

    class Sodas
    {
        int CMaxi = 100;
        private Obelis[] Obelys;
        private int n;

        public Sodas() {
            n = 0;
            Obelys = new Obelis[CMaxi];
        }

        public Obelis get(int i) { return Obelys[i]; }
        public int get() { return n; }
        public void Set(Obelis ob) { Obelys[n++] = ob; }
    }

    class Program
    {
        const string CFin = "../../input.txt";
        const string CFout = "../../output.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Sodas sodas = new Sodas();
            ReadFromFile(ref sodas, CFin);
            WriteToConsole(sodas);

            int metai;
            Console.Write("Įveskite metų reikšmę: ");
            metai = int.Parse(Console.ReadLine());
            Count(sodas, metai);


            /*---*/
            Console.WriteLine("Programa baigė darbą!");
        }

        static void ReadFromFile(ref Sodas sodas, string fv) {
            int koef1, koef2, kiek, prieaug, n;
            string line;

            using (StreamReader reader = new StreamReader(fv)) {
                n = int.Parse(reader.ReadLine());

                for (int i = 0; i < n; i++) {
                    line = reader.ReadLine();
                    string[] parts = line.Split(' ');
                    koef1 = int.Parse(parts[0]);
                    koef2 = int.Parse(parts[1]);
                    kiek = int.Parse(parts[2]);
                    prieaug = int.Parse(parts[3]);
                    Obelis ob = new Obelis(kiek, prieaug, koef1, koef2);
                    sodas.Set(ob);
                }
            }
        }

        static void WriteToConsole(Sodas sodas) {
            string viršus = " Informacija apie obelis \r\n" +
                            " --------------------------------- \r\n" +
                            " Nr. koef1  koef2  kiek prieaug \r\n" +
                            " --------------------------------- ";

            Console.WriteLine(viršus);
            for (int i = 0; i < sodas.get(); i++)
                Console.WriteLine("{0, 4:d} {1}", i + 1, sodas.get(i).ToString());
            Console.WriteLine(" -------------------------------- \n\n");
        }

        static void Count(Sodas sodas, int metai) {
            Console.WriteLine(" Informacija apie derlių");
            for (int i = 0; i < sodas.get(); i++) {
                Console.WriteLine("{0,3:d} obelis", i + 1);
                sodas.get(i).Obuoliai(metai);
            }
        }
    }
}
