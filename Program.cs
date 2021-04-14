using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading;
using System.Security.Cryptography;

namespace RPG_Game_2
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("   ");
            Miscellaneous.SlowWriter("The Bloodiest Moon");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine("-Press Enter to continue-");
            Console.ReadLine();
            Heros();
        }
        static void Heros()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Choose your Class");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-Knight-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  -Health:30|Damage:3|True Damage:0 \n  -Mana:5 |Mana Regen:1|Action:10|Action Regen:1 \n  -Armour:40%|Evasion:10%|Critical:5% |Initiative:1");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-Hunter-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  -Health:15|Damage:5|True Damage:0 \n  -Mana:15|Mana Regen:2|Action:10|Action Regen:2 \n  -Armour:10%|Evasion:25%|Critical:20%|Initiative:3");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-Rogue- ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  -Health:15|Damage:3|True Damage:1 \n  -Mana:10|Mana Regen:1|Action:15|Action Regen:3 \n  -Armour:20%|Evasion:50%|Critical:10%|Initiative:2");
            Console.WriteLine("");
            Console.Write("Your choice: ");
            string choice = Console.ReadLine();
                              //1.name|2.class|3.hp|4.maxhp|5.mana|6.maxmana|7.manaregen|8.action|9.maxaction|10.actionregen|
                              //11.armour|12.maxarmour|13.dodge|14.maxdodge|15.dmg|16.truedmg|17.critical|18.maxcritical|19.int|20.level|21.exp|22.maxexperience
                              //---1------2------3--4--5--6--7--8--9--10-11-12-13-14-15-16-17-18-19-20-21-22
            Hero hero = new Hero("name","class", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 100);
            switch (choice.ToLower())
            {
                case "knight":
                    hero.clasS = "Knight";
                    hero.health = 30;
                    hero.mana = 5;
                    hero.manaregen = 1;
                    hero.action = 10;
                    hero.actionregen = 1;
                    hero.armour = 40;
                    hero.evasion = 10;
                    hero.damage = 3;
                    hero.truedamage = 0;
                    hero.critical = 5;
                    hero.initiative = 1;
                    break;
                case "hunter":
                    hero.clasS = "Hunter";
                    hero.health = 15;
                    hero.mana = 15;
                    hero.manaregen = 2;
                    hero.action = 10;
                    hero.actionregen = 2;
                    hero.armour = 10;
                    hero.evasion = 25;
                    hero.damage = 5;
                    hero.truedamage = 0;
                    hero.critical = 20;
                    hero.initiative = 3;
                    break;
                case "rogue":
                    hero.clasS = "Rogue";
                    hero.health = 15;
                    hero.mana = 10;
                    hero.manaregen = 1;
                    hero.action = 15;
                    hero.actionregen = 3;
                    hero.armour = 20;
                    hero.evasion = 50;
                    hero.damage = 3;
                    hero.critical = 10;
                    hero.truedamage = 1;
                    hero.initiative = 2;
                    break;
                default:
                    Heros();
                    break;
            }
            hero.maxhealth = hero.health;
            hero.maxmana = hero.mana;
            hero.maxaction = hero.action;
            hero.maxarmour = hero.armour;
            hero.maxevasion = hero.evasion;
            hero.maxcritical = hero.critical;
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
            Start(hero);
        }
        static void Start(Hero hero)
        {
            Console.Clear();
            char[,] map =
            {

                {'-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-'},
                {'-', '-', '-', '-', '-'},
                {'-', 'E', 'E', 'E', '-'},
                {'-', '-', '-', '-', '!'}
            };
            int[,] mapVisibility =
            {
                {'0', '0', '0', '0', '0'},
                {'0', '0', '0', '0', '0'},
                {'0', '0', '0', '0', '0'},
                {'0', '0', '0', '0', '0'},
                {'0', '0', '0', '0', '0'}
            };
            map[0, 0] = 'X';
            int x = 0;
            int y = 0;
            char marker = '+';
            bool end = false;
            while (end == false)
            {
                Console.Clear();

                hero.mana = hero.maxmana;

                int n = 1;

                mapVisibility[y, x] = 1;
                if (y + 1 < map.GetLength(0))
                    mapVisibility[y + 1, x] = 1;
                if (y != 0)
                    mapVisibility[y - 1, x] = 1;
                if (x + 1 < map.GetLength(1))
                    mapVisibility[y, x + 1] = 1;
                if (x != 0)
                    mapVisibility[y, x - 1] = 1;

                for (int row = 0; row < map.GetLength(0); row++)
                {
                    for (int cow = 0; cow < map.GetLength(1); cow++)
                    {
                        if (mapVisibility[row, cow] == 1)
                        {
                            switch(map[row, cow])
                            {
                                case 'E':
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    break;
                                case '!':
                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    break;
                            }
                            Console.Write(map[row, cow]);
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        else
                        {
                            Console.Write('?');
                        }
                        Console.Write(" ");
                    }
                    switch(n)
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
                            Console.Write("   [Initiative:{0} | Enemies encoutered:{1}]", hero.initiative, Enemy.enemyCount);
                            break;
                    }
                    Console.WriteLine("");
                    n++;
                }
                map[y, x] = marker;
                marker = '+';
                Console.WriteLine("\n[up[w]|down[s]|left[a]|right[d]]   [end[end]]");
                Console.Write("Decision:");
                string direction = Console.ReadLine();
                switch (direction.ToLower())
                {
                    case "up":
                    case "w":
                        if (y != 0)
                        {
                            y = y - 1;
                        }
                        break;
                    case "down":
                    case "s":
                        if (y + 1 < map.GetLength(0))
                        {
                            y = y + 1;
                        }
                        break;
                    case "left":
                    case "a":
                        if (x != 0)
                        {
                            x = x - 1;
                        }
                        break;
                    case "right":
                    case "d":
                        if (x + 1 < map.GetLength(0))
                        {
                            x = x + 1;
                        }
                        break;
                    case "end":
                        end = true;
                        break;
                }

                if (map[y, x] != '-' )
                {
                    marker = map[y, x];
                }

                if (hero.health == 0)
                {
                    end = true;
                }
                switch (marker)
                {
                    case '!':
                        end = true;
                        break;
                    case 'E':
                        EnemyEncounter(hero);
                        marker = '+';
                        break;
                }
                map[y, x] = 'X';
            }
            End(hero);
            Console.ReadLine();
        }
        static void EnemyEncounter(Hero hero)
        {
            Console.Clear();
                                    //1.name|2.hp|3.maxhp|4.armour|5.maxarmour|6.evasion|7.maxevasion|8.damage|9.truedamage|10.critical|11.maxcritical|12.int|13.level
                                    //--1----2--3--4--5--6--7--8--9--10-11-12-13
            Enemy enemy = new Enemy("Blank", "Class", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            if (Enemy.enemyCount <= 3)
            {
                Random rnd = new Random();
                int enemyspawnnumber = rnd.Next(1, 4);
                switch (enemyspawnnumber)
                {
                    case 1:
                        Console.WriteLine("A zombie approaches...");
                        enemy.name = "Zombie";
                        enemy.clasS = "Undead";
                        enemy.health = 20;
                        enemy.armour = 20;
                        enemy.evasion = 0;
                        enemy.damage = 2;
                        enemy.truedamage = 0;
                        hero.critical = 5;
                        enemy.initiative = 0;
                        break;
                    case 2:
                        Console.WriteLine("A slime approaches...");
                        enemy.name = "Slime";
                        enemy.clasS = "Slime";
                        enemy.health = 10;
                        enemy.armour = 0;
                        enemy.evasion = 50;
                        enemy.damage = 0;
                        enemy.truedamage = 2;
                        enemy.initiative = 2;
                        break;
                    case 3:
                        Console.WriteLine("A skeleton approaches...");
                        enemy.name = "Skeleton";
                        enemy.clasS = "Undead";
                        enemy.health = 15;
                        enemy.armour = 0;
                        enemy.evasion = 20;
                        enemy.damage = 3;
                        enemy.truedamage = 0;
                        enemy.critical = 20;
                        enemy.initiative = 1;
                        break;
                }
            }
            enemy.maxhealth = enemy.health;
            enemy.maxarmour = enemy.armour;
            enemy.maxevasion = enemy.evasion;
            Console.ReadLine();
            Initiattion(hero, enemy);
        }
        static void Initiattion(Hero hero, Enemy enemy)
        {
            Hero.maxhealthstatic = hero.maxhealth;
            Hero.manaregenstatic = hero.manaregen;
            Hero.actionregenstatic = hero.actionregen;
            Hero.evasionstatic = hero.maxevasion;
            Hero.damagestatic = hero.damage;
            Hero.criticalstatic = hero.maxcritical;

            if (hero.initiative > enemy.initiative)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-You take the initiative.");
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n-Choose a buff");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-[1]Regenerate 5 health and for this round gain 5 max health.\n-[2]Get +1 damage for this battle.\n-[3]Get +1 Mana and Action regen for this battle.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Choice:");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        hero.maxhealth += 5;
                        hero.health += 5;
                        break;
                    case "2":
                        hero.damage += 1;
                        break;
                    case "3":
                        hero.manaregen += 1;
                        hero.actionregen += 1;
                        break;
                    default:
                        Initiattion(hero, enemy);
                        break;
                }
            }
            else if (hero.initiative < enemy.initiative)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("-The {0} takes the initiative.", enemy.name);
                Console.ReadLine();
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Random rnd = new Random(Guid.NewGuid().GetHashCode());
                int randombuff = rnd.Next(1, 5);
                switch (randombuff)
                {
                    case 1:
                        Console.WriteLine("-The {0} puts extra armour.\n- +10 enemy Armour.", enemy.name);
                        enemy.armour += 10;
                        enemy.maxarmour += 10;
                        break;
                    case 2:
                        Console.WriteLine("-The {0} hardens up for the battle.\n- +20% enemy Health.", enemy.name);
                        enemy.health *= 1.2;
                        enemy.maxhealth *= 1.2;
                        break;
                    case 3:
                        Console.WriteLine("-The {0} gets a running start.\n- +10 enemy Evasion Chance.", enemy.name);
                        enemy.evasion += 10;
                        enemy.maxevasion += 10;
                        break;
                    case 4:
                        Console.WriteLine("-The {0} looks for a weak spot.\n- +10 enemy Critical Chance.", enemy.name);
                        enemy.critical += 10;
                        enemy.maxcritical += 10;
                        break;
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("-You and the {0} start to battle.", enemy.name);
                Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;
            }

            hero.mana = hero.maxmana;
            hero.action = hero.maxaction;

            Battle(hero, enemy);
        }
        static void Battle(Hero hero, Enemy enemy)
        {

            bool battle = true;

            while (battle == true)
            {

                if (hero.health < 0)
                    hero.health = 0;
                if (hero.health > hero.maxhealth)
                    hero.health = hero.maxhealth;
                if (hero.mana < 0)
                    hero.mana = 0;
                if (hero.mana > hero.maxmana)
                    hero.mana = hero.maxmana;
                if (hero.action < 0)
                    hero.action = 0;
                if (hero.action > hero.maxaction)
                    hero.action = hero.maxaction;
                if (hero.damage < 0)
                    hero.damage = 0;
                if (hero.truedamage < 0)
                    hero.truedamage = 0;
                if (hero.armour < 0)
                    hero.armour = 0;
                if (hero.critical > hero.maxcritical)
                    hero.critical = hero.maxcritical;
                if (hero.evasion > hero.maxevasion)
                    hero.evasion = hero.maxevasion;

                hero.armour = hero.maxarmour;
                hero.evasion = hero.maxevasion;
                hero.critical = hero.maxcritical;

                if (enemy.health < 0)
                    enemy.health = 0;
                if (enemy.health > enemy.maxhealth)
                    enemy.health = enemy.maxhealth;
                if (enemy.damage < 0)
                    enemy.damage = 0;
                if (enemy.truedamage < 0)
                    enemy.truedamage = 0;
                if (enemy.armour < 0)
                    enemy.armour = 0;

                Miscellaneous.BattleUI(hero, enemy);

                if (hero.health <= 0)
                {
                    Console.ReadLine();
                    if (hero.health < 0)
                        hero.health = 0;
                    Miscellaneous.BattleUI(hero, enemy);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n-You are bleeding out...");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ReadLine();
                    BadEnd(hero);
                }
                else if (enemy.health <= 0)
                {
                    Console.ReadLine();
                    if (enemy.health < 0)
                        enemy.health = 0;
                    Miscellaneous.BattleUI(hero, enemy);

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n-You have defeated the " + enemy.name);
                    Console.ForegroundColor = ConsoleColor.White;
                    battle = false;
                }

                if (battle == true)
                {
                    HeroAction(hero, enemy);
                    if (enemy.health <= 0)
                    {
                        Console.ReadLine();
                        if (enemy.health < 0)
                            enemy.health = 0;
                        Miscellaneous.BattleUI(hero, enemy);

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("You have defeated the " + enemy.name);
                        Console.ForegroundColor = ConsoleColor.White;
                        battle = false;
                    }
                    if (battle == true)
                    {
                        EnemyAction(hero, enemy);
                        if (hero.health <= 0)
                        {
                            Console.ReadLine();
                            if (hero.health < 0)
                                hero.health = 0;
                            Miscellaneous.BattleUI(hero, enemy);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("You are bleeding out");
                            Console.ReadLine();
                            Console.ForegroundColor = ConsoleColor.White;
                            BadEnd(hero);
                        }
                    }
                }
                Miscellaneous.turn++;
                hero.mana = hero.mana + hero.manaregen;
                hero.action = hero.action + hero.actionregen;
                Console.ReadLine();
            }
            Miscellaneous.turn = 0;
            hero.maxhealth = Hero.maxhealthstatic;
            hero.manaregen = Hero.manaregenstatic;
            hero.actionregen = Hero.actionregenstatic;
            hero.damage = Hero.damagestatic;
            hero.evasion = Hero.evasionstatic;
            hero.maxevasion = Hero.evasionstatic;
            hero.critical = Hero.criticalstatic;
            hero.maxcritical = Hero.criticalstatic;

        }

        static void HeroAction(Hero hero, Enemy enemy)
        {
            Console.Write("Decision:");
            string choice = Console.ReadLine();
            switch (choice.ToLower())
            {
                case "a":
                    hero.NormalAttackText(hero.clasS);
                    enemy.health = hero.NormalAttack(hero, enemy);
                    break;
                case "s":
                    Abilities ability = new Abilities();
                    hero.AbilitiesPerClass(hero.clasS, hero.mana, hero.action);
                    Console.Write("Decision:");
                    string choice2 = Console.ReadLine();
                    Console.WriteLine("");
                    switch (hero.clasS)
                    {
                        case "Knight":
                            switch (choice2)
                            {
                                case "1":
                                    if (hero.mana >= 5)
                                    {
                                        hero.mana -= 5;
                                        enemy.health = ability.AbilityOneKnight(hero, enemy);
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughMana();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                case "2":
                                    if (hero.action >= 5)
                                    {
                                        hero.action -= 5;
                                        enemy.health = ability.AbilityTwoKnight(hero, enemy);
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughAction();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                case "3":
                                    if (hero.mana >= 2)
                                    {
                                        hero.mana -= 2;
                                        hero.armour = ability.AbilityThreeKnight(hero, enemy);
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughMana();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                case "4":
                                    if (hero.action >= 6)
                                    {
                                        hero.action -= 6;
                                        hero.health = ability.AbilityFourKnight(hero, enemy);
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughAction();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                default:
                                    Battle(hero, enemy);
                                    break;
                            }
                            break;

                        case "Hunter":
                            switch (choice2)
                            {
                                case "1":
                                    if (hero.mana >= 5)
                                    {
                                        hero.mana -= 5;
                                        enemy.health = ability.AbilityOneHunter(hero, enemy);
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughMana();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                case "2":
                                    if (hero.action >= 5)
                                    {
                                        hero.action -= 5;
                                        enemy.health = ability.AbilityTwoHunter(hero, enemy);
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughAction();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                case "3":
                                    if (hero.mana >= 15)
                                    {
                                        hero.mana -= 15;
                                        enemy.health = ability.AbilityThreeHunter(hero, enemy);
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughMana();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                case "4":
                                    if (hero.action >= 10)
                                    {
                                        hero.action -= 10;
                                        var stats = ability.AbilityFourHunter(hero, enemy);
                                        hero.health = stats.Item1;
                                        hero.evasion = stats.Item2;
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughAction();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                default:
                                    Battle(hero, enemy);
                                    break;
                            }
                            break;

                        case "Rogue":
                            switch (choice2)
                            {
                                case "1":
                                    if (hero.action >= 10)
                                    {
                                        hero.action -= 10;
                                        var stats = ability.AbilityOneRogue(hero, enemy);
                                        enemy.health = stats.Item1;
                                        hero.evasion = stats.Item2;
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughAction();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                case "2":
                                    if (hero.action >= 6)
                                    {
                                        hero.action -= 6;
                                        enemy.health = ability.AbilityTwoRogue(hero, enemy);
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughAction();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                case "3":
                                    if (hero.mana >= 4)
                                    {
                                        hero.mana -= 4;
                                        enemy.evasion = ability.AbilityThreeRogue(hero, enemy);
                                    }
                                    else
                                    {
                                        Miscellaneous.NotEnoughMana();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                case "4":
                                    if (hero.mana >= 10 && hero.action >= 5)
                                    {
                                        hero.mana -= 10;
                                        hero.action -= 5;
                                        var stats = ability.AbilityFourRogue(hero, enemy);
                                        hero.health = stats.Item1;
                                        hero.evasion = stats.Item2;
                                        hero.maxevasion = stats.Item3;
                                    }
                                    else
                                    {
                                        if (hero.mana <= 10 && hero.action < 5)
                                            Miscellaneous.NotEnoughManaAndAction();
                                        else if (hero.mana < 10)
                                            Miscellaneous.NotEnoughMana();
                                        else if (hero.action < 5)
                                            Miscellaneous.NotEnoughAction();
                                        Battle(hero, enemy);
                                    }
                                    break;
                                default:
                                    Battle(hero, enemy);
                                    break;
                            }
                            break;
                    }
                    break;
                case "n":
                    {
                        Console.WriteLine("-You do nothing...");
                    }
                    break;
                default:
                    Battle(hero, enemy);
                    break;
            }

            enemy.armour = enemy.maxarmour;
            enemy.evasion = enemy.maxevasion;
        }
        static void EnemyAction(Hero hero, Enemy enemy)
        {
            Random rnd = new Random();
            int enemyaction = rnd.Next(1, 2);
            switch (enemyaction)
            {
                case 1:
                    enemy.NormalAttackText(enemy.name);
                    hero.health = enemy.NormalAttack(hero, enemy);
                    break;
            }
        }
        static void End(Hero hero)
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
        static void BadEnd(Hero hero) //BADEND
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Miscellaneous.SlowWriter("You are dead...");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}
