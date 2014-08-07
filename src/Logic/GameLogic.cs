using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3D2048.Util;
using System.Diagnostics;

namespace _3D2048.Logic
{
    class GameLogic
    {
        public GameState gameModel  {get; private set;}

        public GameLogic()
        {
            gameModel = new GameState();
        }

        public Direction getMoveDependentDirection(Direction direction, Camera gameCamera)
        {
            Direction outputDirection = direction;

            // REMOVEME: return only normal directions
            //return direction;

            switch (gameCamera.getFrontFace())
            {
                case CubeFace.FRONT:
                    // Directions don't need to be changed
                    outputDirection = direction;
                    break;
                case CubeFace.LEFT:
                    if (direction == Direction.Forward)
                    {
                        outputDirection = Direction.Left;
                    }
                    else if (direction == Direction.Back)
                   {
                        outputDirection = Direction.Right;
                    }
                    else if (direction == Direction.Right)
                    {
                        outputDirection = Direction.Forward;
                    }
                    else if (direction == Direction.Left)
                    {
                        outputDirection = Direction.Back;
                    }
                    else
                    {
                        outputDirection = direction; //Up/Down: No change
                    }
                    break;
                case CubeFace.BACK:
                    if (direction == Direction.Forward)
                    {
                        outputDirection = Direction.Back;
                    }
                    else if (direction == Direction.Back)
                    {
                        outputDirection = Direction.Forward;
                    }
                    else if (direction == Direction.Right)
                    {
                        outputDirection = Direction.Left;
                    }
                    else if (direction == Direction.Left)
                    {
                        outputDirection = Direction.Right;
                    }
                    else
                    {
                        outputDirection = direction; //Up/Down: No change
                    }
                    break;
                case CubeFace.RIGHT:
                    if (direction == Direction.Forward)
                    {
                        outputDirection = Direction.Right;
                    }
                    else if (direction == Direction.Back)
                    {
                        outputDirection = Direction.Left;
                    }
                    else if (direction == Direction.Right)
                    {
                        outputDirection = Direction.Back;
                    }
                    else if (direction == Direction.Left)
                    {
                        outputDirection = Direction.Forward;
                    }
                    else
                    {
                        outputDirection = direction; //Up/Down: No change
                    }
                    break;
                default:
                    outputDirection = direction;
                    break;
            }

            return outputDirection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="axis">The axis along to collapse. Must be 0, 1 or 2 (for x, y, and z)</param>
        /// <param name="stepDir">Either +1 or -1 for the direction in which to collapse</param>
        private void collapse(int axis, int stepDir) 
        {
            int[] pos = new int[3];
            int[] nextPos = new int[3];

            // enumerate all stacks to collapse
            for (int i = 0; i < GameState.size; i++)
            {
                for (int j = 0; j < GameState.size; j++)
                {
                    bool modified;
                    do
                    {
                        modified = false;

                        pos[axis] = stepDir > 0 ? GameState.size - 1 : 0;
                        pos[(axis + 1) % 3] = i;
                        pos[(axis + 2) % 3] = j;

                        // for each stack element
                        for (int l = 0; l < GameState.size - 1; l++)
                        {
                            Array.Copy(pos, nextPos, 3);
                            nextPos[axis] -= stepDir;

                            if (gameModel.field[pos[0], pos[1], pos[2]] == 0)
                            {
                                if(gameModel.field[nextPos[0], nextPos[1], nextPos[2]] != 0)
                                {
                                    // move number from next to pos
                                    gameModel.field[pos[0], pos[1], pos[2]] = gameModel.field[nextPos[0], nextPos[1], nextPos[2]];
                                    gameModel.field[nextPos[0], nextPos[1], nextPos[2]] = 0;
                                    modified = true;
                                }
                            }
                            else if (gameModel.field[pos[0], pos[1], pos[2]] == gameModel.field[nextPos[0], nextPos[1], nextPos[2]]) // previous condition ensures that pos and nextPos are not 0
                            {
                                Debug.Assert(gameModel.field[pos[0], pos[1], pos[2]] != 0);

                                // combine numbers into pos
                                gameModel.field[pos[0], pos[1], pos[2]] *= 2;
                                gameModel.field[nextPos[0], nextPos[1], nextPos[2]] = 0;
                                modified = true;
                            }

                            Array.Copy(nextPos, pos, 3);
                        }
                    }
                    while (modified);
                }
            }
        }

        public void Move(Direction direction)
        {
            // collapse current numbers
            switch (direction)
            {
                case Logic.Direction.Right:   collapse(0, +1); break;
                case Logic.Direction.Left:    collapse(0, -1); break;
                case Logic.Direction.Up:      collapse(1, +1); break;
                case Logic.Direction.Down:    collapse(1, -1); break;
                case Logic.Direction.Back:    collapse(2, -1); break;
                case Logic.Direction.Forward: collapse(2, +1); break;
            }

            // randomly insert a new 2
            bool freeField = false;

            for (int l = 0; l < GameState.size; l++)
            {
                for (int j = 0; j < GameState.size; j++)
                {
                    for (int i = 0; i < GameState.size; i++)
                    {
                        if (gameModel.field[i, j, l] == 0)
                        {
                            freeField = true;
                        }
                        
                        else if(gameModel.field[i, j, l] == 2048)
                        {
                            gameModel.won = true;
                        }
                    }
                }
            }

            if (freeField == false)
            {

                gameModel.lost = true;
            }

            Random random = new Random();
            int nullCounter = 0;

            for (int l = 0; l < GameState.size; l++)
            {
                for (int j = 0; j < GameState.size; j++)
                {
                    for (int i = 0; i < GameState.size; i++)
                    {
                        if (gameModel.field[i, j, l] == 0)
                        {
                            nullCounter++;
                        }

                    }
                }
            }

            int randomNull = random.Next(0, nullCounter);
            nullCounter = 0;
            bool nullSet = false;
            for (int l = 0; l < GameState.size && nullSet == false; l++)
            {
                for (int j = 0; j < GameState.size && nullSet == false; j++)
                {
                    for (int i = 0; i < GameState.size && nullSet == false; i++)
                    { 
                        if (gameModel.field[i, j, l] == 0)
                        {
                            if (randomNull == nullCounter)
                            {
                                nullSet = true;
                                Debug.Assert(gameModel.field[i, j, l] == 0);
                                gameModel.field[i, j, l] = 2; // FIXME: this can overwrite following number 

                            }
                            nullCounter++;
                        }
                    }
                }
            }

        }
    }
}
