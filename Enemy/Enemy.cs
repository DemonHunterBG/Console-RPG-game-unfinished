using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    public class Enemy
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
    }
}
