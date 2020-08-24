using System;
using System.Drawing;
using System.Collections.Generic;

namespace kekchess
{
    public class Board
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        char[,] vboard = new char[10, 10];
        bool[,] occ = new bool[10, 10];

        public Board()
        {
            vboard[0, 0] = '+';
            int smth = 97;
            for (int j = 1; j <= 9; j++)
            {
                vboard[0, j] = (char)(smth - 32);
                smth++;
            }

            smth = 49;
            for (int j = 1; j <= 9; j++)
            {
                vboard[j, 0] = (char)(smth);
                smth++;
            }

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j < 9; j++)
                {
                    vboard[i, j] = 'O';
                    occ[i, j] = false;
                }
            }
        }

        public void render()
        {
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    Console.Write(vboard[i, j] + "    ");
                }
                Console.Write("\n\n");
            }
        }

        public void start(Player p1, Player p2)
        {
            for (int i = 7; i <= 8; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    p1.pionki.Add(new Pawn('X', i, j));
                    vboard[i, j] = p1.pionki[0].graphics;
                    occ[i, j] = true;
                }
            }

            for (int i = 1; i <= 2; i++)
            {
                for (int j = 1; j <= 8; j++)
                {
                    p2.pionki.Add(new Pawn('x', i, j));
                    vboard[i, j] = p2.pionki[0].graphics;
                    occ[i, j] = true;
                }
            }
            render();
        }


        public void place(Point which, Point where, Player pl)
        {
            int count = 0;
            vboard[where.Y, where.X] = vboard[which.Y, which.X];
            vboard[which.Y, which.X] = 'O';
            occ[which.Y, which.X] = false;
            occ[where.Y, where.X] = true;
            foreach (Pawn pionek in pl.pionki)
            {
                if (pl.pionki[count].y == which.X && pl.pionki[count].x == which.Y)
                {
                    pl.pionki[count].x = where.Y;
                    pl.pionki[count].y = where.X;
                    Console.WriteLine(pl.pionki[count].x);
                    Console.WriteLine(pl.pionki[count].y);
                }
                count++;
            }
            render();
        }

        public Point takecoords()
        {
            Point p = new Point();
            char coord;
            Console.Write("\nPodaj ktorym pionkiem chcesz sie ruszyc: \nX:");
            coord = char.Parse(Console.ReadLine());
            p.X = (int)(coord - 96);
            Console.Write("\nY:");
            p.Y = int.Parse(Console.ReadLine());
            return p;
        }

        public bool checkifocc(Point p2)
        {
            if (occ[p2.Y, p2.X] == true)
            {
                Console.WriteLine("Pole jest zajete, wybierz inne pole:");
                return true;
            }
            else
            {
                return false;
            }
        }

        public void move(Player fplayer)
        {
            Point p1 = new Point();
            Point p2 = new Point();
            p1 = takecoords();
            p2 = takecoords();
            while (checkifocc(p2) == true)
            {
                p2 = takecoords();
            }
            place(p1, p2, fplayer);
            Logger.Error(occ[p2.Y, p2.X]);

        }
    }

}