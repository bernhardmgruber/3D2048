using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Logic
{
    class GameState
    {
        public const int size = 4;
        public int [, ,] field = new int[size, size, size];
        public bool lost = false;
        public bool won = false;

     
    }
}
