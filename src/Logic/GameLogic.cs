using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Logic
{
    class GameLogic
    {
        /*public GameState gameModel;

        public GameLogic()*/
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Logic.Direction.Right:

                    for (int i = 3; i > 0; i--)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                               //GameState.field
                            }
                        }
                    }

                    break;

                case Logic.Direction.Left:

                    break;

                case Logic.Direction.Up:

                    break;

                case Logic.Direction.Down:

                    break;

                case Logic.Direction.Forward:

                    break;
                case Logic.Direction.Back:

                    break;
            }
        }
    }
}
