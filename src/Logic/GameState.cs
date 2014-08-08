using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Logic
{
    class GameState
    {
        public static int size = 3;
        public int score = 0;

        public int [, ,] field = new int[size, size, size];
        public bool lost = false;
        public bool won = false;
        public bool pause = false;
        public bool started = false;
     
    }
}
