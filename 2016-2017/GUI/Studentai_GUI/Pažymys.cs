using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentai_GUI
{
    class Pažymys
    {
        public int grade { get; set; }
        public string gradeWord { get; set; }

        public Pažymys(int grade, string gradeWord) {
            this.grade = grade;
            this.gradeWord = gradeWord;
        }
    }
}
