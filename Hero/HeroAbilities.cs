using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class HeroAbilities
    {
        public void NormalAttack(Hero hero, Enemy enemy)
        {
            HeroTurn.attacktext = NormalAttackText(hero.clasS);
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                HeroTurn.outcome = "Dodge";
            }
            else
            {
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Critical";
                }
                else
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage), 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Normal";
                }
            }

        }
        public string NormalAttackText(string clasS)
        {
            string attacktext = "";
            switch (clasS)
            {
                case "Knight":
                    attacktext = "-You slash with your sword.";
                    break;
                case "Hunter":
                    attacktext = "-You shoot an arrow.";
                    break;
                case "Rogue":
                    attacktext = "-You slash with your dagger.";
                    break;
            }
            return attacktext;
        }

        public void AbilityOneKnight(Hero hero, Enemy enemy) //attack * 2
        {
            HeroTurn.attacktext = "-You enchant your sword before slashing at the " + enemy.name + ".";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                HeroTurn.outcome = "Dodge";
            }
            else
            {
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2 * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Critical";
                }
                else
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Normal";
                }
            }
        }
        public void AbilityTwoKnight(Hero hero, Enemy enemy) //attack * 2
        {
            HeroTurn.attacktext = "-You slash at the " + enemy.name + " with all your strength.";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                HeroTurn.outcome = "Dodge";
            }
            else
            {
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2 * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Critical";
                }
                else
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Normal";
                }
            }
        }
        public void AbilityThreeKnight(Hero hero, Enemy enemy) //armour * 2
        {
            HeroTurn.outcome = "Blue";
            HeroTurn.heroarmour = Math.Round(hero.armour * 2, 2, MidpointRounding.ToEven);
            if (HeroTurn.heroarmour > 100)
            {
                HeroTurn.heroarmour = 100;
            }
            HeroTurn.attacktext = "-You put your shield up. Shield:" + Math.Round(HeroTurn.heroarmour, 2, MidpointRounding.ToEven) +"%.";
        }
        public void AbilityFourKnight(Hero hero, Enemy enemy) //heal
        {
            HeroTurn.attacktext = "-You heal yourself for 5 health.";
            HeroTurn.outcome = "Green";
            HeroTurn.herohealth = hero.health + 5;
            if (HeroTurn.herohealth > hero.maxhealth)
            {
                HeroTurn.herohealth = hero.maxhealth;
            }
        }

        public void AbilityOneHunter(Hero hero, Enemy enemy)
        {
            HeroTurn.attacktext = "-You fire a magical arrow at the " + enemy.name + ".";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                HeroTurn.outcome = "Dodge";
            }
            else
            {
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 1.5 * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Critical";
                }
                else
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 1.5, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Normal";
                }
            }
        }
        public void AbilityTwoHunter(Hero hero, Enemy enemy)
        {
            HeroTurn.attacktext = "-You take aim and fire at the " + enemy.name + "'s weak point.";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                HeroTurn.outcome = "Dodge";
            }
            else
            {
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Critical";
                }
                else
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage  + hero.truedamage), 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Normal";
                }
            }
        }
        public void AbilityThreeHunter(Hero hero, Enemy enemy)
        {
            HeroTurn.attacktext = "-You fire a volley of magical fire arrows at the " + enemy.name + ".";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                HeroTurn.outcome = "Dodge";
            }
            else
            {

                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 3 * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Critical";
                }
                else
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 3, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Normal";
                }
            }
        }
        public void AbilityFourHunter(Hero hero, Enemy enemy)
        {
            HeroTurn.attacktext = "-You heal yourself for 10 health.";
            HeroTurn.outcome = "Green";
            HeroTurn.herohealth = hero.health + 8;
            if (HeroTurn.herohealth > hero.maxhealth)
            {
                HeroTurn.herohealth = hero.maxhealth;
            }
            HeroTurn.heroevasion = 100;
        }

        public void AbilityOneRogue(Hero hero, Enemy enemy)
        {
            HeroTurn.attacktext = "-You stab the " + enemy.name + " and quickly dash away.";
            HeroTurn.heroevasion = 100;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                HeroTurn.outcome = "Dodge";
            }
            else
            {
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Critical";
                }
                else
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage), 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Normal";
                }
            }
        }
        public void AbilityTwoRogue(Hero hero, Enemy enemy)
        {
            HeroTurn.attacktext = "-You stab the " + enemy.name + "'s weak point.";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                HeroTurn.outcome = "Dodge";
            }
            else
            {
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical * 2)
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Critical";
                }
                else
                {
                    HeroTurn.enemyhealth = Math.Round(enemy.health - (hero.damage + hero.truedamage), 2, MidpointRounding.ToEven);
                    HeroTurn.damagedealt = enemy.health - HeroTurn.enemyhealth;
                    HeroTurn.outcome = "Normal";
                }
            }
        }
        public void AbilityThreeRogue(Hero hero, Enemy enemy)
        {
            HeroTurn.attacktext = "-You throw a magical smoke bomb. The " + enemy.name + " can't hit you.";
            HeroTurn.outcome = "Blue";
            HeroTurn.heroevasion = 100;
        }
        public void AbilityFourRogue(Hero hero, Enemy enemy)
        {
            HeroTurn.attacktext = "-You heal yourself for 10 health and become faster.";
            HeroTurn.outcome = "Green";
            HeroTurn.herohealth = hero.health + 10;
            if (HeroTurn.herohealth > hero.maxhealth)
            {
                HeroTurn.herohealth = hero.maxhealth;
            }
            hero.evasion += 5;
            hero.maxevasion += 5;
        }
    }
}
