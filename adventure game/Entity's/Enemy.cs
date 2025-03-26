using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game
{
    class Enemy : Entity
    {


        public Enemy(string name, int health, int attack, int speed) : base(name, health, attack, speed) { }
        
            
            public override void Attack(Entity target)
            {
                ConWrite.Print($"{name} attacks for {attackPower} damage! \n you now have {target.health} health left", ConsoleColor.Red);
                target.TakeDamage(attackPower);
            }

    }
    
}
