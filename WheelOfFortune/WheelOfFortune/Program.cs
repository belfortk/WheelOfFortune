using System;
using System.Collections.Generic;

namespace WheelOfFortune
{
    class Program
    {
        static void Main(string[] args)
        {
            var numPlayers = GetNumberOfPlayers();
            var numberOfRounds = GetNumberOfRounds();
            var game = new Game(numberOfRounds, numPlayers);
            game.Start();

        }

        public static int GetNumberOfPlayers() {
            int numberOfPlayers = 0;
            while (numberOfPlayers < 1) {
                Console.WriteLine("Enter number of players:");
                var input = Console.ReadLine();
                if(input.GetType() == typeof(int)){
                    numberOfPlayers = Convert.ToInt32(input);
                }
            }
            return numberOfPlayers;
        }

        public static int GetNumberOfRounds() {
            int numberOfRounds = 0;
            while (numberOfRounds < 1) {
                Console.WriteLine("Enter number of rounds:");
                var input = Console.ReadLine();
                if (input.GetType() == typeof(int))
                {
                    numberOfRounds = Convert.ToInt32(input);
                }
            }
            return numberOfRounds;
        }

    }
}
