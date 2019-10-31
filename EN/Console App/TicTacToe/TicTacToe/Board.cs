using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{ 
    public class Board
    {
        public int Size { get; }
        public int HowManyToWin { get; }
        private Square[,] Grid = null;
        public int NumberOfSquares { get; }
        public int NonEmpty { get; private set; }

        public Board(int size, int howManyToWin)
        {
            Size = size;
            HowManyToWin = howManyToWin;
            CreateGrid();
            NumberOfSquares = Grid.Length;
            NonEmpty = 0;
        }
        
        public void SetSymbol(int x, int y, Symbol symbol)
        {
            if(Grid[x, y].Symbol != Symbol.Empty)
            {
                throw new Exception();
            }
            Grid[x, y].Symbol = symbol;
            NonEmpty++;
        }

        public void SetSymbol(Move move, Symbol symbol)
        {
            if (Grid[move.X, move.Y].Symbol != Symbol.Empty)
            {
                throw new Exception();
            }
            Grid[move.X, move.Y].Symbol = symbol;
            NonEmpty++;
        }

        public Square SetSymbol(int x, int y)
        {
            if (Grid[x, y].Symbol != Symbol.Empty)
            {
                throw new Exception();
            }
            NonEmpty++;
            return Grid[x, y];
        }

        public Square SetSymbol(Move move)
        {
            if (Grid[move.X, move.Y].Symbol != Symbol.Empty)
            {
                throw new Exception();
            }
            NonEmpty++;
            return Grid[move.X, move.Y];
        }

        public Symbol GetSymbol(int x, int y)
        {
            return Grid[x, y].Symbol;
        }

        public Symbol GetSymbol(Move move)
        {
            return Grid[move.X, move.Y].Symbol;
        }

        private void CreateGrid()
        {
            Grid = new Square[Size, Size];
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Grid[i, j] = new Square();
                }
            }
        }

        public Board Copy()
        {
            Board copy = new Board(Size, HowManyToWin);
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    Square newSquare = new Square();
                    copy.Grid[i, j] = newSquare;
                    copy.SetSymbol(i, j, GetSymbol(i, j));
                }
            }
            return copy;
        }

    }

    public class Square
    {
        public Square()
        {
        }

        public Symbol Symbol
        { get; set; }
    }

    public enum Symbol { Empty, O, X };

    public static class Opposite
    {
        public static Symbol Symbol(Symbol symbol)
        {
            switch (symbol)
            {
                case TicTacToe.Symbol.O:
                    return TicTacToe.Symbol.X;
                case TicTacToe.Symbol.X:
                    return TicTacToe.Symbol.O;
                default:
                    return TicTacToe.Symbol.Empty;
            }
        }
    }
}
