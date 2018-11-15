using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDS_1
{
    class Program
    {
        const string CFin = "../../input.txt";
        static char[] symbols = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        static void Main(string[] args)
        {
            int[] numbers;
            int[] bases;

            ReadFromFile(out numbers, out bases);
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("{0}.", i + 1);
                Console.WriteLine("Original: {0,-10} | Base: {1}", numbers[i], bases[i]);
                if (bases[i] <= 36)
                    Console.WriteLine("New:      {0,-10}\n", ConvertedNumber(numbers[i], bases[i]));
                else
                    Console.WriteLine("!Base is too big, must be under or equal to 36!\n");
            }
        }

        static void ReadFromFile(out int[] numbers, out int[] bases) {
            string[] lines = File.ReadAllLines(CFin);
            int n = lines.Length;
            numbers = new int[n];
            bases = new int[n];
            for (int i = 0; i < n; i++)
            {
                string[] parts = lines[i].Split(' ');

                numbers[i] = int.Parse(parts[0]);
                bases[i] = int.Parse(parts[1]);
            }
        }

        static string ConvertedNumber(int number, int convertionBase) {
            char[] output = new char[100];
            int i = 0;

            while (number > 0) {
                output[i++] = symbols[number % convertionBase];
                number /= convertionBase;
            }

            Array.Resize(ref output, i);
            Array.Reverse(output);

            return new string(output);
        }
    }
}