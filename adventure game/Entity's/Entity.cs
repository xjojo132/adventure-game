using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game
{
    class Entity
    {
        public string name { get; set; }
        public int health { get; protected set; }
        public int attackPower { get; protected set; }
        public int maxHealth { get; set; }
        public int speed { get; set; }

        // Constructor voor de naam, health en attack
        public Entity(string Name, int Health, int attack, int Speed)
        {
            name = Name;
            health = Health;
            attackPower = attack;
            maxHealth = Health;
            speed = Speed;
        }

        public virtual void TakeDamage(int damage)
        {
            health -= damage;
            if (health < 0) health = 0;
        }

        public virtual void Attack(Entity target)
        {
            target.TakeDamage(attackPower);
        }

        public bool IsDefeated()
        {
            return health <= 0;
        }

        public void EntityList()
        {
            List<Entity> entityList = new List<Entity>();
        }
    }
}
