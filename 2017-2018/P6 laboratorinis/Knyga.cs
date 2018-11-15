using System;
using System.Collections.Generic;
using System.IO;

namespace Knygynai
{
    class Knyga
    {
        public struct Criteria
        {
            public static DateTime start;
            public static DateTime finish;
            public static double price;

            public static bool IsSuitable(Knyga knyga) {
                return start.CompareTo(knyga._releaseDate) <= 0 
                    && finish.CompareTo(knyga._releaseDate) >= 0 
                    && price >= knyga._price;
            }
        }

        private string _author;
        private string _name;
        private DateTime _releaseDate;
        private double _price;
        private int _soldCount;
        private int _leftCount;

        public Knyga(string author, string name, DateTime releaseDate, double price, int soldCount, int leftCount)
        {
            _author = author;
            _name = name;
            _releaseDate = releaseDate;
            _price = price;
            _soldCount = soldCount;
            _leftCount = leftCount;
        }

        public Knyga(string[] parts) {
            _author = parts[0];
            _name = parts[1];
            var releaseDateS = parts[2];
            var releaseDateParts = releaseDateS.Split('-');
            _releaseDate = new DateTime(
                int.Parse(releaseDateParts[0]),
                int.Parse(releaseDateParts[1]),
                int.Parse(releaseDateParts[2]));
            _price = double.Parse(parts[3]);
            _soldCount = int.Parse(parts[4]);
            _leftCount = int.Parse(parts[5]);
        }

        public override string ToString() {
            return String.Format("| {0,15} | {1,25} | {2} | {3,6:f2} | {4,8:d} | {5,4:d} |", _author, _name, _releaseDate.ToShortDateString(), _price, _soldCount, _leftCount);
        }

        public static bool operator >(Knyga lhs, Knyga rhs)
        {
            int s = String.Compare(lhs._name, rhs._name);

            if (s > 0)
                return true;
            if (s == 0)
                return lhs._soldCount < rhs._soldCount;
            return false;
        }

        public static bool operator <(Knyga lhs, Knyga rhs)
        {
            int s = String.Compare(lhs._name, rhs._name);

            if (s < 0)
                return true;
            if (s == 0)
                return lhs._soldCount > rhs._soldCount;
            return false;
        }

        public static bool operator ==(Knyga lhs, Knyga rhs) {
            return lhs._author == rhs._author
                && lhs._name == rhs._name
                && lhs._releaseDate == rhs._releaseDate
                && lhs._price == rhs._price;
        }

        public static bool operator !=(Knyga lhs, Knyga rhs)
        {
            return lhs._author != rhs._author
                || lhs._name != rhs._name
                || lhs._releaseDate != rhs._releaseDate
                || lhs._price != rhs._price;
        }

        public static Knyga operator +(Knyga lhs, Knyga rhs) {
            lhs._leftCount += rhs._leftCount;
            lhs._soldCount += rhs._soldCount;

            return lhs;
        }

        public static void Sort(List<Knyga> knygos)
        {
            for (int i = 0; i < knygos.Count - 1; i++) {
                int max_i = i;
                for (int j = i + 1; j < knygos.Count; j++) {
                    if (knygos[j] < knygos[max_i])
                        max_i = j;
                }

                var tmp = knygos[max_i];
                knygos[max_i] = knygos[i];
                knygos[i] = tmp;
            }
        }

        public static void RemoveByDate(List<Knyga> knygos, DateTime date) {
            for (int i = 0; i < knygos.Count; i++) {
                if (knygos[i]._releaseDate == date)
                    knygos.RemoveAt(i--);
            }
        }

        public static List<Knyga> Filter(List<Knyga> knygos) {
            List<Knyga> result = new List<Knyga>();

            foreach (var knyga in knygos) {
                if (Criteria.IsSuitable(knyga))
                    result.Add(knyga);
            }

            return result;
        }

        private static string ConstructInputFileName(int index, string inputFilesFormat) {
            return String.Format("{0}_{1:d}{2}",
                inputFilesFormat.Substring(0, 12),
                index,
                inputFilesFormat.Substring(12, 4));
        }

        public static void ReadFromFiles(out Dictionary<string, List<Knyga>> knygynai, string inputFilesFormat) {
            knygynai = new Dictionary<string, List<Knyga>>();

            try
            {
                for (int i = 0; i < 100; i++)
                {
                    string fileName = ConstructInputFileName(i, inputFilesFormat);

                    using (var reader = new StreamReader(fileName))
                    {
                        string bookstoreName = reader.ReadLine();
                        List<Knyga> knygos = new List<Knyga>();

                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            var parts = line.Split(';');
                            
                            knygos.Add(new Knyga(parts));
                        }

                        knygynai.Add(bookstoreName, knygos);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        public static void WriteKnygynaiToFiles(Dictionary<string, List<Knyga>> knygynai, StreamWriter writer, string header = "")
        {
            writer.WriteLine(header);
            foreach (var knygynas in knygynai)
            {
                writer.WriteLine(knygynas.Key);


                var knygos = knygynas.Value;

                if (knygos.Count != 0)
                {
                    writer.WriteLine("|-------------------------------------------------------------------------------------|");
                    writer.WriteLine("|    Autorius     |        Pavadinimas        |    Data    |  Kaina | Parduota | Liko |");
                    writer.WriteLine("|-------------------------------------------------------------------------------------|");

                    foreach (var knyga in knygynas.Value)
                    {
                        writer.WriteLine(knyga.ToString());
                    }
                    writer.WriteLine("|-------------------------------------------------------------------------------------|");
                }
                else
                    writer.WriteLine("!Knygynas tuščias!");

            }

        }
    }
}