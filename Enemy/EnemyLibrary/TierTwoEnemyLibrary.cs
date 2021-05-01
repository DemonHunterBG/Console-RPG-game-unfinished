using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class TierTwoEnemyLibrary
    {
        //Undead
        public static void ZombieDefender(Hero hero, Enemy enemy)
        {
            Console.WriteLine("A Zombie Defender approaches...");
            enemy.name = "Zombie Defender";
            enemy.clasS = "Undead";
            enemy.health = 20;
            enemy.armour = 50;
            enemy.evasion = 0;
            enemy.damage = 1;
            enemy.truedamage = 0;
            hero.critical = 5;
            enemy.initiative = 0;
        }
        //Arachnid
        public static void GiantSpider(Enemy enemy)
        {
            Console.WriteLine("A Giant Spider approaches...");
            enemy.name = "Giant Spider";
            enemy.clasS = "Arachnid";
            enemy.health = 10;
            enemy.armour = 30;
            enemy.evasion = 10;
            enemy.damage = 3;
            enemy.truedamage = 0;
            enemy.critical = 5;
            enemy.initiative = 2;
        }
    }
}
