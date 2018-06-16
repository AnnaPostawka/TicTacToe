using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    public abstract class IGracz
    {
        public Znak Znak { get; }

        public IGracz(Znak znak)
        {
            Znak = znak;
        }

        public abstract Ruch Graj(Plansza plansza);
    }

    public class Czlowiek : IGracz
    {
        public Czlowiek(Znak znak) : base(znak)
        {
        }

        public override Ruch Graj(Plansza plansza)
        {
            Konsola konsola = new Konsola();

            Console.WriteLine("Podaj wspolrzedne X (wiersze) i Y (kolumny): ");
            Ruch ruch = konsola.PobierzWspolrzedne(plansza.Rozmiar);
            while (plansza.Znak(ruch.X, ruch.Y) != Znak.Puste)
            {
                Console.WriteLine("To pole jest juz zajete. Podaj inne wspolrzedne: ");
                ruch = konsola.PobierzWspolrzedne(plansza.Rozmiar);
            }
            return ruch;
        }
    }


    public class Komputer : IGracz
    {
        public Komputer(Znak znak) : base(znak)
        {
        }

        private int ilePoziomow = 0;
    
        public override Ruch Graj(Plansza plansza)
        {
            Ruch ruch = new Ruch();
            Plansza planszaKopia = plansza.Kopia();
            ilePoziomow = 5;
            var wynikMinMax = MinMax(planszaKopia, ilePoziomow, true);
            return wynikMinMax.Item2;
        }

        
        private Znak JakiZnak(bool GraczMax)
        {
            if (GraczMax == true)
                return Znak;
            return PrzeciwnyZnak(Znak);
        }


        private Tuple<int, Ruch> MinMax(Plansza plansza, int poziom, bool GraczMax)
        {
            FunkcjaOceny funkcjaOceny = new FunkcjaOceny();
            Znak znak = JakiZnak(GraczMax);
            LinkedList<Ruch> lista = GenerujRozklady(plansza);
            int tmpWynik = 0;
            Ruch najlepszyRuch = new Ruch(-1, -1);
            if (poziom == 0 || lista.Count == 0)
            {
                int wynik = funkcjaOceny.Ocena(plansza, znak);
                return new Tuple<int, Ruch>(wynik, najlepszyRuch);
            }
            if (GraczMax == true)
            {
                Int32 najlepszyWynik = Int32.MinValue;
                while (lista.Count != 0)
                {
                    Ruch tmpRuch = lista.Last.Value;
                    lista.RemoveLast();

                    Plansza kopiaPlanszy = plansza.Kopia();
                    kopiaPlanszy.UstawZnak(tmpRuch, znak);

                    tmpWynik = MinMax(kopiaPlanszy, poziom - 1, false).Item1;
                    if (najlepszyWynik < tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = tmpRuch;
                    }
                    if(poziom == ilePoziomow - 1)
                    {
                        Console.WriteLine("Ocena: {0}, Ruch: {1} {2}", najlepszyWynik, najlepszyRuch.X, najlepszyRuch.Y);
                    }
                }
                return new Tuple<int, Ruch>(najlepszyWynik, najlepszyRuch);
            }
            else
            {
                Int32 najlepszyWynik = Int32.MaxValue;
                while (lista.Count != 0)
                {
                    Ruch tmpRuch = lista.Last.Value;
                    lista.RemoveLast();

                    Plansza kopiaPlanszy = plansza.Kopia();
                    kopiaPlanszy.UstawZnak(tmpRuch, znak);

                    tmpWynik = MinMax(kopiaPlanszy, poziom - 1, true).Item1;
                    if (najlepszyWynik > tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = tmpRuch;
                    }
                    if (poziom == ilePoziomow - 1)
                    {
                        Console.WriteLine("Ocena: {0}, Ruch: {1} {2}", najlepszyWynik, najlepszyRuch.X, najlepszyRuch.Y);
                    }
                }
                return new Tuple<int, Ruch>(najlepszyWynik, najlepszyRuch);
            }
        }

        private LinkedList<Ruch> GenerujRozklady(Plansza plansza)
        {
            LinkedList<Ruch> lista = new LinkedList<Ruch>();
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    if (plansza.Znak(i, j) == Znak.Puste)
                    {
                        Ruch ruch = new Ruch(i, j);
                        lista.AddLast(ruch);
                    }
                }
            }
            return lista;
        }


        // ostatnia wersja
        /*
        private Tuple<int, Ruch> MinMax(Plansza plansza, int poziom, bool GraczMax)
        {
            FunkcjaOceny funkcjaOceny = new FunkcjaOceny();
            Znak znak = JakiZnak(GraczMax);
            LinkedList<PotencjalnyRuch> lista = GenerujRozklady(plansza, znak);
            int tmpWynik = 0;
            Ruch najlepszyRuch = new Ruch(-1, -1);
            if (poziom == 0 || lista.Count == 0)
            {
                int wynik = funkcjaOceny.Ocena(plansza, znak);
                return new Tuple<int, Ruch>(wynik, najlepszyRuch);
            }
            if (GraczMax == true)
            {
                Int32 najlepszyWynik = Int32.MinValue;
                while (lista.Count != 0)
                {
                    PotencjalnyRuch potomek = lista.Last.Value;
                    lista.RemoveLast();
                    tmpWynik = MinMax(potomek.Plansza, poziom - 1, false).Item1;
                    if (najlepszyWynik < tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = potomek.Ruch;
                    }
                }
                return new Tuple<int, Ruch>(najlepszyWynik, najlepszyRuch);
            }
            else
            {
                Int32 najlepszyWynik = Int32.MaxValue;
                while (lista.Count != 0)
                {
                    PotencjalnyRuch potomek = lista.Last.Value;
                    lista.RemoveLast();
                    tmpWynik = MinMax(potomek.Plansza, poziom - 1, true).Item1;
                    if (najlepszyWynik > tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = potomek.Ruch;
                    }
                }
                return new Tuple<int, Ruch>(najlepszyWynik, najlepszyRuch);
            }
        }
        */
        // z wyswietlaniem
        /*
        bool wyswietlaj = false;
        private int MinMax(Plansza plansza, int poziom, bool GraczMax)
        {
            FunkcjaOceny funkcjaOceny = new FunkcjaOceny();
            if (poziom == 0)
            {
                if (GraczMax == true)
                {

                    int ocena = funkcjaOceny.Ocena(plansza, Znak);
                    if (wyswietlaj)
                    {
                        WyswietlaczPlanszy.NarysujPlansze(plansza);
                        Console.WriteLine("Ocena dla {0} to: {1}.", Znak, ocena);
                    }
                    return ocena;
                }
                else
                {
                    int ocena = -funkcjaOceny.Ocena(plansza, PrzeciwnyZnak(Znak));
                    if (wyswietlaj)
                    {
                        WyswietlaczPlanszy.NarysujPlansze(plansza);
                        Console.WriteLine("Ocena dla {0} to: {1}.", PrzeciwnyZnak(Znak), ocena);
                    }
                    return ocena;
                }
            }
            if (GraczMax == true)
            {
                LinkedList<PotencjalnyRuch> lista = GenerujRozklady(plansza, Znak);
                if (lista.Count == 0)
                {
                    int ocena = funkcjaOceny.Ocena(plansza, Znak);
                    if (wyswietlaj)
                    {
                        WyswietlaczPlanszy.NarysujPlansze(plansza);
                        Console.WriteLine("Ocena dla {0} to: {1}.", Znak, ocena);
                    }
                    return ocena;
                }
                Int32 najlepszyWynik = Int32.MinValue;
                Ruch najlepszyRuch = null;
                while (lista.Count != 0)
                {
                    PotencjalnyRuch potomek = lista.Last.Value;
                    lista.RemoveLast();
                    int tmpWynik = MinMax(potomek.Plansza, poziom - 1, false);
                    if (najlepszyWynik < tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = potomek.Ruch;
                    }
                }
                if (poziom == ilePoziomow)
                {
                    zwycieskiRuch = najlepszyRuch;
                }
                return najlepszyWynik;
            }
            else
            {
                LinkedList<PotencjalnyRuch> lista = GenerujRozklady(plansza, PrzeciwnyZnak(Znak));
                if (lista.Count == 0)
                {
                    int ocena = -funkcjaOceny.Ocena(plansza, PrzeciwnyZnak(Znak));
                    if (wyswietlaj)
                    {
                        WyswietlaczPlanszy.NarysujPlansze(plansza);
                        Console.WriteLine("Ocena dla {0} to: {1}.", PrzeciwnyZnak(Znak), ocena);
                    }
                    return ocena;
                }
                Int32 najlepszyWynik = Int32.MaxValue;
                Ruch najlepszyRuch = null;
                while (lista.Count != 0)
                {
                    PotencjalnyRuch potomek = lista.Last.Value;
                    lista.RemoveLast();
                    int tmpWynik = MinMax(potomek.Plansza, poziom - 1, true);
                    if (najlepszyWynik > tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = potomek.Ruch;
                    }
                }
                if (poziom == ilePoziomow)
                {
                    zwycieskiRuch = najlepszyRuch;
                }
                return najlepszyWynik;

            }
        }
        */
        /*
        private LinkedList<PotencjalnyRuch> GenerujRozklady(Plansza plansza, Znak znak)
        {
            LinkedList<PotencjalnyRuch> lista = new LinkedList<PotencjalnyRuch>();
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for(int j = 0; j < plansza.Rozmiar; j++)
                {
                    if (plansza.Znak(i, j) == Znak.Puste)
                    {
                        Plansza kopiaPlanszy = plansza.Kopia();
                        kopiaPlanszy.UstawZnak(i, j, znak);
                        Ruch ruch = new Ruch(i, j);
                        PotencjalnyRuch ruchNaPlanszy = new PotencjalnyRuch(kopiaPlanszy, ruch);
                        lista.AddLast(ruchNaPlanszy);
                    }
                }
            }
            return lista;
        }
        */

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

    }


    public class Ruch
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Ruch(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Ruch()
        {
        }
    }

    class PotencjalnyRuch
    {
        public Plansza Plansza { get; set; }
        public Ruch Ruch { get; set; }

        public PotencjalnyRuch(Plansza plansza, Ruch ruch)
        {
            Plansza = plansza;
            Ruch = ruch;
        }
    }
}

