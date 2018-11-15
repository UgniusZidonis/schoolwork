using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Firmos_automobilių_degalų_sąnaudos
{
    class Auto {
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

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            const int CFn = 100;
            const string CFin = "...\\...\\input.txt";
            const string CFout = "...\\...\\output.txt";

            Auto[] A = new Auto[CFn];
            int n;

            Read(CFin, A, out n);
            if (File.Exists(CFout))
                File.Delete(CFout);
            Write(CFout, A, n);
            WriteAverage(CFout, Average(A, n));
            WriteDieselCount(CFout, FuelTypeCount(A, n, "dyzelinas"));
            WritePetrolAverage(CFout, FuelAverage(A, n, "benzinas"));



            /*---*/
            Console.WriteLine("\nPrograma baigė darbą!");

        }

        static void Read(string fv, Auto[] A, out int n) {
            string line;

            using (StreamReader reader = new StreamReader(fv))
            {
                line = reader.ReadLine();
                n = int.Parse(line);
                string[] parts;

                for (int i = 0; i < n; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');

                    string name = parts[0];
                    string fuel = parts[1];
                    double fcons = double.Parse(parts[2]);

                    A[i] = new Auto(name, fuel, fcons);
                }
            }
        }

        static void Write(string fv, Auto[] A, int n) {
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

        static double Average(Auto[] A, int n) {
            double sum = 0;

            for (int i = 0; i < n; i++) {
                sum += A[i].getFcons();
            }

            return sum / n;
        }

        static void WriteAverage(string fv, double average) {
            using (var fr = File.AppendText(fv)) {
                fr.WriteLine("Vidutinės degalų sąnaudos: {0,1:f2} litro/100km", average);
            }
        }

        static int FuelTypeCount(Auto[] A, int n, string fuel_type) {
            int count = 0;

            for (int i = 0; i < n; i++) {
                if (A[i].getFuel() == fuel_type)
                    count++;
            }

            return count;
        }

        static void WriteDieselCount(string fv, int DieselCount) {
            using (var fr = File.AppendText(fv)) {
                fr.WriteLine("Dyzelinių automobilių yra: {0,1:d}", DieselCount);
            }
        }

        static double FuelAverage(Auto[] A, int n, string fuel) {
            double sum = 0;
            int count = 0;

            for (int i = 0; i < n; i++) {
                if (A[i].getFuel() == fuel) {
                    sum += A[i].getFcons();
                    count++;
                }
            }

            if (count > 0)
                return sum / count;
            else
                return -1;
        }

        static void WritePetrolAverage(string fv, double PetrolAverage) {
            using (var fr = File.AppendText(fv))
            {
                if (PetrolAverage == -1)
                    fr.WriteLine("Benzininių automobilių nėra");
                else
                    fr.WriteLine("Vidutiniškai vienas benzininis automobilis sunaudoja: {0,1:f2} litro/100km", PetrolAverage);
            }
        }
    }
}
