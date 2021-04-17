﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class EnemyEncounter
    {
        public static void EnemyEncounterChooser(Hero hero)
        {
            Console.Clear();
            //1.name|2.hp|3.maxhp|4.armour|5.maxarmour|6.evasion|7.maxevasion|8.damage|9.truedamage|10.critical|11.maxcritical|12.int|13.level
            //--1----2--3--4--5--6--7--8--9--10-11-12-13
            Enemy enemy = new Enemy("Blank", "Class", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0);
            if (Enemy.enemyCount <= 3)
            {
                TierOneEnemies(hero, enemy);
            }

            CurrentToMax(enemy);
            Console.ReadLine();
            Initiation.Initiattion(hero, enemy);
        }

        private static void TierOneEnemies(Hero hero, Enemy enemy)
        {
            Random rnd = new Random();
            int enemyspawnnumber = rnd.Next(1, 4);
            switch (enemyspawnnumber)
            {
                case 1:
                    TierOneEnemyLibrary.Zombie(hero, enemy);
                    break;
                case 2:
                    TierOneEnemyLibrary.Slime(enemy);
                    break;
                case 3:
                    TierOneEnemyLibrary.Skeleton(enemy);
                    break;
            }
        }

        private static void CurrentToMax(Enemy enemy)
        {
            enemy.maxhealth = enemy.health;
            enemy.maxarmour = enemy.armour;
            enemy.maxevasion = enemy.evasion;
        }
    }
}