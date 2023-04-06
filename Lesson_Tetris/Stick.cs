using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_Tetris {
    class Stick : Figure {

        public Stick(int x, int y, char sym) {
            points[0] = new Point(x, y, sym);
            points[1] = new Point(x, y + 1, sym);
            points[2] = new Point(x, y + 2, sym);
            points[3] = new Point(x, y + 3, sym);
        }

        public override void Rotate() {
            // vertical orientation
            if (points[0].x == points[1].x) {
                SetHorizontal();
            }
            // horizontal orientation
            else if (points[0].y == points[1].y) {
                SetVertical();
            }
        }

        private void SetVertical() {
            for (int i = 0; i < points.Length; i++) {
                points[i].x = points[0].x;
                points[i].y = points[0].y + i;

            }
        }

        private void SetHorizontal() {
            for (int i = 0; i < points.Length; i++) {
                points[i].y = points[0].y;
                points[i].x = points[0].x + i;
            }
        }
    }


}
