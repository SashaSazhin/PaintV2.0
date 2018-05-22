using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graph
{
    class OurPaint
    {
        int currentOperation = 0; // point - 1, line - 2, circle - 3, ellipse - 4, rectangle - 5
        Color ourColor = Color.Black;
        Pen pen = new Pen(Color.Black);
        bool isLineFirstPoint = true;

        public int CurrentOperation { get => currentOperation; set => currentOperation = value; }
        public Color OurColor { get => ourColor; set => ourColor = value; }
        public Pen Pen { get => pen; set => pen = value; }
        public bool IsLineFirstPoint { get => isLineFirstPoint; set => isLineFirstPoint = value; }
    }
}
