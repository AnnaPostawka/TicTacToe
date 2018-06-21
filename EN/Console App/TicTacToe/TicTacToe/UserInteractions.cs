using System;

namespace TicTacToe
{
    class UserInteractions
    {
        public static int GetSize()
        {
            string output = "Length of a side of a board (3 - 10): ";
            return GetValue(3, 10, output);
        }

        public static int GetHowManyToWin(int size)
        {
            string output = "How many symbols in a row in order to win: ";
            return GetValue(3, size, output);
        }

        public static Move GetCoords(Board board)
        {
            Console.WriteLine("Give coordinates: ");
            int x = GetX(board.Size);
            int y = GetY(board.Size);
            while (board.GetSymbol(x, y) != Symbol.Empty)
            {
                Console.WriteLine("This square is taken. Choose another one: ");
                x = GetX(board.Size);
                y = GetY(board.Size);
            }
            return new Move(x, y);
        }

        public static bool GetPlayer(int number)
        {
            string whenHuman = "H";
            string whenComputer = "C";
            string output = "Choose whether Player" + number.ToString() + " should be a human or a computer [" + whenHuman + " / " + whenComputer + "]: ";
            bool isHuman = GetAnswer(output, whenHuman, whenComputer);

            return isHuman;
        }


        public static bool WhichAlgorithm(ref int howManyLevels)
        {
            string output = "Depth of a MinMax algorithm: ";
            howManyLevels = GetValue(1, 10, output);

            string yes = "Y";
            string no = "N";
            output = "Algorithm with Alpha-Beta pruning? [" + yes + " / " + no + "]: ";
            bool alphaBeta = GetAnswer(output, yes, no);

            return alphaBeta;
        }

        private static int GetX(int size)
        {
            string output = "Row: ";
            return GetValue(0, size - 1, output);
        }

        private static int GetY(int size)
        {
            string output = "Column: ";
            return GetValue(0, size - 1, output);
        }

        private static int GetValue(int floor, int ceiling, string output)
        {
            int value = 0;
            bool repeat = true;

            while (repeat)
            {
                Console.Write(output);

                string input = Console.ReadLine();
                
                try
                {
                    value = Convert.ToInt32(input);
                    if (value > ceiling)
                    {
                        Console.WriteLine("Number too big.");
                    }
                    else if (value < floor)
                    {
                        Console.WriteLine("Number too small.");
                    }
                    else
                    {
                        repeat = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Input string is not a sequence of digits.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("The number cannot fit in an Int32.");
                }
            }
            return value;
        }

        private static bool GetAnswer(string output, string option1, string option2)
        {
            bool answer = true;
            bool repeat = true;

            while (repeat)
            {
                Console.Write(output);

                string input = Console.ReadLine();
                if (input.CompareTo(option1) == 0 || input.ToLower().CompareTo(option1.ToLower()) == 0)
                {
                    answer = true;
                    repeat = false;
                }
                else if (input.CompareTo(option2) == 0 || input.ToLower().CompareTo(option2.ToLower()) == 0)
                {
                    answer = false;
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("Wrong value.");
                }
            }
            return answer;
        }

        /*
        public static Tuple<bool,bool> Continue()
        {
            string yes = "Y";
            string no = "N";
            string output = "Do you want to play again?  [" + yes + " / " + no + "]: ";
            bool playAgain = GetAnswer(output, yes, no);

            output = "With the same setup?  [" + yes + " / " + no + "]: ";
            bool sameSetup = GetAnswer(output, yes, no);

            return new Tuple<bool, bool> (playAgain, sameSetup);
        }
        */
    }
}
