using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace adventure_game
{

    class Player : Entity
    {

        public int Xp { get; private set; }
        public int level { get; private set; }

        public int xpToNextLevel;
        private double criticalRate = 0.2; 
        private double criticalMultiplier = 2; 

        public int healPotion = 3;
        public int healPotionGain = 15;

        public Player(string name) : base(name, 100, 10) 
        {
            level = 1;
            Xp = 0;
            xpToNextLevel = 100;
        }

        public override void Attack(Entity target)
        {
            Random rand = new Random();
            int damage = AttackPower;

            if (rand.NextDouble() < criticalRate)
            {

                damage = (int)(damage * criticalMultiplier);
                ConWrite.Print($"CRITICAL HIT!!!", ConsoleColor.DarkRed);

            }

            ConWrite.Print($"{Name} attacks {target.Name} for {damage} damage!", ConsoleColor.Green);
            target.TakeDamage(damage);

        }

        public void Heal()
        {
            if (healPotion > 0)
            {
                Health += healPotionGain;
                if (Health >= maxHealth)
                {
                    Health = maxHealth;
                }
                healPotion--;
            }
            else
            {
                Console.WriteLine("You have no more health potions left!");
            }
        }

        public void GainXp(int amount) 
        {
            Xp += amount;
            ConWrite.Print($"You gained {amount} XP!");

            if (Xp >= xpToNextLevel)
            {
                levelUp();
            }

        }

        public void levelUp()
        {
            level++;
            Xp -= xpToNextLevel;
            xpToNextLevel += 50;
            maxHealth = maxHealth + 20;
            Health = maxHealth;
            AttackPower += 5;
            healPotionGain += 5;
            ConWrite.Print($"You leveled up! You are now level {level}!");
            ConWrite.Print($"You Gained 20 max health and +5 attack power!");
        }
    }
}