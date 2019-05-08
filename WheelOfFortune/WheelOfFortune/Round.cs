using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    class Round
    {
        public Player[] Players { get; private set; }
        public string Answer { get; private set; }
        public char[] _characterState { get; private set; }
        private Wheel _wheel;

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

        public void ResetAllPlayerRoundMoney() {
            foreach (Player player in Players) {
                player.ResetRoundMoney();
            }
        }
    }
}
