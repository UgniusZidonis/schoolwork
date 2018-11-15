using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Žodžių_išskyrimas_ir_eilutės_redagavimas
{
    class Program
    {
        const string CFin = "../../ninput.txt";
        static char[] spacers = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] lines;
            lines = File.ReadAllLines(CFin, Encoding.GetEncoding(1257));
            Remove(ref lines, "Labas");
            foreach (string l in lines)
                Console.WriteLine(l);
        }

        static void Insert(ref string[] lines, string search, string insert)
        {
            for (int line = 0; line < lines.Length; line++)
            {
                string new_line = "";

                if (Contains(lines[line], search))
                {
                    string[] words = lines[line].Split(' ');
                    int w = -1;

                    for (int i = 0; i < words.Length; i++)
                        if (words[i] == search)
                            w = i;

                    for (int i = 0; i < w + 1; i++)
                        new_line += words[i] + " ";
                    new_line += insert;
                    for (int i = w + 1; i < words.Length; i++)
                        new_line += " " + words[i];
                }
                else
                    new_line = lines[line];

                lines[line] = new_line;
            }
        }

        static void Remove(ref string[] lines, string search) {
            for (int line = 0; line < lines.Length; line++) {
                string new_line = "";
                int w = -1;
                if (Contains(lines[line], search))
                {
                    string[] words = lines[line].Split(spacers, StringSplitOptions.RemoveEmptyEntries);
                    string[] parts = lines[line].Split(' ');

                    for (int i = 0; i < words.Length; i++) {
                        if (words[i] == search) {
                            w = i;
                            break;
                        }
                    }

                    for (int i = 0; i < parts.Length; i++) {
                        if (i < w)
                            new_line += parts[i] + " ";
                        if (i == w + 1)
                            new_line += parts[i];
                        if (i > w + 1)
                            new_line += " " + parts[i];
                    }
                }
                else
                    new_line = lines[line];

                lines[line] = new_line;
            }
        }

        static bool Contains(string line, string search) {
            bool c = false;

            if (line.Contains(search)) {
                string[] words = line.Split(spacers);

                foreach (string word in words)
                    if (word == search)
                        c = true;
            }

            return c;
        }
    }
}
