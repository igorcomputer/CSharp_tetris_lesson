using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_Tetris
{
    class Stick : Figure
    {
        public Stick(int x, int y)
        {
            Points[0] = new Point(x, y);
            Points[1] = new Point(x, y + 1);
            Points[2] = new Point(x, y + 2);
            Points[3] = new Point(x, y + 3);
            Draw();
        }

        public override void Rotate()
        {
            // vertical orientation
            if (Points[0].X == Points[1].X)
            {
                SetHorizontal();
            }
            // horizontal orientation
            else if (Points[0].Y == Points[1].Y)
            {
                SetVertical();
            }
        }

        private void SetVertical()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].X = Points[0].X;
                Points[i].Y = Points[0].Y + i;

            }
        }

        private void SetHorizontal()
        {
            for (int i = 0; i < Points.Length; i++)
            {
                Points[i].Y = Points[0].Y;
                Points[i].X = Points[0].X + i;
            }
        }
    }
}
