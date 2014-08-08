using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Logic
{
    class GameState
    {
        public int score = 0;
        public int gameSize;
        public int [, ,] field;
        public bool lost = false;
        public bool won = false;
        public bool pause = false;
        public bool started = false;

        public bool pauseNextButton = false;
        public bool pausePressButton = false;

        public GameState(int gameSize)
        {
            this.gameSize = gameSize;
            field = new int[gameSize, gameSize, gameSize];
        }

        public GameState()
        {
            this.gameSize = 0;
        }

    }
}
