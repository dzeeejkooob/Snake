using System;
using System.Diagnostics;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int width = 30;  // szerokość pola gry
            int height = 30; // wysokość pola gry
            //ramka i info
            Frame.DrawFrame(width, height);

            bool esc = false;
            double time = 1000 / 5.0;
            DateTime lastDate = DateTime.Now;

            //tworzenie węża
            Snake snake = new Snake();

            //jedzenie i spowalniacze
            Meal meal = new Meal();
            meal.DelayedDraw();
            MealExtra mealExtra = new MealExtra();
            mealExtra.NewDelayedDraw();
            Slow slow = new Slow();
            slow.NewDelayedDraw();

            //game loop
            while (!esc)
            {
                if (Console.KeyAvailable) 
                {
                    ConsoleKeyInfo input = Console.ReadKey();
                    //sterowanie 
                    switch (input.Key)
                    {
                        //esc
                        case ConsoleKey.Escape:
                            esc = true;
                            break;
                        //right
                        case ConsoleKey.RightArrow:
                            if(snake.Direction!=Direction.Left)
                            snake.Direction = Direction.Right;
                            break;
                        //left
                        case ConsoleKey.LeftArrow:
                            if(snake.Direction!=Direction.Right)
                            snake.Direction = Direction.Left;
                            break;
                        //up
                        case ConsoleKey.UpArrow:
                            if(snake.Direction!=Direction.Down)
                            snake.Direction = Direction.Up;
                            break;
                        //down
                        case ConsoleKey.DownArrow:
                            if(snake.Direction!=Direction.Up)
                            snake.Direction = Direction.Down;
                            break;
                    }
                }
                if ((DateTime.Now - lastDate).TotalMilliseconds >= time)
                {
                    //game action
                    snake.Move();
                    if (meal.CurrnetTarget.x == snake.HeadPosition.x
                        && meal.CurrnetTarget.y == snake.HeadPosition.y)
                    {
                        snake.EatMeal();
                        meal = new Meal();
                        meal.DelayedDraw();
                        time /= 1.05;
                    }
                    else if (mealExtra.CurrnetTarget.x == snake.HeadPosition.x
                        && mealExtra.CurrnetTarget.y == snake.HeadPosition.y)
                    {
                        snake.EatMealExtra();
                        mealExtra = new MealExtra();
                        mealExtra.NewDelayedDraw();
                        time /= 1.05;
                    }
                    else if(slow.CurrnetTarget.x == snake.HeadPosition.x
                        && slow.CurrnetTarget.y == snake.HeadPosition.y)
                    {
                        slow = new Slow();
                        slow.NewDelayedDraw();
                        time *= 1.05;
                    }
                    if (snake.gameOver)
                    {
                        Console.Clear();
                        Console.WriteLine($"GAME OVER! YOUR SCORE: " + snake.Length);
                        esc = true;
                        Console.ReadLine();
                    }
                    lastDate = DateTime.Now;
                }
            }
        }
    }
}