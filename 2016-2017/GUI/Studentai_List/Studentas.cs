using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentai_List
{
    class Studentas
    {
        public string name { get; set; }
        public int grade { get; set; }
        public string gender { get; set; }

        public Studentas(string name, int grade, string gender) {
            this.name = name;
            this.grade = grade;
            this.gender = gender;
        }

        public override string ToString() {
            return String.Format("{0, -20} {1,2} {2}", name, grade, gender);
        }
    }
}
