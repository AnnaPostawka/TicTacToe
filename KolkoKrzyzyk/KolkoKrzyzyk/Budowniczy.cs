using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    class Budowniczy
    {
        KoordynatorRozgrywki koordynatorRozgrywki;

        public Budowniczy(bool isHuman1, bool isHuman2, Znak znak1)
        {
            IGracz gracz1 = StworzGracza(isHuman1, znak1);
            IGracz gracz2 = StworzGracza(isHuman2, PrzeciwnyZnak(znak1));
            Plansza plansza = StworzPlansze();
            koordynatorRozgrywki = new KoordynatorRozgrywki(gracz1, gracz2, plansza);
        }

        private IGracz StworzGracza(bool isHuman, Znak znak)
        {
            IGracz gracz;
            if (isHuman == true)
            {
                gracz = new Czlowiek(znak);
            }
            else
            {
                gracz = new MinMax(znak);
            }
            return gracz;
        }

        private Plansza StworzPlansze()
        {
            Konsola konsola = new Konsola();
            int rozmiar = konsola.PobierzRozmiar();
            int ileByWygrac = konsola.PobierzIleByWygrac(rozmiar);
            Plansza plansza = new Plansza(rozmiar, ileByWygrac);
            return plansza;
        }

        private Znak PrzeciwnyZnak(Znak znak)
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

        public KoordynatorRozgrywki StworzKoordynatora()
        {
            return koordynatorRozgrywki;
        }
    }
}
