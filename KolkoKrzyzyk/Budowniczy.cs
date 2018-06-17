using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    class Budowniczy
    {
        private readonly KoordynatorRozgrywki koordynatorRozgrywki;

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
            bool czyCzlowiek = Konsola.PobierzGracza(nr);
            if (czyCzlowiek)
            {
                gracz = new Czlowiek(znak);
            }
            else
            {
                int ilePoziomow = 0;
                bool alphaBeta = Konsola.JakiAlgorytm(ref ilePoziomow);
                gracz = new Komputer(znak, ilePoziomow, alphaBeta);
            }
            return gracz;
        }

        private Plansza StworzPlansze()
        {
            int rozmiar = Konsola.PobierzRozmiar();
            int ileByWygrac = Konsola.PobierzIleByWygrac(rozmiar);
            Plansza plansza = new Plansza(rozmiar, ileByWygrac);
            return plansza;
        }

        public KoordynatorRozgrywki StworzKoordynatora()
        {
            return koordynatorRozgrywki;
        }
    }
}
