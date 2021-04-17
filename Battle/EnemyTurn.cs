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
            EnemyAbilities ability = new EnemyAbilities();

            Random rnd = new Random();
            int enemyaction = rnd.Next(1, 2);
            switch (enemyaction)
            {
                case 1:
                    ability.NormalAttackText(enemy.name);
                    ability.NormalAttack(hero, enemy);
                    break;
            }
        }
    }
}
