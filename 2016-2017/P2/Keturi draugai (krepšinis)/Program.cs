using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keturi_draugai__krepšinis_
{
    class Draugas
    {
        private string Name;
        private double Height, Weight;
        private string position;

        public Draugas(string Name, double Height, double Weight) {
            this.Name = Name;
            this.Height = Height;
            this.Weight = Weight;
        }

        public string getName() { return Name; }
        public double getHeight() { return Height; }
        public double getWeight() { return Weight; }
        public string getPos() { return position; }

        public void setPos(string position) { this.position = position; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Draugas[] draugai = new Draugas[4];
            draugai[0] = new Draugas("Jonaitis", 180, 80);
            draugai[1] = new Draugas("Petraitis", 180, 84);
            draugai[2] = new Draugas("Rimaitis", 180, 90);
            draugai[3] = new Draugas("Ritaitis", 190, 100);

            nustatytiPoziciją(draugai);
            spausdintiPozicijas(draugai);

            /*---*/
            Console.WriteLine("Programa baigė darbą!");
        }

        static void nustatytiPoziciją(Draugas[] d) {
            int interval_start_gyn = 169;
            int interval_end_gyn = 195;
            int interval_start_puol = 196;
            int interval_end_puol = 220;

            for (int i = 0; i < d.Length; i++)
            {
                int height = (int)d[i].getHeight();

                if (height >= interval_start_gyn && height <= interval_end_gyn)
                    d[i].setPos("gynėjas");
                else if (height >= interval_start_puol && height <= interval_end_puol)
                    d[i].setPos("puolėjas");
                else
                    d[i].setPos("neapibrėžta");
            }
        }

        static void spausdintiPozicijas(Draugas[] d) {
            for (int i = 0; i < d.Length; i++) {
                Console.WriteLine("Draugas {0} gali žaisti kaip: {1}", d[i].getName(), d[i].getPos());
            }
        }
    }
}
