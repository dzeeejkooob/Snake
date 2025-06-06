using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Snake
{
    public class Meal
    {

        public Cordinate CurrnetTarget;

        public Meal()
        {
            Random rand = new Random();
            var x = rand.Next(2, 29);
            var y = rand.Next(2, 29);
            CurrnetTarget = new Cordinate(x, y);
        }

        public async void DelayedDraw()
        {
            await Task.Delay(1000);
            Draw();
        }
        void Draw()
        {
            Console.SetCursorPosition(CurrnetTarget.x, CurrnetTarget.y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("o");
        }
    }
}
