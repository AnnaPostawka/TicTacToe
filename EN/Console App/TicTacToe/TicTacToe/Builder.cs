using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Builder
    {
        private readonly GameMaster gameMaster;

        public Builder()
        {
            IPlayer player1 = CreatePlayer(1, Symbol.X);
            IPlayer player2 = CreatePlayer(2, Symbol.O);
            Board board = CreateBoard();
            gameMaster = new GameMaster(player1, player2, board);
        }

        private IPlayer CreatePlayer(int nr, Symbol symbol)
        {
            IPlayer player;
            bool isHuman = UserInteractions.GetPlayer(nr);
            if (isHuman)
            {
                player = new Human(symbol);
            }
            else
            {
                int howManyLevels = 0;
                bool alphaBeta = UserInteractions.WhichAlgorithm(ref howManyLevels);
                player = new Computer(symbol, howManyLevels, alphaBeta);
            }
            return player;
        }

        private Board CreateBoard()
        {
            int size = UserInteractions.GetSize();
            int howManyToWin = UserInteractions.GetHowManyToWin(size);
            Board board = new Board(size, howManyToWin);
            return board;
        }

        public GameMaster CreateGameMaster()
        {
            return gameMaster;
        }
    }
}
