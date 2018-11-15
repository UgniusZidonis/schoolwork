using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P3_laboratorinis
{
    class Rings : Ring {
        private double _weight;
        private double _price;

        public Rings(string manufacturer = "", string name = "", string metal = "", double purity = 0, string distinction = "", int size = 0, double weight = 0, double price = 0)
            : base(manufacturer, name, metal, purity, distinction, size) {
            _weight = weight;
            _price = price;
        }

        public double GetWeight() { return _weight; }
        public double GetPrice() { return _price; }

        public override string ToString() {
            return string.Format("| {0,12} | {1,8} | {2,7} | {3,6:f1} | {4,15} | {5,4} | {6,6} | {7,7:f2} |", _manufacturer, _name, _metal, _purity, _distinction, _size, _weight, _price);
        }

        public static bool operator <=(Rings lhs, Rings rhs) {
            int m = string.Compare(lhs._manufacturer, rhs._manufacturer);
            if(m < 0)
                return true;
            if(m == 0)
                if(lhs._price >= rhs._price)
                    return true;
            return false;
        }

        public static bool operator >=(Rings lhs, Rings rhs) {
            int m = string.Compare(lhs._manufacturer, rhs._manufacturer);
            if(m < 0)
                return false;
            if(m == 0)
                if(lhs._price >= rhs._price)
                    return false;
            return true;
        }

        static public void Sort(ref List<Rings> source) {
            for(int i = 0; i < source.Count - 1; i++) {
                Rings elem = source[i];
                int elem_i = i;
                for(int j = i + 1; j < source.Count; j++) {
                    if(elem >= source[j]) {
                        elem = source[j];
                        elem_i = j;
                    }
                }
                var tmp = source[i];
                source[i] = elem;
                source[elem_i] = tmp;
            }
        }

        static public List<Rings> FindSpecifiedMetalRings(string metal, List<Rings> source, int count = 2) {
            if(source.Count < count)
                return new List<Rings>();

            List<Rings> result = new List<Rings>();

            for(int elem = 0; elem < count; elem++) {
                Rings maxElem = new Rings();
                foreach(var ring in source) {
                    if(ring.GetMetal() == metal && maxElem.GetPrice() < ring.GetPrice() && !result.Contains(ring))
                        maxElem = ring;
                }
                if(maxElem.GetName() != "") {
                    result.Add(maxElem);
                }
                if(result.Count == count)
                    return result;
            }
            return new List<Rings>();
        }

        static private int RingCount(string metal, List<Rings> source) {
            int count = 0;

            foreach(var ring in source)
                if(ring.GetMetal() == metal)
                    count++;

            return count;
        }

        static public string WhichIsMore(List<Rings> source) {
            int silverCount = RingCount("Silver", source);
            int goldCount = RingCount("Gold", source);

            if(silverCount > goldCount)
                return "silver";
            if(silverCount < goldCount)
                return "gold";
            return "equal";
        }

        static public List<string> RingCountsAndManufacturers(List<Rings> source){
            List<string> manufacturers = new List<string>();

            foreach(var ring in source) {
                if(!manufacturers.Contains(ring._manufacturer))
                    manufacturers.Add(ring._manufacturer);
            }

            int[] counts = new int[manufacturers.Count];

            foreach(var ring in source) {
                for(int i = 0; i < manufacturers.Count; i++) {
                    if(manufacturers[i] == ring._manufacturer)
                        counts[i]++;
                }
            }

            for(int i = 0; i < manufacturers.Count; i++)
                manufacturers[i] = $"{manufacturers[i], 10} {counts[i], 2}";

            return manufacturers;
        }

        static public List<Rings> GetSpecifiedMetalAndSizeRings(string metal, double size, List<Rings> source) {
            List<Rings> result = new List<Rings>();

            foreach(var ring in source) {
                if(ring.GetMetal() == metal && ring.GetSize() == size)
                    result.Add(ring);
            }

            return result;
        }

        static public List<Rings> ReadFromFile(string inputFile) {
            List<Rings> result = new List<Rings>();
            using(StreamReader reader = new StreamReader(inputFile, Encoding.GetEncoding(1257))) {
                string line;

                while((line = reader.ReadLine()) != null) {
                    var parts = line.Split(new char[]{ ' ', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    string manufacturer = parts[0];
                    string name = parts[1];
                    string metal = parts[2];
                    double purity = double.Parse(parts[3]);
                    string distinction = parts[4];
                    int size = int.Parse(parts[5]);
                    double weight = double.Parse(parts[6]);
                    double price = double.Parse(parts[7]);

                    result.Add(new Rings(manufacturer, name, metal, purity, distinction, size, weight, price));
                }
            }

            return result;
        }

        static public void WriteToFile(List<Rings> source, string outputFile) {
            using(var writer = File.AppendText(outputFile)) {
                if(source.Count == 0) {
                    writer.WriteLine("!Sąrašas tuščias!");
                    return;
                }

                string header =
                    "|----------------------------------------------------------------------------------------|\r\n" +
                    "| Manufacturer |   Name   |  Metal  | Purity |   Distinction   | Size | Weight |  Price  |\r\n" +
                    "|----------------------------------------------------------------------------------------|";

                writer.WriteLine(header);

                foreach(var ring in source)
                    writer.WriteLine(ring.ToString());

                writer.WriteLine("|----------------------------------------------------------------------------------------|");
            }
        }
    }
}