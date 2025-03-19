// See https://aka.ms/new-console-template for more information
//Console.ForegroundColor = ConsoleColor.Green;



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

            List<string> enemyNames = new List<string> { "Goblin", "Orc", "Troll", "Bandit", "Skeleton" };


            Print("Welcome Adventurer", ConsoleColor.White);
            Print("whats your name? ", ConsoleColor.White, false);
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            Print($"You are {player.Name} with {player.Health} HP, {player.healPotion} Health potions and {player.Attack} Attack power.", ConsoleColor.Yellow);
            Print($"You are {player.level} level", ConsoleColor.Yellow);
            Print($"You have {player.Health} HP", ConsoleColor.Yellow);
            Print($"You have {player.healPotion} Health potions ", ConsoleColor.Yellow);
            Print($"You have {player.Attack} Attack power \n", ConsoleColor.Yellow);
            Print($"its turn {turn} \n");
            turn++;
            Print("What will you do? ([A]ttack / [H]eal / [Q]uit)", ConsoleColor.Blue);


            Enemy enemy = null;
             

            while (!gameOver)
            {

                if(enemy == null || enemy.Health <= 0)
                {
                    string randomEnemyName = enemyNames[rand.Next(enemyNames.Count)];
                    enemy = new Enemy(randomEnemyName, rand.Next(30, 60), rand.Next(5, 15));
                    //int enemyMaxHealth = enemy.Health;
                    int xpGain = enemy.Health + enemy.Attack;
                }

               
                string action = Console.ReadLine().ToLower();
                Console.Clear();
                Print($"You are {player.level} level", ConsoleColor.Yellow);
                Print($"You have {player.Health} HP", ConsoleColor.Yellow);
                Print($"You have {player.healPotion} Health potions ", ConsoleColor.Yellow);
                Print($"its turn {player.Xp}");
                Print($"You have {player.Attack} Attack power \n", ConsoleColor.Yellow);
                Print($"its turn {turn} \n");
                turn++;
                Print($"A {enemy.Name} appears! It has {enemy.Health} HP and {enemy.Attack} Attack.", ConsoleColor.Red);
                Print("What will you do? ([A]ttack / [H]eal / [Q]uit)", ConsoleColor.Blue);

                if (action == "q")
                {
                    Print("You have quit the game. Goodbye!", ConsoleColor.DarkGray);
                    Environment.Exit(0);
                }
                else if (action == "a")
                {

                    //je eigen turn 
                    enemy.TakeDamage(player.Attack);
                    Print($"you swung your sword at the {enemy.Name} for {player.Attack} damage!", ConsoleColor.DarkGreen);
                    Print($"The {enemy.Name} has {enemy.Health} HP left.", ConsoleColor.Red);

                    if (enemy.Health <= 0)
                    {

                        Print($"The {enemy.Name} has been defeated!", ConsoleColor.White);
                        player.healPotion += 1;
                        player.GainXp(enemy.maxHealth + enemy.Attack);
                        enemy = null;
                        continue;
                    }

                    //enemy turn
                    player.TakeDamage(enemy.Attack);
                    Print($"The {enemy.Name} strikes back for {enemy.Attack} damage!", ConsoleColor.Red);
                    Print($"You have {player.Health} HP left.", ConsoleColor.Green);

                    if (player.Health == 0)
                    {
                        Print($"You have been defeated by the {enemy.Name}!", ConsoleColor.DarkRed);
                        gameOver = true;
                    }

                }
                else if (action == "h")
                {
                    player.Heal();
                    Print($"You have healed yourself for 15 HP.", ConsoleColor.Green);
                    Print($"You have {player.healPotion} health potions left.", ConsoleColor.Green);

                }
                else
                {
                    Print("Invalid command", ConsoleColor.Red);
                }
               

            }

        }

        public static void Print(string message, ConsoleColor color = ConsoleColor.White, bool newLine = true)
        {
            Console.ForegroundColor = color;
            if (newLine)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }
            Console.ResetColor();
        }

    }
}

    



