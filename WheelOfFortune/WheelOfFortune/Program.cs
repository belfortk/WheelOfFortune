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
                numberOfPlayers = Convert.ToInt32(Console.ReadLine());
            }
            return numberOfPlayers;
        }

        public static int GetNumberOfRounds() {
            int numberOfRounds = 0;
            while (numberOfRounds < 1) {
                Console.WriteLine("Enter number of rounds:");
                numberOfRounds = Convert.ToInt32(Console.ReadLine());
            }
            return numberOfRounds;
        }

    }
}
