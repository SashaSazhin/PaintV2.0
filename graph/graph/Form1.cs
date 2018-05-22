using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graph
{
    public partial class Form1 : Form
    {
        OurPaint paint;
        Graphics g;
        int x = 0;
        int y = 0;
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
            //g.Clear(Color.Aqua);
            paint = new OurPaint();


        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (paint.CurrentOperation)
            {
                case 1:
                    g.DrawRectangle(paint.Pen, e.X, e.Y, 1, 1);
                    break;
                case 2:
                    {
                        if (paint.IsLineFirstPoint)
                        {
                            x = e.X;
                            y = e.Y;
                        }
                        else
                            g.DrawLine(paint.Pen, new Point(x, y), new Point(e.X, e.Y));

                        paint.IsLineFirstPoint = !paint.IsLineFirstPoint;
                        break;
                    }
                case 3:
                    {
                        if (paint.IsLineFirstPoint)
                        {
                            x = e.X;
                            y = e.Y;
                        }
                        else
                        {
                            double radius = Math.Sqrt((e.X - x) * (e.X - x) + (e.Y - y) * (e.Y - y));
                            g.DrawEllipse(paint.Pen, (int)(x - radius), (int)(y - radius), (int)(radius + radius), (int)(radius + radius));

                        }

                        paint.IsLineFirstPoint = !paint.IsLineFirstPoint;
                        break;
                    }
                case 4:
                    {
                        if (paint.IsLineFirstPoint)
                        {
                            x = e.X;
                            y = e.Y;
                        }
                        else
                        {

                            g.DrawEllipse(paint.Pen, x, y, e.X - x, e.Y - y);

                        }

                        paint.IsLineFirstPoint = !paint.IsLineFirstPoint;
                        break;
                    }
                case 5:
                    {
                        if (paint.IsLineFirstPoint)
                        {
                            x = e.X;
                            y = e.Y;
                        }
                        else
                        {
                            g.DrawRectangle(paint.Pen, x, y, e.X - x, e.Y - y);
                        }

                        paint.IsLineFirstPoint = !paint.IsLineFirstPoint;
                        break;
                    }
            }

            Form1.ActiveForm.Text = e.X + ", " + e.Y;
        }

        private void btnPoint_Click(object sender, EventArgs e)
        {
            paint.CurrentOperation = 1;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                paint.Pen = new Pen(colorDialog1.Color);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if ((paint.CurrentOperation == 1))
            {
                if (e.Button == MouseButtons.Left)
                    g.DrawRectangle(paint.Pen, e.X, e.Y, 1, 1);
                else
                    if (e.Button == MouseButtons.Right)
                    g.DrawRectangle(SystemPens.ButtonFace, e.X, e.Y, 1, 1);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            paint.CurrentOperation = 2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            paint.CurrentOperation = 3;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            paint.CurrentOperation = 4;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            paint.CurrentOperation = 5;
        }

        private void LineWidth_SelectedIndexChanged(object sender, EventArgs e)
        {
            string curItem = LineWidth.SelectedItem.ToString();

            paint.Pen.Width = Convert.ToInt32(curItem);
        }

    }
}
