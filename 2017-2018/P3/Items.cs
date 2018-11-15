using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace P3
{
    class Items : Item
    {
        int _amount;

        public Items() : base() {
            _amount = 0;
        }

        public Items(int amount = 0) : base() {
            _amount = amount;
        }

        public Items(string name = "-", string type = "-", double price = 0, int amount = 0) : base(name, type, price) {
            _name = name;
            _type = type;
            _price = price;
            _amount = amount;
        }

        public override string ToString() {
            return string.Format("| {0,12} | {1,12} | {2, 5:f2} | {3, 5:d}  |", _name, _type, _price, _amount);
        }

        static public void Sort(ref List<Items> items) {
            for(int i = 0; i < items.Count - 1; i++) {
                int min = i;
                for(int j = i + 1; j < items.Count; j++) {
                    if(items[min].CompareTo(items[j]) > 0) {
                        min = j;
                    }
                }
                var tmp = items[i];
                items[i] = items[min];
                items[min] = tmp;
            }
        }

        static public void Insert(ref List<Items> target, Items item) {
            for(int i = 0; i < target.Count; i++) {
                if(item.CompareTo(target[i]) < 0) {
                    target.Insert(i, item);
                    return;
                }
                if(i == target.Count - 1) {
                    target.Insert(i + 1, item);
                    return;
                }
            }
        }

        static public void InsertList(ref List<Items> target, List<Items> list, string removeType = "") {
            foreach(var item in list)
                if (item._type != removeType)
                    Insert(ref target, item);
        }

        static public double AmountAverage(List<Items> items) {
            double sum = 0.0;

            foreach(Items item in items)
                sum += item._amount;

            return sum / (double) items.Count;
        }

        public override double Sum() { return _price * _amount; }

        public override void IncreasePriceTenPercent() { _price *= 1.1; }

        static void IncreaseListPricesByTenPercent(ref List<Items> items) {
            foreach(var item in items)
                item.IncreasePriceTenPercent();
        }

        static public List<Items> ReadFromFile(string input) {
            List<Items> result = new List<Items>();

            using(StreamReader reader = new StreamReader(input)) {
                string line;
                while((line = reader.ReadLine()) != null) {
                    var parts = line.Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    string name = parts[0];
                    string type = parts[1];
                    double price = double.Parse(parts[2]);
                    int amount;
                    if(parts.Length == 4) {
                        amount = int.Parse(parts[3]);
                        result.Add(new Items(name, type, price, amount));
                    }
                    else
                        result.Add(new Items(name, type, price));
                }
            }

            return result;
        }

        static public void WriteToFile(List<Items> items, string output) {
            using(var writer = File.AppendText(output)) {
                writer.WriteLine("------------------------------------------------");
                writer.WriteLine("|     Name     |     Type     | Price | Amount |");
                writer.WriteLine("------------------------------------------------");

                foreach(var item in items)
                    writer.WriteLine(item.ToString());

                writer.WriteLine("\\*--------------------------------------------*/");
            }
        }

        static public void RemoveSpecifiedTypeItems(ref List<Items> items, string type) {
            for(int i = 0; i < items.Count; i++)
                if(items[i]._type == type) {
                    items.Remove(items[i]);
                    i--;
                }
        }
    }
}