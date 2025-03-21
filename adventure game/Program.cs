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

            List<string> enemyNames = new List<string> { "Goblin", "Orc", "Troll", "Bandit", "Skeleton" };


            ConWrite.Print("Welcome Adventurer", ConsoleColor.White);
            ConWrite.Print("whats your name? ", ConsoleColor.White, false);
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            ConWrite.Print($"You are {player.Name} with {player.Health} HP, {player.healPotion} Health potions and {player.Attack} Attack power.", ConsoleColor.Yellow);
            ConWrite.Print($"You are {player.level} level", ConsoleColor.Yellow);
            ConWrite.Print($"You have {player.Health} HP", ConsoleColor.Yellow);
            ConWrite.Print($"You have {player.healPotion} Health potions ", ConsoleColor.Yellow);
            ConWrite.Print($"You have {player.Attack} Attack power \n", ConsoleColor.Yellow);
            ConWrite.Print($"its turn {turn} \n");
            turn++;
            ConWrite.Print("What will you do? ([A]ttack / [H]eal / [Q]uit)", ConsoleColor.Blue);


            Enemy enemy = null;
            

            while (!gameOver)
            {

                if(enemy == null || enemy.Health <= 0)
                {
                    int enemyType = rand.Next(100);
                    string randomEnemyName = enemyNames[rand.Next(enemyNames.Count)];

                    if (enemyType <= 50)
                    {
                        enemy = new Enemy(randomEnemyName, rand.Next(30, 60), rand.Next(5, 15));
                    }
                    else if (enemyType <= 75)
                    {
                        enemy = new TankEnemy(randomEnemyName, rand.Next(40, 70), rand.Next(4, 12), rand.Next(2, 6));
                        ConWrite.Print($"A {randomEnemyName} appears! It's heavily armored!", ConsoleColor.DarkGray);
                    }
                    else
                    {
                        enemy = new BlitzEnemy(randomEnemyName, rand.Next(25, 50), rand.Next(6, 12), 0.5);
                        ConWrite.Print($"A {randomEnemyName} appears! It's lightning fast!", ConsoleColor.Magenta);
                    }

                    ConWrite.Print($"A {enemy.Name} appears! It has {enemy.Health} HP and {enemy.AttackPower} Attack.", ConsoleColor.Red);

                    //int enemyMaxHealth = enemy.Health;
                    int xpGain = enemy.Health + enemy.AttackPower;
                }

               
                string action = Console.ReadLine().ToLower();
                Console.Clear();
                ConWrite.Print($"You are {player.level} level", ConsoleColor.Yellow);
                ConWrite.Print($"You have {player.Xp} Xp");
                ConWrite.Print($"You have {player.Health} HP", ConsoleColor.Yellow);
                ConWrite.Print($"You have {player.healPotion} Health potions ", ConsoleColor.Yellow);
                ConWrite.Print($"You have {player.Attack} Attack power \n", ConsoleColor.Yellow);
                ConWrite.Print($"its turn {turn} \n");
                turn++;
                ConWrite.Print($"A {enemy.Name} appears! It has {enemy.Health} HP and {enemy.AttackPower} Attack.", ConsoleColor.Red);
                ConWrite.Print("What will you do? ([A]ttack / [H]eal / [Q]uit) \n", ConsoleColor.Blue);

                if (action == "q")
                {
                    ConWrite.Print("You have quit the game. Goodbye!", ConsoleColor.DarkGray);
                    Environment.Exit(0);
                }
                else if (action == "a")
                {

                    //je eigen turn 
                    enemy.TakeDamage(player.AttackPower);
                    ConWrite.Print($"you swung your sword at the {enemy.Name} for {player.AttackPower} damage!", ConsoleColor.DarkGreen);
                    ConWrite.Print($"The {enemy.Name} has {enemy.Health} HP left.\n", ConsoleColor.Red);

                    if (enemy.Health <= 0)
                    {

                        ConWrite.Print($"The {enemy.Name} has been defeated!", ConsoleColor.White);
                        player.healPotion += 1;
                        player.GainXp(enemy.maxHealth + enemy.AttackPower);
                        enemy = null;
                        continue;
                    }

                    //enemy turn
                    player.TakeDamage(enemy.AttackPower);
                    ConWrite.Print($"The {enemy.Name} strikes back for {enemy.AttackPower} damage!", ConsoleColor.Red);
                    ConWrite.Print($"You have {player.Health} HP left.\n", ConsoleColor.Green);

                    if (player.Health == 0)
                    {
                        ConWrite.Print($"You have been defeated by the {enemy.Name}!", ConsoleColor.DarkRed);
                        gameOver = true;
                    }

                }
                else if (action == "h")
                {
                    player.Heal();
                    ConWrite.Print($"You have healed yourself for 15 HP.", ConsoleColor.Green);
                    ConWrite.Print($"You have {player.healPotion} health potions left.", ConsoleColor.Green);

                }
                else
                {
                    ConWrite.Print("Invalid command", ConsoleColor.Red);
                }
               

            }

        }

       

    }
}

    



