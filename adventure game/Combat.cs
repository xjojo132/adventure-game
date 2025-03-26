using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game
{
    class Combat
    {
        public static void genEnemy(int amount, List<Entity> entityList) 
        {
            Random rand = new Random();
            List<string> enemyNames = new List<string> { "goblin", "orc", "troll", "bandit", "skeleton" };
            for (int i = 0; i < amount; i++)
            {
                int enemyType = rand.Next(100);
                Enemy enemy;
                string randomEnemyName = enemyNames[rand.Next(enemyNames.Count)];
                if (enemyType < 50)
                {
                    enemy = new Enemy(randomEnemyName + (i + 1), rand.Next(30, 60), rand.Next(5, 15), rand.Next(10, 20));
                   
                }
                else if (enemyType < 75)
                {
                    enemy = new TankEnemy(randomEnemyName +(i + 1) , rand.Next(40, 70), rand.Next(4, 12), rand.Next(2, 6), rand.Next(1, 10));
                   
                }
                else
                {
                    enemy = new BlitzEnemy(randomEnemyName + (i + 1), rand.Next(25, 50), rand.Next(6, 12), rand.Next(20, 30));
                    
                }
                entityList.Add(enemy);
            }

        }



    }
}
