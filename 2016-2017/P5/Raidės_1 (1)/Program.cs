using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raidės_1__1_
{
    class Letters
    {
        public int[] Rn;
        public string eil { get; set; }
        public string alfa = "";
        public StringBuilder alf = new StringBuilder("aąbcčdeęėfghiįyjklmonprsštuųūvzžAĄBCČDEĘĖFGHIĮYJKLMONPRSŠTUŲŪVZŽ");

        int[] C = new int[383];
        

    public Letters()
        {
            eil = "";
            Rn = new int[383];

            for (int i = 0; i < Rn.Length; i++) {
                Rn[i] = 0;
            }
        }

        public void Count() {
            for (int i = 0; i < eil.Length; i++) {
                for (int j = 0; j < alf.Length; j++)
                    if (alf[j] == eil[i])
                        Rn[eil[i]]++;
            }

            for (int i = 0; i < Rn.Length; i++)
            {
                C[i] = Rn[i];
            }
        }

        public void Sort() {
            for (int i = 0; i < alf.Length / 2; i++) {
                int max = 0;

                for (int j = 0; j < alf.Length / 2 + 1; j++) {
                    if (C[alf[j]] + C[char.ToUpper(alf[j])] > C[alf[max]] + C[char.ToUpper(alf[max])])
                        max = j;
                }
                
                C[alf[max]] = -1;
                C[char.ToUpper(alf[max])] = -1;

                alfa += alf[max];
            }

            alf = new StringBuilder(alfa + alfa.ToUpper());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Letters Le = new Letters();
            Le.eil = "";
            Le.Count();
            Le.Sort();

            Spausdinti(Le);
        }

        static void Spausdinti(Letters L) {
            for (int i = 0; i < L.alf.Length / 2; i++)
                Console.WriteLine("{0} {1} || {2} {3}", L.alf[i], L.Rn[L.alf[i]], L.alf[i + 32], L.Rn[L.alf[i + 32]]);
        }
    }
}
