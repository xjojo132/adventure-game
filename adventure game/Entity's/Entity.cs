﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game
{
    class Entity
    {
        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int AttackPower { get; protected set; }
        public int maxHealth { get; set; }

        // Constructor voor de naam, health en attack
        public Entity(string name, int health, int attack)
        {
            Name = name;
            Health = health;
            AttackPower = attack;
            maxHealth = health;
        }

        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        public virtual void Attack(Entity target)
        {
            target.TakeDamage(AttackPower);
        }
    }
}
