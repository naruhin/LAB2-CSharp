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
        int N = 5;
        int M = 5;
        int i = 0;
        int j = 0;
        Quadrangle[] quadrangle;

        Trapeze[] trapeze;
        
        public Form1()
        {
            InitializeComponent();
            
            quadrangle = new Quadrangle[N];
            trapeze = new Trapeze[M];
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            
            if (i < N)
            {
                quadrangle[i] = new Quadrangle();
                quadrangle[i].title = txtQuadrangleTitle.Text;
                quadrangle[i].x1 = Convert.ToInt32(txtX1.Text);
                quadrangle[i].x2 = Convert.ToInt32(txtX2.Text);
                quadrangle[i].x3 = Convert.ToInt32(txtX3.Text);
                quadrangle[i].x4 = Convert.ToInt32(txtX4.Text);
                quadrangle[i].y1 = Convert.ToInt32(txtY1.Text);
                quadrangle[i].y2 = Convert.ToInt32(txtY2.Text);
                quadrangle[i].y3 = Convert.ToInt32(txtY3.Text);
                quadrangle[i].y4 = Convert.ToInt32(txtY4.Text);
            }
            else
            {
                MessageBox.Show("Вы ввели все фигуры!");
                i = 0;
            }
            richTextBoxQuadrangle.Text = quadrangle[i].ToString();
            i++;
        }

        private void btnEnterT_Click(object sender, EventArgs e)
        {
            if (j < M)
            {
                trapeze[j] = new Trapeze();
                trapeze[j].title = txtTrapezeTitle.Text;
                trapeze[j].x1 = Convert.ToInt32(txtTX1.Text);
                trapeze[j].x2 = Convert.ToInt32(txtTX2.Text);
                trapeze[j].x3 = Convert.ToInt32(txtTX3.Text);
                trapeze[j].x4 = Convert.ToInt32(txtTX4.Text);
                trapeze[j].y1 = Convert.ToInt32(txtTY1.Text);
                trapeze[j].y2 = Convert.ToInt32(txtTY2.Text);
                trapeze[j].y3 = Convert.ToInt32(txtTY3.Text);
                trapeze[j].y4 = Convert.ToInt32(txtTY4.Text);
            }
            else
            {
                MessageBox.Show("Вы ввели все фигуры!");
                j = 0;
            }
            richTextBoxTrapeze.Text = (trapeze[j].IsTrapeze() ? "\nTrapeze - " + trapeze[j].ToString() : "NOT trapeze");
            j++;
            
        }

        private void btnMinSquare_Click(object sender, EventArgs e)
        {
            double min = 10000;

            for (int i = 0; i < quadrangle.Length; i++)
            {
                if (quadrangle[i].GetSquare() > 0 && quadrangle[i].GetSquare() < min)
                {
                    min = quadrangle[i].GetSquare();
                }
            }

            for (int i = 0; i < quadrangle.Length; i++)
            {
                if (min == quadrangle[i].GetSquare())
                {
                    richTextBoxQuadrangle2.Text = "Quadrangle with minimal square:" + quadrangle[i].ToString();
                }
            }
        }

        private void btnMaxMiddleLine_Click(object sender, EventArgs e)
        {
            double max = 0;
            for(int j = 0; j < M; j++)
            {
                if(trapeze[j].IsTrapeze() == true && trapeze[j].MiddleLine() > max)
                {
                    max = trapeze[j].MiddleLine();
                    
                }
            }
            for(int j = 0;j < M; j++)
            {
                if(trapeze[j].IsTrapeze() == true && max == trapeze[j].MiddleLine())
                    richTextBoxTrapeze2.Text = "Trapeze with highest middle line:" + trapeze[j].ToString();
            }

        }
    }
}
