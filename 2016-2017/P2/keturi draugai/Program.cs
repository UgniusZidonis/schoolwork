using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keturi_draugai
{
    class Draugas
    {
        private string Name;
        private int weight, height;

        public Draugas(string Name, int height, int weight) {
            this.Name = Name;
            this.height = height;
            this.weight = weight;
        }

        public string getName() { return Name; }
        public int getWeight() { return weight; }
        public int getHeight() { return height; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            Draugas[] draugai = new Draugas[4];
            draugai[0] = new Draugas("Jonaitis", 180, 80);
            draugai[1] = new Draugas("Petraitis", 180, 84);
            draugai[2] = new Draugas("Rimaitis", 182, 90);
            draugai[3] = new Draugas("Ritaitis", 199, 100);

            Console.WriteLine("Vidutinis draugų svoris: {0,1:d}\n", avWeight(draugai));
            spausdintiŽemiausius(findShortest(draugai));

            /* --- */
            Console.WriteLine("\nPrograma baigė darbą!");
        }

        static int avWeight(Draugas[] d) {
            int sum = 0;

            for (int i = 0; i < d.Length; i++) {
                sum += d[i].getWeight();
            }

            return sum / d.Length;
        }

        static Draugas[] findShortest(Draugas[] d) {
            Draugas shortest = d[0];
            int sCount = 0;
            int arrayLength = 0;
            for (int i = 0; i < d.Length; i++) {
                if (shortest.getHeight() > d[i].getHeight())
                    shortest = d[i];
            }

            for (int i = 0; i < d.Length; i++) {
                if (shortest.getHeight() == d[i].getHeight())
                {
                    arrayLength++;
                }
            }

            Draugas[] s = new Draugas[arrayLength];

            for (int i = 0; i < d.Length; i++) {
                if (shortest.getHeight() == d[i].getHeight()) {
                    s[sCount] = d[i];
                    sCount++;
                }
            }

            return s;
        }
        
        static void spausdintiŽemiausius(Draugas[] s) {
            Console.WriteLine("{0,1:d} žemiausi draugai:", s.Length);
            for (int i = 0; i < s.Length; i++) {
                Console.WriteLine(s[i].getName());
            }
        }
    }
}
