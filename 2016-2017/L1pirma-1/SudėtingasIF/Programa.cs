using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudėtingasIF
{
    class Programa
    {
        static void Main(string[] args)
        {
            double x, y;

            Console.Write("Įveskite x reikšmę: ");
            x = double.Parse(Console.ReadLine());
            Console.Write("Įveskite y reikšmę: ");
            y = double.Parse(Console.ReadLine());

            if (Math.Pow(x, 3) - y != 0)
                Console.WriteLine("x reikšmė = {0,1:f}, y reikšmė = {1,1:f}, fx = {2,1:f8}", x, y, fx(x, y));
            else
                Console.WriteLine("x reikšmė = {0,1:f}, y reikšmė = {1,1:f}, f-ja neegzistuoja", x, y);
        }

        static double fx(double sk1, double sk2)
        {
            return Math.Pow(sk2 - sk1, 2) / (Math.Pow(sk1, 3) - sk2);
        }
    }
}

