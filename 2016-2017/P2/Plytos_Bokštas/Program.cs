using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plytos_Pilis
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

        public double ImtiIlgį() { return ilgis; }
        public double ImtiPlotį() { return plotis; }
        public double ImtiAukštį() { return aukštis; }
    }

    class Bokštas
    {
        private double skersmuo, plotis, aukštis;

        public Bokštas(double skersmuo, double plotis, double aukštis) {
            this.skersmuo = skersmuo;
            this.plotis = plotis;
            this.aukštis = aukštis;
        }

        public double imtiSkersmenį() { return skersmuo; }
        public double imtiPlotį() { return plotis; }
        public double imtiAukštį() { return aukštis; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Plyta p1;
            p1 = new Plyta(250, 120, 90);
            SpausdintiPlytą(p1);

            Siena s1, s2;

            s1 = new Siena(26.5, 0.7, 5.2);
            s2 = new Siena(50.5, 0.5, 5.2);
            Console.WriteLine("\n1-oji siena");
            Console.WriteLine("Sienos ilgis: {0,5:f1}\nSienos plotis: {1,4:f1}\nSienos aukštis: {2,3:f1}\n", s1.ImtiIlgį(), s1.ImtiPlotį(), s1.ImtiAukštį());

            Console.WriteLine("2-oji siena");
            Console.WriteLine("Sienos ilgis: {0,5:f1}\nSienos plotis: {1,4:f1}\nSienos aukštis: {2,3:f1}\n", s2.ImtiIlgį(), s2.ImtiPlotį(), s2.ImtiAukštį());

            Bokštas b1;
            b1 = new Bokštas(5.2, 0.5, 2.5);
            Console.WriteLine("Bokšto aukštis: {0,4:f1}\nBokšto skersmuo: {1,3:f1}\nBokšto storis: {2,5:f1}", b1.imtiAukštį(), b1.imtiSkersmenį(), b1.imtiPlotį());

            Console.WriteLine("\nSienoms plytų reikia: {0,1:d}", (SienosPlytos(s1, p1) + SienosPlytos(s2, p1)) * 2);
            Console.WriteLine("Bokštams plytų reikia: {0,1:d}", BokštoPlytos(b1, p1));
            Console.WriteLine("Iš viso plytų reikia: {0,1:d}", ((SienosPlytos(s1, p1) + SienosPlytos(s2, p1)) * 2) + BokštoPlytos(b1, p1));
        }

        static void SpausdintiPlytą(Plyta p)
        {
            Console.WriteLine("Plytos aukštis: {0,4:d}\nPlytos plotis: {1,5:d}\nPlytos ilgis: {2,6:d}", p.ImtiAukštį(), p.ImtiPlotį(), p.ImtiIlgį());
        }

        static int SienosPlytos(Siena s, Plyta p) {
            return (int)(s.ImtiIlgį() * 1000 / p.ImtiIlgį() *
                         s.ImtiPlotį() * 1000 / p.ImtiPlotį() *
                         s.ImtiAukštį() * 1000 / p.ImtiAukštį());
        }

        static int BokštoPlytos(Bokštas b, Plyta p) {
            return (int)(b.imtiSkersmenį() * Math.PI * 1000 / p.ImtiIlgį() *
                         b.imtiPlotį() * 1000 / p.ImtiPlotį() *
                         b.imtiAukštį() * 1000 / p.ImtiAukštį()) * 4;
        }
    }
}
