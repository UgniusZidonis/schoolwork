using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studentai_GUI
{
    class Studentai
    {
        const int CMax = 500;
        private Studentas[] St;
        private int n;

        public Studentai() {
            n = 0;
            St = new Studentas[CMax];
        }

        public Studentas Get(int i) { return St[i]; }
        public int Get() { return n; }
        public void Set(Studentas obj) { St[n++] = obj; }
    }
}
