using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dvi_klasės
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

    class Siena
    {
        private double ilgis, plotis, aukštis;

        public Siena(double ilgis, double plotis, double aukštis)
        {
            this.ilgis = ilgis;
            this.plotis = plotis;
            this.aukštis = aukštis;
        }

        public double imtiIlgį() { return ilgis; }
        public double imtiPlotį() { return plotis; }
        public double imtiAukštį() { return aukštis; }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            Siena s1;
            s1 = new Siena(12.0, 0.23, 3.0);

            /* 1-o tipo plyta*/
            Plyta p1;
            p1 = new Plyta(250, 120, 88);

            Console.WriteLine("1-o tipo plytos");
            SpausdintiPlytą(p1);

            /* 2-o tipo plyta*/
            Plyta p2;
            p2 = new Plyta(240, 115, 71);
            Console.WriteLine("2-o tipo plytos");
            SpausdintiPlytą(p2);

            /* 3-o tipo plyta*/
            Plyta p3;
            p3 = new Plyta(240, 115, 61);
            Console.WriteLine("3-o tipo plytos");
            SpausdintiPlytą(p3);

            Console.WriteLine("Sienos aukštis:\t {0,6:f2}\nSienos plotis:\t {1,6:f2}\nSienos ilgis:\t {2,6:f2}", s1.imtiAukštį(), s1.imtiPlotį(), s1.imtiIlgį());
            Console.WriteLine("\n1-o tipo plytų reikia: {0,6:d}", (4 * ReikiaPlytų(p1, s1)));
            Console.WriteLine("2-o tipo plytų reikia: {0,6:d}", (4 * ReikiaPlytų(p2, s1)));
            Console.WriteLine("3-o tipo plytų reikia: {0,6:d}", (4 * ReikiaPlytų(p3, s1)));



            /*---*/
            Console.WriteLine("\nPrograma baigė darbą!");
        }

        static int ReikiaPlytų(Plyta p, Siena s)
        {

            return (int)(s.imtiIlgį() * 1000 / p.ImtiIlgį() *
                         s.imtiPlotį() * 1000 / p.ImtiPlotį() *
                         s.imtiAukštį() * 1000 / p.ImtiAukštį());

        }

        static int BokštoSiena(Plyta p, double bokštoSkersmuo, double bokštoPlotis, double bokštoAukštis)
        {

            return (int)(Math.PI * bokštoSkersmuo * 1000 / p.ImtiIlgį() *
                                   bokštoPlotis * 1000 / p.ImtiPlotį() *
                                   bokštoAukštis * 1000 / p.ImtiAukštį());

        }

        static void SpausdintiPlytą(Plyta p)
        {
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1,4:d} \n" + "Plytos ilgis: {2,5:d}\n", p.ImtiAukštį(), p.ImtiPlotį(), p.ImtiIlgį());
        }

    }
}
