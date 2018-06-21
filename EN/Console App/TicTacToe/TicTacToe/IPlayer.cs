using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public abstract class IPlayer
    {
        public Symbol Symbol { get; }

        public IPlayer(Symbol symbol)
        {
            Symbol = symbol;
        }

        public abstract Move Play(Board board);
    }

    public class Human : IPlayer
    {
        public Human(Symbol symbol) : base(symbol)
        {
        }

        public override Move Play(Board board)
        {
            Move move = UserInteractions.GetCoords(board);
            return move;
        }
    }


    public class Computer : IPlayer
    {
        public Computer(Symbol symbol) : base(symbol)
        {
        }

        public Computer(Symbol symbol, int howManyLevels, bool alphaBeta) : base(symbol)
        {
            this.howManyLevels = howManyLevels;
            this.alphaBeta = alphaBeta;
        }

        private int howManyLevels = 6;
        private bool alphaBeta = true;
    
        public override Move Play(Board board)
        {
            if (alphaBeta)
            {
                var scoreMinMaxAlphaBeta = MinMaxAlphaBeta(board, howManyLevels, true, Int32.MinValue, Int32.MaxValue);
                return scoreMinMaxAlphaBeta.Item2;
            }
            else
            {
                var scoreMinMax = MinMax(board, howManyLevels, true);
                return scoreMinMax.Item2;
            }

        }

        
        private Tuple<int, Move> MinMax(Board board, int level, bool playerMax)
        {
            EvaluationFunction funkcjaOceny = new EvaluationFunction();
            LinkedList<Move> list = GeneratePositions(board);
            int tmpScore = 0;
            Move bestMove = new Move(-1, -1);
            if (level == 0 || list.Count == 0 || funkcjaOceny.Victory(Opposite.Symbol(Symbol), board) || funkcjaOceny.Victory(Symbol, board))
            {
                int score = funkcjaOceny.Evaluation(board, Symbol);
                return new Tuple<int, Move>(score, bestMove);
            }
            if (playerMax == true)
            {
                Int32 bestScore = Int32.MinValue;
                while (list.Count != 0)
                {
                    Move tmpMove = list.Last.Value;
                    list.RemoveLast();

                    Board boardCopy = board.Copy();
                    boardCopy.SetSymbol(tmpMove, Symbol);

                    tmpScore = MinMax(boardCopy, level - 1, false).Item1;
                    if (bestScore < tmpScore)
                    {
                        bestScore = tmpScore;
                        bestMove = tmpMove;
                    }
                }
                return new Tuple<int, Move>(bestScore, bestMove);
            }
            else
            {
                Int32 bestScore = Int32.MaxValue;
                while (list.Count != 0)
                {
                    Move tmpMove = list.Last.Value;
                    list.RemoveLast();

                    Board boardCopy = board.Copy();
                    boardCopy.SetSymbol(tmpMove, Opposite.Symbol(Symbol));

                    tmpScore = MinMax(boardCopy, level - 1, true).Item1;
                    if (bestScore > tmpScore)
                    {
                        bestScore = tmpScore;
                        bestMove = tmpMove;
                    }
                }
                return new Tuple<int, Move>(bestScore, bestMove);
            }
        }


        private Tuple<int, Move> MinMaxAlphaBeta(Board board, int level, bool playerMax, int alpha, int beta)
        {
            EvaluationFunction funkcjaOceny = new EvaluationFunction();
            LinkedList<Move> list = GeneratePositions(board);
            int tmpScore = 0;
            Move bestMove = new Move(-1, -1);
            if (level == 0 || list.Count == 0 || funkcjaOceny.Victory(Opposite.Symbol(Symbol), board) || funkcjaOceny.Victory(Symbol, board))
            {
                int score = funkcjaOceny.Evaluation(board, Symbol);
                return new Tuple<int, Move>(score, bestMove);
            }
            if (playerMax == true)
            {
                while (list.Count != 0)
                {
                    Move tmpMove = list.Last.Value;
                    list.RemoveLast();

                    Board boardCopy = board.Copy();
                    boardCopy.SetSymbol(tmpMove, Symbol);

                    tmpScore = MinMaxAlphaBeta(boardCopy, level - 1, false, alpha, beta).Item1;
                    if (alpha < tmpScore)
                    {
                        alpha = tmpScore;
                        bestMove = tmpMove;
                    }
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return new Tuple<int, Move>(alpha, bestMove);
            }
            else
            {
                while (list.Count != 0)
                {
                    Move tmpMove = list.Last.Value;
                    list.RemoveLast();

                    Board boardCopy = board.Copy();
                    boardCopy.SetSymbol(tmpMove, Opposite.Symbol(Symbol));

                    tmpScore = MinMaxAlphaBeta(boardCopy, level - 1, true, alpha, beta).Item1;
                    if (beta > tmpScore)
                    {
                        beta = tmpScore;
                        bestMove = tmpMove;
                    }
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return new Tuple<int, Move>(beta, bestMove);
            }
        }


        private LinkedList<Move> GeneratePositions(Board board)
        {
            LinkedList<Move> list = new LinkedList<Move>();
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.GetSymbol(i, j) == Symbol.Empty)
                    {
                        Move move = new Move(i, j);
                        list.AddLast(move);
                    }
                }
            }
            return list;
        }
    }
    
    public class Move
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Move(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Move()
        {
        }
    }
}

