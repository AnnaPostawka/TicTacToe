using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    public class Konsola
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

        public int PobierzX(int rozmiar)
        {
            string output = "X: ";
            return Pobierz(0, rozmiar - 1, output);
        }

        public int PobierzY(int rozmiar)
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
    }
}
