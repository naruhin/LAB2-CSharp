using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Trapeze : Quadrangle
    {
        public Trapeze()
        {
        }

        public Trapeze(int x1, int x2, int x3, int x4,
            int y1, int y2, int y3, int y4,
            string title = "T")
        {
            this.title = title;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.y1 = y1;
            this.y2 = y2;
            this.y3 = y3;
            this.y4 = y4;
        }



        public bool IsTrapeze()
        {
            bool check = false;
            
            if ((Math.Pow(base.DiagonalAC(), 2) + Math.Pow(base.DiagonalBD(), 2) == 2 * base.SegmentBC() * base.SegmentAD() + Math.Pow(base.SegmentAB(), 2) + Math.Pow(base.SegmentCD(), 2))
                || (y1 == y4 && y2 == y3) || (x1 == x2 && x3 == x4))
                check = true;

            return check;
        }

        new public string ToString()
        {
            return this.title + " \n A(" + this.x1 + ", " + this.y1 + ")\n" +
                " B(" + this.x2 + ", " + this.y2 + ")\n" +
                " C(" + this.x3 + ", " + this.y3 + ")\n" +
                " D(" + this.x4 + ", " + this.y4 + ")\n\n" +
                " \n Side 'a'(BC) = " + base.SegmentBC() + " \n" +
                " Side 'b'(AD) = " + base.SegmentAD() + "\n" +
                " Side 'c'(AB) = " + base.SegmentAB() + "\n" +
                " Side 'd'(CD) = " + base.SegmentCD() + "\n\n" +
                " Middle line  = " + this.MiddleLine();

        }

        public double MiddleLine()
        {
            return (base.SegmentBC() + base.SegmentAD()) / 2;
        }
    }
}
