﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    class Quadrangle
    {
        private String title;
        private int y4;
        private int x1;
        private int x2;
        private int x3;
        private int x4;
        private int y1;
        private int y2;
        private int y3;

        public string Title { get => title; set => title = value; }
        public int X1 { get => x1; set => x1 = value; }
        public int X2 { get => x2; set => x2 = value; }
        public int X3 { get => x3; set => x3 = value; }
        public int X4 { get => x4; set => x4 = value; }
        public int Y1 { get => y1; set => y1 = value; }
        public int Y2 { get => y2; set => y2 = value; }
        public int Y3 { get => y3; set => y3 = value; }
        public int Y4 { get => y4; set => y4 = value; }

        public Quadrangle()
        {

        }

        public Quadrangle(
            int x1, int x2, int x3, int x4,
            int y1, int y2, int y3, int y4,
            string title = "Q")
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

        public override string ToString()
        {
            return this.Title + " \n A(" + this.X1 + ", " + this.Y1 + ")\n" +
                " B(" + this.X2 + ", " + this.Y2 + ")\n" +
                " C(" + this.X3 + ", " + this.Y3 + ")\n" +
                " D(" + this.X4 + ", " + this.Y4 + ")\n\n" +
                "Segments:\n AB = " + SegmentAB() + "\n BC = " + SegmentBC() +
                "\n CD = " + SegmentCD() + "\n AD = " + SegmentAD() +
                "\n\n Diagonals:\n AC = " + DiagonalAC() + "\n BD = " + DiagonalBD() +
                "\n Perimetr = " + GetPerimetr() + "\n Square = " + GetSquare();
        }

        //Поиск стороны AB
        public double SegmentAB()
        {
            double sidea = Math.Sqrt(Math.Pow(this.X2 - this.X1, 2) + Math.Pow(this.Y2 - this.Y1, 2));
            return sidea;
        }

        //Поиск стороны BC
        public double SegmentBC()
        {
            double sideb = Math.Sqrt(Math.Pow(this.X3 - this.X2, 2) + Math.Pow(this.Y3 - this.Y2, 2));
            return sideb;
        }

        //Поиск стороны CD
        public double SegmentCD()
        {
            double sidec = Math.Sqrt(Math.Pow(this.X4 - this.X3, 2) + Math.Pow(this.Y4 - this.Y3, 2));
            return sidec;
        }

        //Поиск стороны AD
        public double SegmentAD()
        {
            double sided = Math.Sqrt(Math.Pow(this.X4 - this.X1, 2) + Math.Pow(this.Y4 - this.Y1, 2));
            return sided;
        }



        //Поиск диагонали AC
        public double DiagonalAC()
        {
            return Math.Sqrt(Math.Pow(this.X3 - this.X1, 2) + Math.Pow(this.Y3 - this.Y1, 2));
        }

        //Поиск диагонали Bd
        public double DiagonalBD()
        {
            return Math.Sqrt(Math.Pow(this.X4 - this.X2, 2) + Math.Pow(this.Y4 - this.Y2, 2));
        }

        public double GetPerimetr()//Периметр
        {
            return SegmentAB() + SegmentAD() + SegmentBC() + SegmentCD();
        }

        public double GetSquare()//Площадь
        {
            double cos = ((this.X3 - this.X1) * (this.X4 - this.X2) + (this.Y3 - this.Y1) * (this.Y4 - this.Y2)) / (DiagonalAC() * DiagonalBD());
            double sin = Math.Sqrt(1 - Math.Pow(cos, 2));
            double square = ((DiagonalAC() * DiagonalBD()) / 2) * sin;
            return square;
        }
    }
}

