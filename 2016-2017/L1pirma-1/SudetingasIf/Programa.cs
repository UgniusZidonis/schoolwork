using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudetingasIf
{
    class Programa
    {
        static void Main(string[] args)
        {
            double a;
            double x;

            Console.Write("Įveskite a reikšmę: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Įveskite x reikšmę: ");
            x = double.Parse(Console.ReadLine());

            Console.Clear();
            //Console.SetCursorPosition(5, 6);
            Console.WriteLine("Reikšmė a = {0,1:f2}, reikšmė x = {1,1:f2}, fx = {2,1:f3}", a, x, fx(x));
        }
        static double fx(double sk) {
            if (sk >= -6 && sk <= -1)
                return 1 / (sk - 3);
            else if (sk > -1 && sk <= 3)
                return Math.Pow(sk, 2) + 6;
            else
                return 2 * sk + 3;
        }
    }
}
