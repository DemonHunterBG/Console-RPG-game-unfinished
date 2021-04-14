using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class Enemy
    {
        public string name;
        public string clasS;
        public double health;
        public double maxhealth;
        public double armour;
        public double maxarmour;
        public double evasion;
        public double maxevasion;
        public double damage;
        public double truedamage;
        public double critical;
        public double maxcritical;
        public double initiative;
        public int level;
        public static int enemyCount = 0;

        public Enemy(string aName, string aClass,  double aHealth, double aMaxhealth, double aArmour, double aMaxarmour, double aEvasion, double aMaxevasion,
            double aDamage, double aTruedamage, double aCritical, double aMaxcritical, double aInitiative, int aLevel)
        {
            name = aName;
            clasS = aClass;
            health = aHealth;
            maxhealth = aMaxhealth;
            armour = aArmour;
            maxarmour = aMaxarmour;
            evasion = aEvasion;
            maxevasion = aMaxevasion;
            damage = aDamage;
            truedamage = aTruedamage;
            critical = aCritical;
            maxcritical = aMaxcritical;
            initiative = aInitiative;
            level = aLevel;
            enemyCount++;
        }
        public double NormalAttack(Hero hero, Enemy enemy)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance < hero.evasion)
            {
                Miscellaneous.HeroDodge();
                return hero.health;
            }
            else
            {
                double finalhealth;
                double damagetaken;
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);

                if (critchance <= enemy.critical)
                {
                    finalhealth = Math.Round(hero.health - (enemy.damage - (enemy.damage * (hero.armour * 0.01)) + enemy.truedamage) * 2, 2, MidpointRounding.ToEven);
                    damagetaken = hero.health - finalhealth;
                    Miscellaneous.EnemyCritical();
                }
                else
                {
                    finalhealth = Math.Round(hero.health - (enemy.damage - (enemy.damage * (hero.armour * 0.01)) + enemy.truedamage), 2, MidpointRounding.ToEven);
                    damagetaken = hero.health - finalhealth;
                }
                Miscellaneous.DamageTaken(damagetaken);
                return finalhealth;
            }
        }
        public void NormalAttackText(string name)
        {
            switch (name)
            {
                case "Zombie":
                    Console.WriteLine("-The Zombie hits you with its arm.");
                    break;
                case "Slime":
                    Console.WriteLine("-The Slime shoots a piece of its body at you.");
                    break;
                case "Skeleton":
                    Console.WriteLine("-The Skeleton slashes you with its blade.");
                    break;
            }
        }
    }
}
