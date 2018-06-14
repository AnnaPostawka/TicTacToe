using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    class KoordynatorRozgrywki
    {
        private IGracz gracz1;
        private IGracz gracz2;
        private WyswietlaczPlanszy wyswietlaczPlanszy = new WyswietlaczPlanszy();
        private Plansza plansza;
        private IGracz aktualnyGracz;

        public KoordynatorRozgrywki(IGracz gracz1, IGracz gracz2, Plansza plansza)
        {
            this.gracz1 = gracz1;
            this.gracz2 = gracz2;
            this.plansza = plansza;
            aktualnyGracz = gracz1;
        }

        public void Graj()
        {
            wyswietlaczPlanszy.NarysujPlansze(plansza);
            bool wygrana = false;
            while(wygrana != true)
            {
                int wynik = WykonajRuch(aktualnyGracz);
                aktualnyGracz = TenDrugi();
                if(wynik == 1)
                {
                    wygrana = true;
                }
            }
            Console.WriteLine("Wygrał gracz {0}!", TenDrugi().Znak);
        }

        private int WykonajRuch(IGracz gracz)
        {
            Konsola konsola = new Konsola();
            Console.WriteLine("Podaj wspolrzedne X (wiersze) i Y (kolumny): ");
            int x = konsola.PobierzX(plansza.Rozmiar);
            int y = konsola.PobierzY(plansza.Rozmiar);
            while (plansza.PoleGry[x, y].Znak != Znak.Puste)
            {
                Console.WriteLine("To pole jest juz zajete. Podaj inne wspolrzedne: ");
                x = konsola.PobierzX(plansza.Rozmiar);
                y = konsola.PobierzY(plansza.Rozmiar);
            }

            plansza.PoleGry[x, y].Znak = gracz.Znak;
            CzyWygrana czyWygrana = new CzyWygrana(plansza);
            int ocena = czyWygrana.Ocena(x, y);

            wyswietlaczPlanszy.NarysujPlansze(plansza);
            
            return ocena;
        }

        private IGracz TenDrugi()
        {
            if (aktualnyGracz == gracz1)
                return gracz2;
            else
                return gracz1;
        }
    }
}
