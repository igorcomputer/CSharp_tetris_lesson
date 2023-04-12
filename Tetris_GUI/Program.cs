using System;
using System.Threading;
using System.Timers;
using Microsoft.SmallBasic.Library;

namespace Lesson_Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static System.Timers.Timer timer;
        static private Object _lockObject = new object();

        static FigureGenerator generator;
        static Figure currentFigure;
        static bool gameOver = false;

        static void Main(string[] args)
        {

            DrawerProvider.Drawer.InitField();

            generator = new FigureGenerator(Field.Width / 2, 0);
            currentFigure = generator.GetNewFigure();

            SetTimer();

            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;

        }

        private static void GraphicsWindow_KeyDown()
        {
            Monitor.Enter(_lockObject);

            var result = HandleKey(currentFigure, GraphicsWindow.LastKey);

            if(GraphicsWindow.LastKey == "Down")
            {
                gameOver = ProcessResult(result, ref currentFigure);
            }

            Monitor.Exit(_lockObject);
        }

        private static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if (currentFigure.IsOnTop())
                {
                    DrawerProvider.Drawer.WriteGameOver();
                    timer.Elapsed -= OnTimerEvent;
                    return true;
                } else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }

            } else
                return false;
        }

        private static Result HandleKey(Figure f, String key)
        {
            switch (key)
            {
                case "Left":
                    return f.TryMove(Direction.LEFT);
                case "Right":
                    return f.TryMove(Direction.RIGHT);
                case "Down":
                    return f.TryMove(Direction.DOWN);
                case "Space":
                    return f.TryRotate();
            }
            return Result.SUCCESS;
        }

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimerEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimerEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            gameOver = ProcessResult(result, ref currentFigure);
            if (gameOver)
                timer.Stop();
            Monitor.Exit(_lockObject);

        }
    }
}
