using System;
using System.Threading;

namespace KolkoKrzyzyk
{
    class Program
    {
        static void Main(string[] args)
        {
            Budowniczy budowniczy = new Budowniczy();
            KoordynatorRozgrywki koordynatorRozgrywki = budowniczy.StworzKoordynatora();

            koordynatorRozgrywki.Graj();            

            Console.WriteLine("Nacisnij dowolny klawisz, aby zakonczyc.");
            Console.ReadKey();
        }
    }
}
