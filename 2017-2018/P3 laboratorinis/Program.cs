using System;
using System.Collections.Generic;
using System.IO;

namespace P3_laboratorinis
{
    class Program {
        const string inputFile = "../../input.txt";
        const string outputFile = "../../output.txt";

        static void Main(string[] args) {
            if(File.Exists(outputFile))
                File.Delete(outputFile);
            var list = Rings.ReadFromFile(inputFile);
            WriteToFile("Pirmas sąrašas", outputFile);
            Rings.WriteToFile(list, outputFile);
            Console.Write("Įveskite metalo tipą: ");
            string metal = Console.ReadLine();
            Console.Write("Įveskite žiedo dydį: ");
            int size = int.Parse(Console.ReadLine());
            var mostExpensive = Rings.FindSpecifiedMetalRings(metal, list);
            WriteToFile("Brangiausi du žiedai", outputFile);
            Rings.WriteToFile(mostExpensive, outputFile);
            WriteToFile(string.Format("\r\nŽiedų daugiausiai yra: {0}\r\n", Rings.WhichIsMore(list)), outputFile);
            WriteToFile("Gamintojų sąrašas", outputFile);
            PrintManufacturers(Rings.RingCountsAndManufacturers(list), outputFile);
            var list1 = Rings.GetSpecifiedMetalAndSizeRings(metal, size, list);
            Rings.Sort(ref list1);
            WriteToFile("", outputFile);
            WriteToFile("Rikiuotas sąrašas", outputFile);
            Rings.WriteToFile(list1, outputFile);
        }

        static void PrintManufacturers(List<string> manufacturers, string outputFile) {
            foreach(var line in manufacturers)
                WriteToFile(line, outputFile);
        }

        static void WriteToFile(string line, string outputFile) {
            using(var writer = File.AppendText(outputFile)) {
                writer.WriteLine(line);
            }
        }
    }
}
