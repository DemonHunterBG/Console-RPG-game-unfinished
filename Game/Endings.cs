using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RPG_Game_2
{
    public static class Endings
    {
        public static void End(Hero hero)
        {
            Console.Clear();
            for (int a = 0; a < 3; a++)
            {
                Console.Clear();
                switch (a)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;
                    case 1:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;
                    case 2:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;
                }
                Console.WriteLine("You have won!!!");
                Thread.Sleep(250);
            }
            Console.ReadLine();
            Environment.Exit(0);
        }
        public static void BadEnd(Hero hero) //BADEND - second try
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Miscellaneous.SlowWriter("You are dead...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
