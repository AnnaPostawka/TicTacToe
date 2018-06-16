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

        public Ruch PobierzWspolrzedne(int rozmiar)
        {
            int x = PobierzX(rozmiar);
            int y = PobierzY(rozmiar);
            Ruch ruch = new Ruch(x, y);
            return ruch;
        }

        private int PobierzX(int rozmiar)
        {
            string output = "X: ";
            return Pobierz(0, rozmiar - 1, output);
        }

        private int PobierzY(int rozmiar)
        {
            string output = "Y: ";
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

                // ToInt32 can throw FormatException or OverflowException.
                try
                {
                    wartosc = Convert.ToInt32(input);
                }
                catch (FormatException)
                {
                    Console.WriteLine("To nie jest wartosc liczbowa.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Za duza liczba.");
                }
                finally
                {
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
