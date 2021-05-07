using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class BattleFlow
    {
        public static int turn = 1;
        public static void Battle(Hero hero, Enemy enemy)
        {

            bool battle = true;

            while (battle == true)
            {
                TurnStatsResetter();

                HeroBeforeRoundStatsReset(hero);
                EnemyBeforeRoundStatsReset(enemy);

                Miscellaneous.BattleUI(hero, enemy);

                bool enemydefeated = false;
                if (hero.health <= 0)
                {
                    HeroDefeated(hero, enemy);
                }
                else if (enemy.health <= 0 && battle == true && enemydefeated == false)
                {
                    battle = YouHaveDefeatedTheEnemy(hero, enemy);
                    enemydefeated = true;
                }

                if (battle == true)
                {
                    HeroTurn.HeroAction(hero, enemy);

                    HeroTurnStatsSetter(hero, enemy);

                    bool continuee = true;

                    if (enemy.health <= 0)
                        continuee = false;
                    else
                    {
                        EnemyTurn.EnemyAction(hero, enemy);
                        EnemyTurnStatsSetter(hero);
                    }

                    HeroBeforeRoundStatsReset(hero);
                    EnemyBeforeRoundStatsReset(enemy);

                    HeroOutcome(hero, enemy);

                    if (enemy.health <= 0 && battle == true && enemydefeated == false)
                    {
                        battle = YouHaveDefeatedTheEnemy(hero, enemy);
                        enemydefeated = true;
                    }
                    else if (battle == true && continuee == true)
                    {
                        EnemyOutcome();
                    }
                    if (hero.health <= 0 && battle == true)
                    {
                        HeroDefeated(hero, enemy);
                    }
                }

                AfterTurnStats(hero);
                Console.ReadLine();
            }
            AfterBattleStats(hero);

        }

        private static void TurnStatsResetter()
        {
            HeroTurn.attacktext = "";
            HeroTurn.enemyhealth = 0;
            HeroTurn.damagedealt = 0;
            HeroTurn.outcome = "";
            HeroTurn.herohealth = 0;
            HeroTurn.heroarmour = 0;
            HeroTurn.heroevasion = 0;
            EnemyTurn.attacktext = "";
            EnemyTurn.damagedealt = 0;
            EnemyTurn.outcome = "";
            EnemyTurn.herohealth = 0;
        }

        private static void EnemyOutcome()
        {
            switch (EnemyTurn.outcome)
            {
                case "Dodge":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(EnemyTurn.attacktext);
                    Console.ForegroundColor = ConsoleColor.White;
                    Miscellaneous.HeroDodge();
                    break;
                case "Normal":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(EnemyTurn.attacktext);
                    Console.ForegroundColor = ConsoleColor.White;
                    Miscellaneous.DamageTaken(EnemyTurn.damagedealt);
                    break;
                case "Critical":
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(EnemyTurn.attacktext);
                    Miscellaneous.EnemyCritical();
                    Console.ForegroundColor = ConsoleColor.White;
                    Miscellaneous.DamageTaken(EnemyTurn.damagedealt);
                    break;
            }
        }

        private static void HeroOutcome(Hero hero, Enemy enemy)
        {
            switch (HeroTurn.outcome)
            {
                case "Dodge":
                    Miscellaneous.BattleUI(hero, enemy);
                    Console.WriteLine(HeroTurn.attacktext);
                    Miscellaneous.EnemyDodge(enemy);
                    break;
                case "Normal":
                    Miscellaneous.BattleUI(hero, enemy);
                    Console.WriteLine(HeroTurn.attacktext);
                    Miscellaneous.DamageDealt(HeroTurn.damagedealt);
                    break;
                case "Critical":
                    Miscellaneous.BattleUI(hero, enemy);
                    Console.WriteLine(HeroTurn.attacktext);
                    Miscellaneous.HeroCritical();
                    Miscellaneous.DamageDealt(HeroTurn.damagedealt);
                    break;
                case "Blue":
                    Miscellaneous.BattleUI(hero, enemy);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine(HeroTurn.attacktext);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Green":
                    Miscellaneous.BattleUI(hero, enemy);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(HeroTurn.attacktext);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "Grey":
                    Miscellaneous.BattleUI(hero, enemy);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(HeroTurn.attacktext);
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }

        private static void HeroTurnStatsSetter(Hero hero, Enemy enemy)
        {
            if (HeroTurn.heroevasion != 0)
                hero.evasion = HeroTurn.heroevasion;
            if (HeroTurn.herohealth != 0)
                hero.health = HeroTurn.herohealth;
            if (hero.health > hero.maxhealth)
                hero.health = hero.maxhealth;
            if (HeroTurn.heroarmour != 0)
                hero.armour = HeroTurn.heroarmour;
            if (HeroTurn.outcome != "Dodge")
            {
                if (HeroTurn.enemyhealth != 0)
                    enemy.health = HeroTurn.enemyhealth;
                if (enemy.health > enemy.maxhealth)
                    enemy.health = enemy.maxhealth;
            }
        }

        private static void EnemyTurnStatsSetter(Hero hero)
        {
            if (EnemyTurn.outcome != "Dodge")
            {
                if (EnemyTurn.herohealth != 0)
                    hero.health = EnemyTurn.herohealth;
            }

        }

        private static void HeroBeforeRoundStatsReset(Hero hero)
        {
            if (hero.health > hero.maxhealth)
                hero.health = hero.maxhealth;
            if (hero.health < 0)
                hero.health = 0;
            if (hero.damage < 0)
                hero.damage = 0;
            if (hero.truedamage < 0)
                hero.truedamage = 0;
            if (hero.mana > hero.maxmana)
                hero.mana = hero.maxmana;
            if (hero.mana < 0)
                hero.mana = 0;
            if (hero.action > hero.maxaction)
                hero.action = hero.maxaction;
            if (hero.action < 0)
                hero.action = 0;
            if (hero.armour > hero.maxarmour)
                hero.armour = hero.maxarmour;
            if (hero.armour < 0)
                hero.armour = 0;
            if (hero.critical > hero.maxcritical)
                hero.critical = hero.maxcritical;
            if (hero.critical < 0)
                hero.critical = 0;
            if (hero.evasion > hero.maxevasion)
                hero.evasion = hero.maxevasion;
            if (hero.evasion < 0)
                hero.evasion = 0;
        }

        private static void EnemyBeforeRoundStatsReset(Enemy enemy)
        {
            if (enemy.health < 0)
                enemy.health = 0;
            if (enemy.health > enemy.maxhealth)
                enemy.health = enemy.maxhealth;
            if (enemy.damage < 0)
                enemy.damage = 0;
            if (enemy.truedamage < 0)
                enemy.truedamage = 0;
            if (enemy.armour > enemy.maxarmour)
                enemy.armour = enemy.maxarmour;
            if (enemy.armour < 0)
                enemy.armour = 0;
            if (enemy.critical > enemy.maxcritical)
                enemy.critical = enemy.maxcritical;
            if (enemy.critical < 0)
                enemy.critical = 0;
            if (enemy.evasion > enemy.maxevasion)
                enemy.evasion = enemy.maxevasion;
            if (enemy.evasion < 0)
                enemy.evasion = 0;
        }

        private static void HeroDefeated(Hero hero, Enemy enemy)
        {
            if (hero.health < 0)
                hero.health = 0;

            Miscellaneous.HeroDefeatedText();

            Console.ReadLine();
            Endings.BadEnd(hero);
        }

        private static bool YouHaveDefeatedTheEnemy(Hero hero, Enemy enemy)
        {
            bool battle = false;

            if (enemy.health < 0)
                enemy.health = 0;

            Miscellaneous.EnemyDefeatedText(enemy);
            Console.ReadLine();
            Console.Clear();
            LevelUpAndOtherDrops.AfterBattleDrops(hero, enemy);

            return battle;
        }

        private static void AfterTurnStats(Hero hero)
        {
            turn++;
            hero.mana = hero.mana + hero.manaregen;
            hero.action = hero.action + hero.actionregen;
        }

        private static void AfterBattleStats(Hero hero)
        {
            hero.maxhealth = Hero.maxhealthstatic;
            hero.manaregen = Hero.manaregenstatic;
            hero.actionregen = Hero.actionregenstatic;
            hero.damage = Hero.damagestatic;
            hero.evasion = Hero.evasionstatic;
            hero.maxevasion = Hero.evasionstatic;
            hero.critical = Hero.criticalstatic;
            hero.maxcritical = Hero.criticalstatic;
        }
    }
}
