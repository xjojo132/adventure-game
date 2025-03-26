// See https://aka.ms/new-console-template for more information
//Console.ForegroundColor = ConsoleColor.Green;



using adventure_game;
using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace adventure_game
{


    public class Program
    {
        static void Main()
        {
            int turn = 1;
            bool gameOver = false;
            Random rand = new Random();

            List<string> enemyNames = new List<string> { "goblin", "orc", "troll", "bandit", "skeleton" };
            List<Entity> entityList = new List<Entity>();


            ConWrite.Print("Welcome Adventurer", ConsoleColor.White);
            ConWrite.Print("whats your name? ", ConsoleColor.White, false);
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            entityList.Add(player);
            PlayerStats();
            turn++;
            //ConWrite.Print("What will you do? ([A]ttack / [H]eal / [Q]uit)", ConsoleColor.Blue);


            Enemy enemy = null;
            
            Combat.genEnemy(20, entityList);
            foreach (var entity in entityList) 
            {
                Console.WriteLine($"{entity.name} joined the battle!");
            }
            CombatLoop();

            void CombatLoop()
            {
                while (entityList.Any(e => e is Player) && entityList.Any(e => e is Enemy))
                {
                    
                    //Console.Clear();
                    PlayerStats();
                    CombatSetup();

                    foreach (var entity in entityList)
                    {
                        if (entity.IsDefeated()) continue;

                        if (entity is Player player)
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

            void CombatSetup()
            {
                entityList = entityList.OrderByDescending(e => e.speed).ToList();

                ConWrite.Print("Combat order:", ConsoleColor.DarkRed);
                foreach (Entity entity in entityList)
                {
                    ConWrite.Print($"{entity.name} with {entity.speed} speed and {entity.attackPower} damage", ConsoleColor.DarkRed);
                }
            }

            void PlayerStats()
            {
                ConWrite.Print($"You are {player.level} level", ConsoleColor.Yellow);
                ConWrite.Print($"You have {player.Xp} Xp", ConsoleColor.Yellow);
                ConWrite.Print($"You have {player.health} HP", ConsoleColor.Green);
                ConWrite.Print($"You have {player.healPotion} Health potions ", ConsoleColor.Green);
                ConWrite.Print($"You have {player.speed} speed.", ConsoleColor.Yellow);
                ConWrite.Print($"You have {player.attackPower} Attack power \n", ConsoleColor.Red);
                ConWrite.Print($"its turn {turn} \n");
            }


        }

       

    }
}

    



