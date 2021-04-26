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

        public static void WhiteSlime(Enemy enemy)
        {
            Console.WriteLine("A White Slime approaches...");
            enemy.name = "White Slime";
            enemy.clasS = "Slime";
            enemy.health = 10;
            enemy.armour = 0;
            enemy.evasion = 50;
            enemy.damage = 0;
            enemy.truedamage = 2;
            enemy.initiative = 2;
        }

        public static void GreenSlime(Enemy enemy)
        {
            Console.WriteLine("A Green Slime approaches...");
            enemy.name = "Green Slime";
            enemy.clasS = "Slime";
            enemy.health = 20;
            enemy.armour = 0;
            enemy.evasion = 50;
            enemy.damage = 2;
            enemy.truedamage = 0;
            enemy.initiative = 2;
        }

        public static void BlueSlime(Enemy enemy)
        {
            Console.WriteLine("A Blue Slime approaches...");
            enemy.name = "Blue Slime";
            enemy.clasS = "Slime";
            enemy.health = 10;
            enemy.armour = 50;
            enemy.evasion = 50;
            enemy.damage = 2;
            enemy.truedamage = 0;
            enemy.initiative = 2;
        }

        public static void RedSlime(Enemy enemy)
        {
            Console.WriteLine("A Red Slime approaches...");
            enemy.name = "Red Slime";
            enemy.clasS = "Slime";
            enemy.health = 10;
            enemy.armour = 0;
            enemy.evasion = 50;
            enemy.damage = 1;
            enemy.truedamage = 0;
            enemy.initiative = 2;
        }

        public static void YellowSlime(Enemy enemy)
        {
            Console.WriteLine("A Yellow Slime approaches...");
            enemy.name = "Yellow Slime";
            enemy.clasS = "Slime";
            enemy.health = 2;
            enemy.armour = 0;
            enemy.evasion = 90;
            enemy.damage = 2;
            enemy.truedamage = 0;
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
