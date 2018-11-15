using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plytos
{
    class Plyta
    {
        private int ilgis, plotis, aukštis;

        public Plyta(int ilgis, int plotis, int aukštis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.aukštis = aukštis;
        }

        public int ImtiIlgį() { return ilgis; }
        public int ImtiPlotį() { return plotis; }
        public int ImtiAukštį() { return aukštis; }

    }

    class Programa
    {
        static void Main(string[] args)
        {
            double sienosIlgis = 12.0;
            double sienosPlotis = 0.23;
            double sienosAukštis = 3.0;


            /*Pirma plyta*/
            Plyta p1;
            p1 = new Plyta(250, 120, 88);
            int k1;

            k1 = VienaSiena(p1, sienosIlgis, sienosPlotis, sienosAukštis);

            SpausdintiPlytą(p1);
            Console.WriteLine("1-o tipo plytų reikia: {0,6:d}\n", 4 * k1);


            /*Antra plyta*/
            Plyta p2;
            p2 = new Plyta(240, 115, 71);
            int k2;

            k2 = VienaSiena(p2, sienosIlgis, sienosPlotis, sienosAukštis);

            SpausdintiPlytą(p2);
            Console.WriteLine("2-o tipo plytų reikia: {0,6:d}\n", 4 * k2);


            /*Trečia plyta*/
            Plyta p3;
            p3 = new Plyta(240, 115, 61);
            int k3;

            k3 = VienaSiena(p3, sienosIlgis, sienosPlotis, sienosAukštis);

            SpausdintiPlytą(p3);
            Console.WriteLine("1-o tipo plytų reikia: {0,6:d}\n", 4 * k3);

            /*---*/

            Console.WriteLine("Programa baigė darbą!");
        }

        static int VienaSiena(Plyta p, double sienosIlgis, double sienosPlotis, double sienosAukštis) {

            return (int)(sienosIlgis * 1000 / p.ImtiIlgį() *
                         sienosPlotis * 1000 / p.ImtiPlotį() *
                         sienosAukštis * 1000 / p.ImtiAukštį());

        }

        static int BokštoSiena(Plyta p, double bokštoSkersmuo, double bokštoPlotis, double bokštoAukštis) {

            return (int)(Math.PI * bokštoSkersmuo * 1000 / p.ImtiIlgį() *
                                   bokštoPlotis * 1000 / p.ImtiPlotį() *
                                   bokštoAukštis * 1000 / p.ImtiAukštį());

        }

        static void SpausdintiPlytą(Plyta p) {
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1,4:d} \n" + "Plytos ilgis: {2,5:d}\n", p.ImtiAukštį(), p.ImtiPlotį(), p.ImtiIlgį());
        }

    }
}
