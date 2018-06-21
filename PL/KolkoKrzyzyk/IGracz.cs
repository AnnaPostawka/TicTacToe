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
            Ruch ruch = Konsola.PobierzWspolrzedne(plansza);
            return ruch;
        }
    }


    public class Komputer : IGracz
    {
        public Komputer(Znak znak) : base(znak)
        {
        }

        public Komputer(Znak znak, int ilePoziomow, bool alphaBeta) : base(znak)
        {
            this.ilePoziomow = ilePoziomow;
            this.alphaBeta = alphaBeta;
        }

        private int ilePoziomow = 6;
        private bool alphaBeta = true;
    
        public override Ruch Graj(Plansza plansza)
        {
            if (alphaBeta)
            {
                var wynikMinMaxAlphaBeta = MinMaxAlphaBeta(plansza, ilePoziomow, true, Int32.MinValue, Int32.MaxValue);
                return wynikMinMaxAlphaBeta.Item2;
            }
            else
            {
                var wynikMinMax = MinMax(plansza, ilePoziomow, true);
                return wynikMinMax.Item2;
            }

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

                    Plansza kopiaPlanszy = plansza.Kopia();
                    kopiaPlanszy.UstawZnak(tmpRuch, Znak);

                    tmpWynik = MinMax(kopiaPlanszy, poziom - 1, false).Item1;
                    if (najlepszyWynik < tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = tmpRuch;
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
                    kopiaPlanszy.UstawZnak(tmpRuch, Przeciwny.Znak(Znak));

                    tmpWynik = MinMax(kopiaPlanszy, poziom - 1, true).Item1;
                    if (najlepszyWynik > tmpWynik)
                    {
                        najlepszyWynik = tmpWynik;
                        najlepszyRuch = tmpRuch;
                    }
                }
                return new Tuple<int, Ruch>(najlepszyWynik, najlepszyRuch);
            }
        }


        private Tuple<int, Ruch> MinMaxAlphaBeta(Plansza plansza, int poziom, bool GraczMax, int alpha, int beta)
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
                while (lista.Count != 0)
                {
                    Ruch tmpRuch = lista.Last.Value;
                    lista.RemoveLast();

                    Plansza kopiaPlanszy = plansza.Kopia();
                    kopiaPlanszy.UstawZnak(tmpRuch, Znak);

                    tmpWynik = MinMaxAlphaBeta(kopiaPlanszy, poziom - 1, false, alpha, beta).Item1;
                    if (alpha < tmpWynik)
                    {
                        alpha = tmpWynik;
                        najlepszyRuch = tmpRuch;
                    }
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return new Tuple<int, Ruch>(alpha, najlepszyRuch);
            }
            else
            {
                while (lista.Count != 0)
                {
                    Ruch tmpRuch = lista.Last.Value;
                    lista.RemoveLast();

                    Plansza kopiaPlanszy = plansza.Kopia();
                    kopiaPlanszy.UstawZnak(tmpRuch, Przeciwny.Znak(Znak));

                    tmpWynik = MinMaxAlphaBeta(kopiaPlanszy, poziom - 1, true, alpha, beta).Item1;
                    if (beta > tmpWynik)
                    {
                        beta = tmpWynik;
                        najlepszyRuch = tmpRuch;
                    }
                    if (alpha >= beta)
                    {
                        break;
                    }
                }
                return new Tuple<int, Ruch>(beta, najlepszyRuch);
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
}

