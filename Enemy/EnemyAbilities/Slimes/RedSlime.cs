using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class RedSlime
    {
        public static void SpecialAttack(Hero hero, Enemy enemy)
        {
            EnemyTurn.attacktext = "-The " + enemy.name + " explodes!";
            EnemyTurn.herohealth = Math.Round(hero.health - 15, 2, MidpointRounding.ToEven);
            EnemyTurn.damagedealt = hero.health - EnemyTurn.herohealth;
            EnemyTurn.outcome = "Critical";
            enemy.health = 0;
        }
    }
}
