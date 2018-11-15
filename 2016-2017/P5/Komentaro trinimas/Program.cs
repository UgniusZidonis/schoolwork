using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Komentaro_trinimas
{
    class Program
    {
        const string CFin = "../../input.txt";
        const string CFout = "../../output.txt";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            string[] lines;
            int n;

            ReadFromFile(CFin, out lines, out n);
            DeleteLongComments(ref lines, n);
            DeleteComments(ref lines, n);
            DeleteEmptyLines(ref lines, ref n);
            WriteToConsole(CFout, lines, n);
        }

        static void ReadFromFile(string fv, out string[] lines, out int n)
        {
            lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            n = lines.Length;
        }

        static void WriteToConsole(string fv, string[] lines, int n)
        {
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(lines[i]);
            }
        }

        static void DeleteComments(ref string[] lines, int n)
        {
            bool in_quote = false;
            for (int line = 0; line < n; line++)
                for (int i = 0; i < lines[line].Length - 1; i++) {
                    switch (in_quote) {
                        case false:
                            if (lines[line][i] == '"')
                                in_quote = true;
                            break;
                        case true:
                            if (lines[line][i] == '"')
                                in_quote = false;
                            break;
                    }

                    if (!in_quote)
                    {
                        if (lines[line][i] == '/' && lines[line][i + 1] == '/') {
                            lines[line] = lines[line].Remove(i, lines[line].Length - i);
                            break;
                        }
                    }
                }
        }

        static void DeleteEmptyLines(ref string[] lines, ref int n)
        {
            for (int i = 0; i < n; i++)
            {
                if (String.IsNullOrEmpty(lines[i]))
                {
                    for (int j = i; j < n - 1; j++)
                    {
                        lines[j] = lines[j + 1];
                    }
                    n--;
                    i--;
                }
            }
        }

        static void DeleteLongComments(ref string[] lines, int n) {
            int cs = -1;
            int ce = -1;
            bool in_quote = false;
            for (int line = 0; line < lines.Length; line++) {
                for (int i = 0; i < lines[line].Length - 1; i++) {

                    switch (in_quote) {
                        case false:
                            if (lines[line][i] == '"')
                                in_quote = true;
                            break;
                        case true:
                            if (lines[line][i] == '"')
                                in_quote = false;
                            break;
                    }

                    if (!in_quote)
                    {
                        if (lines[line][i] == '/' && lines[line][i + 1] == '*')
                            cs = i;
                        if (lines[line][i] == '*' && lines[line][i + 1] == '/')
                            ce = i + 2;
                    }

                    if (cs != -1 && ce != -1) {
                        lines[line] = lines[line].Remove(cs, ce - cs);
                        cs = -1;
                        ce = -1;
                    }
                }
                if (cs != -1 && ce == -1) {
                    lines[line] = lines[line].Remove(cs, lines[line].Length - cs);
                    cs = 0;
                }

            }
        }
    }
}