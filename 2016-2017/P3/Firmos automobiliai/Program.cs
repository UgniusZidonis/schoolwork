using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Firmos_automobiliai
{
    class Auto
    {
        private string name;
        private string fuel;
        private double fcons;

        public Auto(string name, string fuel_type, double fuel_consumption)
        {
            this.name = name;
            this.fuel = fuel_type;
            this.fcons = fuel_consumption;
        }

        public string getName() { return name; }
        public string getFuel() { return fuel; }
        public double getFcons() { return fcons; }
    }

    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            const string CFin = "...\\...\\input.txt";
            const string CFout = "...\\...\\output.txt";

            Auto[] A = new Auto[100];
            int n;

            Read(CFin, A, out n);
            if (File.Exists(CFout))
                File.Delete(CFout);
            Write(CFout, A, n);


        }

        static void Read(string fv, Auto[] A, out int n) {
            string line;

            using (StreamReader reader = new StreamReader(fv)) {
                line = reader.ReadLine();
                n = int.Parse(line);
                string[] parts;

                for (int i = 0; i < n; i++) {
                    line = reader.ReadLine();
                    parts = line.Split(';');

                    string name = parts[0];
                    string fuel = parts[1];
                    double fcons = double.Parse(parts[2]);

                    A[i] = new Auto(name, fuel, fcons);
                }
            }
        }

        static void Write(string fv, Auto[] A, int n)
        {

            const string viršus =
                "|-------------------|------------|--------------------|\r\n" +
                "|                   |            |                    |\r\n" +
                "|    Pavadinimas    |   Degalai  | Sąnaudos (l/100 km)|\r\n" +
                "|                   |            |                    |\r\n" +
                "|-----------------------------------------------------|";
            using (var fr = File.AppendText(fv))
            {
                fr.WriteLine("Automobilių kiekis: {0,1:d}", n);
                fr.WriteLine("Automobilių sąrašas:");
                fr.WriteLine(viršus);

                for (int i = 0; i < n; i++)
                {
                    fr.WriteLine("|{0}. {1,-15} | {2,-10} |        {3,-11:f2} |", i + 1, A[i].getName(), A[i].getFuel(), A[i].getFcons());
                }
                fr.WriteLine("-------------------------------------------------------");
            }
        }
    }
}
