using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class Map
    {
        public static char[,] map;
        public static int[,] mapVisibility;
        public static string mapname;
        public static int mapnumber = 0;
        public static void Start(Hero hero)
        {
            mapnumber++;
            MapGenerator.MapGenController();
            MapController(hero);
        }

        public static void MapController(Hero hero)
        {

            Console.Clear();

            map[0, 0] = 'X';
            int x = 0;
            int y = 0;
            char marker = '+';
            bool end = false;

            while (end == false)
            {
                Console.Clear();

                int n = 1;

                MapVisibilityChanger(y, x);
                n = MapUI(hero, n);

                map[y, x] = marker;
                marker = '+';

                MovementAndOther(ref x, ref y, ref end, map);

                if (map[y, x] != '-')
                {
                    marker = map[y, x];
                }

                MapCharacterChecker(hero, ref marker, ref end);

                map[y, x] = 'X';

                if (hero.health == 0)
                {
                    Endings.BadEnd(hero);
                }
            }
            Endings.End(hero);
            Console.ReadLine();
        }

        static void MapVisibilityChanger(int y, int x)
        {
            mapVisibility[y, x] = 1;
            if (y + 1 < map.GetLength(0))
                mapVisibility[y + 1, x] = 1;
            if (y != 0)
                mapVisibility[y - 1, x] = 1;
            if (x + 1 < map.GetLength(1))
                mapVisibility[y, x + 1] = 1;
            if (x != 0)
                mapVisibility[y, x - 1] = 1;
        }
        private static int MapUI(Hero hero, int n)
        {
            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int cow = 0; cow < map.GetLength(1); cow++)
                {
                    MapVisibilityChecker(row, cow);

                    Console.Write(" ");
                }
                n = NextToMapUi(hero, n);

                Console.WriteLine("");
            }

            return n;
        }
        private static void MapVisibilityChecker(int row, int cow)
        {
            if (mapVisibility[row, cow] == 1)
            {
                MapCharacterColor(row, cow);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write('?');
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static int NextToMapUi(Hero hero, int n)
        {
            switch (n)
            {
                case 1:
                    Console.Write("   [{0} - {1}]", hero.name, hero.clasS);
                    break;
                case 2:
                    if (hero.health < 0)
                    {
                        hero.health = 0;
                    }
                    if (hero.health > hero.maxhealth)
                    {
                        hero.health = hero.maxhealth;
                    }
                    Console.Write("   [Level:{0} | EXP:{1}/{2} | HP:{3}/{4}]",
                        hero.level, hero.experience, hero.maxexperience, hero.health, hero.maxhealth);
                    break;
                case 3:
                    Console.Write("   [Starting Mana:{0} Mana Regen:{1} | Starting Action:{2} Action Regen:{3}]",
                        hero.maxmana, hero.manaregen, hero.maxaction, hero.actionregen);
                    break;
                case 4:
                    Console.Write("   [DMG:{0} TrueDmg:{1} Critical Chance:{2}% | Armour:{3}%  Evasion Chance:{4}%]",
                        hero.damage, hero.truedamage, hero.critical, hero.armour, hero.evasion);
                    break;
                case 5:
                    Console.Write("   [Initiative:{0} | Enemies encoutered:{1}] [Map:{2} - {3}]", hero.initiative, Enemy.enemyCount, Map.mapnumber, Map.mapname);
                    break;
            }
            n++;
            return n;
        }

        private static void MovementAndOther(ref int x, ref int y, ref bool end, char [,] map)
        {
            Console.WriteLine("\n[up[w]|down[s]|left[a]|right[d]]   [end[e]]");
            Console.Write("Decision:");
            string direction = Console.ReadLine();
            switch (direction.ToLower())
            {
                case "up":
                case "w":
                    if (y != 0)
                    {
                        if (map[y - 1, x] != 'M')
                        {
                            y = y - 1;
                        }
                    }
                    break;
                case "down":
                case "s":
                    if (y + 1 < map.GetLength(0))
                    {
                        if (map[y + 1, x] != 'M')
                        {
                            y = y + 1;
                        }
                    }
                    break;
                case "left":
                case "a":
                    if (x != 0)
                    {
                        if (map[y, x - 1] != 'M')
                        {
                            x = x - 1;
                        }
                    }
                    break;
                case "right":
                case "d":
                    if (x + 1 < map.GetLength(1))
                    {
                        if (map[y, x + 1] != 'M')
                        {
                            x = x + 1;
                        }
                    }
                    break;
                case "end":
                case "e":
                    end = true;
                    break;
            }
        }

        private static void MapCharacterColor(int row, int cow)
        {
            switch (map[row, cow])
            {
                case 'X':
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case '-':
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                case 'E':
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case '!':
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case 'M':
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    break;
                case 'S':
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.Write(map[row, cow]);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void MapCharacterChecker(Hero hero, ref char marker, ref bool end)
        {
            switch (marker)
            {
                case '!':
                    if (Map.mapnumber != 3)
                        Start(hero);
                    else 
                        end = true;
                    break;
                case 'E':
                    EnemyEncounter.EnemyEncounterChooser(hero);
                    marker = '+';
                    break;
            }
        }
    }
}
