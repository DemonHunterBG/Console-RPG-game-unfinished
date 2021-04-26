using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class EnemyTurn
    {
        public static string attacktext = "";
        public static double damagedealt = 0;
        public static string outcome = "";
        public static double herohealth = 0;
        public static void EnemyAction(Hero hero, Enemy enemy)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int enemyaction;

            switch (enemy.clasS)
            {
                case "Undead":
                    switch (enemy.name)
                    {
                        case "Zombie":
                            enemyaction = rnd.Next(1, 2);
                            switch (enemyaction)
                            {
                                case 1:
                                    EnemyAbilities.NormalAttack(hero, enemy);
                                    break;
                            }
                            break;
                        case "Skeleton":
                            enemyaction = rnd.Next(1, 2);
                            switch (enemyaction)
                            {
                                case 1:
                                    EnemyAbilities.NormalAttack(hero, enemy);
                                    break;
                            }
                            break;
                    }
                    break;
                case "Slime":
                    switch (enemy.name)
                    {
                        case "White Slime":
                            enemyaction = rnd.Next(1, 4);
                            switch (enemyaction)
                            {
                                case 1:
                                case 2:
                                    EnemyAbilities.NormalAttack(hero, enemy);
                                    break;
                                case 3:
                                    WhiteSlime.SpecialAttack(hero, enemy);
                                    break;

                            }
                            break;
                        case "Green Slime":
                            enemyaction = rnd.Next(1, 2);
                            switch (enemyaction)
                            {
                                case 1:
                                    EnemyAbilities.NormalAttack(hero, enemy);
                                    break;

                            }
                            break;
                        case "Blue Slime":
                            enemyaction = rnd.Next(1, 2);
                            switch (enemyaction)
                            {
                                case 1:
                                    EnemyAbilities.NormalAttack(hero, enemy);
                                    break;

                            }
                            break;
                        case "Red Slime":
                            if (BattleFlow.turn >= 10)
                                RedSlime.SpecialAttack(hero, enemy);
                            else
                                EnemyAbilities.NormalAttack(hero, enemy);

                            break;
                        case "Yellow Slime":
                            enemyaction = rnd.Next(1, 2);
                            switch (enemyaction)
                            {
                                case 1:
                                    EnemyAbilities.NormalAttack(hero, enemy);
                                    break;
                            }
                            break;
                    }
                    break;
            }
        }
    }
}
