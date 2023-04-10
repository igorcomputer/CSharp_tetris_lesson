using System;
using System.Threading;

namespace Lesson_Tetris
{
    class Program
    {
        static FigureGenerator generator = new FigureGenerator(Field.Width / 2, 0, '*');
        static Figure currentFigure = generator.GetNewFigure();

        static void Main(string[] args)
        {
            Field.Width = 20;
            Field.Height = 20;

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                }
            }
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();
                currentFigure = generator.GetNewFigure();
                return true;
            } else
                return false;
        }

        private static Result HandleKey(Figure f, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                return f.TryMove(Direction.LEFT);
                case ConsoleKey.RightArrow:
                return f.TryMove(Direction.RIGHT);
                case ConsoleKey.DownArrow:
                return f.TryMove(Direction.DOWN);
                case ConsoleKey.Spacebar:
                return f.TryRotate();
            }
            return Result.SUCCESS;
        }
    }
}
