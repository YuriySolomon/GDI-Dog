using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDI_Dog
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Рамка             
            Rectangle rect1 = new Rectangle(150, 50, 400, 400);
            Rectangle rect2 = new Rectangle(200, 100, 300, 300);                                 
            g.FillRectangle(Brushes.Blue, rect1);
            g.FillRectangle(Brushes.Yellow, rect2);            

            // Тело
            Rectangle rectBody = new Rectangle(300, 250, 120, 100);            
            g.FillRectangle(Brushes.Brown, rectBody);            

            // Голова
            e.Graphics.RotateTransform(-30);            
            SolidBrush solidBrushHead = new SolidBrush(Color.FromArgb(255, Color.Brown));
            g.FillEllipse(solidBrushHead, 80, 310, 100, 80);
            e.Graphics.RotateTransform(30);

            // Нос         
            SolidBrush solidBrushNos = new SolidBrush(Color.FromArgb(255, Color.Black));
            g.FillEllipse(solidBrushNos, 230, 240, 20, 20);

            // Правый глаз
            SolidBrush solidBrushGlas = new SolidBrush(Color.FromArgb(255, Color.White));
            g.FillEllipse(solidBrushGlas, 280, 205, 25, 25);

            // Правый зрачок
            g.FillEllipse(solidBrushNos, 282, 213, 15, 15);

            // Левый глаз
            g.FillEllipse(solidBrushGlas, 290, 232, 25, 25);

            // Левый зрачок
            g.FillEllipse(solidBrushNos, 292, 240, 15, 15);

            GraphicsPath pathLimbs = new GraphicsPath();

            // Хвост
            pathLimbs.StartFigure();
            pathLimbs.AddLine(420, 250, 380, 220);
            pathLimbs.AddLine(380, 220, 410, 200);
            pathLimbs.AddLine(410, 200, 420, 250);
            pathLimbs.CloseFigure();

            // Задняя нога
            pathLimbs.StartFigure();
            pathLimbs.AddLine(415, 345, 395, 385);
            pathLimbs.AddLine(395, 385, 435, 385);
            pathLimbs.AddLine(435, 385, 415, 345);
            pathLimbs.CloseFigure();

            // Передняя нога
            pathLimbs.StartFigure();
            pathLimbs.AddLine(305, 345, 285, 385);
            pathLimbs.AddLine(285, 385, 325, 385);
            pathLimbs.AddLine(325, 385, 305, 345);
            pathLimbs.CloseFigure();

            // Правое ухо
            pathLimbs.StartFigure();
            pathLimbs.AddLine(310, 200, 315, 160);
            pathLimbs.AddLine(315, 160, 345, 180);
            pathLimbs.AddLine(345, 180, 310, 200);
            pathLimbs.CloseFigure();

            // Левое ухо
            pathLimbs.StartFigure();
            pathLimbs.AddLine(320, 260, 300, 300);
            pathLimbs.AddLine(300, 300, 330, 305);
            pathLimbs.AddLine(330, 305, 320, 260);
            pathLimbs.CloseFigure();

            g.DrawPath(new Pen(Color.DarkRed, 2), pathLimbs);

            Region rgnLimbs = new Region(pathLimbs);
            g.FillRegion(Brushes.DarkRed, rgnLimbs);

            // Текст
            Font f = new Font("Verdana", 16, FontStyle.Bold | FontStyle.Italic);
            g.DrawString("PATRON", f, Brushes.Blue, 305, 110);
                        
            g.Dispose();
        }

    }
}
