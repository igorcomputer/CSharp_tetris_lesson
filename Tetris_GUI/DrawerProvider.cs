using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson_Tetris
{
    static class DrawerProvider
    {
        private static IDrawer _drawer = new GuiDrawer();

        public static IDrawer Drawer
        {
            get
            {
                return _drawer;
            }
        }

    }
}
