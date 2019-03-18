using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Quadrangle
    {
        public String title;
        public int x1, x2, x3, x4, y1, y2, y3, y4;

        public Quadrangle()
        {

        }

        public Quadrangle(
            int x1, int x2, int x3, int x4,
            int y1, int y2, int y3, int y4,
            string title = "Q")
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

        public override string ToString()
        {
            return this.title + " \n A(" + this.x1 + ", " + this.y1 + ")\n" +
                " B(" + this.x2 + ", " + this.y2 + ")\n" +
                " C(" + this.x3 + ", " + this.y3 + ")\n" +
                " D(" + this.x4 + ", " + this.y4 + ")\n\n" +
                "Segments:\n AB = " + SegmentAB() + "\n BC = " + SegmentBC() +
                "\n CD = " + SegmentCD() + "\n AD = " + SegmentAD() +
                "\n\n Diagonals:\n AC = " + DiagonalAC() + "\n BD = " + DiagonalBD() +
                "\n Perimetr = " + GetPerimetr() + "\n Square = " + GetSquare();
        }

        //Поиск стороны AB
        public double SegmentAB()
        {
            double sidea = Math.Sqrt(Math.Pow(this.x2 - this.x1, 2) + Math.Pow(this.y2 - this.y1, 2));
            return sidea;
        }

        //Поиск стороны BC
        public double SegmentBC()
        {
            double sideb = Math.Sqrt(Math.Pow(this.x3 - this.x2, 2) + Math.Pow(this.y3 - this.y2, 2));
            return sideb;
        }

        //Поиск стороны CD
        public double SegmentCD()
        {
            double sidec = Math.Sqrt(Math.Pow(this.x4 - this.x3, 2) + Math.Pow(this.y4 - this.y3, 2));
            return sidec;
        }

        //Поиск стороны AD
        public double SegmentAD()
        {
            double sided = Math.Sqrt(Math.Pow(this.x4 - this.x1, 2) + Math.Pow(this.y4 - this.y1, 2));
            return sided;
        }



        //Поиск диагонали AC
        public double DiagonalAC()
        {
            return Math.Sqrt(Math.Pow(this.x3 - this.x1, 2) + Math.Pow(this.y3 - this.y1, 2));
        }

        //Поиск диагонали Bd
        public double DiagonalBD()
        {
            return Math.Sqrt(Math.Pow(this.x4 - this.x2, 2) + Math.Pow(this.y4 - this.y2, 2));
        }

        public double GetPerimetr()//Периметр
        {
            return SegmentAB() + SegmentAD() + SegmentBC() + SegmentCD();
        }

        public double GetSquare()//Площадь
        {
            double cos = ((this.x3 - this.x1) * (this.x4 - this.x2) + (this.y3 - this.y1) * (this.y4 - this.y2)) / (DiagonalAC() * DiagonalBD());
            double sin = Math.Sqrt(1 - Math.Pow(cos, 2));
            double square = ((DiagonalAC() * DiagonalBD()) / 2) * sin;
            return square;
        }
    }
}

