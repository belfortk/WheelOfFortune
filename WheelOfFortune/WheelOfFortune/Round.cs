using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    /// <summary>
    /// The Round class contains the methods to start the round and reset all the Player.RoundMoney at the end of the round.
    /// </summary>
    class Round
    {
        /// <values>
        /// Get the array of Players
        /// </values>
        public Player[] Players { get; private set; }

        /// <values>
        /// Get the answer string. This is the solution to the puzzle.
        /// </values>
        public string Answer { get; private set; }

        /// <values>
        /// the array of characters that represent which letters have guessed.
        /// </values>
        
        public char[] _characterState { get; private set; }
        /// <values>
        /// The wheel for this round. The values change each round.
        /// </values>
        private Wheel _wheel;

        /// <values>
        /// The Set of previously guessed characters.
        /// </values>
        public HashSet<char> previousGuesses = new HashSet<char>();
        public Round(string answer, Player[] players, Wheel wheel) 
        {
            this.Answer = answer;
            this.Players = players;
            this._characterState = new char[answer.Length];
            for (var i = 0; i < this._characterState.Length; i++)
            {
                this._characterState[i] = '_';
            }
            this._wheel = wheel;
        }

        /// <summary>
        /// While the puzzle is unsolved, give each Player a turn solving it.
        /// </summary>
        /// <remarks>
        /// If a player does not solve the puzzle, update the state of the puzzle and add to previous guesses.
        /// </remarks>
        /// <returns>Returns the winning Player of the round. </returns>
        public Player Start() {
            var answered = false;
            int winner = 0;
            while (!answered) {
                for (var p = 0; p < Players.Length; p++) {
                    Console.WriteLine();
                    Console.WriteLine($"It is {Players[p].Name}'s turn.");
                    System.Threading.Thread.Sleep(1000);

                    var turn = new Turn(Answer, this._characterState, Players[p], previousGuesses, this._wheel);
                    answered = turn.Start();
                    if (answered)
                    {
                        winner = p;
                        break;
                    }
                    else {
                        this._characterState = turn.CharacterState;
                        this.previousGuesses = turn.PreviousGuesses;
                    }
                }
            }
            return Players[winner];
        }

        /// <summary>
        /// Loops through all the Players and set's their RoundMoney to 0;
        /// </summary>
        public void ResetAllPlayerRoundMoney() {
            foreach (Player player in Players) {
                player.ResetRoundMoney();
            }
        }
    }
}
