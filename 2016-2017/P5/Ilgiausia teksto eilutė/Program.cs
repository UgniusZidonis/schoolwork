using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Ilgiausia_teksto_eilutė
{
    class Program
    {
        const string CFin = "../../input.txt";
        const string CFout = "../../output.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] lines = new string[100];
            int n = 0;

            ReadFromFile(CFin, lines, out n);
            RemoveEmpty(ref lines, ref n);
            RemoveLongest(ref lines, ref n);

            for (int i = 0; i < n; i++) {
                Console.WriteLine(lines[i]);
            }
        }

        static void ReadFromFile(string fv, string[] lines, out int n) {
            n = 0;

            using (StreamReader reader = new StreamReader(CFin)) {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    lines[n++] = line;
                }
            }
        }

        static void RemoveLongest(ref string[] lines, ref int n) {
            int[] a = new int[100];
            int an = 0;
            int max = 0;

            for (int j = 1; j < n; j++)
            {
                if (lines[max].Length < lines[j].Length)
                    max = j;
            }

            for (int i = 0; i < n; i++)
            {
                if (max != i)
                {
                    if (lines[max].Length == lines[i].Length)
                        a[an++] = i;
                }
            }
            a[an++] = max;

            for (int i = 0; i < an; i++)
            {
                for (int j = a[i]; j < n - 1; j++)
                {
                    lines[j] = lines[j + 1];
                }
                n--;
            }
        }

        static void RemoveEmpty(ref string[] lines, ref int n) {
            for (int i = 0; i < n; i++) {
                if (lines[i] == "") {
                    for (int j = i; j < n - 1; j++)
                        lines[j] = lines[j + 1];
                    n--;
                }
            }
        }
    }
}
