using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simboliai
{
    class Programa
    {
        static void Main(string[] args)
        {
            char pr, pb;
            string vardas;

            Console.WriteLine("Koks jūsų vardas?");
            vardas = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Sveiki, {0}!", vardas);

            Console.Write("Įveskite raidę raidžių intervalo pradžiai: ");
            pr = (char)Console.ReadLine()[0];
            Console.Write("Įveskite raidę raidžių intervalo pabaigai: ");
            pb = (char)Console.Read();
            Console.Clear();

            for (char ch = pr; ch <= pb; ch++) {
                Console.Write("{0} - {1}", ch, (int) ch);
                Console.WriteLine();
            }
        }
    }
}
