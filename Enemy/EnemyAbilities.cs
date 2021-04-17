using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class EnemyAbilities
    {
        public void NormalAttack(Hero hero, Enemy enemy)
        {
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
                    EnemyTurn.herohealth = Math.Round(hero.health - (enemy.damage - (enemy.damage * (hero.armour * 0.01)) + enemy.truedamage) * 2, 2, MidpointRounding.ToEven);
                    EnemyTurn.damagedealt = hero.health - EnemyTurn.herohealth;
                    EnemyTurn.outcome = "Critical";
                }
                else
                {
                    EnemyTurn.herohealth = Math.Round(hero.health - (enemy.damage - (enemy.damage * (hero.armour * 0.01)) + enemy.truedamage), 2, MidpointRounding.ToEven);
                    EnemyTurn.damagedealt = hero.health - EnemyTurn.herohealth;
                    EnemyTurn.outcome = "Normal";
                }
            }
        }
        public void NormalAttackText(string name)
        {
            switch (name)
            {
                case "Zombie":
                    EnemyTurn.attacktext = "-The Zombie hits you with its arm.";
                    break;
                case "Slime":
                    EnemyTurn.attacktext = "-The Slime shoots a piece of its body at you.";
                    break;
                case "Skeleton":
                    EnemyTurn.attacktext = "-The Skeleton slashes you with its blade.";
                    break;
            }
        }
    }
}
