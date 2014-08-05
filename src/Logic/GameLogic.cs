using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D2048.Logic
{
    class GameLogic
    {
        public GameState gameModel;

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
                              if (gameModel.field[i, j, l] == 0)
                                {
                                    gameModel.field[i + 1, j, l] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
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

                     for (int i = 3; i > 0; i--)
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

                    for (int j = 3; j > 0; j--)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                              if (gameModel.field[i, j, l] == 0)
                                {
                                    gameModel.field[i , j-1, l] = gameModel.field[i, j, l];
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

                      for (int j = 0; j < 3; j++)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                              if (gameModel.field[i, j, l] == 0)
                                {
                                    gameModel.field[i , j+1, l] = gameModel.field[i, j, l];
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

                case Logic.Direction.Back:

                    for (int l = 0; l < 3; l++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (gameModel.field[i, j, l] == 0)
                                {
                                    gameModel.field[i, j, l+1] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i, j, l + 1])
                                {
                                    gameModel.field[i, j, l + 1] = gameModel.field[i, j, l + 1] + gameModel.field[i, j, l];
                                }


                            }
                        }
                    }

                    break;
                case Logic.Direction.Forward:

                    for (int l = 3; l > 0; l--)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                if (gameModel.field[i, j, l] == 0)
                                {
                                    gameModel.field[i, j, l - 1] = gameModel.field[i, j, l];
                                    gameModel.field[i, j, l] = 0;
                                }

                                else if (gameModel.field[i, j, l] == gameModel.field[i, j, l - 1])
                                {
                                    gameModel.field[i, j, l - 1] = gameModel.field[i, j, l - 1] + gameModel.field[i, j, l];
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

           bool freeSpawn = false;
            int ii;
            int jj;
            int ll;
           while (freeSpawn == false ) {
            Random x = new Random();
           
            int randomX = x.Next(0, 2);
            if (randomX >= 1)
            {
                ii = 3;
            }
            else
            {
                ii = 0;
            }

            Random y = new Random();

            int randomY = y.Next(0, 2);
            if (randomY >= 1)
            {
                jj = 3;
            }
            else
            {
                jj = 0;
            }
            Random z = new Random();

            int randomZ = z.Next(0, 2);
            if (randomZ >= 1)
            {
                ll = 3;
            }
            else
            {
                ll = 0;
            }
            if (gameModel.field[ii, jj, ll] == 0)
            {
                gameModel.field[ii, jj, ll] = 2;
                freeSpawn = true;
            }
        }
             
        }
    }
}
