using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Dviratis
{
    class Dviratis
    {
        private int metai;
        private double kaina;

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
            const int Cn = 100;
            const string CFin = "../../input.txt";

            int n;
            int am;

            Dviratis[] D = new Dviratis[Cn];
            Skaityti(CFin, D, out n, out am);

            int kiek;
            double suma;
            double vidurkis;
            Pinigai(D, n, 0, 1000, 2015, out kiek, out suma);
            vidurkis = Vidurkis(D, n, 2015, 0, 1000);
            Console.WriteLine("Dviračiai: {0,3:d} {1,2:f2}   Amžių vidurkis: {2,2:f2}\n", kiek, suma, vidurkis);

            int kiekTinka;
            double sumaTinka;
            Pinigai(D, n, 0, am, 2015, out kiekTinka, out sumaTinka);
            Console.WriteLine("Tinkami naudoti: {0,5:d} {1,8:f2}", kiekTinka, sumaTinka);

            int kiekNetinka;
            double sumaNetinka;
            Pinigai(D, n, am + 1, 1000, 2015, out kiekNetinka, out sumaNetinka);
            Console.WriteLine("Netinkami naudoti: {0,3:d} {1,8:f2}\n", kiekNetinka, sumaNetinka);

            double vidurkisTinka = Vidurkis(D, n, 2015, 0, am);
            if (vidurkisTinka > 0)
                Console.WriteLine("Tinkamų naudoti dviračių vidutinis amžius: {0,7:f2}", vidurkisTinka);
            else
                Console.WriteLine("Tinkamų naudoti dviračių nėra");

            double vidurkisNetinka = Vidurkis(D, n, 2015, am + 1, 1000);
            if (vidurkisNetinka > 0)
                Console.WriteLine("Netinkamų naudoti dviračių vidutinis amžius: {0,1:f2}", vidurkisNetinka);
            else
                Console.WriteLine("Netinkamų naudoti dviračių nėra");

            int kiek_2012;
            double sum_2012;
            Pinigai(D, n, 4, 4, 2016, out kiek_2012, out sum_2012);
            Console.WriteLine("{0} {1}", kiek_2012, sum_2012);

            int kiek_1000;
            double sum_1000;
            double vidurkis_1000;
            Pinigai(D, n, 1016, 1016, 2016, out kiek_1000, out sum_1000);
            vidurkis_1000 = Vidurkis(D, n, 2016, 1016, 1016);
            Console.WriteLine("{0} {1} {2}", kiek_1000, sum_1000, vidurkis_1000);

            /*---*/
            Console.WriteLine("\nPrograma baigė darbą!");
        }

        static void Skaityti(string fv, Dviratis[] D, out int n, out int m) {
            int metai;
            double kaina;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                m = int.Parse(line);
                line = reader.ReadLine();
                n = int.Parse(line);
                for (int i = 0; i < n; i++) {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    metai = int.Parse(parts[0]);
                    kaina = double.Parse(parts[1]);
                    D[i] = new Dviratis(metai, kaina);
                }
            }
        }

        static void Pinigai(Dviratis[] D, int n, int amPr, int amPb, int metai, out int kiek, out double sum) {
            kiek = 0;
            sum = 0;

            for (int i = 0; i < n; i++) {
                int amžius = metai - D[i].getMetai();

                if (amPr <= amžius && amžius <= amPb) {
                    kiek++;
                    sum += D[i].getKaina();
                }
            }
        }

        static double Vidurkis(Dviratis[] D, int n, int metai, int amPr, int amPb) {
            int kiek = 0; int sum = 0;
            for (int i = 0; i < n; i++) {
                int amžius = metai - D[i].getMetai();

                if (amPr <= amžius && amžius <= amPb) {
                    sum += amžius;
                    kiek++;
                }
            }

            if (kiek > 0)
                return (double) sum / kiek;
            else
                return 0;
        }
    }
}
