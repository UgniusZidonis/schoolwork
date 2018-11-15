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
        private Node first;
        private Node last;
        private int count;

        public Charity(string name) {
            this.name = name;
            last = new Node();
            first = new Node(null, last);
            count = 0;
        }

        public Node GetFirst() { return first; }

        public void RemoveAverageCondition() {
            for (var elem = first; elem.GetNext() != null ? elem.GetNext().GetValue() != null : false; elem = elem)
                if (elem.GetNext().GetValue().condition == "patenkinama")
                {
                    count--;
                    elem.SetNext(elem.GetNext().GetNext());
                }
                else
                    elem = elem.GetNext();
        }

        public override string ToString() {
            string output = name + "\n";
            output += "Batų tipas |    Sezonas   | Dydis |    Būklė    | Spalva\n";

            if (count > 0)
                for (var elem = first.GetNext(); elem.GetValue() != null; elem = elem.GetNext())
                    output += elem.GetValue().ToString() + "\n";
            else
                output += "Masyvas tuščias!\n";
            output += "----------";
            return output;
        }

        public void WriteToFile(string dir) {
            using (var fr = File.AppendText(dir)) {
                fr.WriteLine(name);
                fr.WriteLine("Batų tipas | Sezonas | Dydis | Būklė | Spalva");
                if (count > 0)
                    for (var elem = first.GetNext(); elem.GetValue() != null; elem = elem.GetNext())
                        fr.WriteLine(elem.GetValue().ToString());
                else
                    fr.WriteLine("Masyvas tuščias!");
                fr.WriteLine("----------");
            }
        }

        public void Sort() {
            for (int i = 0; i < count; i++) {
                for (var elem = first.GetNext(); elem.GetNext() != null; elem = elem.GetNext()) {
                    if (elem.GetValue() < elem.GetNext().GetValue())
                        Node.Swap(elem, elem.GetNext());
                }
            }
        }

        public void Add(Shoe s) {
            count++;
            for (var elem = first.GetNext(); elem != null; elem = elem.GetNext()) {
                if (elem.GetValue() != null)
                {
                    if (s < elem.GetValue())
                    {
                        var tmpVal = elem.GetValue();
                        var tmpNext = elem.GetNext();
                        elem.SetValue(s);
                        elem.SetNext(new Node(tmpVal, tmpNext));
                        return;
                    }
                }
                else {
                    var tmpVal = elem.GetValue();
                    var tmpNext = elem.GetNext();
                    elem.SetValue(s);
                    elem.SetNext(new Node(tmpVal, tmpNext));
                    return;
                }
            }
        }

        public int AdultShoeCount() {
            int sum = 0;

            for (var elem = first.GetNext(); elem.GetValue() != null; elem = elem.GetNext())
                if (elem.GetValue().type != "vaikiški")
                    sum++;

            return sum;
        }
    }
}