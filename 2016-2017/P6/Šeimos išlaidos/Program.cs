using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Šeimos_išlaidos
{
    class Asmuo
    {
        string name;
        double spent;

        public Asmuo(string name, double spent) {
            this.name = name;
            this.spent = spent;
        }

        public string getName() { return name; }
        public double getSpent() { return spent; }
        public override string ToString() { return String.Format("{0,-5} {1,6:f2}   ", name, spent); }
    }

    class Matrica
    {
        int CMaxWeeks = 100;
        int CMaxDays = 7;
        Asmuo[,] A;
        public int w { get; set; }
        public int d { get; set; }

        public Matrica() {
            A = new Asmuo[CMaxWeeks, CMaxDays];
            w = 0;
            d = 0;
        }

        public void set(int j, int i, Asmuo obj) {
            A[j, i] = obj;
        }

        public Asmuo get(int j, int i) { return A[j, i]; }

        public double AllSpent() {
            double sum = 0;

            for (int j = 0; j < w; j++) {
                for (int i = 0; i < d; i++) {
                    sum += A[j, i].getSpent();
                }
            }

            return sum;
        }

        public int CountNoSpentDays() {
            int sum = 0;

            for (int j = 0; j < w; j++) {
                for (int i = 0; i < d; i++)
                    if (A[j, i].getSpent() == 0)
                        sum++;
            }

            return sum;
        }

        public double CountIndividualSpent(string name) {
            double sum = 0;

            for (int j = 0; j < w; j++) {
                for (int i = 0; i < d; i++)
                    if (A[j, i].getName() == name)
                        sum += A[j, i].getSpent();
            }

            return sum;
        }

        public double CountWeekSpent(int week) {
            double sum = 0;
            for (int i = 0; i < d; i++)
                sum += A[week, i].getSpent();

            return sum;
        }

        public double CountDaysSpent(int day) {
            double sum = 0;

            for (int j = 0; j < w; j++)
                sum += A[j, day].getSpent();

            return sum;
        }

        public string MostSpent(out double spent) {
            spent = 0;
            string mostSpent = "-----";

            for (int j = 0; j < w; j++) {
                for (int i = 0; i < d; i++)
                    if (A[j, i].getSpent() > spent) {
                        mostSpent = A[j, i].getName();
                        spent = A[j, i].getSpent();
                    }
            }

            return mostSpent;
        }

        public int[] LeastSpentWeek(out double leastSpent) {
            int least = 0;
            int count = 0;

            for (int j = 0; j < w; j++) {
                if (CountWeekSpent(j) < CountWeekSpent(least))
                    least = j;
            }

            for (int j = 0; j < w; j++)
                if (CountWeekSpent(j) == CountWeekSpent(least))
                    count++;

            int[] leastSpentWeeks = new int[count];

            int n = 0;
            for (int j = 0; j < w; j++)
                if (CountWeekSpent(j) == CountWeekSpent(least))
                    leastSpentWeeks[n++] = j + 1;


            leastSpent = CountWeekSpent(least);
            return leastSpentWeeks;
        }

        public void WriteLeastSpentWeeks() {
            double leastSpent;
            int[] weeks = LeastSpentWeek(out leastSpent);

            Console.Write("Mažiausiai išleista buvo šiomis savaitėmis: ");

            for (int i = 0; i < weeks.Length; i++) {
                if (i != weeks.Length - 1)
                    Console.Write("{0}, ", weeks[i]);
                else
                    Console.WriteLine("{0}.", weeks[i]);
            }
        }
    }

    class Program
    {
        const string CFin = "../../input.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Matrica šeimosIšlaidos = new Matrica();
            int day = 3;

            ReadFromFile(ref šeimosIšlaidos);

            Console.WriteLine("Pradiniai duomenys");
            WriteToConsole(šeimosIšlaidos);
            Console.WriteLine("\nVisos šeimos išlaidos: {0,1:f2}", šeimosIšlaidos.AllSpent());
            Console.WriteLine("Šeimos išlaidos {0}-dieniais: {1,1:f2}", day + 1, šeimosIšlaidos.CountDaysSpent(day));
            Console.WriteLine("Dienų skaičius, kada šeima neturėjo išlaidų: {0}", šeimosIšlaidos.CountNoSpentDays());
            //Console.WriteLine("Mažiausiai išlaidų buvo {0}-ą savaitę {1,1:f2}", šeimosIšlaidos.LeastSpentWeek(out leastWeekSpentSum) + 1, leastWeekSpentSum);
            šeimosIšlaidos.WriteLeastSpentWeeks();
            Console.WriteLine("Vyro išlaidos:   {0,1:f2}", šeimosIšlaidos.CountIndividualSpent("vyras"));
            Console.WriteLine("Žmonos išlaidos: {0,1:f2}", šeimosIšlaidos.CountIndividualSpent("žmona"));


            /*---*/
            Console.WriteLine("\nPrograma baigė darbą...");
        }

        static void ReadFromFile(ref Matrica M) {
            using (StreamReader reader = new StreamReader(CFin)) {
                M.w = int.Parse(reader.ReadLine());
                M.d = int.Parse(reader.ReadLine());

                for (int j = 0; j < M.w; j++) {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(';');
                    for (int i = 0; i < M.d * 2; i += 2) {
                        Asmuo obj = new Asmuo(parts[i], double.Parse(parts[i + 1]));
                        M.set(j, i / 2, obj);
                    }
                }
            }
        }

        static void WriteToConsole(Matrica M) {
            Console.WriteLine("Savaičių kiekis: {0}", M.w);
            Console.WriteLine("Dienų kiekis: {0}\n", M.d);

            string header = "";
            for (int i = 0; i < M.d; i++) {
                header += String.Format("   {0}-dienis    ", i + 1);
            }

            Console.WriteLine(header);

            for (int j = 0; j < M.w; j++) {
                string line = String.Format("{0}. ", j + 1);
                for (int i = 0; i < M.d; i++) {
                    Asmuo obj = M.get(j, i);
                    line += obj.ToString();
                }
                Console.WriteLine(line);
            }

            Console.WriteLine();

            Console.WriteLine("Savaičių išlaidos:");
            Console.WriteLine("Numeris | Išlaidos");
            for (int j = 0; j < M.w; j++) {
                Console.WriteLine("{0,4}    | {1,8:f2}", j + 1, M.CountWeekSpent(j));
            }

            Console.WriteLine("\nDienų išlaidos:");
            Console.WriteLine("Numeris | Išlaidos");
            for (int i = 0; i < M.d; i++) {
                Console.WriteLine("{0,4}    | {1,8:f2}", i + 1, M.CountDaysSpent(i));
            }
        }
    }
}
