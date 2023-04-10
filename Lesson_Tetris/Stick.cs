using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_Tetris
{
    class Stick : Figure
    {
        public Stick(int x, int y, char sym)
        {
            Points[0] = new Point(x, y, sym);
            Points[1] = new Point(x, y + 1, sym);
            Points[2] = new Point(x, y + 2, sym);
            Points[3] = new Point(x, y + 3, sym);
            Draw();
        }

        public override void Rotate(Point[] pList)
        {
            // vertical orientation
            if (pList[0].X == pList[1].X)
            {
                SetHorizontal(pList);
            }
            // horizontal orientation
            else if (pList[0].Y == pList[1].Y)
            {
                SetVertical(pList);
            }
        }

        private void SetVertical(Point[] pList)
        {
            for (int i = 0; i < pList.Length; i++)
            {
                pList[i].X = pList[0].X;
                pList[i].Y = pList[0].Y + i;

            }
        }

        private void SetHorizontal(Point[] pList)
        {
            for (int i = 0; i < pList.Length; i++)
            {
                pList[i].Y = pList[0].Y;
                pList[i].X = pList[0].X + i;
            }
        }
    }
}
