using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;

namespace Tetris_GUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Turtle.Show();
            //Turtle.Move(100);
            //Turtle.TurnLeft();
            //Turtle.Move(100);
            //Turtle.Speed++;
            //Turtle.Move(100);

            GraphicsWindow.Width = 100;
            GraphicsWindow.Height = 100;
            GraphicsWindow.BackgroundColor = "LightBlue";
            GraphicsWindow.PenColor = "red";
            GraphicsWindow.DrawRectangle(20, 20, 10, 10);
        }
    }
}
