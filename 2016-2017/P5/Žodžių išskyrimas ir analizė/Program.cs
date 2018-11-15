using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Žodžių_išskyrimas_ir_analizė
{
    class Program
    {
        const string CFin = "../../input.txt";
        static char[] spacers = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t' };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] words;
            int n;

            Read(CFin, out words, out n);
            Console.WriteLine(Count(words, n));
            Console.WriteLine(Palindromas(words, n));
        }

        static void Read(string fv, out string[] words, out int n)
        {
            string[] lines = File.ReadAllLines(fv, Encoding.GetEncoding(1257));
            n = 0;
            string[] parts;
            words = new string[100];

            for (int line = 0; line < lines.Length; line++)
            {
                parts = lines[line].Split(spacers, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < parts.Length; i++)
                {
                    words[n++] = parts[i];
                }
            }
        }

        static int Count(string[] words, int n)
        {
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                string word = words[i];

                if (char.ToUpper(word[0]) == char.ToUpper(word[word.Length - 1]))
                    count++;
            }
            return count;
        }

        static int Palindromas(string[] words, int n) {
            int count = 0;

            for (int i = 0; i < n; i++) {
                string word = words[i];
                string other;

                char[] other_char = new char[word.Length];

                for (int j = 0; j < word.Length; j++) {
                    other_char[word.Length - 1 - j] = word[j];
                }

                other = new string(other_char);

                if (word == other)
                    count++;

            }

            return count;
        }
    }
}
