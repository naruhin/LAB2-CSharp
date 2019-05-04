using System;
using System.IO;
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
            
            return this.Title + "\t\tSegments: " +
                " \n A(" + this.X1 + ", " + this.Y1 + ")" + "\t\tSide 'a'(BC) = " + Math.Round(base.SegmentBC(),3) +
                " \n B(" + this.X2 + ", " + this.Y2 + ")" + "\t\tSide 'b'(AD) = " + Math.Round(base.SegmentAD(),3) +
                " \n C(" + this.X3 + ", " + this.Y3 + ")" + "\t\tSide 'c'(AB) = " + Math.Round(base.SegmentAB(),3) +
                " \n D(" + this.X4 + ", " + this.Y4 + ")" + "\t\tSide 'd'(CD) = " + Math.Round(base.SegmentCD(),3) +
                " \nMiddle line  = " + this.MiddleLine() +
                "\n-------------------------------------------------------------------------------------------";

    
        }

        public double MiddleLine()
        {
            return (base.SegmentBC() + base.SegmentAD()) / 2;
        }

        new public void Write(BinaryWriter bw)
        {
            // Все данные записываются по отдельности
            bw.Write(Title);
            bw.Write(X1);
            bw.Write(X2);
            bw.Write(X3);
            bw.Write(X4);
            bw.Write(Y1);
            bw.Write(Y2);
            bw.Write(Y3);
            bw.Write(Y4);
        }

        new public static Trapeze Read(BinaryReader br)
        {
            Trapeze q = new Trapeze();
            q.Title = br.ReadString();
            q.X1 = br.ReadInt32();
            q.X2 = br.ReadInt32();
            q.X3 = br.ReadInt32();
            q.X4 = br.ReadInt32();
            q.Y1 = br.ReadInt32();
            q.Y2 = br.ReadInt32();
            q.Y3 = br.ReadInt32();
            q.Y4 = br.ReadInt32();
            return q;
        }
    }
}
