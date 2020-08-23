using System;
using System.Drawing;
using System.Collections.Generic;

namespace kekchess
{
    public class pawn
    {
        public char graphics;
        public int x;
        public int y;


        
        public pawn(char gp, int fx, int fy)
        {
            graphics = gp;
            x=fx;
            y=fy;
        }

        public pawn()
        {
            graphics = 'X';
        }


    }



    public class board
    {
        char[,] vboard = new char[10, 10];
        bool[,] occ = new bool[10, 10];
        
        public board()
        {
            vboard[0, 0] = '+';
            int smth=97;
            for(int j=1; j<=9; j++)
            {
                vboard[0, j] = (char)(smth-32);
                smth++;
            }

            smth = 49;
            for(int j=1; j<=9; j++)
            {
                vboard[j, 0] = (char)(smth);
                smth++;
            }
            
            for(int i=1; i<=9; i++)
            {
                for(int j=1; j<9; j++)
                {
                    vboard[i, j] = 'O';
                    occ[i, j] = false;
                }
            }
        }

        public void render()
        {
            for(int i=0; i<=8; i++)
            {
                for(int j=0; j<=8; j++)
                {
                    Console.Write(vboard[i, j] + "    ");
                }
                Console.Write("\n\n");
            }


        }

        public void start(player p1, player p2)
        {


            for(int i=7; i<=8; i++)
            {
                for(int j=1; j<=8; j++)
                {
                    p1.pionki.Add(new pawn('X', i, j));
                    vboard[i, j] = p1.pionki[0].graphics;
                    occ[i, j] = true;
                }
            }

            for(int i=1; i<=2; i++)
            {
                for(int j=1; j<=8; j++)
                {
                    p2.pionki.Add(new pawn('x', i, j));
                    vboard[i, j] = p2.pionki[0].graphics;
                    occ[i, j] = true;
                }
            }
            render();

        }
        

        public void place(Point which, Point where)
        {
            vboard[where.X, where.Y] = vboard[which.X, which.Y];
            vboard[which.X, which.Y] = 'O';
            occ[which.X, which.Y] = false;
            occ[where.X, where.Y] = true;
            render();
        }

        public void move(player fplayer)
        {
            Point p1 = new Point();
            Point p2 = new Point();
            Console.Write("\nPodaj ktorym pionkiem chcesz sie ruszyc: \n X:");
            p1.X = int.Parse(Console.ReadLine());
            Console.Write("\nY:");
            p1.Y = int.Parse(Console.ReadLine());
            Console.Write("\nPodaj gdzie chcesz sie ruszyc: \n X:");
            p2.X = int.Parse(Console.ReadLine());
            Console.Write("\nY:");
            p2.Y = int.Parse(Console.ReadLine());


            place(p1, p2);
        }

    }

    public class player
    {
        public string name;
        public List<pawn> pionki = new List<pawn>();

        public player(string fname)
        {
            name = fname;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            player p1 = new player("p1");
            player p2 = new player("p2");
            Console.WriteLine("Hello World!\n");
            board plansza = new board();
            plansza.start(p1, p2);
            Console.WriteLine("\n\n\n");
            while(true)
            {
                plansza.move(p1);
            }
           
            
        }
    }
}
