using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_Tetris
{
    public static class Drawer
    {
        public const char DEFAULT_SYMBOL = '*';

        public static void DrawPoint(int x, int y, char c = DEFAULT_SYMBOL)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(c);
            Console.SetCursorPosition(0, 0);
        }

        public static void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(' ');
            Console.SetCursorPosition(0, 0);
        }
    }
}
