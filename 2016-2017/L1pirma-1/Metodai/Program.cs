using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodai
{
    class Program
    {
        static void Main(string[] args)
        {
            int a;
            int b;
            Console.Write("Įveskite sveikąją a reikšmę: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Įveskite sveikąją b reikšmę: ");
            b = int.Parse(Console.ReadLine());
            Console.WriteLine("{0,1:d} + {1,1:d} = {2,1:d}", a, b, Suma(a, b));
        }
        static int Suma(int sk1, int sk2) {
            return sk1 + sk2;
        }
    }
}
