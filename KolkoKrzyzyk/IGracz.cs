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
            Ruch ruch = konsola.PobierzWspolrzedne(plansza);
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
            ilePoziomow = 10;
            var wynikMinMax = MinMax(planszaKopia, ilePoziomow, true);
            return wynikMinMax.Item2;
        }

        
        private Tuple<int, Ruch> MinMax(Plansza plansza, int poziom, bool GraczMax)
        {
            FunkcjaOceny funkcjaOceny = new FunkcjaOceny();
            LinkedList<Ruch> lista = GenerujRozklady(plansza);
            int tmpWynik = 0;
            Ruch najlepszyRuch = new Ruch(-1, -1);
            if (poziom == 0 || lista.Count == 0 || funkcjaOceny.CzyWygrana(Przeciwny.Znak(Znak), plansza) || funkcjaOceny.CzyWygrana(Znak, plansza))
            {
                int wynik = funkcjaOceny.Ocena(plansza, Znak);
                return new Tuple<int, Ruch>(wynik, najlepszyRuch);
            }
            if (GraczMax == true)
            {
                Int32 najlepszyWynik = Int32.MinValue;
                while (lista.Count != 0)
                {
                    Ruch tmpRuch = lista.Last.Value;
                    lista.RemoveLast();
                    if (poziom == ilePoziomow)
                    {
                        Console.WriteLine("Potencjalny ruch: {0} {1}", tmpRuch.X, tmpRuch.Y);
                    }
                    Plansza kopiaPlanszy = plansza.Kopia();
                    kopiaPlanszy.UstawZnak(tmpRuch, Znak);

                    tmpWynik = MinMax(kopiaPlanszy, poziom - 1, false).Item1;
                    if (najlepszyWynik < tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = tmpRuch;
                    }
                    if(poziom == ilePoziomow - 1)
                    {
                        Console.WriteLine("Poziom {3}, GraczMax {4}: Tmp:  Ocena: {0}, Ruch: {1} {2}", tmpWynik, tmpRuch.X, tmpRuch.Y, poziom, GraczMax);
                        Console.WriteLine("Poziom {3}, GraczMax {4}: Best: Ocena: {0}, Ruch: {1} {2}", najlepszyWynik, najlepszyRuch.X, najlepszyRuch.Y, poziom, GraczMax);
                    }
                    if (poziom == ilePoziomow)
                    {
                        Console.WriteLine("Poziom {3}, GraczMax {4}: Ocena: {0}, Ruch: {1} {2}", najlepszyWynik, najlepszyRuch.X, najlepszyRuch.Y, poziom, GraczMax);
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
                    if (poziom == ilePoziomow)
                    {
                        Console.WriteLine("Potencjalny ruch: {0} {1}", tmpRuch.X, tmpRuch.Y);
                    }
                    Plansza kopiaPlanszy = plansza.Kopia();
                    kopiaPlanszy.UstawZnak(tmpRuch, Przeciwny.Znak(Znak));

                    tmpWynik = MinMax(kopiaPlanszy, poziom - 1, true).Item1;
                    if (najlepszyWynik > tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = tmpRuch;
                    }
                    if (poziom == ilePoziomow - 1)
                    {
                        Console.WriteLine("Poziom {3}, GraczMax {4}: Tmp:  Ocena: {0}, Ruch: {1} {2}", tmpWynik, tmpRuch.X, tmpRuch.Y, poziom, GraczMax);
                        Console.WriteLine("Poziom {3}, GraczMax {4}: Best: Ocena: {0}, Ruch: {1} {2}", najlepszyWynik, najlepszyRuch.X, najlepszyRuch.Y, poziom, GraczMax);
                    }
                    if (poziom == ilePoziomow)
                    {
                        Console.WriteLine("Poziom {3}, GraczMax {4}: Ocena: {0}, Ruch: {1} {2}", najlepszyWynik, najlepszyRuch.X, najlepszyRuch.Y, poziom, GraczMax);
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

