using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_Tetris {
    abstract class Figure {

        const int LENGHT = 4;

        protected Point[] points = new Point[LENGHT];

        public void Draw() {
            foreach (Point p in points) {
                p.Draw();
            }
        }

        public void TryMove(Direction dir) {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            if (VerifyPosition(clone)) {
                points = clone;
            }
            Draw();
        }

        private bool VerifyPosition(Point[] clonePoints) {
            foreach(var p in clonePoints) {
                if (p.x < 0 || p.y < 0 || p.x >= 40 || p.y >= 30)
                    return false;
            }
            return true;
        }

        private Point[] Clone() {
            var newPoints = new Point[LENGHT];
            for (int i = 0; i < 4; i++) {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        }

        private void Move(Point[] clonePoints, Direction dir) {
            foreach(var p in clonePoints) {
                p.Move(dir);
            }
        }

        public void TryRotate() {
            Hide();
            var clone = Clone();
            Rotate(clone);
            if (VerifyPosition(clone)) {
                points = clone;
            }
            Draw();
        }

        //public void Move(Direction dir) {
        //    Hide();
        //    foreach (Point p in points) {
        //        p.Move(dir);
        //    }
        //    Draw();
        //}

        public void Hide() {
            foreach (Point p in points) {
                p.Hide();
            }
        }

        abstract public void Rotate(Point[] pList);

    }
}
