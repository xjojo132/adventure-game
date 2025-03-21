using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game
{
    class BlitzEnemy : Enemy
    {
        private double extraAttackChance;
        public BlitzEnemy(string name, int health, int attack, double extraAttackChance) : base(name, health, attack)
        {
            this.extraAttackChance = extraAttackChance;
        }

        public override void Attack(Entity target)
        {
            Random rand = new Random();
            do
            {
                ConWrite.Print($"{Name} attacks for {AttackPower} damage!", ConsoleColor.Red);
                target.TakeDamage(AttackPower);
                extraAttackChance *= 0.75;
            }
            while (rand.NextDouble() < extraAttackChance);
        }
    }
}
