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


        public Enemy(string name, int health, int attack) : base(name, health, attack) { }
        
            
            public override void Attack(Entity target)
            {
                ConWrite.Print($"{Name} attacks for {AttackPower} damage!", ConsoleColor.Red);
                target.TakeDamage(AttackPower);
            }

    }
    
}
