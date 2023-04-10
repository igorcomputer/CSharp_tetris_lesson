using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_Tetris {
    abstract class Figure {

        const int LENGHT = 4;

        public Point[] Points = new Point[LENGHT];

        public void Draw() {
            foreach (Point p in Points) {
                p.Draw();
            }
        }

        public Result TryMove(Direction dir) {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            var result = VerifyPosition(clone);

            if (result == Result.SUCCESS) {
                Points = clone;
            }
            Draw();
            return result;
        }

        private Result VerifyPosition(Point[] clonePoints) {
            foreach(var p in clonePoints) {

                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;

                if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;

                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;
            }
            return Result.SUCCESS;
        }

        private Point[] Clone() {
            var newPoints = new Point[LENGHT];
            for (int i = 0; i < 4; i++) {
                newPoints[i] = new Point(Points[i]);
            }
            return newPoints;
        }

        public bool IsOnTop()
        {
            return Points[0].Y == 0;
        }

        private void Move(Point[] clonePoints, Direction dir) {
            foreach(var p in clonePoints) {
                p.Move(dir);
            }
        }

        public Result TryRotate() {
            Hide();
            var clone = Clone();
            Rotate(clone);
            var result = VerifyPosition(clone);
            if (result == Result.SUCCESS) {
                Points = clone;
            }
            Draw();
            return result;
        }

        public void Hide() {
            foreach (Point p in Points) {
                p.Hide();
            }
        }

        abstract public void Rotate(Point[] pList);

    }
}
