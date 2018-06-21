using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    public class WyswietlaczPlanszy
    {
        public WyswietlaczPlanszy()
        {
        }

        public static void NarysujPlansze(Plansza plansza)
        {
            WspolrzedneKolumny(plansza.Rozmiar);
            for (int wiersz = 0; wiersz < plansza.Rozmiar; wiersz++)
            {
                LiniaPozioma(plansza.Rozmiar);
                WspolrzedneWiersze(wiersz);
                Kratki(plansza, wiersz);
            }
            LiniaPozioma(plansza.Rozmiar);
        }


        private static void Tabulacja()
        {
            Console.Write("    ");

        }

        private static void WspolrzedneWiersze(int wiersz)
        {
            Console.Write(" {0}  ", wiersz);
        }

        private static void LiniaPozioma(int rozmiar)
        {
            Tabulacja();
            for (int i = 0; i < rozmiar; i++)
            {
                Console.Write("----");
            }
            Console.WriteLine("-");

        }

        private static void WspolrzedneKolumny(int rozmiar)
        {
            Tabulacja();
            for (int kolumna = 0; kolumna < rozmiar; kolumna++)
            {
                Console.Write("  {0} ", kolumna);
            }
            Console.WriteLine();
        }

        private static void Kratki(Plansza plansza, int wiersz)
        {
            for (int kolumna = 0; kolumna < plansza.Rozmiar; kolumna++)
            {
                Console.Write("| ");
                NarysujZnak(wiersz, kolumna, plansza);
                Console.Write(" ");
            }
            Console.WriteLine("|");
        }

        private static void NarysujZnak(int i, int j, Plansza plansza)
        {
            switch (plansza.Znak(i, j))
            {
                case Znak.Kolko:
                    Console.Write("O");
                    break;
                case Znak.Krzyzyk:
                    Console.Write("X");
                    break;
                default:
                    Console.Write(" ");
                    break;
            }
        }
    }
}
