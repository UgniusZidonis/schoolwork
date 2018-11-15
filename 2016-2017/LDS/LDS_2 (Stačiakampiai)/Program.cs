using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LDS_2__Stačiakampiai_
{
    class Stačiakampis
    {
        public int length { get; set; }
        public int width { get; set; }

        public Stačiakampis(int length, int width) {
            this.length = length;
            this.width = width;
        }
    }
    class Program
    {
        const string CFin = "../../input.txt";
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(CFin);
            Stačiakampis[][] parts = new Stačiakampis[lines.Length][];
            AssignArrays(ref parts, lines);
            Stačiakampis[] fullBlocks = new Stačiakampis[lines.Length];
            CountFullBlocksDimensions(ref fullBlocks, parts);
            WriteDimensions(fullBlocks);
        }
        static Stačiakampis[] ConvertToArray(string line) {
            string[] parts = line.Split(' ');
            Stačiakampis[] array = new Stačiakampis[4];

            for (int i = 0; i < array.Length; i++) {
                Stačiakampis obj = new Stačiakampis(int.Parse(parts[i * 2]), int.Parse(parts[i * 1 + 1]));
                array[i] = obj;
            }

            return array;
        }
        static void AssignArrays(ref Stačiakampis[][] parts, string[] lines) {
            for (int i = 0; i < lines.Length; i++) {
                parts[i] = ConvertToArray(lines[i]);
            }
        }
        static int Case(Stačiakampis[] parts) {
            if (parts[0].length + parts[1].length == parts[2].length + parts[3].length)
                return 1;
            else if (parts[0].length + parts[2].length == parts[1].length + parts[3].length)
                return 2;
            else if (parts[0].length + parts[3].length == parts[1].length + parts[2].length)
                return 3;
            else
                return -1;
        }
        static int Length(Stačiakampis[] parts) {
            int output = 0;
            switch (Case(parts)) {
                case 1:
                    output = parts[0].length + parts[1].length;
                    break;
                case 2:
                    output = parts[0].length + parts[2].length;
                    break;
                case 3:
                    output = parts[0].length + parts[3].length;
                    break;
                case -1:
                    output = -1;
                    break;
            }

            return output;
        }
        static int Width(Stačiakampis[] parts) {
            int output = 0;
            switch (Case(parts)) {
                case 1:
                    output = parts[0].width + parts[1].width;
                    break;
                case 2:
                    output = parts[0].width + parts[2].width;
                    break;
                case 3:
                    output = parts[0].width + parts[3].width;
                    break;
                case -1:
                    output = -1;
                    break;
            }

            return output;
        }
        static void CountFullBlocksDimensions(ref Stačiakampis[] fullBlocks, Stačiakampis[][] parts) {
            for (int i = 0; i < parts.Length; i++)
                fullBlocks[i] = new Stačiakampis(Length(parts[i]), Width(parts[i]));
        }
        static void WriteDimensions(Stačiakampis[] results) {
            for (int i = 0; i < results.Length; i++)
                Console.WriteLine("{0} {1}", results[i].length, results[i].width);
        }
    }
}
