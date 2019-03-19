using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        private static int n;
        private static int m;
        int i = 0;
        int j = 0;
        
        public int I { get => i; set => i = value; }
        public int J { get => j; set => j = value; }
        public static int N { get => n; set => n = value; }
        public static int M { get => m; set => m = value; }

        Quadrangle[] quadrangle;
        Trapeze[] trapeze;

        public Form1()
        {
            InitializeComponent();
        }

        //Установка размерности массива quadrabgle
        private void btnSetN_Click(object sender, EventArgs e)
        {
            quadrangle = new Quadrangle[Convert.ToInt32(numUpDownQ.Value)];
            if (quadrangle != null) //Если массив не пустой - вывести сообщение об успехе
                MessageBox.Show("Отлично!Можете вводить данные!");
        }

        //Установка размерности массива trapeze
        private void btnSetM_Click(object sender, EventArgs e)
        {   
            trapeze = new Trapeze[Convert.ToInt32(numUpDownT.Value)];
            if (trapeze != null)
                MessageBox.Show("Отлично!Можете вводить данные!");
        }

        //Очистка полей и массивов
        private void button1_Click(object sender, EventArgs e)
        {
            quadrangle = null;
            trapeze = null;
            richTextBoxQuadrangle.Text = " ";
            richTextBoxQuadrangle2.Text = " ";
            richTextBoxTrapeze.Text = " ";
            richTextBoxTrapeze2.Text = " ";
            MessageBox.Show("Поля и хранилище очищены!");
        }

        //Заполнение массива quadrangle
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(quadrangle != null)
            {
                if (i < quadrangle.Length)
                {
                    quadrangle[i] = new Quadrangle();
                    quadrangle[i].Title = txtQuadrangleTitle.Text;
                    quadrangle[i].X1 = Convert.ToInt32(txtX1.Text);
                    quadrangle[i].X2 = Convert.ToInt32(txtX2.Text);
                    quadrangle[i].X3 = Convert.ToInt32(txtX3.Text);
                    quadrangle[i].X4 = Convert.ToInt32(txtX4.Text);
                    quadrangle[i].Y1 = Convert.ToInt32(txtY1.Text);
                    quadrangle[i].Y2 = Convert.ToInt32(txtY2.Text);
                    quadrangle[i].Y3 = Convert.ToInt32(txtY3.Text);
                    quadrangle[i].Y4 = Convert.ToInt32(txtY4.Text);
                }
                else
                {
                    MessageBox.Show("Вы ввели все фигуры!");
                    i = 0;
                }
                richTextBoxQuadrangle.Text = quadrangle[i].ToString();
                i++;
            }
            else
                MessageBox.Show("Неопределенно количество фигур!");
        }
        //Заполнение массива trapeze
        private void btnEnterT_Click(object sender, EventArgs e)
        {
            if(trapeze != null)
            {
                if (j < trapeze.Length)
                {
                    trapeze[j] = new Trapeze();
                    trapeze[j].Title = txtTrapezeTitle.Text;
                    trapeze[j].X1 = Convert.ToInt32(txtTX1.Text);
                    trapeze[j].X2 = Convert.ToInt32(txtTX2.Text);
                    trapeze[j].X3 = Convert.ToInt32(txtTX3.Text);
                    trapeze[j].X4 = Convert.ToInt32(txtTX4.Text);
                    trapeze[j].Y1 = Convert.ToInt32(txtTY1.Text);
                    trapeze[j].Y2 = Convert.ToInt32(txtTY2.Text);
                    trapeze[j].Y3 = Convert.ToInt32(txtTY3.Text);
                    trapeze[j].Y4 = Convert.ToInt32(txtTY4.Text);
                }
                else
                {
                    MessageBox.Show("Вы ввели все фигуры!");
                    j = 0;
                }
                richTextBoxTrapeze.Text = (trapeze[j].IsTrapeze() ? "\nTrapeze - " + trapeze[j].ToString() : "NOT trapeze");
                j++;
            }
            else
                MessageBox.Show("Нопределенно количество фигур!");
        }
        //Поиск фигуры с минимальной площадью.
        private void btnMinSquare_Click(object sender, EventArgs e)
        {
            double min = 10000;
            //Поиск
            for (int i = 0; i < quadrangle.Length; i++)
            {
                if (quadrangle[i].GetSquare() > 0 && quadrangle[i].GetSquare() < min)
                {
                    min = quadrangle[i].GetSquare();
                }
            }
            //Вывод в текстовое поле
            for (int i = 0; i < quadrangle.Length; i++)
            {
                if (min == quadrangle[i].GetSquare())
                {
                    richTextBoxQuadrangle2.Text = "Quadrangle with minimal square:" + quadrangle[i].ToString();
                }
            }
        }
        //Поиск трапеции с максимальной средней линией
        private void btnMaxMiddleLine_Click(object sender, EventArgs e)
        {
            double max = 0;
            for(int j = 0; j < trapeze.Length; j++)
            {
                if(trapeze[j].IsTrapeze() == true && trapeze[j].MiddleLine() > max)  
                    max = trapeze[j].MiddleLine();
            }
            for(int j = 0;j < trapeze.Length; j++)
            {
                if(trapeze[j].IsTrapeze() == true && max == trapeze[j].MiddleLine())
                    richTextBoxTrapeze2.Text = "Trapeze with highest middle line:" + trapeze[j].ToString();
            }
        }

        
    }
}
