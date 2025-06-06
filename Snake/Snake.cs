using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Snake : ISnake
    {
        public int Length { get; set; } = 1;
        public Direction Direction { get; set; } = Direction.Right;
        public Cordinate HeadPosition { get; set; } = new Cordinate();
        public List<Cordinate> Tail { get; set; } = new List<Cordinate>();
        private bool outOfRange = false;

        public bool gameOver
        {
            get
            {
                bool hitTail = Tail.Where(c => c.x == HeadPosition.x && c.y == HeadPosition.y).ToList().Count > 1;
                bool hitWall = HeadPosition.x <= 0 || HeadPosition.x >= 29 || HeadPosition.y <= 0 || HeadPosition.y >= 29;
                return hitTail || hitWall;
            }
        }
        public void EatMeal()
        {
            Length+=1;
        }
        public void EatMealExtra()
        {
            Length += 3;
        }
        public void Move()
        {
            switch (Direction)
            {
                case Direction.Left:
                    HeadPosition.x--;
                    break;
                case Direction.Right:
                    HeadPosition.x++;
                    break;
                case Direction.Up:
                    HeadPosition.y--;
                    break;
                case Direction.Down:
                    HeadPosition.y++;
                    break;
            }
            try
            {
                Console.SetCursorPosition(HeadPosition.x, HeadPosition.y);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("@");
                Tail.Add(new Cordinate(HeadPosition.x, HeadPosition.y));
                if(Tail.Count > this.Length)
                {
                    var endTail = Tail.First();
                    Console.SetCursorPosition(endTail.x, endTail.y);
                    Console.Write(" ");
                    Tail.Remove(endTail);
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                outOfRange = true;
            }
        }
    }
    public enum Direction {Left, Right, Up, Down}
}
