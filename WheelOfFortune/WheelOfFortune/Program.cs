using System;
using System.Collections.Generic;
using System.IO;

namespace WheelOfFortune
{
    class Program 
    {
        /// <summary>
        /// This is where the Wheel of Fortune game is intialized.
        /// </summary>
        static void Main(string[] args)
        {
            var numPlayers = GetNumberOfPlayers();
            var numberOfRounds = GetNumberOfRounds();
            var game = new Game(numberOfRounds, numPlayers);
            game.Start();
        }

        /// <summary>
        /// Get the number of players from the user.
        /// Only returns when given an int.
        /// </summary>
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

        /// <summary>
        /// Get the number of players from the user.
        /// Only returns when given an int.
        /// </summary>
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
