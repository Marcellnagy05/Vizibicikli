using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    public class kolcsonzes
    {
        string nev;
        char jazon;
        int eOra;
        int ePerc;
        int vOra;
        int vPerc;

        public kolcsonzes(string nev, char jazon, int eOra, int ePerc, int vOra, int vPerc)
        {
            this.nev = nev;
            this.jazon = jazon;
            this.eOra = eOra;
            this.ePerc = ePerc;
            this.vOra = vOra;
            this.vPerc = vPerc;
        }

        public string Nev { get => nev; set => nev = value; }
        public char Jazon { get => jazon; set => jazon = value; }
        public int EOra { get => eOra; set => eOra = value; }
        public int EPerc { get => ePerc; set => ePerc = value; }
        public int VOra { get => vOra; set => vOra = value; }
        public int VPerc { get => vPerc; set => vPerc = value; }
    }
}
