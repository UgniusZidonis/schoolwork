using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Prekybos_bazė
{
    class Matrica
    {
        const int CMaxEil = 10;
        const int CMaxSt = 100;
        private int[,] A;
        public int n { get; set; }
        public int m { get; set; }

        public Matrica() {
            n = 0;
            m = 0;
            A = new int[CMaxEil, CMaxSt];
        }

        public void set(int i, int j, int pirk) {
            A[i, j] = pirk;
        }

        public int get(int i, int j) { return A[i, j]; }
        public int allBuyers() {
            int sum = 0;

            for (int j = 0; j < n; j++) {
                for (int i = 0; i < m; i++) {
                    sum += A[j, i];
                }
            }

            return sum;
        }
        public double averagePerTill(int i) {
            double sum = 0;
            for (int j = 0; j < m; j++) {
                sum += A[i, j];
            }

            return sum / (double) m;
        }
        public int didNotWorkDayCount(int i) {
            int sum = 0;

            for (int j = 0; j < m; j++) {
                if (A[i, j] == 0)
                    sum++;
            }

            return sum;
        }
        public double allAverage() {
            return (double) allBuyers() / (double) (n * m);
        }
        public int allDayBuyers(int j) {
            int sum = 0;

            for (int i = 0; i < n; i++) {
                sum += A[i, j];
            }

            return sum;
        }

        public int leastBuyers() {
            int sum = 0;

            for (int j = 0; j < m - 1; j++) {
                if (allDayBuyers(j + 1) < allDayBuyers(j))
                    sum = allDayBuyers(j + 1);
            }

            return sum;
        }

        public int[] leastBuyersDays(out int d) {
            int[] days = new int[m];
            d = 0;

            for (int j = 0; j < m; j++) {
                if (allDayBuyers(j) == leastBuyers())
                    days[d++] = j + 1;
            }

            return days;
        }
    }

    class Program
    {
        const string CFin = "../../input.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Matrica prekybosBazė = new Matrica();

            ReadFromFile(ref prekybosBazė);
            Console.WriteLine("Pradiniai duomenys:\n");
            WriteToFile(prekybosBazė);
            Console.WriteLine("Viso aptarnauta: {0}", prekybosBazė.allBuyers());
            Console.WriteLine("Visų aptarnautų vidurkis: {0,1:f2}", prekybosBazė.allAverage());

            /*---*/
            Console.WriteLine("\nPrograma baigė darbą...");
        }

        static void ReadFromFile(ref Matrica M) {
            int n, m;
            using (StreamReader reader = new StreamReader(CFin)) {
                n = int.Parse(reader.ReadLine());
                m = int.Parse(reader.ReadLine());

                M = new Matrica();
                string[] lines = new string[n];
                for (int i = 0; i < n; i++) {
                    lines[i] = reader.ReadLine();
                }

                for (int j = 0; j < n; j++) {
                    string[] parts = lines[j].Split(';');

                    for (int i = 0; i < m; i++) {
                        M.set(j, i, int.Parse(parts[i]));
                    }
                }
            }

            M.n = n;
            M.m = m;
        }

        static void WriteToFile(Matrica M) {
            Console.WriteLine("Kasų kiekis: {0}", M.n);
            Console.WriteLine("Darbo dienų kiekis: {0}", M.m);
            Console.WriteLine("Aptarnautų klientų kiekiai");

            for (int j = 0; j < M.n; j++) {
                Console.Write("K{0}: ", j);
                for (int i = 0; i < M.m; i++) {
                    Console.Write("{0} ", M.get(j, i));
                }
                Console.Write("   Vidutiniškai aptarnautų žmonių skaičius: {0,1:f2}", M.averagePerTill(j));
                Console.WriteLine(" | Dienų nedirbo: {0}", M.didNotWorkDayCount(j));
            }

            Console.Write("Mažiausiai aptarnautų žmonių skaičius: {0}", M.leastBuyers());
            Console.Write(" Tai buvo ");
            int d;
            int[] days = M.leastBuyersDays(out d);
            for (int i = 0; i < d; i++) {
                if (i < d - 1)
                    Console.Write("{0} ", days[i]);
                else
                    Console.WriteLine("{0} dienomis", days[i]);
            }
        }
    }
}
