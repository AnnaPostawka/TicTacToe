using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    class Budowniczy
    {
        private KoordynatorRozgrywki koordynatorRozgrywki;
        private Konsola konsola = new Konsola();

        public Budowniczy()
        {
            IGracz gracz1 = StworzGracza(1, Znak.Krzyzyk);
            IGracz gracz2 = StworzGracza(2, Znak.Kolko);
            Plansza plansza = StworzPlansze();
            koordynatorRozgrywki = new KoordynatorRozgrywki(gracz1, gracz2, plansza);
        }

        private IGracz StworzGracza(int nr, Znak znak)
        {
            IGracz gracz;
            bool isHuman = konsola.PobierzGracza(nr);
            if (isHuman == true)
            {
                gracz = new Czlowiek(znak);
            }
            else
            {
                gracz = new Komputer(znak);
            }
            return gracz;
        }

        private Plansza StworzPlansze()
        {
            int rozmiar = konsola.PobierzRozmiar();
            int ileByWygrac = konsola.PobierzIleByWygrac(rozmiar);
            Plansza plansza = new Plansza(rozmiar, ileByWygrac);
            return plansza;
        }

        public KoordynatorRozgrywki StworzKoordynatora()
        {
            return koordynatorRozgrywki;
        }
    }
}
