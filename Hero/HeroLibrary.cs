using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class HeroLibrary
    {
        public static void RogueStats(Hero hero)
        {
            hero.clasS = "Rogue";
            hero.health = 15;
            hero.mana = 10;
            hero.manaregen = 1;
            hero.action = 15;
            hero.actionregen = 3;
            hero.armour = 20;
            hero.evasion = 50;
            hero.damage = 3;
            hero.critical = 10;
            hero.truedamage = 1;
            hero.initiative = 2;
        }

        public static void HunterStats(Hero hero)
        {
            hero.clasS = "Hunter";
            hero.health = 15;
            hero.mana = 15;
            hero.manaregen = 2;
            hero.action = 10;
            hero.actionregen = 2;
            hero.armour = 10;
            hero.evasion = 25;
            hero.damage = 5;
            hero.truedamage = 0;
            hero.critical = 20;
            hero.initiative = 3;
        }

        public static void KnightStats(Hero hero)
        {
            hero.clasS = "Knight";
            hero.health = 30;
            hero.mana = 5;
            hero.manaregen = 1;
            hero.action = 10;
            hero.actionregen = 1;
            hero.armour = 40;
            hero.evasion = 10;
            hero.damage = 3;
            hero.truedamage = 0;
            hero.critical = 5;
            hero.initiative = 1;
        }
    }
}
