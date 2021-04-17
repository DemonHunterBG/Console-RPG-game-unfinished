using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class TierOneEnemyLibrary
    {
        public static void Zombie(Hero hero, Enemy enemy)
        {
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
        }

        public static void Slime(Enemy enemy)
        {
            Console.WriteLine("A slime approaches...");
            enemy.name = "Slime";
            enemy.clasS = "Slime";
            enemy.health = 10;
            enemy.armour = 0;
            enemy.evasion = 50;
            enemy.damage = 0;
            enemy.truedamage = 2;
            enemy.initiative = 2;
        }

        public static void Skeleton(Enemy enemy)
        {
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
        }
    }
}
