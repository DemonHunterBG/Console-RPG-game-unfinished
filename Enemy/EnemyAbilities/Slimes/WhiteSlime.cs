using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class WhiteSlime
    {
        public static void SpecialAttack(Hero hero, Enemy enemy)
        {
            EnemyTurn.attacktext = "-The " + enemy.name + " transforms itself into giant spikes!";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance < hero.evasion)
            {
                EnemyTurn.outcome = "Dodge";
            }
            else
            {
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= enemy.critical)
                {
                    EnemyTurn.herohealth = Math.Round(hero.health - (enemy.damage - (enemy.damage * (hero.armour * 0.01)) + enemy.truedamage) * 2 * 2, 2, MidpointRounding.ToEven);
                    EnemyTurn.damagedealt = hero.health - EnemyTurn.herohealth;
                    EnemyTurn.outcome = "Critical";
                }
                else
                {
                    EnemyTurn.herohealth = Math.Round(hero.health - (enemy.damage - (enemy.damage * (hero.armour * 0.01)) + enemy.truedamage), 2 * 2, MidpointRounding.ToEven);
                    EnemyTurn.damagedealt = hero.health - EnemyTurn.herohealth;
                    EnemyTurn.outcome = "Normal";
                }
            }
        }
    }
}
