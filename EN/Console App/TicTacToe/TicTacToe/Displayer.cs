using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Displayer
    {
        public Displayer()
        {
        }

        public static void DisplayBoard(Board board)
        {
            ColumnCoords(board.Size);
            for (int row = 0; row < board.Size; row++)
            {
                HorizontalLine(board.Size);
                RowCoords(row);
                Squares(board, row);
            }
            HorizontalLine(board.Size);
        }


        private static void Tab()
        {
            Console.Write("    ");

        }

        private static void RowCoords(int row)
        {
            Console.Write(" {0}  ", row);
        }

        private static void HorizontalLine(int size)
        {
            Tab();
            for (int i = 0; i < size; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine("-");

        }

        private static void ColumnCoords(int size)
        {
            Tab();
            for (int column = 0; column < size; column++)
            {
                Console.Write("  {0} ", column);
            }
            Console.WriteLine();
        }

        private static void Squares(Board board, int row)
        {
            for (int column = 0; column < board.Size; column++)
            {
                Console.Write("| ");
                DisplaySymbol(row, column, board);
                Console.Write(" ");
            }
            Console.WriteLine("|");
        }

        private static void DisplaySymbol(int i, int j, Board board)
        {
            switch (board.GetSymbol(i, j))
            {
                case Symbol.O:
                    Console.Write("O");
                    break;
                case Symbol.X:
                    Console.Write("X");
                    break;
                default:
                    Console.Write(" ");
                    break;
            }
        }
    }
}
