using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;

namespace RPG_Game_2
{
    class Start
    {
        static void Main()
        {
            Console.SetWindowSize(120, 32);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   ");
            Miscellaneous.SlowWriter("The Bloodiest Moon");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine("-Press Enter to continue-");
            Console.ReadLine();
            Heroes();
        }
        public static void Heroes()
        {
            Console.Clear();
            Miscellaneous.HeroStatsUI();
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();

            //1.name|2.class|3.hp|4.maxhp|5.mana|6.maxmana|7.manaregen|8.action|9.maxaction|10.actionregen|
            //11.armour|12.maxarmour|13.dodge|14.maxdodge|15.dmg|16.truedmg|17.critical|18.maxcritical|19.int|20.level|21.exp|22.maxexperience
            //---1------2------3--4--5--6--7--8--9--10-11-12-13-14-15-16-17-18-19-20-21-22
            Hero hero = new Hero("name", "class", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 100);

            switch (choice.ToLower())
            {
                case "knight":
                    HeroLibrary.KnightStats(hero);
                    break;
                case "hunter":
                    HeroLibrary.HunterStats(hero);
                    break;
                case "rogue":
                    HeroLibrary.RogueStats(hero);
                    break;
                default:
                    Heroes();
                    break;
            }
            CurrentToMaxStats(hero);
            Name(hero);
        }
        static void Name(Hero hero)
        {
            Console.Clear();
            Miscellaneous.SlowWriter("What is the name of this lost ");
            Console.ForegroundColor = ConsoleColor.Red;
            Miscellaneous.SlowWriter("SOUL... ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.Write("Name: ");
            Console.ForegroundColor = ConsoleColor.Red;
            hero.name = Console.ReadLine();
            Console.WriteLine("");
            Miscellaneous.SlowWriter("Welcome to Hell....");
            Thread.Sleep(500);
            Miscellaneous.SlowWriter(hero.name + "...");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(500);
            Map.Start(hero);
        }

        private static void CurrentToMaxStats(Hero hero)
        {
            hero.maxhealth = hero.health;
            hero.maxmana = hero.mana;
            hero.maxaction = hero.action;
            hero.maxarmour = hero.armour;
            hero.maxevasion = hero.evasion;
            hero.maxcritical = hero.critical;
        }
    }
}
