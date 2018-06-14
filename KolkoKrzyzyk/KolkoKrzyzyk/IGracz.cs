using System;
using System.Collections.Generic;
using System.Text;

namespace KolkoKrzyzyk
{
    class Ruch
    {
        private int x;
        private int y;

        public Ruch(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class IGracz
    {
        public Znak Znak { get; set; }

        public Ruch Graj(Plansza plansza)
        {
            Ruch ruch = new Ruch(0, 0);

            return ruch;
        }
    }

    class Czlowiek : IGracz
    {
        public Czlowiek(Znak znak)
        {
            Znak = znak;
        }


    }

    class MinMax : IGracz
    {
        public MinMax(Znak znak)
        {
            Znak = znak;
        }




        /*
        minimax(level, player)  // player may be "computer" or "opponent"
        if (gameover || level == 0)
           return score
        children = all legal moves for this player
        if (player is computer, i.e., maximizing player)
           // find max
           bestScore = -inf
           for each child
              score = minimax(level - 1, opponent)
              if (score > bestScore) bestScore = score
           return bestScore
        else (player is opponent, i.e., minimizing player)
           // find min
           bestScore = +inf
           for each child
              score = minimax(level - 1, computer)
              if (score<bestScore) bestScore = score
           return bestScore

        // Initial Call
        minimax(2, computer)
            */

    }

    class MinMaxAlphaBeta : MinMax
    {
        public MinMaxAlphaBeta(Znak znak) : base(znak)
        {
        }
    }
}

