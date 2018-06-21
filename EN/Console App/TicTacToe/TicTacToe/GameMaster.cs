using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class GameMaster
    {
        private IPlayer player1;
        private IPlayer player2;
        private Board board;
        private Displayer displayer = new Displayer();

        public GameMaster(IPlayer player1, IPlayer player2, Board board)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.board = board;
        }

        public void Play()
        {
            Displayer.DisplayBoard(board);

            int numberOfMoves = 0;
            bool victory = false;
            IPlayer currentPlayer = player1;

            while(victory != true && numberOfMoves < board.NumberOfSquares)
            {
                victory = MakeAMove(currentPlayer);
                Displayer.DisplayBoard(board);
                if (victory == true)
                {
                    Console.WriteLine("Player {0} won!", currentPlayer.Symbol);
                }
                if(numberOfMoves == board.NumberOfSquares - 1)
                {
                    victory = true;
                    Console.WriteLine("Draw. End of the game.");
                }
                currentPlayer = TheOtherOne(currentPlayer);
                numberOfMoves++;
            }
        }

        private bool MakeAMove(IPlayer player)
        {
            Move move = player.Play(board);            
            board.SetSymbol(move.X, move.Y, player.Symbol);

            EvaluationFunction funkcjaOceny = new EvaluationFunction();
            if (funkcjaOceny.Victory(player.Symbol, board) == true)
            {
                return true;
            }
            return false;
        }


        private IPlayer TheOtherOne(IPlayer player)
        {
            if (player == player1)
                return player2;
            else
                return player1;
        }
    }
}
