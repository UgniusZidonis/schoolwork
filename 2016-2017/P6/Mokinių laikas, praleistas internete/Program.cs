using System;
using System.Text;
using System.IO;

namespace Mokinių_laikas__praleistas_internete
{
    class Program
    {
        const string CFin1 = "../../input1.txt";
        const string CFin2 = "../../input2.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Mokiniai mokiniai = new Mokiniai();

            ReadFromFile(ref mokiniai);
            Console.WriteLine("   Pradiniai duomenys:");
            mokiniai.WriteKidsToConsole();
            Console.WriteLine("\n   Mokinių laikai:");
            mokiniai.WriteTimesToConsole();
            Console.WriteLine("\n   -- -- --\n   Surikiuoti duomenys:");
            mokiniai.Sort();
            mokiniai.WriteKidsToConsole();
            Console.WriteLine("\n   Mokinių laikai:");
            mokiniai.WriteTimesToConsole();
            Console.WriteLine("\n5 klasės mokinių vidutiniškai praleistas laikas internete: {0,1:f2}min.", mokiniai.getAverageTimeSpentOnNet(5));
            Console.WriteLine("Vaikų, nesinaudojančių internetu, skaičius: {0}", mokiniai.getKidsNotUsingTheInternetCount());

            /*---*/
            Console.WriteLine("\nPrograma baigė darbą...");
        }

        static void ReadFromFile(ref Mokiniai M)
        {
            using (StreamReader reader = new StreamReader(CFin1))
            {
                int n = int.Parse(reader.ReadLine());

                for (int i = 0; i < n; i++)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(';');
                    int grade = int.Parse(parts[2]);
                    double average = double.Parse(parts[3]);

                    Vaikas v = new Vaikas(parts[1], parts[0], grade, average);
                    M.set(v);
                }
            }

            using (StreamReader reader = new StreamReader(CFin2))
            {
                int n = int.Parse(reader.ReadLine());
                int m = int.Parse(reader.ReadLine());

                int[,] times = new int[n, m];

                for (int j = 0; j < n; j++)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(' ');

                    for (int i = 0; i < m; i++)
                    {
                        times[j, i] = int.Parse(parts[i]);
                    }
                }

                SetTimes(ref M, times);
            }
        }

        static void SetTimes(ref Mokiniai M, int[,] times) {
            int[] timesArray;
            for (int j = 0; j < M.get(); j++) {
                timesArray = new int[times.GetLongLength(1)];

                for (int i = 0; i < timesArray.Length; i++)
                    timesArray[i] = times[j, i];

                M.get(j).setTimeOnNet(timesArray);
            }
        }
    }
}