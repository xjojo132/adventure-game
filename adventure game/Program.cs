// See https://aka.ms/new-console-template for more information
//Console.ForegroundColor = ConsoleColor.Green;



using System;
using System.Runtime.InteropServices;
using System.Xml;



public class Program
{
    static void Main()
    {
        Print("Welcome Adventurer", ConsoleColor.Green);
        Print("whats your name? ", ConsoleColor.White, false);
        

        string playerName = Console.ReadLine();
        Player player = new Player(playerName, 100 , 10);
        Print($"You are {player.Name} with {player.Health} HP and {player.Attack} Attack.", ConsoleColor.Yellow);
        

        List<string> enemyNames = new List<string> { "Goblin", "Orc", "Troll", "Bandit", "Skeleton" };
        Random rand = new Random();
        string randomEnemyName = enemyNames[rand.Next(enemyNames.Count)];
        Enemy enemy = new Enemy(randomEnemyName, 50 , 8);
        

        Print($"A {enemy.Name} appears! It has {enemy.Health} HP and {enemy.Attack} Attack.", ConsoleColor.Red);


        bool gameOver = false;
       

        while (!gameOver)
        {
            Print("What will you do? ([A]ttack / [Q]uit)", ConsoleColor.White);
            string action = Console.ReadLine().ToLower();


            if (action == "q")
            {
                Print("You have quit the game. Goodbye!", ConsoleColor.DarkGray);
                Environment.Exit(0);
            }


            if (action == "a")
            {
                int playerDamage = rand.Next(5, player.Attack);
                enemy.TakeDamage(playerDamage);
                Print($"You hit the {enemy.Name} for {playerDamage} damage!", ConsoleColor.Green);

                if (enemy.Health == 0)
                {
                    Print($"The {enemy.Name} has been defeated!", ConsoleColor.White);
                    gameOver = true;
                    continue;
                }

                int enemyDamage = rand.Next(3, enemy.Attack);
                player.TakeDamage(enemyDamage);
                Print($"The {enemy.Name} strikes back for {enemyDamage} damage!", ConsoleColor.Red);


                if (player.Health == 0)
                {
                    Print($"You have been defeated by the {enemy.Name}!", ConsoleColor.Red);
                    gameOver = true;
                }
            }

            else
            {
                Print("Invalid command", ConsoleColor.Red);
            }
        }

    }

    static void Print(string message, ConsoleColor color = ConsoleColor.White, bool newLine = true)
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



class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }

    public Player(string name, int health, int attack)
    {
        Name = name;
        Health = health;
        Attack = attack;

    }



    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }


}

class Enemy
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }

    public Enemy(string name, int health, int attack)
    {
        Name = name;
        Health = health;
        Attack = attack;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }




}
