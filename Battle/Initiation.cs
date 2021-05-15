using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class Initiation
    {
        public static void Initiattion(Hero hero, Enemy enemy)
        {
            StatsToStatic(hero);

            if (hero.initiative > enemy.initiative)
            {
                BiggerInitiative(hero, enemy);
            }
            else if (hero.initiative < enemy.initiative)
            {
                SmallerInitiative(enemy);
            }
            else
            {
                EqualInitiative(enemy);
            }

            BeforeBattleStats(hero);

            BattleFlow.BattleStart(hero, enemy);
        }

        private static void StatsToStatic(Hero hero)
        {
            Hero.maxhealthstatic = hero.maxhealth;
            Hero.manaregenstatic = hero.manaregen;
            Hero.actionregenstatic = hero.actionregen;
            Hero.evasionstatic = hero.maxevasion;
            Hero.damagestatic = hero.damage;
            Hero.criticalstatic = hero.maxcritical;
        }

        private static void BiggerInitiative(Hero hero, Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-You take the initiative.");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-Choose a buff");
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

        private static void SmallerInitiative(Enemy enemy)
        {
            Console.Clear();
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
                    enemy.health = Math.Round(enemy.health * 1.2, 2);
                    enemy.maxhealth = Math.Round(enemy.maxhealth * 1.2, 2);
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
                default:
                    SmallerInitiative(enemy);
                        break;
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        private static void EqualInitiative(Enemy enemy)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-You and the {0} start to battle.", enemy.name);
            Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void BeforeBattleStats(Hero hero)
        {
            hero.mana = hero.maxmana;
            hero.action = hero.maxaction;

            BattleFlow.turn = 1;
        }
    }
}
