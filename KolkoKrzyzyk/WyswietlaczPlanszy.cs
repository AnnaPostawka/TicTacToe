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
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    Console.Write("----");
                }
                Console.WriteLine("-");
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    Console.Write("| ");
                    NarysujZnak(i, j, plansza);
                    Console.Write(" ");
                }
                Console.WriteLine("|");
            }
            for (int j = 0; j < plansza.Rozmiar; j++)
            {
                Console.Write("----");
            }
            Console.WriteLine("-");
        }

        private static void NarysujZnak(int i, int j, Plansza plansza)
        {
            switch (plansza.PoleGry[i, j].Znak)
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
