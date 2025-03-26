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
        public int healPotionGain = 20;

        public Player(string name) : base(name, 100, 10, 15) 
        {
            level = 1;
            Xp = 0;
            xpToNextLevel = 100;
        }

        public override void Attack(Entity target)
        {
            Random rand = new Random();
            int damage = attackPower;

            if (rand.NextDouble() < criticalRate)
            {

                damage = (int)(damage * criticalMultiplier);
                ConWrite.Print($"CRITICAL HIT!!!", ConsoleColor.DarkRed);

            }

            ConWrite.Print($"{name} attacks {target.name} for {damage} damage!", ConsoleColor.Green);
            target.TakeDamage(damage);

        }

        public void Heal()
        {
            if (healPotion > 0)
            {
                health += healPotionGain;
                if (health >= maxHealth)
                {
                    health = maxHealth;
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
            health = maxHealth;
            attackPower += 5;
            healPotionGain += 1;
            speed += 1;
            criticalMultiplier += 0.1;
            healPotionGain += 5;
            ConWrite.Print($"You leveled up! You are now level {level}!");
            ConWrite.Print($"You Gained 20 max health and +5 attack power!");
        }
    }
}