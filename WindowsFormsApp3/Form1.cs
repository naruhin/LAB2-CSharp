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
      
        private int i = 0;
        private int j = 0;
        
        public int I { get => i; set => i = value; }
        public int J { get => j; set => j = value; }
       

        Quadrangle[] quadrangle;
        Trapeze[] trapeze;

        public Form1()
        {
            InitializeComponent();
        }

        //Установка размерности массива quadrangle
        private void btnSetN_Click(object sender, EventArgs e)
        {
           
           

            if(quadrangle == null)
            {
                quadrangle = new Quadrangle[Convert.ToInt32(numUpDownQ.Value)];
                if (quadrangle != null) //Если массив не пустой - вывести сообщение об успехе
                    MessageBox.Show("Отлично!Можете вводить данные!");
            }
            else
            {
                Array.Resize<Quadrangle>(ref  quadrangle, Convert.ToInt32(numUpDownQ.Value));
                if (quadrangle != null) //Если массив не пустой - вывести сообщение об успехе
                    MessageBox.Show("Размерность изменена!");
            }
            
            
        }

        //Установка размерности массива trapeze
        private void btnSetM_Click(object sender, EventArgs e)
        {

            if (trapeze == null)
            {
                trapeze = new Trapeze[Convert.ToInt32(numUpDownT.Value)];
                if (trapeze != null) //Если массив не пустой - вывести сообщение об успехе
                    MessageBox.Show("Отлично!Можете вводить данные!");
            }
            else
            {
                Array.Resize<Trapeze>(ref trapeze, Convert.ToInt32(numUpDownT.Value));
                if (trapeze != null) //Если массив не пустой - вывести сообщение об успехе
                    MessageBox.Show("Размерность изменена!");
            }

            
        }

       

        //Заполнение массива quadrangle
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(quadrangle != null)
            {
                if (I < quadrangle.Length)
                {
                    quadrangle[I] = new Quadrangle();
                    
                    quadrangle[I].Title = txtQuadrangleTitle.Text;
                    quadrangle[I].X1 = Convert.ToInt32(txtX1.Text);
                    quadrangle[I].X2 = Convert.ToInt32(txtX2.Text);
                    quadrangle[I].X3 = Convert.ToInt32(txtX3.Text);
                    quadrangle[I].X4 = Convert.ToInt32(txtX4.Text);
                    quadrangle[I].Y1 = Convert.ToInt32(txtY1.Text);
                    quadrangle[I].Y2 = Convert.ToInt32(txtY2.Text);
                    quadrangle[I].Y3 = Convert.ToInt32(txtY3.Text);
                    quadrangle[I].Y4 = Convert.ToInt32(txtY4.Text);
                }
                else
                {
                    MessageBox.Show("Вы ввели все фигуры!");
                    I = 0;
                }
                richTextBoxQuadrangle.Text = quadrangle[I].ToString();
                I++;
            }
            else
                MessageBox.Show("Неопределенно количество фигур!");
        }
        //Заполнение массива trapeze
        private void btnEnterT_Click(object sender, EventArgs e)
        {
            if(trapeze != null)
            {
                if (J < trapeze.Length)
                {
                    trapeze[J] = new Trapeze();
                    trapeze[J].Title = txtTrapezeTitle.Text;
                    trapeze[J].X1 = Convert.ToInt32(txtTX1.Text);
                    trapeze[J].X2 = Convert.ToInt32(txtTX2.Text);
                    trapeze[J].X3 = Convert.ToInt32(txtTX3.Text);
                    trapeze[J].X4 = Convert.ToInt32(txtTX4.Text);
                    trapeze[J].Y1 = Convert.ToInt32(txtTY1.Text);
                    trapeze[J].Y2 = Convert.ToInt32(txtTY2.Text);
                    trapeze[J].Y3 = Convert.ToInt32(txtTY3.Text);
                    trapeze[J].Y4 = Convert.ToInt32(txtTY4.Text);
                }
                else
                {
                    MessageBox.Show("Вы ввели все фигуры!");
                    J = 0;
                }
                richTextBoxTrapeze.Text = (trapeze[J].IsTrapeze() ? "\nTrapeze - " + trapeze[J].ToString() : "NOT trapeze");
                J++;
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

        private void btnClearTxtBoxs_Click(object sender, EventArgs e)
        {
            richTextBoxQuadrangle.Text = null;
            richTextBoxQuadrangle2.Text = null ;
            richTextBoxTrapeze.Text = null;
            richTextBoxTrapeze2.Text = null;
        }

        
    }
}
