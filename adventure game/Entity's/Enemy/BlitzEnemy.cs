using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game
{
    class BlitzEnemy : Enemy

    {
        private int chance = 50;
        
        
        public BlitzEnemy(string name, int health, int attack, int speed) : base(name, health, attack, speed)
        {
            
        }

        public override void Attack(Entity target)
        {
            target.TakeDamage(attackPower);
            ConWrite.Print($"The {name} strikes back for {attackPower} damage!  \n you now have {target.health} health left", ConsoleColor.Red);
            int random = new Random().Next(100);
            if (chance >= random)
            {
                target.TakeDamage(attackPower);
                ConWrite.Print($"The {name} is super fast and strikes again for {attackPower} damage!  \n you now have {target.health} health left", ConsoleColor.Red);
                chance /= 2;
            }
        }
    }
}
