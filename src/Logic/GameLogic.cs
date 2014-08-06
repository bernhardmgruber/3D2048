using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3D2048.Util;

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
            return direction;

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
                    else if (direction == Direction.Right)
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

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Logic.Direction.Right:

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                              if (gameModel.field[i+1, j, l] == 0)
                                {
                                    gameModel.field[i + 1, j, l] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i + 1, j, l])
                                {
                                    gameModel.field[i + 1, j, l] = gameModel.field[i + 1, j, l] + gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }
                            }
                        }
                    }

                    break;

                case Logic.Direction.Left:

                     for (int i = 3; i > 0; i--)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                              if (gameModel.field[i-1, j, l] == 0)
                                {
                                    gameModel.field[i - 1, j, l] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i - 1, j, l])
                                {
                                    gameModel.field[i - 1, j, l] = gameModel.field[i - 1, j, l] + gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }
                            }
                        }
                    }

                    break;

                case Logic.Direction.Up:

                    for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                              if (gameModel.field[i, j+1, l] == 0)
                                {
                                    gameModel.field[i , j+1, l] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i, j+1, l])
                                {
                                    gameModel.field[i, j + 1, l] = gameModel.field[i, j + 1, l] + gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }
                            }
                        }
                    }

                    break;

                case Logic.Direction.Down:

                      for (int j = 3; j > 0; j--)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                              if (gameModel.field[i, j-1, l] == 0)
                                {
                                    gameModel.field[i , j-1, l] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i, j-1, l])
                                {
                                    gameModel.field[i, j-1, l] = gameModel.field[i, j-1, l] + gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }
                            }
                        }
                    }

                    break;

                case Logic.Direction.Back:

                    for (int l = 3; l > 0; l--)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (gameModel.field[i, j, l-1] == 0)
                                {
                                    gameModel.field[i, j, l-1] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i, j, l - 1])
                                {
                                    gameModel.field[i, j, l - 1] = gameModel.field[i, j, l - 1] + gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }


                            }
                        }
                    }

                    break;
                case Logic.Direction.Forward:

                    for (int l = 0; l < 3; l++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (gameModel.field[i, j, l+1] == 0)
                                {
                                    gameModel.field[i, j, l + 1] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i, j, l + 1])
                                {
                                    gameModel.field[i, j, l + 1] = gameModel.field[i, j, l + 1] + gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }


                            }
                        }
                    }
                    break;
            }

            bool freeField = false;

            for (int l = 0; l < 4; l++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 4; i++)
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

            for (int l = 0; l < 4; l++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 4; i++)
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

            for (int l = 0; l < 4; l++)
            {
                for (int j = 0; j < 4; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (gameModel.field[i, j, l] == 0)
                        {
                            nullCounter++;
                        }
                        if (randomNull == nullCounter)
                        
                        {
                            gameModel.field[i, j, l] = 2;

                        }

                    }
                }
            }


     
             
        }
    }
}
