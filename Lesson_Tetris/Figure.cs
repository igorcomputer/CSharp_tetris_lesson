﻿using System;
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

        public void TryMove(Direction dir) {
            Hide();
            var clone = Clone();
            Move(clone, dir);
            if (VerifyPosition(clone)) {
                Points = clone;
            }
            Draw();
        }

        private bool VerifyPosition(Point[] clonePoints) {
            foreach(var p in clonePoints) {
                if (p.X < 0 || p.Y < 0 || p.X >= Field.Width || p.Y >= Field.Height)
                    return false;
            }
            return true;
        }

        private Point[] Clone() {
            var newPoints = new Point[LENGHT];
            for (int i = 0; i < 4; i++) {
                newPoints[i] = new Point(Points[i]);
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
                Points = clone;
            }
            Draw();
        }

        public void Hide() {
            foreach (Point p in Points) {
                p.Hide();
            }
        }

        abstract public void Rotate(Point[] pList);

    }
}
