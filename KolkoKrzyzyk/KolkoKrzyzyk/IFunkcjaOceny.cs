using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    abstract class IFunkcjaOceny
    {
        protected Plansza plansza;
        protected int x;
        protected int y;
        public IFunkcjaOceny(Plansza plansza)
        {
            this.plansza = plansza;
        }
        public abstract int Ocena(int x, int y);
    }

    class ImWiecejPodRzadTymLepiej : IFunkcjaOceny
    {
        public ImWiecejPodRzadTymLepiej(Plansza plansza) : base(plansza)
        {
        }

        public override int Ocena(int x, int y)
        {
            this.x = x;
            this.y = y;
            return Policz_wartosc();
        }

        private int Policz_wartosc()
        {
            int ocena = 0;
            int znakIPustePodRzad = 1;

            // wiersz
            znakIPustePodRzad += ZnakIPustePodRzad(Stan.maleje, Stan.stoi);
            znakIPustePodRzad += ZnakIPustePodRzad(Stan.rosnie, Stan.stoi);
            // kolumna
            int tmp = 1;
            tmp += ZnakIPustePodRzad(Stan.stoi, Stan.maleje);
            tmp += ZnakIPustePodRzad(Stan.stoi, Stan.rosnie);
            if (tmp > znakIPustePodRzad)
                znakIPustePodRzad = tmp;
            // skos 1
            tmp = 1;
            tmp += ZnakIPustePodRzad(Stan.maleje, Stan.maleje);
            tmp += ZnakIPustePodRzad(Stan.rosnie, Stan.rosnie);
            if (tmp > znakIPustePodRzad)
                znakIPustePodRzad = tmp;
            // skos 2
            tmp = 1;
            tmp += ZnakIPustePodRzad(Stan.maleje, Stan.rosnie);
            tmp += ZnakIPustePodRzad(Stan.rosnie, Stan.maleje);
            if (tmp > znakIPustePodRzad)
                znakIPustePodRzad = tmp;

            if (znakIPustePodRzad <= plansza.IleByWygrac)
            {
                ocena = 0;
            }
            else
            {
                ocena = znakIPustePodRzad;
            }

            return ocena;
        }

        private int ZnakIPustePodRzad(Stan stanX, Stan stanY)
        {
            Znak przeciwnyZnak = plansza.PoleGry[x, y].PrzeciwnyZnak();
            Kratka ruchomaKratka = new Kratka();
            int znakIPustePodRzad = 0;
            int x2 = 0, y2 = 0;

            if (Warunek1(x, stanX) && Warunek1(y, stanY))
            {
                x2 = PrzesuniecieWspolrzednej(x, stanX);
                y2 = PrzesuniecieWspolrzednej(y, stanY);
                ruchomaKratka = plansza.PoleGry[x2, y2];
                while (ruchomaKratka.Znak != przeciwnyZnak && Warunek2(x2, stanX) && Warunek2(y2, stanY))
                {
                    znakIPustePodRzad++;
                    x2 = PrzesuniecieWspolrzednej(x2, stanX);
                    y2 = PrzesuniecieWspolrzednej(y2, stanY);
                    if (Warunek2(x2, stanX) && Warunek2(y2, stanY))
                    {
                        ruchomaKratka = plansza.PoleGry[x2, y2];
                    }
                }
            }
            return znakIPustePodRzad;
        }

        private enum Stan { maleje, rosnie, stoi };

        private bool Warunek1(int z, Stan stanZ)
        {
            int rozmiar = plansza.Rozmiar;
            if (stanZ == Stan.maleje)
                if (z > 0)
                    return true;
            if (stanZ == Stan.rosnie)
                if (z < rozmiar - 1)
                    return true;
            if (stanZ == Stan.stoi)
                return true;
            return false;
        }

        private bool Warunek2(int z, Stan stanZ)
        {
            int rozmiar = plansza.Rozmiar;
            if (stanZ == Stan.maleje)
                if (z >= 0)
                    return true;
            if (stanZ == Stan.rosnie)
                if (z < rozmiar)
                    return true;
            if (stanZ == Stan.stoi)
                return true;
            return false;
        }

        private int PrzesuniecieWspolrzednej(int z, Stan stanZ)
        {
            if (stanZ == Stan.maleje)
                return z - 1;
            if (stanZ == Stan.rosnie)
                return z + 1;
            return z;
        }
    }


    class CzyWygrana : IFunkcjaOceny
    {
        public CzyWygrana(Plansza plansza) : base(plansza)
        {
        }

        public override int Ocena(int x, int y)
        {
            this.x = x;
            this.y = y;
            if (CzyZwycieskaSekwencja() == true)
            {
                return 1;
            }
            return 0;
        }

        private bool CzyZwycieskaSekwencja()
        {
            int znakPodRzad = 1;

            // wiersz
            znakPodRzad += ZnakPodRzad(Stan.maleje, Stan.stoi);
            znakPodRzad += ZnakPodRzad(Stan.rosnie, Stan.stoi);
            // kolumna
            int tmp = 1;
            tmp += ZnakPodRzad(Stan.stoi, Stan.maleje);
            tmp += ZnakPodRzad(Stan.stoi, Stan.rosnie);
            if (tmp > znakPodRzad)
                znakPodRzad = tmp;
            // skos 1
            tmp = 1;
            tmp += ZnakPodRzad(Stan.maleje, Stan.maleje);
            tmp += ZnakPodRzad(Stan.rosnie, Stan.rosnie);
            if (tmp > znakPodRzad)
                znakPodRzad = tmp;
            // skos 2
            tmp = 1;
            tmp += ZnakPodRzad(Stan.maleje, Stan.rosnie);
            tmp += ZnakPodRzad(Stan.rosnie, Stan.maleje);
            if (tmp > znakPodRzad)
                znakPodRzad = tmp;

            if (znakPodRzad == plansza.IleByWygrac)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private int ZnakPodRzad(Stan stanX, Stan stanY)
        {
            Znak znak = plansza.PoleGry[x, y].Znak;
            Kratka ruchomaKratka = new Kratka();
            int znakPodRzad = 0;
            int x2 = 0, y2 = 0;

            if (Warunek1(x, stanX) && Warunek1(y, stanY))
            {
                x2 = PrzesuniecieWspolrzednej(x, stanX);
                y2 = PrzesuniecieWspolrzednej(y, stanY);
                ruchomaKratka = plansza.PoleGry[x2, y2];
                while (ruchomaKratka.Znak == znak && Warunek2(x2, stanX) && Warunek2(y2, stanY))
                {
                    znakPodRzad++;
                    x2 = PrzesuniecieWspolrzednej(x2, stanX);
                    y2 = PrzesuniecieWspolrzednej(y2, stanY);
                    if (Warunek2(x2, stanX) && Warunek2(y2, stanY))
                    {
                        ruchomaKratka = plansza.PoleGry[x2, y2];
                    }
                }
            }
            return znakPodRzad;
        }

        private enum Stan { maleje, rosnie, stoi };

        private bool Warunek1(int z, Stan stanZ)
        {
            int rozmiar = plansza.Rozmiar;
            if (stanZ == Stan.maleje)
                if (z > 0)
                    return true;
            if (stanZ == Stan.rosnie)
                if (z < rozmiar - 1)
                    return true;
            if (stanZ == Stan.stoi)
                return true;
            return false;
        }

        private bool Warunek2(int z, Stan stanZ)
        {
            int rozmiar = plansza.Rozmiar;
            if (stanZ == Stan.maleje)
                if (z >= 0)
                    return true;
            if (stanZ == Stan.rosnie)
                if (z < rozmiar)
                    return true;
            if (stanZ == Stan.stoi)
                return true;
            return false;
        }

        private int PrzesuniecieWspolrzednej(int z, Stan stanZ)
        {
            if (stanZ == Stan.maleje)
                return z - 1;
            if (stanZ == Stan.rosnie)
                return z + 1;
            return z;
        }
    }

}

