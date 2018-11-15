using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciklas
{
    class Programa
    {
        static void Main(string[] args)
        {

            int a;
            int b;

            Console.Write("Įveskite sveikąją a reikšmę: ");
            a = int.Parse(Console.ReadLine());
            Console.Write("Įveskite sveikąją b reikšmę: ");
            b = int.Parse(Console.ReadLine());

            Spausdinti(a, b);
            /*
            for (int i = a; i <= b; i++) {
                Console.WriteLine(i + " " + i * i + " " + i*i*i);
                count++;
            }
            Console.WriteLine();
            Console.WriteLine(count);
            */
        }
        static void Spausdinti(int start, int finish) {
            int squares = 0;
            int cubes = 0;

            for (int i = start; i <= finish; i++) {
                Console.WriteLine(i + " " + Math.Pow(i, 2) + " " + Math.Pow(i, 3));
                squares += (int) Math.Pow(i, 2);
                cubes += (int) Math.Pow(i, 3);
            }
            Console.WriteLine("Skaičiuota = {0,1:d}, kvadratai = {1,1:d}, kubai = {2,1:d}", finish - start, squares, cubes);
        }
    }
}
