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
                int number;
                bool success = Int32.TryParse(input, out number);
                if (success){
                    numberOfPlayers = number;
                }
            }
            return numberOfPlayers;
        }

        public static int GetNumberOfRounds() {
            int numberOfRounds = 0;
            while (numberOfRounds < 1) {
                Console.WriteLine("Enter number of rounds:");
                var input = Console.ReadLine();
                int number;
                bool success = Int32.TryParse(input, out number);
                if (success)
                {
                    numberOfRounds = number;
                }
            }
            return numberOfRounds;
        }

    }
}
