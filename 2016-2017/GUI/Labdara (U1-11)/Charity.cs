using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Labdara__U1_11_
{
    class Charity
    {
        public string name { get; }
        public List<Shoe> shoes { get; }

        public Charity(string name, List<Shoe> shoes) {
            this.name = name;
            this.shoes = shoes;
        }

        public override string ToString() {
            string output = name + "\n";
            output += "Batų tipas |    Sezonas   | Dydis |    Būklė    | Spalva\n";

            if (shoes.Count > 0)
                foreach (Shoe s in shoes)
                    output += s.ToString() + "\n";
            else
                output += "Masyvas tuščias!\n";
            output += "----------";
            return output;
        }

        public void WriteToFile(string dir) {
            using (var fr = File.AppendText(dir)) {
                fr.WriteLine(name);
                fr.WriteLine("Batų tipas | Sezonas | Dydis | Būklė | Spalva");
                if (shoes.Count > 0)
                    foreach (Shoe s in shoes)
                        fr.WriteLine(s.ToString());
                else
                    fr.WriteLine("Masyvas tuščias!");
                fr.WriteLine("----------");
            }
        }

        public void Sort() {
            for (int j = 0; j < shoes.Count - 1; j++) {
                Shoe min = shoes[j];
                int min_i = j;

                for (int i = j + 1; i < shoes.Count; i++) {
                    if (shoes[i] < min) {
                        min = shoes[i];
                        min_i = i;
                    }
                }

                shoes[min_i] = shoes[j];
                shoes[j] = min;
            }
        }

        public void Add(Shoe s) {
            shoes.Add(s);
            int changeIndex = -1;
            for (int i = 0; i < shoes.Count - 1; i++) {
                if (shoes[i] > s) {
                    changeIndex = i;
                    break;
                }
            }

            if (changeIndex != -1)
            for (int i = changeIndex; i < shoes.Count - 1; i++) {
                    Shoe tmp = shoes[shoes.Count - 1];
                    shoes[shoes.Count - 1] = shoes[i];
                    shoes[i] = tmp;
            }
        }

        public int AdultShoeCount() {
            int sum = 0;

            foreach (Shoe s in shoes)
                if (s.type != "vaikiški")
                    sum++;

            return sum;
        }
    }
}