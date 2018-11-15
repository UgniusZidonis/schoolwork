using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Turistai
{
	class Turistas
	{
		double money;

		public Turistas(double money) {
			this.money = money;
		}

		public double getMoney() { return money; }
	}

	class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = Encoding.UTF8;
			const int CFn = 100;
			const string CFin = "...\\...\\input.txt";

			Turistas[] T = new Turistas[CFn];
			int n;

			Skaityti(CFin, T, out n);

			double sum;
			double vidurkis;
			double bišlaidos;
			sum = Pinigai(T, n);
			Console.WriteLine(sum);
			vidurkis = Vidurkis(n, sum);
			bišlaidos = B_Išlaidos(sum);

			Console.WriteLine("Visi pinigai:           {0,10:d} eur ir {1,2:d} cent", (int)sum, (int) ((sum - (int) sum) * 100));
			Console.WriteLine("Turimų pinigų vidurkis: {0,10:d} eur ir {1,2:d} cent", (int)vidurkis, (int) ((vidurkis - (int) vidurkis) * 100));
			Console.WriteLine("Bendrų išlaidų pinigai: {0,10:d} eur ir {1,2:d} cent", (int)bišlaidos, (int) ((bišlaidos - (int) bišlaidos) * 100));


			/*---*/
			Console.WriteLine("\nPrograma baigė darbą!");
		}

		static void Skaityti(string fv, Turistas[] T, out int n)
		{
			double money;
			using (StreamReader reader = new StreamReader(fv))
			{
				string line;
				line = reader.ReadLine();
				n = int.Parse(line);
				string[] parts;
				for (int i = 0; i < n; i++)
				{
					line = reader.ReadLine();
					parts = line.Split(' ');
					int euros = int.Parse(parts[0]);
					int cents = int.Parse(parts[1]);
					money = euros + (double) cents / 100;
					T[i] = new Turistas(money);
				}
			}
		}

		static double Pinigai(Turistas[] T, int n) {
			double sum = 0;

			for (int i = 0; i < n; i++) {
				sum += T[i].getMoney();
			}
			return sum;
		}

		static double Vidurkis(int n, double sum) {
			return sum / n;
		}

		static double B_Išlaidos(double sum) {
			return sum / 4;
		}
	}
}
