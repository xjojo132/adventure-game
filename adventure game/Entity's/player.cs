using System;
using System.Collections.Generic;
using System.Linq;
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

        public int healPotion = 3;
        public int healPotionGain = 15;

        public Player(string name) : base(name, 100, 10) // Standaardwaarden voor health en attack
        {
            level = 1;
            Xp = 0;
            xpToNextLevel = 100;
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
            Console.WriteLine($"You gained {amount} XP!");

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
            Attack += 5;
            healPotionGain += 5;
            Console.WriteLine($"You leveled up! You are now level {level}!");
        }
    }
}