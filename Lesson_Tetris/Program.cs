﻿using System;
using System.Threading;

namespace Lesson_Tetris {
    class Program {
        static void Main(string[] args) {

            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            FigureGenerator generator = new FigureGenerator(20, 0, '*');
            Figure s;

            while (true) {
                s = generator.GetNewFigure();
                s.Draw();

                for (int i = 0; i < 15; i++) {
                    s.Hide();
                    s.Move(Direction.DOWN);
                    s.Draw();
                    Thread.Sleep(200);
                }

            }

            Console.ReadLine();

        }

    }
}
