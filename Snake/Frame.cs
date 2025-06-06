using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Frame
    {
        public static void DrawFrame(int width, int height)
        {
            // Górna krawędź
            Console.SetCursorPosition(0, 0);
            Console.Write("+");
            for (int x = 1; x < width - 1; x++)
                Console.Write("-");
            Console.Write("+");

            // Boki
            for (int y = 1; y < height - 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("|");
                Console.SetCursorPosition(width - 1, y);
                Console.Write("|");
            }

            // Dolna krawędź
            //height + 1 bo wtedy szerokość np32 a pole gry 30
            Console.SetCursorPosition(0, height - 1);
            Console.Write("+");
            for (int x = 1; x < width - 1; x++)
                Console.Write("-");
            Console.Write("+");

            Console.SetCursorPosition(40, 10);
            Console.WriteLine("0 - Length+=1");
            Console.SetCursorPosition(40, 11);
            Console.WriteLine("$ - Length+=3");
            Console.SetCursorPosition(40, 12);
            Console.WriteLine("s - Slow");
        }
    }
}
