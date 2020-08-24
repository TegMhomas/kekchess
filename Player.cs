using System;
using System.Drawing;
using System.Collections.Generic;

namespace kekchess
{
    public class Player
    {
        public string name;
        public List<Pawn> pionki = new List<Pawn>();

        public Player(string fname)
        {
            name = fname;
        }
    }
}