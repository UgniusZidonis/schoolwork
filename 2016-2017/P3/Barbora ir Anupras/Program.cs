using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Barbora_ir_Anupras
{
    class Žmogus
	{
		private string name;
        private double[] money;
        private double[] exchange;
        private int count;

		public Žmogus(string name, double[] money, double[] exchange, int count){
			this.name = name;
			this.money = money;
			this.exchange = exchange;
            this.count = count;
		}

		public string getName() { return name; }
		public double getMoney(int i) { return money[i]; }
		public double getExch(int i) { return exchange[i]; }
        public int getCount() { return count; }
	}

	class Program
	{
        static int CFn = 100;
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;

			const string CFa_in = "...\\...\\A.txt";
			const string CFb_in = "...\\...\\B.txt";

			Žmogus Anupras;
            double[] mA = new double[CFn];
            double[] eA = new double[CFn];
            int nA;
            Read(CFa_in, mA, eA, out nA);
            Anupras = new Žmogus("Anupras", mA, eA, nA);

			Žmogus Barbora;
            double[] mB = new double[CFn];
            double[] eB = new double[CFn];
            int nB;
            Read(CFb_in, mB, eB, out nB);
            Barbora = new Žmogus("Barbora", mB, eB, nB);

			WriteSeperateMoney(Anupras, CountMoney(Anupras));
			WriteSeperateMoney(Barbora, CountMoney(Barbora));
			WriteCombinedMoney(CountMoney(Anupras), CountMoney(Barbora));
		}

		static void Read(string fv, double[] money, double[] exch, out int n){
			using (StreamReader reader = new StreamReader(fv)){
				string line = reader.ReadLine();
                n = int.Parse(line);
                string[] parts;
                for (int i = 0; i < n; i++) {
                    line = reader.ReadLine();
                    parts = line.Split(' ');
                    int full = int.Parse(parts[0]);
                    int cent = int.Parse(parts[1]);
                    exch[i] = double.Parse(parts[2]);
                    money[i] = (double)full + (double)cent / 100;
                }
			}
		}

        static double CountMoney(Žmogus ž) {
            double money = 0;

            for (int i = 0; i < ž.getCount(); i++) {
                money += ž.getMoney(i) * ž.getExch(i);
            }

            return money;
        }

		static void WriteSeperateMoney(Žmogus ž, double money){
            Console.WriteLine("{0} turi {1,3:d}EUR ir {2,2:d}ct", ž.getName(), (int)money, (int)((money - (int)money) * 100));
		}

		static void WriteCombinedMoney(double money1, double money2){
			double money = money1 + money2;

			Console.WriteLine("Bendra suma: {0,1:d}EUR ir {1,2:d}ct bendrai", (int) money, (int)((money - (int)money) * 100));
		}
	}
}
