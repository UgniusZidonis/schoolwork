using System;
using System.Collections.Generic;
using System.IO;

namespace P3
{
    class Program
    {
        static string inputFile1 = "../../inputItems1.txt";
        static string inputFile2 = "../../inputItems2.txt";
        static string outputFile = "../../outputItems.txt";

        static void Main(string[] args) {
            if(File.Exists(outputFile))
               File.Delete(outputFile);

            List<Items> items1 = new List<Items>();
            items1 = Items.ReadFromFile(inputFile1);
            WriteToFile("Pradinis sąrašas", outputFile);
            Items.WriteToFile(items1, outputFile);

            List<Items> items2 = new List<Items>(items1);
            string removeType = Console.ReadLine();
            Items.RemoveSpecifiedTypeItems(ref items2, removeType);
            WriteToFile("", outputFile);
            WriteToFile("Naujas sąrašas", outputFile);
            Items.WriteToFile(items2, outputFile);

            Items.Sort(ref items2);
            WriteToFile("", outputFile);
            WriteToFile("Naujas rikiuotas sąrašas", outputFile);
            Items.WriteToFile(items2, outputFile);
            WriteToFile(string.Format("Vidurkis: {0,0:f2}", Items.AmountAverage(items2)), outputFile);
            WriteToFile(string.Format("Bendra suma: {0,0:f2}", Sum(items2)), outputFile);

            List<Items> items3 = new List<Items>();
            items3 = Items.ReadFromFile(inputFile2);
            WriteToFile("", outputFile);
            WriteToFile("Trečias sąrašas", outputFile);
            Items.WriteToFile(items3, outputFile);

            Items.InsertList(ref items2, items3, removeType);
            WriteToFile("", outputFile);
            WriteToFile("Antras sąrašas (papildytas trečiu)", outputFile);
            Items.WriteToFile(items2, outputFile);

            IncreaseListPricesTenPercent(ref items1);
            IncreaseListPricesTenPercent(ref items2);
            IncreaseListPricesTenPercent(ref items3);

            WriteToFile("", outputFile);
            WriteToFile("---Nauji sąrašai:", outputFile);
            WriteToFile("", outputFile);
            WriteToFile("Pirmas sąrašas", outputFile);
            Items.WriteToFile(items1, outputFile);

            WriteToFile("", outputFile);
            WriteToFile("Antras sąrašas", outputFile);
            Items.WriteToFile(items3, outputFile);

            WriteToFile("", outputFile);
            WriteToFile("Trečias sąrašas", outputFile);
            Items.WriteToFile(items2, outputFile);
        }

        static void WriteToFile(string line, string output) {
            using(var writer = File.AppendText(output))
                writer.WriteLine(line);
        }

        static double Sum(List<Items> items) {
            double sum = 0;

            foreach(var item in items)
                sum += item.Sum();

            return sum;
        }

        static void IncreaseListPricesTenPercent(ref List<Items> list) {
            foreach(var item in list)
                item.IncreasePriceTenPercent();
        }
    }
}