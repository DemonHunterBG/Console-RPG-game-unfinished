using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace RPG_Game_2
{
    class Miscellaneous
    {
        public static int turn = 1;
        public static void SlowWriter(string text)
        {
            Random rnd = new Random();
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(rnd.Next(30, 60));
            }
        }
        public static void BattleUI(Hero hero, Enemy enemy)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("   -Turn[{0}]\n" + "====================================", Miscellaneous.turn);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("   -" + hero.name + "   -Class: " + hero.clasS);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[Health:{0}/{1}|Mana:{2}/{3}|Action:{4}/{5}|Damage:{6}|True Damage:{7}]\n[Critical Chance:{8}%|Armour:{9}%|Evasion Chance:{10}%|Initiative:{11}]",
                hero.health, hero.maxhealth, hero.mana, hero.maxmana, hero.action, hero.maxaction, hero.damage, hero.truedamage, hero.critical, hero.armour, hero.evasion, hero.initiative);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n   -" + enemy.name + "   -Class: " + enemy.clasS);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[Health:{0}/{1}|Damage:{2}|True Damage:{3}]\n[Critical Chance:{4}%|Armour:{5}%|Evasion Chance:{6}%|Initiative:{7}]",
                enemy.health, enemy.maxhealth, enemy.damage, enemy.truedamage, enemy.critical, enemy.armour, enemy.evasion, enemy.initiative);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("====================================");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[[a]Normal Atttack|[s]Abilities]");
        }
        public static void DamageDealt(double damagedealt)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-You deal {0} damage.", Math.Round(damagedealt, 2, MidpointRounding.ToEven));
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void DamageTaken(double damagetaken)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("-You take {0} damage.", Math.Round(damagetaken, 2, MidpointRounding.ToEven));
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void NotEnoughMana()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-Not enough Mana...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        public static void NotEnoughAction()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-Not enough Action...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        public static void NotEnoughManaAndAction()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-Not enough Mana...");
            Console.WriteLine("-Not enough Action...");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }
        public static void HeroDodge()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-You dodge the attack.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void EnemyDodge()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-The enemy dodges your attack.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void HeroCritical()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-You hit a week spot. You deal critical damage.");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void EnemyCritical()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("-You are badly hit. You take critical damage.");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
