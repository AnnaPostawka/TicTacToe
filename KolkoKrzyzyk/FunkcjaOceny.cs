using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    public class FunkcjaOceny
    {
        public FunkcjaOceny()
        {
        }

        public int WagaZwyciestwa { get; set; } = 100;


        public int Ocena(Plansza plansza, Znak znak)
        {
            int wynik = Policz(znak, plansza);
            int wynikPrzeciwnika = Policz(Przeciwny.Znak(znak), plansza);
            if (wynik == WagaZwyciestwa)
                return WagaZwyciestwa;
            if (wynikPrzeciwnika == WagaZwyciestwa)
                return -(WagaZwyciestwa);
            return wynik - wynikPrzeciwnika;
        }

        private int Policz(Znak znak, Plansza plansza)
        {
            int znakiPodRzad = 0;
            int znakiIPuste = 0;
            int znakiNiezblokowane = 0;
            int wynik = 0;

            // rzad
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    if (plansza.Znak(i, j) == znak)
                    {
                        DobryZnak(ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad);
                    }
                    else
                    {
                        if (plansza.Znak(i, j) == Znak.Puste)
                        {
                            if (PustaKratka(ref znakiIPuste, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                        else
                        {
                            if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                    }
                }
                if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                {
                    return WagaZwyciestwa;
                }
            }

            // kolumna
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    if (plansza.Znak(j, i) == znak)
                    {
                        DobryZnak(ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad);
                    }
                    else
                    {
                        if (plansza.Znak(j, i) == Znak.Puste)
                        {
                            if (PustaKratka(ref znakiIPuste, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                        else
                        {
                            if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                    }
                }
                if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                {
                    return WagaZwyciestwa;
                }
            }

            // skos 1
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j, i + j) == znak)
                    {
                        DobryZnak(ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad);
                    }
                    else
                    {
                        if (plansza.Znak(j, i + j) == Znak.Puste)
                        {
                            if (PustaKratka(ref znakiIPuste, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                        else
                        {
                            if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                    }
                }
                if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                {
                    return WagaZwyciestwa;
                }
            }
            for (int i = 1; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(i + j, j) == znak)
                    {
                        DobryZnak(ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad);
                    }
                    else
                    {
                        if (plansza.Znak(i + j, j) == Znak.Puste)
                        {
                            if (PustaKratka(ref znakiIPuste, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                        else
                        {
                            if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                    }
                }
                if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                {
                    return WagaZwyciestwa;
                }
            }

            // skos 2
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j, plansza.Rozmiar - 1 - i - j) == znak)
                    {
                        DobryZnak(ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad);
                    }
                    else
                    {
                        if (plansza.Znak(j, plansza.Rozmiar - 1 - i - j) == Znak.Puste)
                        {
                            if (PustaKratka(ref znakiIPuste, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                        else
                        {
                            if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                    }
                }
                if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                {
                    return WagaZwyciestwa;
                }
            }
            for (int i = 1; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j + i, plansza.Rozmiar - 1 - j) == znak)
                    {
                        DobryZnak(ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad);
                    }
                    else
                    {
                        if (plansza.Znak(j + i, plansza.Rozmiar - 1 - j) == Znak.Puste)
                        {
                            if (PustaKratka(ref znakiIPuste, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                        else
                        {
                            if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                            {
                                return WagaZwyciestwa;
                            }
                        }
                    }
                }
                if (Wynik(ref wynik, ref znakiIPuste, ref znakiNiezblokowane, ref znakiPodRzad, plansza) == true)
                {
                    return WagaZwyciestwa;
                }
            }
            return wynik;
        }

        private bool Wynik(ref int wynik, ref int znakiIPuste, ref int znakiNiezblokowane, ref int znakiPodRzad, Plansza plansza)
        {
            if (znakiPodRzad >= plansza.IleByWygrac)
            {
                return true;
            }
            if (znakiIPuste >= plansza.IleByWygrac)
            {
                wynik += znakiNiezblokowane;
            }
            znakiIPuste = 0;
            znakiNiezblokowane = 0;
            znakiPodRzad = 0;
            return false;
        }

        private void DobryZnak(ref int znakiIPuste, ref int znakiNiezblokowane, ref int znakiPodRzad)
        {
            znakiIPuste++;
            znakiNiezblokowane++;
            znakiPodRzad++;
        }

        private bool PustaKratka(ref int znakiIPuste, ref int znakiPodRzad, Plansza plansza)
        {
            znakiIPuste++;
            if (znakiPodRzad >= plansza.IleByWygrac)
            {
                return true;
            }
            znakiPodRzad = 0;
            return false;
        }


        public bool CzyWygrana(Znak znak, Plansza plansza)
        {
            int znakiPodRzad = 0;

            // rzad
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    if (plansza.Znak(i, j) == znak)
                    {
                        znakiPodRzad++;
                    }
                    else
                    {
                        if (znakiPodRzad >= plansza.IleByWygrac)
                        {
                            return true;
                        }
                        znakiPodRzad = 0;
                    }
                }
                if (znakiPodRzad >= plansza.IleByWygrac)
                {
                    return true;
                }
                znakiPodRzad = 0;
            }

            // kolumna
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    if (plansza.Znak(j, i) == znak)
                    {
                        znakiPodRzad++;
                    }
                    else
                    {
                        if (znakiPodRzad >= plansza.IleByWygrac)
                        {
                            return true;
                        }
                        znakiPodRzad = 0;
                    }
                }
                if (znakiPodRzad >= plansza.IleByWygrac)
                {
                    return true;
                }
                znakiPodRzad = 0;
            }

            // skos 1
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j, i + j) == znak)
                    {
                        znakiPodRzad++;
                    }
                    else
                    {
                        if (znakiPodRzad >= plansza.IleByWygrac)
                        {
                            return true;
                        }
                        znakiPodRzad = 0;
                    }
                }
                if (znakiPodRzad >= plansza.IleByWygrac)
                {
                    return true;
                }
                znakiPodRzad = 0;
            }
            for (int i = 1; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(i + j, j) == znak)
                    {
                        znakiPodRzad++;
                    }
                    else
                    {
                        if (znakiPodRzad >= plansza.IleByWygrac)
                        {
                            return true;
                        }
                        znakiPodRzad = 0;
                    }
                }
                if (znakiPodRzad >= plansza.IleByWygrac)
                {
                    return true;
                }
                znakiPodRzad = 0;
            }

            // skos 2
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j, plansza.Rozmiar - 1 - i - j) == znak)
                    {
                        znakiPodRzad++;
                    }
                    else
                    {
                        if (znakiPodRzad >= plansza.IleByWygrac)
                        {
                            return true;
                        }
                        znakiPodRzad = 0;
                    }
                }
                if (znakiPodRzad >= plansza.IleByWygrac)
                {
                    return true;
                }
                znakiPodRzad = 0;
            }
            for (int i = 1; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j + i, plansza.Rozmiar - 1 - j) == znak)
                    {
                        znakiPodRzad++;
                    }
                    else
                    {
                        if (znakiPodRzad >= plansza.IleByWygrac)
                        {
                            return true;
                        }
                        znakiPodRzad = 0;
                    }
                }
                if (znakiPodRzad >= plansza.IleByWygrac)
                {
                    return true;
                }
                znakiPodRzad = 0;
            }
            return false;
        }
    }
    
}

