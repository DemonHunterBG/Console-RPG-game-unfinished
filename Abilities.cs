using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game_2
{
    class Abilities
    {
        public Abilities()
        {

        }
        public double AbilityOneKnight(Hero hero, Enemy enemy) //attack * 2
        {
            Console.WriteLine("-You enchant your sword before slashing at the {0}.", enemy.name);
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                Miscellaneous.EnemyDodge();
                return enemy.health;
            }
            else
            {
                double finalhealth;
                double damagedealt;
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2 * 2, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                    Miscellaneous.HeroCritical();
                }
                else
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                }
                Miscellaneous.DamageDealt(damagedealt);
                return finalhealth;
            }
        }
        public double AbilityTwoKnight(Hero hero, Enemy enemy) //attack * 2
        {
            Console.WriteLine("-You slash at the {0} with all your strength.", enemy.name);
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                Miscellaneous.EnemyDodge();
                return enemy.health;
            }
            else
            {
                double finalhealth;
                double damagedealt;
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2 * 2, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                    Miscellaneous.HeroCritical();
                }
                else
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                }
                Miscellaneous.DamageDealt(damagedealt);
                return finalhealth;
            }
        }
        public double AbilityThreeKnight(Hero hero, Enemy enemy) //armour * 2
        {
            hero.armour = Math.Round(hero.armour * 2, 2, MidpointRounding.ToEven);
            if (hero.armour > 100)
            {
                hero.armour = 100;
            }
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-You put your shield up. Shield:{0}%.", Math.Round(hero.armour, 2, MidpointRounding.ToEven));
            Console.ForegroundColor = ConsoleColor.White;
            return hero.armour;
        }
        public double AbilityFourKnight(Hero hero, Enemy enemy) //heal
        {
            hero.health += 5;
            if (hero.health > hero.maxhealth)
            {
                hero.health = hero.maxhealth;
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-You heal yourself for 5 health.");
            Console.ForegroundColor = ConsoleColor.White;
            return hero.health;
        }

        public double AbilityOneHunter(Hero hero, Enemy enemy)
        {
            Console.WriteLine("-You fire a magical arrow at the {0}.", enemy.name);
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                Miscellaneous.EnemyDodge();
                return enemy.health;
            }
            else
            {
                double finalhealth;
                double damagedealt;
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 1.5 * 2, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                    Miscellaneous.HeroCritical();
                }
                else
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 1.5, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                }
                Miscellaneous.DamageDealt(damagedealt);
                return finalhealth;
            }
        }
        public double AbilityTwoHunter(Hero hero, Enemy enemy)
        {
            Console.WriteLine("-You take aim and fire at the {0}'s weak point.", enemy.name);
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                Miscellaneous.EnemyDodge();
                return enemy.health;
            }
            else
            {
                double finalhealth;
                double damagedealt;
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                    Miscellaneous.HeroCritical();
                }
                else
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage  + hero.truedamage), 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                }
                Miscellaneous.DamageDealt(damagedealt);
                return finalhealth;
            }
        }
        public double AbilityThreeHunter(Hero hero, Enemy enemy)
        {
            Console.WriteLine("-You fire a volley of magical fire arrows at the {0}.", enemy.name);
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                Miscellaneous.EnemyDodge();
                return enemy.health;
            }
            else
            {
                double finalhealth;
                double damagedealt;
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 3 * 2, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                    Miscellaneous.HeroCritical();
                }
                else
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 3, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                }
                Miscellaneous.DamageDealt(damagedealt);
                return finalhealth;
            }
        }
        public Tuple<double, double> AbilityFourHunter(Hero hero, Enemy enemy)
        {
            hero.health += 8;
            if (hero.health > hero.maxhealth)
            {
                hero.health = hero.maxhealth;
            }
            hero.evasion = 100;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-You heal yourself for 10 health.");
            Console.ForegroundColor = ConsoleColor.White;
            return Tuple.Create(hero.health, hero.evasion);
        }

        public Tuple<double, double> AbilityOneRogue(Hero hero, Enemy enemy)
        {
            Console.WriteLine("-You stab the {0} and quickly dash away.", enemy.name);
            hero.evasion = 100;
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                Miscellaneous.EnemyDodge();
                return Tuple.Create(hero.health, hero.evasion);
            }
            else
            {
                double finalhealth;
                double damagedealt;
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical)
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                    Miscellaneous.HeroCritical();
                }
                else
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage - (hero.damage * (enemy.armour * 0.01)) + hero.truedamage), 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                }
                Miscellaneous.DamageDealt(damagedealt);
                return Tuple.Create(finalhealth, hero.evasion);
            }
        }
        public double AbilityTwoRogue(Hero hero, Enemy enemy)
        {
            Console.WriteLine("-You stab the {0}'s weak point.", enemy.name);
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            int hitchance = rnd.Next(1, 101);
            if (hitchance <= enemy.evasion)
            {
                Miscellaneous.EnemyDodge();
                return enemy.health;
            }
            else
            {
                double finalhealth;
                double damagedealt;
                Random rnd2 = new Random(Guid.NewGuid().GetHashCode());
                int critchance = rnd2.Next(1, 101);
                if (critchance <= hero.critical * 2)
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage + hero.truedamage) * 2, 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                    Miscellaneous.HeroCritical();
                }
                else
                {
                    finalhealth = Math.Round(enemy.health - (hero.damage + hero.truedamage), 2, MidpointRounding.ToEven);
                    damagedealt = enemy.health - finalhealth;
                }
                Miscellaneous.DamageDealt(damagedealt);
                return finalhealth;
            }
        }
        public double AbilityThreeRogue(Hero hero, Enemy enemy)
        {
            hero.evasion = 100;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("-You throw a magical smoke bomb. The {0} can't hit you.", enemy.name);
            Console.ForegroundColor = ConsoleColor.White;
            return hero.evasion;
        }
        public Tuple<double, double, double> AbilityFourRogue(Hero hero, Enemy enemy)
        {
            hero.health += 10;
            if (hero.health > hero.maxhealth)
            {
                hero.health = hero.maxhealth;
            }
            hero.evasion += 5;
            hero.maxevasion += 5;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-You heal yourself for 10 health and become faster.");
            Console.ForegroundColor = ConsoleColor.White;
            return Tuple.Create(hero.health, hero.evasion, hero.maxevasion);
        }
    }
}
