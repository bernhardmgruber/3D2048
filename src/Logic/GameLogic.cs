using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Logic
{
    class GameLogic
    {
        public GameState gameModel = new GameState();

        public GameLogic() {
		
		}

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
                                 if (gameModel.field[i,j,l] == 0) 
                                    {
                                       gameModel.field[i+1,j,l] = gameModel.field[i,j,l];
                                       gameModel.field[i,j,l] = 0; 
                                    }

                                 else if (gameModel.field[i, j, l] == gameModel.field[i + 1, j, l])
                                 {
                                     gameModel.field[i + 1, j, l] = gameModel.field[i + 1, j, l] + gameModel.field[i, j, l];
                                 }
                                 
                                 
                            }
                        }
                    }

                    break;

                case Logic.Direction.Left:

                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                                if (gameModel.field[i, j, l] == 0)
                                {
                                    gameModel.field[i - 1, j, l] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i - 1, j, l])
                                {
                                    gameModel.field[i - 1, j, l] = gameModel.field[i - 1, j, l] + gameModel.field[i, j, l];
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
                                if (gameModel.field[i, j, l] == 0)
                                {
                                    gameModel.field[i, j-1, l] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i, j-1, l])
                                {
                                    gameModel.field[i, j-1, l] = gameModel.field[i, j-1, l] + gameModel.field[i, j, l];
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
                                if (gameModel.field[i, j, l] == 0)
                                {
                                    gameModel.field[i, j+1, l] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i, j+1, l])
                                {
                                    gameModel.field[i, j+1, l] = gameModel.field[i, j+1, l] + gameModel.field[i, j, l];
                                }


                            }
                        }
                    }

                    break;

                case Logic.Direction.Forward:

                    break;
                case Logic.Direction.Back:

                    break;
            }
        }
    }
}
