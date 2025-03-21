using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game
{
    class TankEnemy : Enemy
    {
        private int armorValue;

        public TankEnemy(string name, int health, int attack, int armor) : base(name, health, attack)
        {
            this.armorValue = armor;
        }

        public override void TakeDamage(int damage)
        {
            int reducedDamage = Math.Max(damage - armorValue, 0);
            base.TakeDamage(reducedDamage);
            ConWrite.Print($"{Name} absorbs {reducedDamage} damage! due to its heavy armor", ConsoleColor.Red);
        }

    }
}
