using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace adventure_game
{
    class Combat
    {

        public static void StartCombat(Player player, List<Entity> entityList) 
        {
            genEnemy(3, entityList);
            foreach (var entity in entityList)
            {
                Console.WriteLine($"{entity.name} joined the battle!");
            }
            CombatLoop(player, entityList);
        }

        private static void CombatLoop(Player player, List<Entity> entityList)
        {

            while (entityList.Any(e => e is Player) && entityList.Any(e => e is Enemy))
            {

                //Console.Clear();
                PlayerStats(player);
                CombatSetup(entityList);

                foreach (var entity in entityList)
                {
                    if (entity.IsDefeated()) continue;

                    if (entity is Player)
                    {
                        ConWrite.Print("What will  do? ([A]ttack / [H]eal / [Q]uit)", ConsoleColor.Blue);
                        string action = Console.ReadLine().ToLower();

                        if (action == "a")
                        {
                            List<Enemy> enemies = entityList.OfType<Enemy>().ToList();
                            Console.WriteLine("\nChoose an enemy to attack:");

                            for (int i = 0; i < enemies.Count; i++)
                            {
                                Console.WriteLine($"{i + 1}. {enemies[i].name} (HP: {enemies[i].health})");
                            }

                            int targetIndex;

                            while (!int.TryParse(Console.ReadLine(), out targetIndex) || targetIndex < 1 || targetIndex > enemies.Count)
                            {
                                Console.WriteLine("Invalid choice. Try again:");
                            }

                            Enemy target = enemies[targetIndex - 1];
                            player.Attack(target);

                            if (target.health <= 0)
                            {
                                Console.WriteLine($"{target.name} has been defeated!");
                                entityList.Remove(target);
                            }
                        }

                        else if (action == "h")
                        {
                            player.Heal();
                            ConWrite.Print($"You have healed yourself for {player.healPotionGain} HP.", ConsoleColor.Green);
                        }

                        else if (action == "q")
                        {
                            ConWrite.Print("You have quit the game. Goodbye!", ConsoleColor.DarkGray);
                            Environment.Exit(0);
                        }

                        else
                        {
                            ConWrite.Print("Invalid command", ConsoleColor.Red);
                        }

                    }
                    else if (entity is Enemy enemy)
                    {
                        Player target = entityList.OfType<Player>().FirstOrDefault();
                        enemy.Attack(target);


                    }
                }

            }

        }


        private static void CombatSetup(List<Entity> entityList)
        {
            entityList.Sort((a, b) => b.speed.CompareTo(a.speed));

            ConWrite.Print("Combat order:", ConsoleColor.DarkRed);
            foreach (Entity entity in entityList)
            {
                ConWrite.Print($"{entity.name} with {entity.speed} speed and {entity.attackPower} damage", ConsoleColor.DarkRed);
            }
        }

        public static void PlayerStats(Player player)
        {
            ConWrite.Print($"You are {player.level} level", ConsoleColor.Yellow);
            ConWrite.Print($"You have {player.Xp} Xp", ConsoleColor.Yellow);
            ConWrite.Print($"You have {player.health} HP", ConsoleColor.Green);
            ConWrite.Print($"You have {player.healPotion} Health potions ", ConsoleColor.Green);
            ConWrite.Print($"You have {player.speed} speed.", ConsoleColor.Yellow);
            ConWrite.Print($"You have {player.attackPower} Attack power \n", ConsoleColor.Red);
            
        }



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
