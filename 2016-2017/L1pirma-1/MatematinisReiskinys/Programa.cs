using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematinisReiskinys
{
    class Programa
    {
        static void Main(string[] args)
        {
            int x, y;
            Console.Write("Įveskite x reikšmę: ");
            x = int.Parse(Console.ReadLine());

            Console.Write("Įveskite y reikšmę: ");
            y = int.Parse(Console.ReadLine());

            if (Math.Pow(x, 3) - y != 0) {
                Console.WriteLine("f = {0,1:f3}", f(x, y));
            }
            
        }
        static double f(int sk1, int sk2) {
            return Math.Pow(sk2 - sk1, 2) / (Math.Pow(sk1, 3) - sk2);
        }
    }
}
