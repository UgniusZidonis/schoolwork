using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skaiciuotuvas
{
    class Programa
    {
        static void Main(string[] args)
        {
            double a, b;
            char veiksmas;

            Console.Write("Įveskite pirmąjį skaičių: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Įveskite atliekamą veiksmą: ");
            veiksmas = char.Parse(Console.ReadLine());
            Console.Write("Įveskite antrąjį skaičių: ");
            b = double.Parse(Console.ReadLine());

            if (veiksmas == '+' || veiksmas == '-' || veiksmas == '*' || (veiksmas == '/' && b != 0))
                Console.WriteLine(a + " " + veiksmas + " " + b + " = " + atsakymas(a, b, veiksmas));
            else
                Console.WriteLine("KLAIDA");
        }
        static double atsakymas(double sk1, double sk2, char op) {
            if (op == '+')
                return sk1 + sk2;
            if (op == '-')
                return sk1 - sk2;
            if (op == '*')
                return sk1 * sk2;
            if (op == '/')
                return sk1 / sk2;
            else
                return 0;
        }
    }
}
