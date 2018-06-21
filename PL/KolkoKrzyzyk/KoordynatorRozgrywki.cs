using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    class KoordynatorRozgrywki
    {
        private IGracz gracz1;
        private IGracz gracz2;
        private Plansza plansza;
        private WyswietlaczPlanszy wyswietlaczPlanszy = new WyswietlaczPlanszy();

        public KoordynatorRozgrywki(IGracz gracz1, IGracz gracz2, Plansza plansza)
        {
            this.gracz1 = gracz1;
            this.gracz2 = gracz2;
            this.plansza = plansza;
        }

        public void Graj()
        {
            WyswietlaczPlanszy.NarysujPlansze(plansza);

            int nrRuchu = 0;
            bool wygrana = false;
            IGracz aktualnyGracz = gracz1;

            while(wygrana != true && nrRuchu < plansza.LiczbaKratek)
            {
                wygrana = WykonajRuch(aktualnyGracz);
                WyswietlaczPlanszy.NarysujPlansze(plansza);
                if (wygrana == true)
                {
                    Console.WriteLine("Wygrał gracz {0}!", aktualnyGracz.Znak);
                }
                if(nrRuchu == plansza.LiczbaKratek - 1)
                {
                    wygrana = true;
                    Console.WriteLine("Remis. Koniec gry.");
                }
                aktualnyGracz = TenDrugi(aktualnyGracz);
                nrRuchu++;
            }
            
        }

        private bool WykonajRuch(IGracz gracz)
        {
            Ruch ruch = gracz.Graj(plansza);            
            plansza.UstawZnak(ruch.X, ruch.Y, gracz.Znak);

            FunkcjaOceny funkcjaOceny = new FunkcjaOceny();
            if (funkcjaOceny.CzyWygrana(gracz.Znak, plansza) == true)
            {
                return true;
            }
            return false;
        }


        private IGracz TenDrugi(IGracz gracz)
        {
            if (gracz == gracz1)
                return gracz2;
            else
                return gracz1;
        }
    }
}
