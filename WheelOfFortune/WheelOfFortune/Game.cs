using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Reflection;

namespace WheelOfFortune
{
    public class Game
    {
        public int Rounds { get; private set; }
        public int NumberOfPlayers { get; private set; }
        private Player[] Players { get; set; }
        private string[] _words = LoadDictionary();
        public Game(int rounds, int numberOfPlayers)
        {
            this.Rounds = rounds;
            this.Players = new Player[numberOfPlayers];
            this.NumberOfPlayers = numberOfPlayers;
        }

        public static string[] LoadDictionary()
        {
            var filePath = Path.GetFullPath(@"..\..\..\Dictionary\Dictionary.txt");
            string readText = File.ReadAllText(filePath);
            var words = readText.Split(" ");
            return words;
        }

        public void Start() {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Welcome to Wheel of Fortune.");
            Console.ResetColor();
            for (var i = 0; i < NumberOfPlayers; i++) {
                Console.WriteLine($"Enter Player {i+1}'s name");
                var playerName = Console.ReadLine();
                this.Players[i] = new Player(playerName);
            }


            for (var i = 0; i < this.Rounds; i++){
                var roundNumber = i + 1;
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine($"Starting Round {roundNumber}...");
                Console.ResetColor();
                System.Threading.Thread.Sleep(2000);
                var round = new Round(_words[i % _words.Length], this.Players, new Wheel(roundNumber));
                var winner = round.Start();
                DisplayRoundWinner(winner, roundNumber);
                round.ResetAllPlayerRoundMoney();
                DisplayEndRoundMessage();
                this.Players = round.Players;
            }
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("GAME OVER");
            var gameWinner = FindWinner();
            DisplayWinner(gameWinner);
        }

        public Player FindWinner() {
            var sortedPlayers = Players.OrderBy(p => p.Bank);
            Console.WriteLine();
            foreach (Player player in Players) {
                Console.WriteLine($"{player.Name}: {player.Bank}");
            }
            return sortedPlayers.Last();
        }

        public void DisplayWinner(Player winner) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("GG, Well Played All");
            Console.WriteLine($"The winner is {winner.Name}. You take home ${winner.Bank}");
            Console.ResetColor();

        }
        public void DisplayRoundWinner(Player winner, int round) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Congrats {winner.Name}!");
            Console.WriteLine($"You won ${winner.RoundMoney} that for Round {round}.");
            winner.AddMoneyToBank(winner.RoundMoney);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();
        }

        public void DisplayEndRoundMessage() {
            Console.WriteLine();
            Console.WriteLine("Total earnings thus far:");
            foreach (Player player in Players)
            {
                Console.WriteLine($"{player.Name}: ${player.Bank}");
            }
        }

    }
}
