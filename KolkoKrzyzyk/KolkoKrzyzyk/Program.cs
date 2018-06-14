using System;
using System.Threading;

namespace KolkoKrzyzyk
{
    class Program
    {
        public static void ZmienZnak(int x, int y, ref int [,] tab)
        {
            tab[x, y] = 1;
        }

        public static Znak PrzeciwnyZnak(Znak znak)
        {
            switch (znak)
            {
                case Znak.Kolko:
                    return Znak.Krzyzyk;
                case Znak.Krzyzyk:
                    return Znak.Kolko;
                default:
                    return Znak.Puste;
            }
        }

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
