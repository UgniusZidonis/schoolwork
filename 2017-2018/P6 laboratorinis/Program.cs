using System;
using System.Collections.Generic;
using System.IO;

namespace Knygynai
{
    class Program
    {
        const string inputFiles = "../../input1.txt";
        const string inputFile2 = "../../input2.txt";
        const string outputFile = "../../output.txt";

        static DateTime ConvertStringToDateTime(string input)
        {
            var parts = input.Split('-');
            if (parts.Length != 3)
                throw new Exception("Neteisingu formatu pateikta data");

            int year = int.Parse(parts[0]);
            int month = int.Parse(parts[1]);
            int day = int.Parse(parts[2]);

            return new DateTime(year, month, day);
        }

        static void ReadFromFile(string inputFile)
        {
            using (StreamReader reader = new StreamReader(inputFile))
            {
                var parts = reader.ReadLine().Split(';');

                Knyga.Criteria.start = ConvertStringToDateTime(parts[0]);
                Knyga.Criteria.finish = ConvertStringToDateTime(parts[1]);
                Knyga.Criteria.price = double.Parse(parts[2]);
            }
        }

        static List<Knyga> MergeKnygynai(Dictionary<string, List<Knyga>> knygynai) {
            List<Knyga> result = new List<Knyga>();
            foreach (var knygynas in knygynai) {
                foreach (var knyga in knygynas.Value)
                {
                    bool isInserted = false;
                    for (int i = 0; i < result.Count; i++)
                    {
                        if (knyga < result[i])
                        {
                            result.Insert(i, knyga);
                            isInserted = true;
                            break;
                        }
                        if (knyga == result[i])
                        {
                            result[i] += knyga;
                            isInserted = true;
                            break;
                        }
                    }

                    if (!isInserted)
                        result.Add(knyga);
                }
            }

            return result;
        }

        static void WriteToFile(List<Knyga> knygos, StreamWriter writer, string name = "")
        {
            writer.WriteLine(name);

            if (knygos.Count != 0)
            {
                writer.WriteLine("|-------------------------------------------------------------------------------------|");
                writer.WriteLine("|    Autorius     |        Pavadinimas        |    Data    |  Kaina | Parduota | Liko |");
                writer.WriteLine("|-------------------------------------------------------------------------------------|");

                foreach (var knyga in knygos)
                {
                    writer.WriteLine(knyga.ToString());
                }
                writer.WriteLine("|-------------------------------------------------------------------------------------|");
            }
            else
                writer.WriteLine("!Knygų masyvas tuščias!");

        }

        static void Main(string[] args)
        {
            if (File.Exists(outputFile))
                File.Delete(outputFile);
            var writer = File.AppendText(outputFile);

            Dictionary<string, List<Knyga>> knygynai;
            Knyga.ReadFromFiles(out knygynai, inputFiles);
            ReadFromFile(inputFile2);
            Knyga.WriteKnygynaiToFiles(knygynai, writer, "Pradiniai duomenys");
            writer.WriteLine("---");

            List<Knyga> filtered = Knyga.Filter(MergeKnygynai(knygynai));
            Knyga.Sort(filtered);
            WriteToFile(filtered, writer, "Filtruota ir rūšiuota");
            writer.WriteLine("---");

            Console.Write("Įveskite datą (yyyy-mm-dd): ");
            try
            {
                var date = ConvertStringToDateTime(Console.ReadLine());
                Knyga.RemoveByDate(filtered, date);
                WriteToFile(filtered, writer, String.Format("Atrinkti ({0})", date.ToShortDateString()));
            }
            catch (Exception ex) {
                Console.WriteLine("Nepavyko sudaryti sąrašo, nes: " + ex.Message);
            }

            writer.Close();
        }

    }
}