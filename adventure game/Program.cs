// See https://aka.ms/new-console-template for more information
//Console.ForegroundColor = ConsoleColor.Green;



using adventure_game;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace adventure_game
{


    public class Program
    {

        private static GameState gameState = GameState.COMBAT;
        static void Main()
        {


            int turn = 1;
            bool gameOver = false;
            Random rand = new Random();


            List<Entity> entityList = new List<Entity>();


            ConWrite.Print("Welcome Adventurer", ConsoleColor.White);
            ConWrite.Print("whats your name? ", ConsoleColor.White, false);
            string playerName = Console.ReadLine();
            Player player = new Player(playerName);
            entityList.Add(player);
            Combat.PlayerStats(player);
            ConWrite.Print($"its turn {turn}", ConsoleColor.White);
            turn++;

        }
           

        //Combat.StartCombat(player, entityList);
        //ConWrite.Print("What will you do? ([A]ttack / [H]eal / [Q]uit)", ConsoleColor.Blue);


        //Enemy enemy = null;

        //Combat.genEnemy(3, entityList);
        //foreach (var entity in entityList) 
        //{
        //    Console.WriteLine($"{entity.name} joined the battle!");
        //}





        

    }
}

    



