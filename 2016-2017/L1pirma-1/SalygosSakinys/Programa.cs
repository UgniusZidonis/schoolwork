using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalygosSakinys
{
    class Programa
    {
        static void Main(string[] args)
        {
            char symbol;
            int lineCount;
            int symbolCount;
            Console.Write("Įveskite spausdinamą simbolį: ");
            symbol = char.Parse(Console.ReadLine());
            Console.Write("Įveskite spausdinamų simbolių kiekį: ");
            symbolCount = int.Parse(Console.ReadLine());
            Console.Write("Įveskite spausdinamų eilučių kiekį: ");
            lineCount = int.Parse(Console.ReadLine());

            Spausdinti(symbol, lineCount, symbolCount);
        }
        static void Spausdinti(char ch, int lines, int count) {
            int lineCount = count / lines;
            int lastLineCount = count % lines;

            for (int i = 0; i < lineCount; i++) {
                for (int j = 0; j < lines; j++) {
                    Console.Write(ch);
                }
                Console.WriteLine();
            }

            for (int i = 0; i < lastLineCount; i++) {
                Console.Write(ch);
            }

            if (lastLineCount != 0)
                Console.WriteLine();

        }
    }
}

