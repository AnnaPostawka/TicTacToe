using System;
using System.Threading;

namespace KolkoKrzyzyk
{
    class Program
    {
        static void Main(string[] args)
        {
            Budowniczy budowniczy = new Budowniczy(true, true, Znak.Krzyzyk);
            KoordynatorRozgrywki koordynatorRozgrywki = budowniczy.StworzKoordynatora();

            koordynatorRozgrywki.Graj();

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
