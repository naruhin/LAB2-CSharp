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
            this.Title = title;
            this.X1 = x1;
            this.X2 = x2;
            this.X3 = x3;
            this.X4 = x4;
            this.Y1 = y1;
            this.Y2 = y2;
            this.Y3 = y3;
            this.Y4 = y4;
        }



        public bool IsTrapeze()
        {
            bool check = false;
            
            if ((Y1 == Y4 && Y2 == Y3) || (X1 == X2 && X3 == X4))
                check = true;

            return check;
        }

        new public string ToString()
        {
            return this.Title + " \n A(" + this.X1 + ", " + this.Y1 + ")\n" +
                " B(" + this.X2 + ", " + this.Y2 + ")\n" +
                " C(" + this.X3 + ", " + this.Y3 + ")\n" +
                " D(" + this.X4 + ", " + this.Y4 + ")\n\n" +
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
