using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    class Konsola
    {
        public Konsola()
        {
        }

        public int PobierzRozmiar()
        {
            string output = "Podaj dlugosc boku planszy (od 3 do 10): ";
            return Pobierz(3, 10, output);
        }

        public int PobierzIleByWygrac(int rozmiar)
        {
            string output = "Podaj dlugosc zwycieskiej sekwencji: ";
            return Pobierz(3, rozmiar, output);
        }

        public Ruch PobierzWspolrzedne(Plansza plansza)
        {
            Console.WriteLine("Podaj wspolrzedne: ");
            int x = PobierzX(plansza.Rozmiar);
            int y = PobierzY(plansza.Rozmiar);
            while (plansza.Znak(x, y) != Znak.Puste)
            {
                Console.WriteLine("To pole jest juz zajete. Podaj inne wspolrzedne: ");
                x = PobierzX(plansza.Rozmiar);
                y = PobierzY(plansza.Rozmiar);
            }
            return new Ruch(x, y);
        }

        private int PobierzX(int rozmiar)
        {
            string output = "Wiersz: ";
            return Pobierz(0, rozmiar - 1, output);
        }

        private int PobierzY(int rozmiar)
        {
            string output = "Kolumna: ";
            return Pobierz(0, rozmiar - 1, output);
        }

        private int Pobierz(int dolnaGranica, int gornaGranica, string output)
        {
            int wartosc = 0;
            bool repeat = true;

            while (repeat)
            {
                Console.Write(output);

                string input = Console.ReadLine();
                
                try
                {
                    wartosc = Convert.ToInt32(input);
                    if (wartosc > gornaGranica)
                    {
                        Console.WriteLine("Za duza wartosc.");
                    }
                    else if (wartosc < dolnaGranica)
                    {
                        Console.WriteLine("Za mala wartosc.");
                    }
                    else
                    {
                        repeat = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("To nie jest wartosc liczbowa.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Za duza liczba.");
                }
            }
            return wartosc;
        }

        public bool PobierzGracza(int nr)
        {
            bool isHuman = true;
            bool repeat = true;

            while (repeat)
            {
                Console.Write("Wybierz, czy Gracz{0} ma byc czlowiekiem czy komputerem [C / K]: ", nr);

                string input = Console.ReadLine();
                if (input.CompareTo("C") == 0 || input.ToLower().CompareTo("c") == 0)
                {
                    isHuman = true;
                    repeat = false;
                }
                else if (input.CompareTo("K") == 0 || input.ToLower().CompareTo("k") == 0)
                {
                    isHuman = false;
                    repeat = false;
                }
                else
                {
                    Console.WriteLine("Nieprawidlowa wartosc.");
                }
            }
            return isHuman;
        }
    }
}
