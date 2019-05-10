using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Reflection;

namespace WheelOfFortune
{
    /// <summary>
    /// The Game class.
    /// Contains the methods for starting the game, finding the winner, and displaying game state messages.
    /// </summary>
    public class Game
    {
        /// <value>Gets the number of rounds in the Game</value>
        public int Rounds { get; private set; }
        /// <value>Gets the number of players.</value>
        public int NumberOfPlayers { get; private set; }
        /// <value>Gets and array of the Players.</value>
        private Player[] Players { get; set; }
        /// <value> Holds the word bank </value>
        private string[] _words = LoadDictionary();
        public Game(int rounds, int numberOfPlayers)
        {
            this.Rounds = rounds;
            this.Players = new Player[numberOfPlayers];
            this.NumberOfPlayers = numberOfPlayers;
        }

        /// <summary>
        /// Creates the word bank from the words found in Dictionary/Dictionary.txt.
        /// </summary>
        /// <returns>
        /// A string array of words pulled from Dictionary/Dictionary.txt
        /// </returns>
        public static string[] LoadDictionary()
        {
            var filePath = Path.GetFullPath(@"..\..\..\Dictionary\Dictionary.txt");
            string readText = File.ReadAllText(filePath);
            var words = readText.Split(" ");
            Random r = new Random();
            var randomized = words.OrderBy(x => r.Next()).ToArray();
            return words;
        }

        /// <summary>
        /// Starts the game loop. Makes a new Round for Rounds times.
        /// </summary>
        /// <remark>
        /// At the end of the round, pretty prints the winner and updates their Bank.
        /// </remark>
        /// <remarks>
        /// At the end of all rounds, finds and pretty prints the winner.
        /// </remarks>
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
                if (winner.RoundMoney == 0) {
                    winner.AddMoneyToBank(800);
                }
                else {
                    winner.AddMoneyToBank(winner.RoundMoney);
                }
                round.ResetAllPlayerRoundMoney();
                DisplayEndRoundMessage();
                this.Players = round.Players;
            }
            System.Threading.Thread.Sleep(2000);

            Console.WriteLine("GAME OVER");
            FindWinner();
        }

        /// <summary>
        /// Finds the winner of the game.
        /// </summary>
        /// <remarks>
        /// Creates a IEnumerable of Players, sorted by Player.Bank
        /// Displays them in a table. Displays if there is a tie.
        /// Displays winner if there is a winner.
        /// </remarks>
        public void FindWinner() {
            var sortedPlayers = Players.OrderBy(p => p.Bank);
            var length = sortedPlayers.Count();
            Console.WriteLine();
            foreach (Player player in Players) {
                Console.WriteLine($"{player.Name}: {player.Bank}");
            }
            if (sortedPlayers.ElementAt(length - 2).Bank == sortedPlayers.Last().Bank)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
                Console.WriteLine("GG, Well Played All");
                Console.WriteLine("Tie game.");
                Console.ResetColor();
            }
            else {
                DisplayWinner(sortedPlayers.Last());
            }
        }

        /// <summary>
        /// Pretty prints the provided winner of the game.
        /// </summary>
        public void DisplayWinner(Player winner) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("GG, Well Played All");
            Console.WriteLine($"The winner is {winner.Name}. You take home ${winner.Bank}");
            Console.ResetColor();

        }

        /// <summary>
        /// Pretty prints the provided winner of the round and the round number
        /// </summary>
        public void DisplayRoundWinner(Player winner, int round) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine($"Congrats {winner.Name}!");
            Console.WriteLine($"You won ${winner.RoundMoney} that for Round {round}.");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.ResetColor();
        }

        /// <summary>
        /// Pretty prints the Bank of each Player in Players.
        /// </summary>
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
