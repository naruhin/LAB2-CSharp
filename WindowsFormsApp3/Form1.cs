using System;
using System.IO;
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
        Quadrangle[] quadrangleFromFile;
        Trapeze[] trapeze;
        Trapeze[] trapezeFromFile;

        OpenFileDialog openFileDialog1;
        SaveFileDialog saveFileDialog1;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1 = new OpenFileDialog();
            saveFileDialog1 = new SaveFileDialog();
           
           
        }

        //Установка размерности массива quadrangle
        private void btnSetN_Click(object sender, EventArgs e)
        {

            if(quadrangle == null)
            {
                quadrangle = new Quadrangle[Convert.ToInt32(numUpDownQ.Value)];
                for (int i = 0; i < quadrangle.Length; i++)
                    quadrangle[i] = new Quadrangle();

                if (quadrangle != null) //Если массив не пустой - вывести сообщение об успехе
                    MessageBox.Show("Отлично!Можете вводить данные!");
            }
            else
            {
                int l = quadrangle.Length;
                Array.Resize<Quadrangle>(ref  quadrangle, Convert.ToInt32(numUpDownQ.Value));
                for (int i = l; i < quadrangle.Length; i++)
                    quadrangle[i] = new Quadrangle();

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
                for (int i = 0; i < trapeze.Length; i++)
                   trapeze[i] = new Trapeze();
                if (trapeze != null) //Если массив не пустой - вывести сообщение об успехе
                    MessageBox.Show("Отлично!Можете вводить данные!");
            }
            else
            {
                int l = trapeze.Length;
                Array.Resize<Trapeze>(ref trapeze, Convert.ToInt32(numUpDownT.Value));
                for (int i = l; i < trapeze.Length; i++)
                    trapeze[i] = new Trapeze();
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
                    richTextBoxQuadrangle.Text = quadrangle[I].ToString() + '\n';
                }
                else
                {
                    MessageBox.Show("Вы ввели все фигуры!");
                    richTextBoxQuadrangle.Text = null;
                    I = 0;
                }
                
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
                    richTextBoxTrapeze.Text = (trapeze[J].IsTrapeze() ? "\nTrapeze - " + trapeze[J].ToString() : "NOT trapeze") + '\n';
                }
                else
                {
                    MessageBox.Show("Вы ввели все фигуры!");
                    richTextBoxTrapeze.Text = null;
                    J = 0;
                }
                J++;
            }
            else
                MessageBox.Show("Нопределенно количество фигур!");
        }
        
        //Поиск фигуры с минимальной площадью.
        private void btnMinSquare_Click(object sender, EventArgs e)
        {
            if(quadrangle != null)
            {
                double min = quadrangle[0].GetSquare();
                //Поиск
                for (int i = 1; i < quadrangle.Length; i++)
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
                        richTextBoxQuadrangle.Text = "Quadrangle with minimal square:\n" + quadrangle[i].ToString() + '\n';
                    }
                }
            }
            else if(quadrangleFromFile != null)
            {
                double min = quadrangleFromFile[0].GetSquare();
                //Поиск
                for (int i = 1; i < quadrangleFromFile.Length; i++)
                {
                    if (quadrangleFromFile[i].GetSquare() > 0 && quadrangleFromFile[i].GetSquare() < min)
                    {
                        min = quadrangleFromFile[i].GetSquare();
                    }
                }
                //Вывод в текстовое поле
                for (int i = 0; i < quadrangleFromFile.Length; i++)
                {
                    if (min == quadrangleFromFile[i].GetSquare())
                    {
                        richTextBoxQuadrangle.Text = "Quadrangle with minimal square:\n" + quadrangleFromFile[i].ToString() + '\n';
                    }
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Вы не ввели ни одной фигуры!");
            }




        }
        
        //Поиск трапеции с максимальной средней линией
        private void btnMaxMiddleLine_Click(object sender, EventArgs e)
        {
            if(trapeze != null)
            {
                double max = trapeze[0].MiddleLine();
                for (int j = 1; j < trapeze.Length; j++)
                {
                    if (trapeze[j].IsTrapeze() == true && trapeze[j].MiddleLine() > max)
                        max = trapeze[j].MiddleLine();
                }
                for (int j = 0; j < trapeze.Length; j++)
                {
                    if (trapeze[j].IsTrapeze() == true && max == trapeze[j].MiddleLine())
                        richTextBoxTrapeze.Text = "Trapeze with highest middle line:\n" + trapeze[j].ToString() + '\n';
                }
            }
            else if(trapezeFromFile != null)
            {
                double max1 = trapezeFromFile[0].MiddleLine();
                for (int j = 1; j < trapezeFromFile.Length; j++)
                {
                    if (trapezeFromFile[j].IsTrapeze() == true && trapezeFromFile[j].MiddleLine() > max1)
                        max1 = trapezeFromFile[j].MiddleLine();
                }
                for (int j = 0; j < trapezeFromFile.Length; j++)
                {
                    if (trapezeFromFile[j].IsTrapeze() == true && max1 == trapezeFromFile[j].MiddleLine())
                        richTextBoxTrapeze.Text = "Trapeze with highest middle line:\n" + trapezeFromFile[j].ToString() + '\n';
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Вы не ввели ни одной фигуры!");
            }

        }

        //Случайные числа в поля координат четырехугольника
        private void btnRndQ_Click(object sender, EventArgs e)
        {
            Random  rnd = new Random();
            txtX1.Text = Convert.ToString(rnd.Next(-10, 10));
            txtX2.Text = Convert.ToString(rnd.Next(-10, 10));
            txtX3.Text = Convert.ToString(rnd.Next(-10, 10));
            txtX4.Text = Convert.ToString(rnd.Next(-10, 10));
            txtY1.Text = Convert.ToString(rnd.Next(-10, 10));
            txtY2.Text = Convert.ToString(rnd.Next(-10, 10));
            txtY3.Text = Convert.ToString(rnd.Next(-10, 10));
            txtY4.Text = Convert.ToString(rnd.Next(-10, 10));
        }
        
        //Случайные числа в поля координат трапеции
        private void btnRndT_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            txtTX1.Text = Convert.ToString(rnd.Next(-10, 10));
            txtTX2.Text = Convert.ToString(rnd.Next(-10, 10));
            txtTX3.Text = Convert.ToString(rnd.Next(-10, 10));
            txtTX4.Text = Convert.ToString(rnd.Next(-10, 10));
            txtTY1.Text = Convert.ToString(rnd.Next(-10, 10));
            txtTY2.Text = Convert.ToString(rnd.Next(-10, 10));
            txtTY3.Text = Convert.ToString(rnd.Next(-10, 10));
            txtTY4.Text = Convert.ToString(rnd.Next(-10, 10));
        }
        
        //Открытие файла с данными о четырехугольниках 
        private void BtnOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;


            // получаем выбранный файл
            string filename = openFileDialog1.FileName;

            FileStream fsR = new FileStream(filename, FileMode.Open, FileAccess.Read);
            // Создаем двоичный поток для чтения
            BinaryReader br = new BinaryReader(fsR, Encoding.UTF8);

            //Считываем длину массива и создаём новый массив объектов
            int length = br.ReadInt32();
            
            quadrangleFromFile = new Quadrangle[length];

            //Вывод в текстовое поле информации о фигурах
            richTextBoxQuadrangle.Text = "Кол-во фигур - " + length + "\n";
            for (int i = 0;i < length; i++)
            {
                quadrangleFromFile[i] = Quadrangle.Read(br);
                richTextBoxQuadrangle.Text += quadrangleFromFile[i].ToString() + "\n";
            }
            
            // Закрываем потоки
            br.Close();
            fsR.Close();
        }

        //Сохранение в файл данных о четырехуголниках и завершение работы 
        private void BtnFinish_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("Сохранить результаты?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // если пользователь нажал кнопку да 
            if (rsl == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;
                
                string path = Path.GetDirectoryName(Application.ExecutablePath);

                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);

                int length = quadrangle.Length;
                bw.Write(length);

                // Пишем данные
                for(int i = 0; i < quadrangle.Length; i++)
                {
                    quadrangle[i].Write(bw);
                }
            
                // Закрываем потоки
                bw.Close();
                fs.Close();
                MessageBox.Show("Файл сохранен");
                // выходим из приложения 
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }
        
        //Вывод всех данных о четырехугольниках 
        private void btnShowAllQ_Click(object sender, EventArgs e)
        {
            richTextBoxQuadrangle.Text = null;
            if(quadrangle != null)
            {
                for (int i = 0; i < quadrangle.Length; i++)
                {
                    richTextBoxQuadrangle.Text += quadrangle[i].ToString() + '\n';
                }
            }
            else if(quadrangleFromFile != null)
            {
                for (int i = 0; i < quadrangleFromFile.Length; i++)
                {
                    richTextBoxQuadrangle.Text += quadrangleFromFile[i].ToString() + '\n';
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Вы не ввели ни одной фигуры!");
            }

        }
        
        //Вывод всех данных о трапециях
        private void btnShowAllT_Click(object sender, EventArgs e)
        {
            richTextBoxTrapeze.Text = null;
            if(trapeze != null)
            {
                for (int i = 0; i < trapeze.Length; i++)
                {
                    richTextBoxTrapeze.Text += trapeze[i].ToString() + '\n';
                }
            }
            else if(trapezeFromFile != null)
            {
                for (int i = 0; i < trapezeFromFile.Length; i++)
                {
                    richTextBoxTrapeze.Text += trapezeFromFile[i].ToString() + '\n';
                }
            }
            else
            {
                MessageBox.Show("Ошибка! Вы не ввели ни одной фигуры!");
            }
            
        }
        
        //Сохранение в файл данных о трапециях и завершение работы 
        private void BtnFinishT_Click(object sender, EventArgs e)
        {
            DialogResult rsl = MessageBox.Show("Сохранить результаты?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // если пользователь нажал кнопку да 
            if (rsl == DialogResult.Yes)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                    return;
                string filename = saveFileDialog1.FileName;

                

                FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write);
                BinaryWriter bw = new BinaryWriter(fs, Encoding.UTF8);

                int length = trapeze.Length;
                bw.Write(length);

                // Пишем данные
                for (int i = 0; i < trapeze.Length; i++)
                {
                    trapeze[i].Write(bw);
                }

                // Закрываем потоки
                bw.Close();
                fs.Close();
                MessageBox.Show("Файл сохранен");
                // выходим из приложения 
                Application.Exit();
            }
            else
            {
                Application.Exit();
            }
        }
        
        //Открытие файла с данными о трапециях 
        private void BtnOpenFileT_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;


            // получаем выбранный файл
            string filename = openFileDialog1.FileName;

            FileStream fsR = new FileStream(filename, FileMode.Open, FileAccess.Read);
            // Создаем двоичный поток для чтения
            BinaryReader br = new BinaryReader(fsR, Encoding.UTF8);

            //Считываем длину массива и создаём новый массив объектов
            int length = br.ReadInt32();

            trapezeFromFile = new Trapeze[length];

            //Вывод в текстовое поле информации о фигурах
            richTextBoxQuadrangle.Text = "Кол-во фигур - " + length + "\n";
            for (int i = 0; i < length; i++)
            {
                trapezeFromFile[i] = Trapeze.Read(br);
                richTextBoxTrapeze.Text += trapezeFromFile[i].ToString() + "\n";
            }

            // Закрываем потоки
            br.Close();
            fsR.Close();
        }
    }
}
