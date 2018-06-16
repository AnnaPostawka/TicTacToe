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
            int najdluzszaSekwencja = Policz(znak, plansza);
            int wrogaSekwencja = Policz(Przeciwny.Znak(znak), plansza);
            if (najdluzszaSekwencja == plansza.IleByWygrac)
                return 100;
            if (najdluzszaSekwencja == plansza.IleByWygrac - 1)
                return 10;
            if (wrogaSekwencja == plansza.IleByWygrac)
                return -100;
            if (wrogaSekwencja == plansza.IleByWygrac - 1)
                return -10;
            return 0;
        }

        private int Policz(Znak znak, Plansza plansza)
        {
            int najdluzszaSekwencja = 0;
            int tmp = 0;
            int tmp2 = 0;

            // rzad
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    if (plansza.Znak(i, j) == znak)
                    {
                        tmp++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                    }
                }
                CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
            }
            if (CzyWygrana(najdluzszaSekwencja, plansza.IleByWygrac) == true)
            {
                return najdluzszaSekwencja;
            }
            // kolumna
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    if (plansza.Znak(j, i) == znak)
                    {
                        tmp++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                    }
                }
                CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
            }
            if (CzyWygrana(najdluzszaSekwencja, plansza.IleByWygrac) == true)
            {
                return najdluzszaSekwencja;
            }
            // skos 1
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j, i + j) == znak)
                    {
                        tmp++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                    }
                    if (plansza.Znak(i + j, j) == znak)
                    {
                        tmp2++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp2, ref najdluzszaSekwencja);
                    }
                }
                CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                CzyNowaNajdluzszaSekwencja(ref tmp2, ref najdluzszaSekwencja);
            }
            if (CzyWygrana(najdluzszaSekwencja, plansza.IleByWygrac) == true)
            {
                return najdluzszaSekwencja;
            }
            // skos 2
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j, plansza.Rozmiar - 1 - i - j) == znak)
                    {
                        tmp++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                    }
                    if (plansza.Znak(j + i, plansza.Rozmiar - 1 - j) == znak)
                    {
                        tmp2++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp2, ref najdluzszaSekwencja);
                    }
                }
                CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                CzyNowaNajdluzszaSekwencja(ref tmp2, ref najdluzszaSekwencja);
            }
            return najdluzszaSekwencja;
        }


        /*
        public int Ocena(Plansza plansza, Znak znak)
        {
            int najdluzszaSekwencja = 0;
            int tmp = 0;
            int tmp2 = 0;
            // rzad
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    if(plansza.Znak(i, j) == znak)
                    {
                        tmp++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                    }
                }
                CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
            }
            if (CzyWygrana(najdluzszaSekwencja, plansza.IleByWygrac) == true)
            {
                return WagaZwyciestwa;
            }
            // kolumna
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar; j++)
                {
                    if (plansza.Znak(j, i) == znak)
                    {
                        tmp++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                    }
                }
                CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
            }
            if (CzyWygrana(najdluzszaSekwencja, plansza.IleByWygrac) == true)
            {
                return WagaZwyciestwa;
            }
            // skos 1
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j, i+j) == znak)
                    {
                        tmp++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                    }
                    if (plansza.Znak(i+j, j) == znak)
                    {
                        tmp2++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp2, ref najdluzszaSekwencja);
                    }
                }
                CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                CzyNowaNajdluzszaSekwencja(ref tmp2, ref najdluzszaSekwencja);
            }
            if (CzyWygrana(najdluzszaSekwencja, plansza.IleByWygrac) == true)
            {
                return WagaZwyciestwa;
            }
            // skos 2
            for (int i = 0; i < plansza.Rozmiar; i++)
            {
                for (int j = 0; j < plansza.Rozmiar - i; j++)
                {
                    if (plansza.Znak(j, plansza.Rozmiar - 1 - i - j) == znak)
                    {
                        tmp++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                    }
                    if (plansza.Znak(j + i, plansza.Rozmiar - 1 - j) == znak)
                    {
                        tmp2++;
                    }
                    else
                    {
                        CzyNowaNajdluzszaSekwencja(ref tmp2, ref najdluzszaSekwencja);
                    }
                }
                CzyNowaNajdluzszaSekwencja(ref tmp, ref najdluzszaSekwencja);
                CzyNowaNajdluzszaSekwencja(ref tmp2, ref najdluzszaSekwencja);
            }
            if (CzyWygrana(najdluzszaSekwencja, plansza.IleByWygrac) == true)
            {
                return WagaZwyciestwa;
            }
            return 0;
        }
        */

        private void CzyNowaNajdluzszaSekwencja(ref int tmp, ref int najdluzszaSekwencja)
        {
            if (tmp > najdluzszaSekwencja)
            {
                najdluzszaSekwencja = tmp;
            }
            tmp = 0;
        }
        

        private bool CzyWygrana(int najdluzszaSekwencja, int ileByWygrac)
        {
            if (najdluzszaSekwencja >= ileByWygrac)
                return true;
            return false;
        }
    }
    
}

