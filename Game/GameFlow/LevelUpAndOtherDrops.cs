using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class LevelUpAndOtherDrops
    {
        public static void AfterBattleDrops(Hero hero, Enemy enemy)
        {
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            double experienceGained = 0;
            int moneyGained = 0;

            ExpAndMoneyPerMap(rnd, ref experienceGained, ref moneyGained);

            hero.experience += experienceGained;
            Hero.money += moneyGained;

            Miscellaneous.AfterBattleRewards(experienceGained, moneyGained);

            LevelUpChecker(hero);
        }

        private static void ExpAndMoneyPerMap(Random rnd, ref double experienceGained, ref int moneyGained)
        {
            switch (Map.mapnumber)
            {
                case 1:
                    experienceGained = rnd.Next(15, 21);
                    moneyGained = rnd.Next(3, 9);
                    break;
                case 2:
                    experienceGained = rnd.Next(21, 35);
                    moneyGained = rnd.Next(6, 13);
                    break;
                case 3:
                    experienceGained = rnd.Next(35, 46);
                    moneyGained = rnd.Next(10, 17);
                    break;
            }
        }

        public static void LevelUpChecker (Hero hero)
        {
            while (hero.experience >= hero.maxexperience)
            {
                hero.level++;
                double leftOverExperience = hero.experience - hero.maxexperience;
                hero.experience = leftOverExperience;
                hero.maxexperience += 50;
            }
        }
    }
}
