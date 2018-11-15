using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labdara__U1_11_
{
    class Shoe {
        public string type { get; }
        public string season { get; }
        public string color { get; }
        public string condition { get; }
        public int size { get; }

        public override string ToString() {
            return String.Format("{0,10}   {1,12}      {4,2:d}   {3,11}    {2}", type, season, color, condition, size);
        }

        public Shoe(string type, string season, int size, string color, string condition) {
            this.type = type;
            this.season = season;
            this.size = size;
            this.color = color;
            this.condition = condition;
        }

        public static bool operator <(Shoe s1, Shoe s2) {
            int s;
            if (s1.size < s2.size) s = -1; else s = 1;

            return s < 0;
        }

        public static bool operator >(Shoe s1, Shoe s2) {
            int s;
            if (s1.size < s2.size) s = -1; else s = 1;

            return s > 0;
        }
    }
}
