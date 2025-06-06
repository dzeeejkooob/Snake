using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class Cordinate
    {
        public int x;
        public int y;

        public Cordinate()
        {
            x = 1;
            y = 1;
        }
        public Cordinate(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
