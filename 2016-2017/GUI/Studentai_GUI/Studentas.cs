using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentai_GUI
{
    class Studentas
    {
        public string name { get; set; }
        public int grade { get; set; }

        public Studentas(string name, int grade) {
            this.name = name;
            this.grade = grade;
        }

        public override string ToString() {
            return String.Format("{0, -20} {1,2}", name, grade);
        }
    }
}
