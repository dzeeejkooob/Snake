using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class MealExtra : Meal
    {
        public async void NewDelayedDraw()
        {
            await Task.Delay(7000);
            Draw();
        }
        void Draw()
        {
            Console.SetCursorPosition(CurrnetTarget.x, CurrnetTarget.y);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("$");
        }
    }
}
