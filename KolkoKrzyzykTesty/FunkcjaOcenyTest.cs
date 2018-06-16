using System;
using Xunit;
using KolkoKrzyzyk;


namespace KolkoKrzyzykTesty
{
    public class FunkcjaOcenyTest
    {
        FunkcjaOceny sut = new FunkcjaOceny();

        [Fact]
        public void WRzedzie()
        {
            Plansza plansza = new Plansza(3, 3);
            plansza.UstawZnak(0, 0, Znak.Krzyzyk);
            plansza.UstawZnak(0, 1, Znak.Krzyzyk);
            plansza.UstawZnak(0, 2, Znak.Krzyzyk);
            plansza.UstawZnak(1, 0, Znak.Kolko);
            plansza.UstawZnak(2, 0, Znak.Kolko);

            Assert.Equal(0, sut.Ocena(plansza, Znak.Kolko));
            Assert.Equal(10, sut.Ocena(plansza, Znak.Krzyzyk));
        }

        [Fact]
        public void WRzedzie2()
        {
            Plansza plansza = new Plansza(3, 3);
            plansza.UstawZnak(0, 0, Znak.Kolko);
            plansza.UstawZnak(0, 1, Znak.Kolko);
            plansza.UstawZnak(0, 2, Znak.Kolko);
            plansza.UstawZnak(1, 0, Znak.Krzyzyk);
            plansza.UstawZnak(2, 0, Znak.Krzyzyk);

            Assert.Equal(0, sut.Ocena(plansza, Znak.Krzyzyk));
            Assert.Equal(10, sut.Ocena(plansza, Znak.Kolko));
        }

        [Fact]
        public void WKolumnie()
        {
            Plansza plansza = new Plansza(3, 3);
            plansza.UstawZnak(0, 0, Znak.Krzyzyk);
            plansza.UstawZnak(1, 0, Znak.Krzyzyk);
            plansza.UstawZnak(2, 0, Znak.Krzyzyk);
            plansza.UstawZnak(1, 1, Znak.Kolko);
            plansza.UstawZnak(2, 2, Znak.Kolko);

            Assert.Equal(0, sut.Ocena(plansza, Znak.Kolko));
            Assert.Equal(10, sut.Ocena(plansza, Znak.Krzyzyk));
        }

        [Fact]
        public void Skos1()
        {
            Plansza plansza = new Plansza(3, 3);
            plansza.UstawZnak(0, 0, Znak.Krzyzyk);
            plansza.UstawZnak(1, 1, Znak.Krzyzyk);
            plansza.UstawZnak(2, 2, Znak.Krzyzyk);
            plansza.UstawZnak(1, 0, Znak.Kolko);
            plansza.UstawZnak(2, 0, Znak.Kolko);

            Assert.Equal(0, sut.Ocena(plansza, Znak.Kolko));
            Assert.Equal(10, sut.Ocena(plansza, Znak.Krzyzyk));
        }

        [Fact]
        public void Skos2()
        {
            Plansza plansza = new Plansza(3, 3);
            plansza.UstawZnak(0, 2, Znak.Krzyzyk);
            plansza.UstawZnak(1, 1, Znak.Krzyzyk);
            plansza.UstawZnak(2, 0, Znak.Krzyzyk);
            plansza.UstawZnak(1, 0, Znak.Kolko);
            plansza.UstawZnak(2, 2, Znak.Kolko);

            Assert.Equal(0, sut.Ocena(plansza, Znak.Kolko));
            Assert.Equal(10, sut.Ocena(plansza, Znak.Krzyzyk));
        }

        [Fact]
        public void MinMax()
        {
            Plansza plansza = new Plansza(3, 3);
            plansza.UstawZnak(0, 0, Znak.Krzyzyk);
            plansza.UstawZnak(2, 2, Znak.Kolko);
            plansza.UstawZnak(0, 1, Znak.Krzyzyk);
            plansza.UstawZnak(2, 1, Znak.Kolko);
            plansza.UstawZnak(2, 0, Znak.Krzyzyk);
            plansza.UstawZnak(1, 2, Znak.Kolko);
            plansza.UstawZnak(1, 1, Znak.Krzyzyk);

            Komputer komputer = new Komputer(Znak.Kolko);
            var ruch = komputer.Graj(plansza);
        }
    }
}
