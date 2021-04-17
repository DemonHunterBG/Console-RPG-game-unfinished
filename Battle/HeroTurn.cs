using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class HeroTurn
    {
        public static string attacktext = "";
        public static double enemyhealth = 0;
        public static double damagedealt = 0;
        public static string outcome = "";
        public static double herohealth = 0;
        public static double heroarmour = 0;
        public static double heroevasion = 0;
        public static void HeroAction(Hero hero, Enemy enemy)
        {
            HeroAbilities ability = new HeroAbilities();
            Console.Write("Decision:");
            string choice = Console.ReadLine();

            switch (choice.ToLower())
            {
                case "a":
                    ability.NormalAttack(hero, enemy);

                    break;
                case "s":
                    hero.AbilitiesPerClass(hero.clasS, hero.mana, hero.action);
                    Console.Write("Decision:");
                    string choice2 = Console.ReadLine();
                    Console.WriteLine("");
                    switch (hero.clasS)
                    {
                        case "Knight":
                            KnightAbilities(hero, enemy, ability, choice2);
                            break;

                        case "Hunter":
                            HunterAbilities(hero, enemy, ability, choice2);
                            break;

                        case "Rogue":
                            RogueAbilities(hero, enemy, ability, choice2);
                            break;
                    }
                    break;
                case "n":
                    {
                        Console.WriteLine("-You do nothing...");
                    }
                    break;
                default:
                    BattleFlow.Battle(hero, enemy);
                    break;
            }
        }

        private static void KnightAbilities(Hero hero, Enemy enemy, HeroAbilities ability, string choice2)
        {
            switch (choice2)
            {
                case "1":
                    if (hero.mana >= 5)
                    {
                        hero.mana -= 5;
                        ability.AbilityOneKnight(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughMana();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                case "2":
                    if (hero.action >= 5)
                    {
                        hero.action -= 5;
                        ability.AbilityTwoKnight(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughAction();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                case "3":
                    if (hero.mana >= 2)
                    {
                        hero.mana -= 2;
                        ability.AbilityThreeKnight(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughMana();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                case "4":
                    if (hero.action >= 6)
                    {
                        hero.action -= 6;
                        ability.AbilityFourKnight(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughAction();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                default:
                    BattleFlow.Battle(hero, enemy);
                    break;
            }
        }

        private static void HunterAbilities(Hero hero, Enemy enemy, HeroAbilities ability, string choice2)
        {
            switch (choice2)
            {
                case "1":
                    if (hero.mana >= 5)
                    {
                        hero.mana -= 5;
                        ability.AbilityOneHunter(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughMana();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                case "2":
                    if (hero.action >= 5)
                    {
                        hero.action -= 5;
                        ability.AbilityTwoHunter(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughAction();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                case "3":
                    if (hero.mana >= 15)
                    {
                        hero.mana -= 15;
                        ability.AbilityThreeHunter(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughMana();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                case "4":
                    if (hero.action >= 10)
                    {
                        hero.action -= 10;
                        ability.AbilityFourHunter(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughAction();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                default:
                    BattleFlow.Battle(hero, enemy);
                    break;
            }
        }

        private static void RogueAbilities(Hero hero, Enemy enemy, HeroAbilities ability, string choice2)
        {
            switch (choice2)
            {
                case "1":
                    if (hero.action >= 10)
                    {
                        hero.action -= 10;
                        ability.AbilityOneRogue(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughAction();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                case "2":
                    if (hero.action >= 6)
                    {
                        hero.action -= 6;
                        ability.AbilityTwoRogue(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughAction();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                case "3":
                    if (hero.mana >= 4)
                    {
                        hero.mana -= 4;
                        ability.AbilityThreeRogue(hero, enemy);
                    }
                    else
                    {
                        Miscellaneous.NotEnoughMana();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                case "4":
                    if (hero.mana >= 10 && hero.action >= 5)
                    {
                        hero.mana -= 10;
                        hero.action -= 5;
                        ability.AbilityFourRogue(hero, enemy);
                    }
                    else
                    {
                        if (hero.mana <= 10 && hero.action < 5)
                            Miscellaneous.NotEnoughManaAndAction();
                        else if (hero.mana < 10)
                            Miscellaneous.NotEnoughMana();
                        else if (hero.action < 5)
                            Miscellaneous.NotEnoughAction();
                        BattleFlow.Battle(hero, enemy);
                    }
                    break;
                default:
                    BattleFlow.Battle(hero, enemy);
                    break;
            }
        }
    }
}
