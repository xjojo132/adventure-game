// See https://aka.ms/new-console-template for more information
//Console.ForegroundColor = ConsoleColor.Green;



using adventure_game;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Collections.Generic;


namespace adventure_game
{


    public class Program
    {
        static GameState gameState = GameState.STORY;
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


            while (gameState != GameState.GAMEOVER)
            {
                switch (gameState)
                {
                    case GameState.STORY:
                        StoryPhase();
                        break;
                    case GameState.COMBAT:
                        Combat.StartCombat(player, entityList, ref gameState);
                        
                        break;
                    case GameState.GAMEOVER:
                        GameOverPhase();
                        break;
                }
            }
        }


        private static void StoryPhase()
        {
            // TODO: Hier komen de story elementen
            Console.WriteLine("Story is not implemented yet.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
            gameState = GameState.COMBAT;
        }

        private static void GameOverPhase()
        {
            Console.WriteLine("\n-- GAME OVER --");
            Console.WriteLine("You have fallen in battle...");
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            Environment.Exit(0);
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

    



