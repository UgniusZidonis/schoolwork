using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lietuvos_keliai
{
    class Kelias {
        private string name;
        private int distance;
        private int speed_limit;

        public Kelias(string name, int distance, int speed_limit) {
            this.name = name;
            this.distance = distance;
            this.speed_limit = speed_limit;
        }

        public string getName() { return name; }
        public int getDist() { return distance; }
        public int getSpeed() { return speed_limit; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            const int CFn = 100;
            const string CFin = "...\\...\\input.txt";
            const string CFout = "...\\...\\output.txt";

            Kelias[] keliai = new Kelias[CFn];
            int n;

            Read(CFin, keliai, out n);
            if (File.Exists(CFout))
                File.Delete(CFout);
            Write(CFout, keliai, n);

        }

        static void Read(string fv, Kelias[] K, out int n) {
            string line;

            using (StreamReader reader = new StreamReader(fv)) {
                line = reader.ReadLine();
                n = int.Parse(line);

                string[] parts;

                for (int i = 0; i < n; i++) {
                    line = reader.ReadLine();
                    parts = line.Split(';');

                    string name = parts[0];
                    int distance = int.Parse(parts[1]);
                    int speed_limit = int.Parse(parts[2]);

                    K[i] = new Kelias(name, distance, speed_limit);
                }
            }
        }

        static void Write(string fv, Kelias[] K, int n) {
            const string viršus =
                "|-----------------------------------------------|\r\n" +
                "|                 |         |                   |\r\n" +
                "|   Pavadinimas   |  Ilgis  |  Greičio limitas  |\r\n" +
                "|                 |         |                   |\r\n" +
                "|-----------------------------------------------|";

            using (var fr = File.AppendText(fv)) {
                fr.WriteLine(viršus);

                for (int i = 0; i < n; i++) {
                    fr.WriteLine("|    {0,-9}    |   {1,-5:d} |        {2,-7:d}    |", K[i].getName(), K[i].getDist(), K[i].getSpeed());
                }
                fr.WriteLine("-------------------------------------------------");
            }
        }
    }
}
