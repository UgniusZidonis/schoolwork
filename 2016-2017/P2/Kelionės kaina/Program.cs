using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kelionės_kaina
{
    class Kelias
    {
        private string name;
        private double length, maxSpeed;

        public Kelias(string name, double length, double maxSpeed)
        {
            this.name = name;
            this.length = length;
            this.maxSpeed = maxSpeed;
        }

        public string getName() { return name; }
        public double getLength() { return length; }
        public double getMaxSpeed() { return maxSpeed; }
    }

    class Auto
    {
        private string name, kuras;
        private double sąnaudos;

        public Auto(string name, string kuras, double sąnaudos) {
            this.name = name;
            this.kuras = kuras;
            this.sąnaudos = sąnaudos;
        }

        public string getName() { return name; }
        public string getKuras() { return kuras; }
        public double getSąnaudos() { return sąnaudos; }
    }

    class Degalai
    {
        string Name;
        double Price;

        public Degalai(string Name, double Price) {
            this.Name = Name;
            this.Price = Price;
        }

        public string getName() { return Name; }
        public double getPrice() { return Price; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kelias[] keliai = new Kelias[3];
            keliai[0] = new Kelias("Kaunas - Vilnius", 105, 110);
            keliai[1] = new Kelias("Kaunas - Alytus", 65.6, 90);
            keliai[2] = new Kelias("Vilnius - Panevėžys", 136, 120);

            Auto[] mašinos = new Auto[2];
            mašinos[0] = new Auto("Opel Meriva", "benzinas", 7.5);
            mašinos[1] = new Auto("Volkswagen Golf", "dyzelinas", 6.3);

            Degalai[] degalai = new Degalai[2];
            Console.Write("Įveskite benzino kainą: ");
            degalai[0] = new Degalai("benzinas", double.Parse(Console.ReadLine()));
            Console.Write("Įveskite dyzelino kainą: ");
            degalai[1] = new Degalai("dyzelinas", double.Parse(Console.ReadLine()));
            Console.Clear();
            
            

            

            Console.WriteLine("Kelionė {0} iš Alytaus į Panevėžį kainuos {1,1:f2}EUR", mašinos[0].getName(), skaičiuotiKelionę(mašinos[0].getSąnaudos(), keliai, degalai[0].getPrice()));
            Console.WriteLine("Kelionė {0} iš Alytaus į Panevėžį kainuos {1,1:f2}EUR", mašinos[1].getName(), skaičiuotiKelionę(mašinos[1].getSąnaudos(), keliai, degalai[1].getPrice()));
        }

        static double skaičiuotiKelionę(double sąnaudos, Kelias[] k, double kuras) {
            double distance = k[1].getLength() + k[0].getLength() + k[2].getLength();
            return distance / 100 * sąnaudos * kuras;
        }
    }
}
