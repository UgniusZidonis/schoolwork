using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Analizės_failo_sukūrimas
{
    class Program
    {
        const string CFin = "../../input.txt";
        static char[] spacers = { ' ', '.', ',', '!', '?', ':', ';', '(', ')', '\t', '-' };
        static char[] vowels = { 'a', 'e', 'i', 'o', 'u', 'ą', 'ę', 'ė', 'į', 'ų', 'ū' };

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
        }


    }
}