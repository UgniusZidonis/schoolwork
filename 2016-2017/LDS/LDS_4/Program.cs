using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LDS_4
{
    class Program
    {
        const string CFin = "../../input.txt";
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(CFin);
        }
        static bool DividesBy9(string number, out int sum) {
            sum = 0;
            for (int i = 0; i < number.Length; i++) {
                sum += (int)number[i];
            }

            return sum % 9 == 0;
        }
        static bool DividesBy11(string number, out int difference) {
            int sum1 = 0;
            for (int i = 0; i < number.Length; i += 2)
                sum1 += (int)number[i];

            int sum2 = 0;
            for (int i = 1; i < number.Length; i += 2)
                sum2 += (int)number[i];

            difference = sum1 - sum2;

            return difference % 11 == 0;
        }
        static void WriteToConsole(string number) {
            int sum, difference;
            bool d9, d11;
            d9 = DividesBy9(number, out sum);
            d11 = DividesBy11(number, out difference);
            Console.WriteLine(d9 ? sum + " dalinasi iš 9" : sum + " nesidalina iš 9");
            Console.WriteLine(d11 ? difference + " dalinasi iš 11" : difference + " nesidalina iš 11");
            Console.WriteLine(d9 && d11 ? number + " dalinasi iš 99" : number + " nesidalina iš 99");
        }
    }
}
