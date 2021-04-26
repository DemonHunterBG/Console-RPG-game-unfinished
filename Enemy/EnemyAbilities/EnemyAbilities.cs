using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class EnemyAbilities
    {
        public static void NormalAttack(Hero hero, Enemy enemy)
        {
            EnemyTurn.attacktext = NormalAttackText(enemy.clasS, enemy.name);
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
        public static string NormalAttackText(string clasS, string name)
        {
            string attacktext = "";
            switch (clasS)
            {
                case "Undead":
                    switch (name)
                    {
                        case "Zombie":
                            attacktext = "-The Zombie hits you with its arm.";
                            break;
                        case "Skeleton":
                            attacktext = "-The Skeleton slashes you with its dagger.";
                            break;
                    }
                    break;
                case "Slime":
                    switch (name)
                    {
                        case "White Slime":
                            attacktext = "-The Slime shoots a piece of its body at you.";
                            break;
                        case "Green Slime":
                            attacktext = "-The Slime shoots a piece of its body at you.";
                            break;
                        case "Blue Slime":
                            attacktext = "-The Slime shoots a piece of its body at you.";
                            break;
                        case "Red Slime":
                            attacktext = "-The Slime shoots a piece of its body at you.";
                            break;
                    }
                    break;
            }
            return attacktext;
        }
    }
}
