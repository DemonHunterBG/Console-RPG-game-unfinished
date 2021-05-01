using System;
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
            if (Map.mapnumber == 1)
            {
                TierOneEnemies(hero, enemy);
            }
            else if (Map.mapnumber == 2)
            {
                TierOneEnemies(hero, enemy);
            }
            else if (Map.mapnumber == 3)
            {
                TierOneEnemies(hero, enemy);
            }

            CurrentToMax(enemy);
            Console.ReadLine();
            Initiation.Initiattion(hero, enemy);
        }

        private static void TierOneEnemies(Hero hero, Enemy enemy)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int enemyspawnnumber;
            switch (Map.mapname)
            {
                case "Slime Plains":
                    enemyspawnnumber = rnd.Next(1, 6);
                    switch (enemyspawnnumber)
                    {
                        case 1:
                            TierOneEnemyLibrary.WhiteSlime(enemy);
                            break;
                        case 2:
                            TierOneEnemyLibrary.GreenSlime(enemy);
                            break;
                        case 3:
                            TierOneEnemyLibrary.BlueSlime(enemy);
                            break;
                        case 4:
                            TierOneEnemyLibrary.RedSlime(enemy);
                            break;
                        case 5:
                            TierOneEnemyLibrary.YellowSlime(enemy);
                            break;
                    }
                    break;
                case "Undead Lands":
                    enemyspawnnumber = rnd.Next(1, 5);
                    switch (enemyspawnnumber)
                    {
                        case 1:
                            TierOneEnemyLibrary.Zombie(enemy);
                            break;
                        case 2:
                            TierOneEnemyLibrary.ZombieDog(enemy);
                            break;
                        case 3:
                            TierOneEnemyLibrary.Skeleton(enemy);
                            break;
                        case 4:
                            TierOneEnemyLibrary.SkeletonDog(enemy);
                            break;
                    }
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
