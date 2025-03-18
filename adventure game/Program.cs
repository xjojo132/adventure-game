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
        string name = Console.ReadLine();
        Print("welcome " + name);
        Player player = new Player(playerName);
        Print($"You are {player.Name} with {player.Health} HP and {player.Attack} Attack.", ConsoleColor.Yellow);

    }


    static void Print(string message, ConsoleColor color = ConsoleColor.White, bool newLine = true)
        {
            Console.ForegroundColor = color;
            if (newLine)
                Console.WriteLine(message);
            else
                Console.Write(message);
            Console.ResetColor();
        }

        

}


class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int Attack { get; private set; }

    public Player(string name)
    {
        Name = name;
        Health = 100;
        Attack = 10;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0; // Zorgt dat health niet negatief wordt
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
        if (Health < 0) Health = 0; // Zorgt dat health niet negatief wordt
    }

}
