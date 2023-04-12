using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_Tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int a, int b)
        {
            X = a;
            Y = b;
        }

        public Point()
        {

        }

        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }

        public void Draw()
        {
            DrawerProvider.Drawer.DrawPoint(X, Y);  
        }

        public void Move(Direction dir)
        {
            switch (dir)
            {
                case Direction.UP:
                    Y -= 1;
                    break;
                case Direction.DOWN:
                    Y += 1;
                    break;
                case Direction.LEFT:
                    X -= 1;
                    break;
                case Direction.RIGHT:
                    X += 1;
                    break;
            }
        }

        public void Hide()
        {
            DrawerProvider.Drawer.HidePoint(X, Y);
        }
    }
}
