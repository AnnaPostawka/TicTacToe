using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{ 
    class Plansza
    {
        public int Rozmiar { get; }
        public int IleByWygrac { get; }
        public Kratka[,] PoleGry = null;

        public Plansza(int rozmiar, int ileByWygrac)
        {
            this.Rozmiar = rozmiar;
            this.IleByWygrac = ileByWygrac;
            StworzPoleGry();
        }
        
        public void Znak(int x, int y, Znak znak)
        {
            PoleGry[x, y].Znak = znak;
        }

        public Znak Znak(int x, int y)
        {
            return PoleGry[x, y].Znak;
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
                    kopia.PoleGry[i, j] = PoleGry[i, j];
                }
            }
            return kopia;
        }
    }

    public enum Znak { Puste, Kolko, Krzyzyk };

    public class Kratka
    {
        public Kratka()
        {
        }

        public Znak Znak
        { get; set; }

        public Znak PrzeciwnyZnak()
        {
            switch (Znak)
            {
                case Znak.Kolko:
                    return Znak.Krzyzyk;
                case Znak.Krzyzyk:
                    return Znak.Kolko;
                default:
                    return Znak.Puste;
            }
        }
    }
}
