using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public abstract class IEvaluationFunction
    {
        public abstract int Evaluation(Board board, Symbol symbol);
    }

    public class EvaluationFunction : IEvaluationFunction
    {
        public EvaluationFunction()
        {
        }

        public int WinningScore { get; set; } = 100;

        public override int Evaluation(Board board, Symbol symbol)
        {
            int score = CountValue(symbol, board);
            int opponentScore = CountValue(Opposite.Symbol(symbol), board);
            if (score == WinningScore)
                return WinningScore;
            if (opponentScore == WinningScore)
                return -(WinningScore);
            return score - opponentScore;
        }

        private int CountValue(Symbol symbol, Board board)
        {
            int symbolsInARow = 0;
            int symbolsAndEmptyInARow = 0;
            int nonblockedSymbols = 0;
            int score = 0;

            // row
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.GetSymbol(i, j) == symbol)
                    {
                        GoodSymbol(ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow);
                    }
                    else
                    {
                        if (board.GetSymbol(i, j) == Symbol.Empty)
                        {
                            if (EmptySquare(ref symbolsAndEmptyInARow, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                        else
                        {
                            if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                    }
                }
                if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                {
                    return WinningScore;
                }
            }

            // column
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.GetSymbol(j, i) == symbol)
                    {
                        GoodSymbol(ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow);
                    }
                    else
                    {
                        if (board.GetSymbol(j, i) == Symbol.Empty)
                        {
                            if (EmptySquare(ref symbolsAndEmptyInARow, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                        else
                        {
                            if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                    }
                }
                if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                {
                    return WinningScore;
                }
            }

            // diagonal 1
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - i; j++)
                {
                    if (board.GetSymbol(j, i + j) == symbol)
                    {
                        GoodSymbol(ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow);
                    }
                    else
                    {
                        if (board.GetSymbol(j, i + j) == Symbol.Empty)
                        {
                            if (EmptySquare(ref symbolsAndEmptyInARow, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                        else
                        {
                            if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                    }
                }
                if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                {
                    return WinningScore;
                }
            }
            for (int i = 1; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - i; j++)
                {
                    if (board.GetSymbol(i + j, j) == symbol)
                    {
                        GoodSymbol(ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow);
                    }
                    else
                    {
                        if (board.GetSymbol(i + j, j) == Symbol.Empty)
                        {
                            if (EmptySquare(ref symbolsAndEmptyInARow, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                        else
                        {
                            if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                    }
                }
                if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                {
                    return WinningScore;
                }
            }

            // diagonal 2
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - i; j++)
                {
                    if (board.GetSymbol(j, board.Size - 1 - i - j) == symbol)
                    {
                        GoodSymbol(ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow);
                    }
                    else
                    {
                        if (board.GetSymbol(j, board.Size - 1 - i - j) == Symbol.Empty)
                        {
                            if (EmptySquare(ref symbolsAndEmptyInARow, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                        else
                        {
                            if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                    }
                }
                if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                {
                    return WinningScore;
                }
            }
            for (int i = 1; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - i; j++)
                {
                    if (board.GetSymbol(j + i, board.Size - 1 - j) == symbol)
                    {
                        GoodSymbol(ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow);
                    }
                    else
                    {
                        if (board.GetSymbol(j + i, board.Size - 1 - j) == Symbol.Empty)
                        {
                            if (EmptySquare(ref symbolsAndEmptyInARow, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                        else
                        {
                            if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                            {
                                return WinningScore;
                            }
                        }
                    }
                }
                if (Score(ref score, ref symbolsAndEmptyInARow, ref nonblockedSymbols, ref symbolsInARow, board) == true)
                {
                    return WinningScore;
                }
            }
            return score;
        }

        private bool Score(ref int score, ref int symbolsAndEmptyInARow, ref int nonblockedSymbols, ref int symbolsInARow, Board board)
        {
            if (symbolsInARow >= board.HowManyToWin)
            {
                return true;
            }
            if (symbolsAndEmptyInARow >= board.HowManyToWin)
            {
                score += nonblockedSymbols;
            }
            symbolsAndEmptyInARow = 0;
            nonblockedSymbols = 0;
            symbolsInARow = 0;
            return false;
        }

        private void GoodSymbol(ref int symbolsAndEmptyInARow, ref int nonblockedSymbols, ref int symbolsInARow)
        {
            symbolsAndEmptyInARow++;
            nonblockedSymbols++;
            symbolsInARow++;
        }

        private bool EmptySquare(ref int symbolsAndEmptyInARow, ref int symbolsInARow, Board plansza)
        {
            symbolsAndEmptyInARow++;
            if (symbolsInARow >= plansza.HowManyToWin)
            {
                return true;
            }
            symbolsInARow = 0;
            return false;
        }


        public bool Victory(Symbol symbol, Board board)
        {
            int symbolsInARow = 0;

            // row
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.GetSymbol(i, j) == symbol)
                    {
                        symbolsInARow++;
                    }
                    else
                    {
                        if (symbolsInARow >= board.HowManyToWin)
                        {
                            return true;
                        }
                        symbolsInARow = 0;
                    }
                }
                if (symbolsInARow >= board.HowManyToWin)
                {
                    return true;
                }
                symbolsInARow = 0;
            }

            // column
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if (board.GetSymbol(j, i) == symbol)
                    {
                        symbolsInARow++;
                    }
                    else
                    {
                        if (symbolsInARow >= board.HowManyToWin)
                        {
                            return true;
                        }
                        symbolsInARow = 0;
                    }
                }
                if (symbolsInARow >= board.HowManyToWin)
                {
                    return true;
                }
                symbolsInARow = 0;
            }

            // diagonal 1
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - i; j++)
                {
                    if (board.GetSymbol(j, i + j) == symbol)
                    {
                        symbolsInARow++;
                    }
                    else
                    {
                        if (symbolsInARow >= board.HowManyToWin)
                        {
                            return true;
                        }
                        symbolsInARow = 0;
                    }
                }
                if (symbolsInARow >= board.HowManyToWin)
                {
                    return true;
                }
                symbolsInARow = 0;
            }
            for (int i = 1; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - i; j++)
                {
                    if (board.GetSymbol(i + j, j) == symbol)
                    {
                        symbolsInARow++;
                    }
                    else
                    {
                        if (symbolsInARow >= board.HowManyToWin)
                        {
                            return true;
                        }
                        symbolsInARow = 0;
                    }
                }
                if (symbolsInARow >= board.HowManyToWin)
                {
                    return true;
                }
                symbolsInARow = 0;
            }

            // diagonal 2
            for (int i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - i; j++)
                {
                    if (board.GetSymbol(j, board.Size - 1 - i - j) == symbol)
                    {
                        symbolsInARow++;
                    }
                    else
                    {
                        if (symbolsInARow >= board.HowManyToWin)
                        {
                            return true;
                        }
                        symbolsInARow = 0;
                    }
                }
                if (symbolsInARow >= board.HowManyToWin)
                {
                    return true;
                }
                symbolsInARow = 0;
            }
            for (int i = 1; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size - i; j++)
                {
                    if (board.GetSymbol(j + i, board.Size - 1 - j) == symbol)
                    {
                        symbolsInARow++;
                    }
                    else
                    {
                        if (symbolsInARow >= board.HowManyToWin)
                        {
                            return true;
                        }
                        symbolsInARow = 0;
                    }
                }
                if (symbolsInARow >= board.HowManyToWin)
                {
                    return true;
                }
                symbolsInARow = 0;
            }
            return false;
        }
    }
    
}

