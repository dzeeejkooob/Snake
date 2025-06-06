using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Slow:Meal
    {
        public async void NewDelayedDraw()
        {
            await Task.Delay(10000);
            Draw();
        }
        void Draw()
        {
            Console.SetCursorPosition(CurrnetTarget.x, CurrnetTarget.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("s");
        }

    }
}
