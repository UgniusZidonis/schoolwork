using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Universalus_metodas
{
    class Program
    {
        static void Main(string[] args)
        {
            double fx;
            int z;
            Console.Write("Įveskite z reikšmę: ");
            z = int.Parse(Console.ReadLine());
            if (z - 1 >= 0)
                Console.WriteLine(" z = {0,1:d} f(x) = {1,1:f3}", z, Reiksme(z, 1, 0.5));
            else
                Console.WriteLine(" z = {0} f-ja neegzistuoja", z);
        }
        static double Reiksme(int sk1, int sk2, double laipsnis) {
            return Math.Pow(sk1 - sk2, laipsnis);
        }
    }
}
