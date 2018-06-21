using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{ 
    public class Plansza
    {
        public int Rozmiar { get; }
        public int IleByWygrac { get; }
        private Kratka[,] PoleGry = null;
        public int LiczbaKratek { get; }
        public int IleWypelnionych { get; private set; }

        public Plansza(int rozmiar, int ileByWygrac)
        {
            Rozmiar = rozmiar;
            IleByWygrac = ileByWygrac;
            StworzPoleGry();
            LiczbaKratek = PoleGry.Length;
            IleWypelnionych = 0;
        }
        
        public void UstawZnak(int x, int y, Znak znak)
        {
            if(PoleGry[x, y].Znak != KolkoKrzyzyk.Znak.Puste)
            {
                throw new Exception();
            }
            PoleGry[x, y].Znak = znak;
            IleWypelnionych++;
        }

        public void UstawZnak(Ruch ruch, Znak znak)
        {
            if (PoleGry[ruch.X, ruch.Y].Znak != KolkoKrzyzyk.Znak.Puste)
            {
                throw new Exception();
            }
            PoleGry[ruch.X, ruch.Y].Znak = znak;
            IleWypelnionych++;
        }

        public Kratka UstawZnak(int x, int y)
        {
            if (PoleGry[x, y].Znak != KolkoKrzyzyk.Znak.Puste)
            {
                throw new Exception();
            }
            IleWypelnionych++;
            return PoleGry[x, y];
        }

        public Kratka UstawZnak(Ruch ruch)
        {
            if (PoleGry[ruch.X, ruch.Y].Znak != KolkoKrzyzyk.Znak.Puste)
            {
                throw new Exception();
            }
            IleWypelnionych++;
            return PoleGry[ruch.X, ruch.Y];
        }

        public Znak Znak(int x, int y)
        {
            return PoleGry[x, y].Znak;
        }

        public Znak Znak(Ruch ruch)
        {
            return PoleGry[ruch.X, ruch.Y].Znak;
        }

        private void StworzPoleGry()
        {
            PoleGry = new Kratka[Rozmiar, Rozmiar];
            for (int i = 0; i < Rozmiar; i++)
            {
                for (int j = 0; j < Rozmiar; j++)
                {
                    PoleGry[i, j] = new Kratka();
                }
            }
        }

        public Plansza Kopia()
        {
            Plansza kopia = new Plansza(Rozmiar, IleByWygrac);
            for (int i = 0; i < Rozmiar; i++)
            {
                for (int j = 0; j < Rozmiar; j++)
                {
                    Kratka nowaKratka = new Kratka();
                    kopia.PoleGry[i, j] = nowaKratka;
                    kopia.UstawZnak(i, j, Znak(i, j));
                }
            }
            return kopia;
        }

    }

    public class Kratka
    {
        public Kratka()
        {
        }

        public Znak Znak
        { get; set; }
    }

    public enum Znak { Puste, Kolko, Krzyzyk };

    public static class Przeciwny
    {
        public static Znak Znak(Znak znak)
        {
            switch (znak)
            {
                case KolkoKrzyzyk.Znak.Kolko:
                    return KolkoKrzyzyk.Znak.Krzyzyk;
                case KolkoKrzyzyk.Znak.Krzyzyk:
                    return KolkoKrzyzyk.Znak.Kolko;
                default:
                    return KolkoKrzyzyk.Znak.Puste;
            }
        }
    }
}
