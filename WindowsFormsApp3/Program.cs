using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    static class Program
    {
        /*Вариант 17. Создать класс четырёхугольник, члены класса - координаты 4-х точек.Предусмотреть в классе методы
         вычисления и вывода сведений о фигуре - длины сторон, диагоналей, периметр, площадь. Создать производный класс - трапеция,
         предусмотреть в классе проверку,является ли фигура трапецией. Написать программу, демонстрирующую работу с классом : 
         дано N четырехугольников и M трапеций, найти четырехугольник с минимальной площадью и трапецию с максимальной средней линией.*/
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
