using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plytos_Savarankiškas
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
        private double ilgis, aukštis;

        public Siena(double ilgis, double aukštis)
        {
            this.ilgis = ilgis;
            this.aukštis = aukštis;
        }

        public double ImtiIlgį() { return ilgis; }
        public double ImtiAukštį() { return aukštis; }
    }

    class Programa
    {
        static void Main(string[] args)
        {
            Siena s1, s2, s3, s4;

            s1 = new Siena(2.5, 5.4);
            s2 = new Siena(3.2, 3.7);
            s3 = new Siena(3, 6.2);
            s4 = new Siena(2.7, 4.7);

            /* 1-o tipo plyta*/
            Plyta p1;
            p1 = new Plyta(250, 120, 88);
            int k1;

            SpausdintiPlytą(p1);

            k1 = outSiena(s1, p1) + outSiena(s2, p1) + outSiena(s3, p1) + outSiena(s4, p1);
            Console.WriteLine("1-o tipo plytų reikia: {0,1:d}\n", k1);

            /* 2-o tipo plyta*/
            Plyta p2;
            p2 = new Plyta(200, 115, 71);
            int k2;

            SpausdintiPlytą(p2);

            k2 = inSiena(s1, p2) + inSiena(s2, p2) + inSiena(s3, p2) + inSiena(s4, p2);
            Console.WriteLine("2-o tipo plytų reikia: {0,1:d}\n", k2);





            /*---*/
            Console.WriteLine("Programa baigė darbą!");
        }

        static void SpausdintiPlytą(Plyta p)
        {
            Console.WriteLine("Plytos aukštis: {0,3:d} \nPlytos plotis: {1,4:d} \n" + "Plytos ilgis: {2,5:d}", p.ImtiAukštį(), p.ImtiPlotį(), p.ImtiIlgį());
        }

        static int outSiena(Siena s, Plyta p) {
            return (int)(s.ImtiIlgį() * 1000 / p.ImtiIlgį() *
                         s.ImtiAukštį() * 1000 / p.ImtiAukštį());
        }

        static int inSiena(Siena s, Plyta p) {
            return (int)(s.ImtiIlgį() * 1000 / p.ImtiIlgį() *
                        s.ImtiAukštį() * 1000 / p.ImtiAukštį());
        }

    }
}
