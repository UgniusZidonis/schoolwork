using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Paskaitos__U6_11_
{
    class Program
    {
        const string CFin = "../../input.txt";
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Universitetas uni = new Universitetas();

            ReadFromFile(ref uni);
            Console.WriteLine("   Pradiniai duomenys:");
            uni.WriteStudentsToConsole();
            Console.WriteLine("\n   Praleistų paskaitų duomenys:");
            uni.WriteAbsentDaysToConsole();
            uni.WriteNonAbsentDaysToConsole(uni.nonAbsentDays());
            Console.WriteLine("\n   Surikiuotas studentų sąrašas:");
            uni.Sort();
            uni.WriteStudentsToConsole();
            uni.WriteDifferentProfessionsAbsentHours();
            uni.Remove(uni.StudentsWhoShouldBeRemovedIndexes());
            Console.WriteLine("\n   Studentų sąrašas be nelankančių:");
            uni.WriteStudentsToConsole();

            /*---*/
            Console.WriteLine("\nPrograma baigė darbą...");
        }

        static void ReadFromFile(ref Universitetas U) {
            using (StreamReader reader = new StreamReader(CFin)) {
                string line = reader.ReadLine();
                string[] parts = line.Split(' ');
                int n = int.Parse(parts[0]);
                int m = int.Parse(parts[1]);

                for (int i = 0; i < n; i++) {
                    parts = reader.ReadLine().Split(';');

                    Studentas S = new Studentas(parts[0], parts[1], parts[2], parts[3], m);
                    U.Set(S);
                }

                int[,] absentDays = new int[m, n];

                for (int j = 0; j < m; j++) {
                    parts = reader.ReadLine().Split(' ');

                    for (int i = 0; i < parts.Length; i++) {
                        absentDays[j, i] = int.Parse(parts[i]);
                    }
                }

                for (int i = 0; i < U.get(); i++) {
                    U.get(i).setAbsentDays(column(absentDays, i));
                }
            }
        }

        static int[] column(int[,] matrix, int index) {
            int[] values = new int[matrix.GetLongLength(0)];

            for (int i = 0; i < matrix.GetLongLength(0); i++) {
                values[i] = matrix[i, index];
            }

            return values;
        }
    }
}
