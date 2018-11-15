using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raidės
{
    class Letters
    {
        public int[] L;
        public string line;
        public StringBuilder alf = new StringBuilder("aąbcčdeęėfghjiįyjklmonprsštuųūvzžAĄBCČDEĘĖFGHIĮYJKLMONPRSŠTUŲŪVZŽ");

        public Letters()
        {
            L = new int[383];
            line = "";

            for (int i = 0; i < L.Length; i++)
                L[i] = 0;
        }

        public void Count()
        {
            for (int i = 0; i < line.Length; i++)
                for (int j = 0; j < alf.Length; j++)
                    if (line[i] == alf[j])
                        L[alf[j]]++;
        }

        public void Sort()
        {
            string alfa = "";
            for (int i = 0; i < alf.Length / 2 + 1; i++) {
                char max = alf[i];
                //Console.Write(max);

                for (int j = i; j < alf.Length / 2 + 1; j++) {
                    if (L[max] + L[char.ToUpper(max)] < L[alf[j]] + L[char.ToUpper(alf[j])]) {
                        max = alf[j];
                        //Console.WriteLine(max);
                    }
                }

                alfa += max;
            }

            alf = new StringBuilder(alfa);
            Console.WriteLine("\n" + alfa);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Letters L = new Letters();
            string line = "AaAbbba";
            L.line = line;
            L.Count();
            L.Sort();
            Spausdinti(L);
        }

        static void Spausdinti(Letters L)
        {
            for (int i = 0; i < L.alf.Length / 2 + 1; i++)
            {
                char ch = L.alf[i];
                Console.WriteLine("{0} {1} || {2} {3}", ch, L.L[ch], char.ToUpper(ch), L.L[char.ToUpper(ch)]);
            }
        }
    }
}