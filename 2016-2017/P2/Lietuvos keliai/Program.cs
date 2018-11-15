using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lietuvos_keliai
{
    class Kelias
    {
        private string Name;
        private double length, maxSpeed;

        public Kelias(string Name, double length, double maxSpeed)
        {
            this.Name = Name;
            this.length = length;
            this.maxSpeed = maxSpeed;
        }

        public string getName() { return Name; }
        public double getLength() { return length; }
        public double getMaxSpeed() { return maxSpeed; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Kelias KauVil, KauAly, VilPan;
            Kelias[] keliai = new Kelias[5];
            int keliaiCount = 3;

            keliai[0] = new Kelias("Kaunas - Vilnius", 105, 110);
            keliai[1] = new Kelias("Kaunas - Alytus", 65.6, 90);
            keliai[2] = new Kelias("Vilnius - Panevėžys", 136, 120);

            //time = calcTime(KauAly) + calcTime(KauVil) + calcTime(VilPan);


            Console.WriteLine("Iš Alytaus į Panevėžį nuvažiuosime per {0,1:f2} val.", calcTime(keliai, keliaiCount));
            Console.WriteLine("Ilgiausias kelias: {0}", findLongest(keliaiCount, keliai).getName());

            /* --- */
            Console.WriteLine("\nPrograma baigė darbą!");
        }

        static double calcTime(Kelias[] keliai, int kelCount)
        {
            double time = 0;

            for (int i = 0; i < kelCount; i++)
            {
                time += keliai[i].getLength() / keliai[i].getMaxSpeed();
            }

            return time;
        }
        static Kelias findLongest(int count, Kelias[] array)
        {
            Kelias longest = array[0];

            for (int i = 1; i < count; i++)
            {
                if (longest.getLength() < array[i].getLength())
                    longest = array[i];
            }

            return longest;
        }
    }
}
