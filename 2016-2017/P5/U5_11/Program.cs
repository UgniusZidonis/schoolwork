using System;
using System.Linq;
using System.Text;
using System.IO;

namespace U5_11
{
    class Letters
    {
        private int CMax;
        private int[] Cl;
        private string alf;
        public string word;
        private int different;

        public Letters()
        {
            word = "";
            CMax = 383;
            different = 0;
            Cl = new int[CMax];

            for (int i = 0; i < CMax; i++)
                Cl[i] = 0;

            alf = "aąbcčdeęėfghiįyjklmonprsštuųūvzžAĄBCČDEĘĖFGHIĮYJKLMONPRSŠTUŲŪVZŽ";
        }

        public int getDifferent() { return different; }

        public void Count()
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (alf.Contains(word[i]))
                    Cl[word[i]]++;
            }
        }

        public void CountDifferent()
        {
            int n = 0;
            for (int i = 0; i < CMax; i++)
            {
                if (Cl[i] > 0)
                    n++;
            }

            different = n;
        }
    }

    class Program
    {
        const string CFin = "../../input.txt";
        static char[] spacers = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '–', '-', '"', '\'', '\t' };
        static string alfa = "aąbcčdeęėfghiįyjklmonprsštuųūvzžAĄBCČDEĘĖFGHIĮYJKLMONPRSŠTUŲŪVZŽ";

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string[] lines = File.ReadAllLines(CFin);

            for (int line = 0; line < lines.Length; line++)
            {
                if (CountFirstAndLast(lines[line]) > 0)
                {
                    string[] words = lines[line].Split(spacers, StringSplitOptions.RemoveEmptyEntries);
                    string m = MostDifferentLetters(lines[line]);
                    Console.WriteLine("{0, -75} || {1} {2}", ChangeLine(lines[line]), CountFirstAndLast(lines[line]), m);
                }
                else
                    Console.WriteLine("{0, -75} || {1}", lines[line], CountFirstAndLast(lines[line]));
            }

        }

        static bool FirstAndLastLetters(string word)
        {
            return word[0] == word[word.Length - 1] && alfa.Contains(word[0]) && alfa.Contains(word[word.Length - 1]);
        }

        static int CountFirstAndLast(string line) {
            int n = 0;
            string[] words = line.Split(spacers, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++)
                if (FirstAndLastLetters(words[i]))
                {
                    n++;
                }

            return n;
        }

        static string MostDifferentLetters(string line)
        {
            int m = -1;
            string[] words = line.Split(spacers, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < words.Length; i++) {
                if (FirstAndLastLetters(words[i]))
                {
                    m = i;
                    break;
                }
            }

            for (int i = m; i < words.Length; i++) {
                Letters d = new Letters();
                d.word = words[m];
                d.Count();
                d.CountDifferent();

                Letters o = new Letters();
                o.word = words[i];
                o.Count();
                o.CountDifferent();

                if (FirstAndLastLetters(words[i]) && d.getDifferent() < o.getDifferent())
                    m = i;
            }

            return words[m];
        }

        static string ChangeLine(string line) {
            if (CountFirstAndLast(line) > 0)
            {
                StringBuilder new_line = new StringBuilder(line);
                string find = MostDifferentLetters(line);
                int find_st = line.IndexOf(find);
                int find_l = find.Length;
                while (find_st + find_l < line.Length && line[find_st + find_l] != ' ')
                    find_l++;

                int repl_l = 0;
                while (line[repl_l] != ' ')
                    repl_l++;

                new_line.Remove(find_st, find_l);
                new_line.Insert(find_st, line.Substring(0, repl_l));
                new_line.Remove(0, repl_l);
                new_line.Insert(0, line.Substring(find_st, find_l));

                return new_line.ToString();
            }

            return line;
        }
    }
}