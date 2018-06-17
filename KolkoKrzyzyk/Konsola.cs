using System;

namespace KolkoKrzyzyk
{
    class Konsola
    {
        public static int PobierzRozmiar()
        {
            string output = "Podaj dlugosc boku planszy (od 3 do 10): ";
            return Pobierz(3, 10, output);
        }

        public static int PobierzIleByWygrac(int rozmiar)
        {
            string output = "Podaj dlugosc zwycieskiej sekwencji: ";
            return Pobierz(3, rozmiar, output);
        }

        public static Ruch PobierzWspolrzedne(Plansza plansza)
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

        private static int PobierzX(int rozmiar)
        {
            string output = "Wiersz: ";
            return Pobierz(0, rozmiar - 1, output);
        }

        private static int PobierzY(int rozmiar)
        {
            string output = "Kolumna: ";
            return Pobierz(0, rozmiar - 1, output);
        }

        private static int Pobierz(int dolnaGranica, int gornaGranica, string output)
        {
            int wartosc = 0;
            bool powtarzaj = true;

            while (powtarzaj)
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
                        powtarzaj = false;
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

        public static bool PobierzGracza(int nr)
        {            
            string output = "Wybierz, czy Gracz" + nr.ToString() + " ma byc czlowiekiem czy komputerem [C / K]: ";
            bool czyCzlowiek = PobierzOdpowiedz(output, "C", "K");

            return czyCzlowiek;
        }
        

        public static bool JakiAlgorytm(ref int ilePoziomow)
        {
            string output = "Wybierz glebokosc algorytmu MinMax: ";
            ilePoziomow = Pobierz(1, 10, output);

            output = "Zastosowac ciecia Alpha-Beta? [T / N]: ";
            bool alphaBeta = PobierzOdpowiedz(output, "T", "N");

            return alphaBeta;
        }

        private static bool PobierzOdpowiedz(string output, string prawda, string falsz)
        {
            bool odpowiedz = true;
            bool powtarzaj = true;

            while (powtarzaj)
            {
                Console.Write(output);

                string input = Console.ReadLine();
                if (input.CompareTo(prawda) == 0 || input.ToLower().CompareTo(prawda.ToLower()) == 0)
                {
                    odpowiedz = true;
                    powtarzaj = false;
                }
                else if (input.CompareTo(falsz) == 0 || input.ToLower().CompareTo(falsz.ToLower()) == 0)
                {
                    odpowiedz = false;
                    powtarzaj = false;
                }
                else
                {
                    Console.WriteLine("Nieprawidlowa wartosc.");
                }
            }
            return odpowiedz;
        }
    }
}
