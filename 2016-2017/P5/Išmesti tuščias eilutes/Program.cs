using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Išmesti_tuščias_eilutes
{
    class Program
    {
        const string CFin = "../../input.txt";
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(CFin);
            int n = lines.Length;
            EmptyLines(ref lines, ref n);
            for (int i = 0; i < n; i++) {
                Console.WriteLine(lines[i]);
            }
        }

        static void EmptyLines(ref string[] lines, ref int n) {
            for (int line = 0; line < lines.Length; line++) {
                if (isEmpty(lines[line])) {
                    n--;
                    for (int i = line; i < n; i++) {
                        lines[i] = lines[i + 1];
                    }
                    line--;
                }
            }
        }

        static bool isEmpty(string value) {
            if (value.Length > 0)
                for (int i = 0; i < value.Length; i++)
                    if (value[i] != ' ')
                        return false;
            return true;
        }
    }
}
