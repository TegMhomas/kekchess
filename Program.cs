using System;
using System.Drawing;
using System.Collections.Generic;

namespace kekchess
{
    class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player("p1");
            Player p2 = new Player("p2");
            Board plansza = new Board();
            plansza.start(p1, p2);
            Console.WriteLine("\n\n\n");
            while (true)
            {
                plansza.move(p1);
                Console.WriteLine("\n\n\n");
                plansza.move(p2);
            }
        }
    }
}
