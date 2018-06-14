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
            Konsola konsola = new Konsola();
            int rozmiar = konsola.PobierzRozmiar();
            int ileByWygrac = konsola.PobierzIleByWygrac(rozmiar);
            Plansza plansza = new Plansza(rozmiar, ileByWygrac);
            WyswietlaczPlanszy wyswietlaczPlanszy = new WyswietlaczPlanszy();
            wyswietlaczPlanszy.NarysujPlansze(plansza);
            Znak aktualnyZnak = Znak.Krzyzyk;

            for (int i = 0; i < 9; i++)
            {
                Console.WriteLine("Podaj wspolrzedne X (wiersze) i Y (kolumny): ");
                int x = konsola.PobierzX(rozmiar);
                int y = konsola.PobierzY(rozmiar);

                plansza.PoleGry[x, y].Znak = aktualnyZnak;
                aktualnyZnak = PrzeciwnyZnak(aktualnyZnak);


                wyswietlaczPlanszy.NarysujPlansze(plansza);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
