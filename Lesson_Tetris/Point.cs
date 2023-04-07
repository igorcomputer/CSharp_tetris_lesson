﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_Tetris {
    public class Point {

        public int x;
        public int y;
        public char c;

        public Point(int a, int b, char sym) {
            x = a;
            y = b;
            c = sym;
        }

        public Point() {

        }

        public Point(Point p) {
            x = p.x;
            y = p.y;
            c = p.c;
        }

        public void Draw() {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
            Console.SetCursorPosition(0, 0);
        }

        public void Move(Direction dir) {
            switch (dir) {
                case Direction.DOWN:
                    y += 1;
                    break;
                case Direction.LEFT:
                    x -= 1;
                    break;
                case Direction.RIGHT:
                    x += 1;
                    break;
            }
        }

        public void Hide() {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }
}
