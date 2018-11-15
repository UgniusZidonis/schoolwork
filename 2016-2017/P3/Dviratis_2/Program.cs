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
        int metai;
        double kaina;

        public Dviratis(int metai, double kaina)
        {
            this.metai = metai;
            this.kaina = kaina;
        }

        public int getMetai() { return metai; }
        public double getKaina() { return kaina; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            const int CFn = 100;
            const string CFin1 = "...\\...\\input1.txt";
            const string CFin2 = "...\\...\\input2.txt";

            Dviratis[] D1 = new Dviratis[CFn];
            string name1;
            int n1, am1;
            int kiekTinka1, kiekNetinka1;
            double vidTinka1, vidNetinka1;
            double sumaTinka1, sumaNetinka1;
            double vertė1;
            Dviratis[] D2 = new Dviratis[CFn];
            string name2;
            int n2, am2;
            int kiekTinka2, kiekNetinka2;
            double sumaTinka2, sumaNetinka2;
            double vidTinka2, vidNetinka2;
            double vertė2;

            Skaityti(CFin1, out name1, D1, out n1, out am1);
            Skaityti(CFin2, out name2, D2, out n2, out am2);

            Pinigai(D1, n1, 0, am1, 2016, out kiekTinka1, out sumaTinka1);
            Pinigai(D1, n1, am1 + 1, 1000, 2016, out kiekNetinka1, out sumaNetinka1);
            vidTinka1 = vidAmžius(D1, n1, 0, am1, 2016);
            vidNetinka1 = vidAmžius(D1, n1, am1 + 1, 1000, 2016);
            vertė1 = sumaTinka1 + sumaNetinka1;

            Pinigai(D2, n2, 0, am2, 2016, out kiekTinka2, out sumaTinka2);
            Pinigai(D2, n2, am2 + 1, 1000, 2016, out kiekNetinka2, out sumaNetinka2);
            vidTinka2 = vidAmžius(D2, n2, 0, am2, 2016);
            vidNetinka2 = vidAmžius(D2, n2, am2 + 1, 1000, 2016);
            vertė2 = sumaTinka2 + sumaNetinka2;

            Console.WriteLine("'{0}' dviračių skaičius: {1,1:d}", name1, n1);
            Console.WriteLine("Tinkami naudoti dviračiai: {0,1:d} {1,1:f2} || Vidutinis amžius: {2,3:f0}", kiekTinka1, sumaTinka1, vidTinka1);
            Console.WriteLine("Netinkami naudoti dviračiai: {0,1:d} {1,1:f2} || Vidutinis amžius: {2,1:f0}", kiekNetinka1, sumaNetinka1, vidNetinka1);

            Console.WriteLine("\n'{0}' dviračių skaičius: {1,1:d}", name2, n2);
            Console.WriteLine("Tinkami naudoti dviračiai: {0,1:d} {1,1:f2} || Vidutinis amžius: {2,3:f0}", kiekTinka2, sumaTinka2, vidTinka2);
            Console.WriteLine("Netinkami naudoti dviračiai: {0,1:d} {1,1:f2} || Vidutinis amžius: {2,1:f0}", kiekNetinka2, sumaNetinka2, vidNetinka2);

            Console.WriteLine();
            SpausdintiDaugiauTinka(kiekTinka1, kiekTinka2);


            /*---*/
            Console.WriteLine("\nPrograma baigė darbą!");
        }

        static void Skaityti(string fv, out string name, Dviratis[] D, out int n, out int m)
        {
            int metai;
            double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                name = reader.ReadLine();
                line = reader.ReadLine();
                string[] parts;
                m = int.Parse(line);
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    metai = int.Parse(parts[0]);
                    kaina = double.Parse(parts[1]);
                    D[i] = new Dviratis(metai, kaina);
                }
            }
        }

        static void Pinigai(Dviratis[] D, int n, int amPr, int amPb, int metai, out int kiek, out double sum)
        {
            kiek = 0;
            sum = 0;

            for (int i = 0; i < n; i++)
            {
                int amžius = metai - D[i].getMetai();

                if (amPr <= amžius && amžius <= amPb)
                {
                    kiek++;
                    sum += D[i].getKaina();
                }
            }
        }

        static double vidAmžius(Dviratis[] D, int n, int amPr, int amPb, int metai) {
            int kiek = 0;
            int sum = 0;

            for (int i = 0; i < n; i++) {
                int amžius = metai - D[i].getMetai();

                if (amPr <= amžius && amžius <= amPb) {
                    sum += amžius;
                    kiek++;
                }
            }

            if (kiek > 0)
                return sum / kiek;
            else
                return 0;
        }

        static void SpausdintiDaugiauTinka(int kiekTinka1, int kiekTinka2) {
            if (kiekTinka1 > kiekTinka2)
                Console.WriteLine("Pirmajame dviračių punkte yra daugiau tinkamų naudoti dviračių");
            else if (kiekTinka2 > kiekTinka1)
                Console.WriteLine("Antrajame dviračių punkte yra daugiau tinkamų naudoti dviračių");
            else
                Console.WriteLine("Abiejuose dviračių punktsuoe yra vienodai tinkamų naudoti dviračių");
        }

        static void SpausdintiDidesnęVertė(int vertė1, int vertė2) {
            if (vertė1 > vertė2)
                Console.WriteLine("Pirmajame dviračių punkte yra didesnė dviračių vertė");
            else if (vertė2 > vertė1)
                Console.WriteLine("Antrajame dviračių punkte yra didesnė dviračių vertė");
            else
                Console.WriteLine("Abiejuose dviračių punktuose yra vienoda dviračių vertė");
        }
    }
}
