using System;
using System.Threading;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new Builder();
            GameMaster gameMaster = builder.CreateGameMaster();

            gameMaster.Play();            

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
