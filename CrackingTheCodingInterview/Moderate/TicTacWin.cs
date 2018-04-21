using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview.Moderate
{
    class TicTacWin : ISolution
    {
        enum Player { Red, Blue, None}
        
        class Cell
        {
            public bool IsPlayed { get; private set; }
            public Player Player { get; private set; }
            public void Play(Player player)
            {
                if (!IsPlayed)
                {
                    IsPlayed = true;
                    Player = player;
                }
            }
        }
        class Game
        {
            public Game(int height, int width)
            {
                Cells = new List<List<Cell>>();
                for (int h = 0; h < height; h++)
                {
                    var row = new List<Cell>();
                    for(int w = 0; w < width; w++)
                    {
                        row.Add(new Cell());
                    }
                    Cells.Add(row);
                }
                Width = width;
                Height = height;
            }
            public int Width { get; private set; }
            public int Height { get; private set; }
            public List<List<Cell>> Cells { get; private set; }

        }
        const int NEED_TO_WIN = 4;
        Player WhoWon(Game game)
        {
            for(int h = 0; h < game.Height; h++)
            {
                for(int w = 0; w < game.Width; w++)
                {
                    var cell = game.Cells[h][w];
                    if (cell.IsPlayed)
                    {
                        var player = cell.Player;
                        if (h + (NEED_TO_WIN - 1) <= game.Height)
                        {
                            bool hasWon = true;
                            for (int i = 1; i < NEED_TO_WIN; i++)
                            {
                                var up = game.Cells[h + i][w];
                                if (!up.IsPlayed || (up.IsPlayed && up.Player != player))
                                {
                                    hasWon = false;
                                    break;
                                }
                            }
                            if (hasWon)
                            {
                                return player;
                            }
                        }
                        if (h - (NEED_TO_WIN - 1) >= 0)
                        {
                            bool hasWon = true;
                            for (int i = 1; i < NEED_TO_WIN; i++)
                            {
                                var up = game.Cells[h - i][w];
                                if (!up.IsPlayed || (up.IsPlayed && up.Player != player))
                                {
                                    hasWon = false;
                                    break;
                                }
                            }
                            if (hasWon)
                            {
                                return player;
                            }
                        }
                        if (w + (NEED_TO_WIN - 1) <= game.Width)
                        {
                            bool hasWon = true;
                            for (int i = 1; i < NEED_TO_WIN; i++)
                            {
                                var up = game.Cells[h][w + i];
                                if (!up.IsPlayed || (up.IsPlayed && up.Player != player))
                                {
                                    hasWon = false;
                                    break;
                                }
                            }
                            if (hasWon)
                            {
                                return player;
                            }
                        }
                        if (w - (NEED_TO_WIN - 1) >= 0)
                        {
                            bool hasWon = true;
                            for (int i = 1; i < NEED_TO_WIN; i++)
                            {
                                var up = game.Cells[h][w - i];
                                if (!up.IsPlayed || (up.IsPlayed && up.Player != player))
                                {
                                    hasWon = false;
                                    break;
                                }
                            }
                            if(hasWon)
                            {
                                return player;
                            }
                        }
                    }
                }
            }
            return Player.None;
    }

        public void Test()
        {
            {
                Game g = new Game(1, 4);
                g.Cells[0][0].Play(Player.Red);
                g.Cells[0][1].Play(Player.Red);
                g.Cells[0][2].Play(Player.Red);
                g.Cells[0][3].Play(Player.Red);
                Assert.That(WhoWon(g) == Player.Red);
            }
            {
                Game g = new Game(1, 4);
                g.Cells[0][0].Play(Player.Red);
                g.Cells[0][1].Play(Player.Red);
                g.Cells[0][2].Play(Player.Red);
                g.Cells[0][3].Play(Player.Blue);
                Assert.That(WhoWon(g) == Player.None);
            }
        }
    }
}
