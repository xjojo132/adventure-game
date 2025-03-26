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

        public TankEnemy(string name, int health, int attack,int speed, int armor) : base(name, health, attack, speed)
        {
            this.armorValue = armor;
        }

        public override void TakeDamage(int damage)
        {
            int reducedDamage = Math.Max(damage - armorValue, 0);
            base.TakeDamage(reducedDamage);
            ConWrite.Print($"{name} absorbs {armorValue} damage! due to its heavy armor", ConsoleColor.Red);
        }

    }
}
