using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    /// <summary>
    /// The Player class. Contains the methods for Player actions.
    /// </summary>
    public class Player
    { 

        /// <value>
        /// Gets the Name
        /// </value>
        public string Name { get; set; }
        /// <value>
        /// Gets the Player's total earned money. Money is earned after winning a round.
        /// </value>
        public int Bank { get; private set; }
        /// <value>
        /// Gets the sum of the money Player has earned in current round. 
        /// </value>
        public int RoundMoney { get; private set; }

        public Player(string name)
        {
            this.Name = name;
            this.Bank = 0;
            this.RoundMoney = 0;
        }

        /// <summary>
        /// Determines whether or not the char guess is in the word. If it is, updates the character state and add the reward money to the Player's RoundMoney
        /// </summary>
        /// <param name="guess"></param>
        /// <param name="answer"></param>
        /// <param name="state"></param>
        /// <param name="reward"></param>
        /// <returns>Returns a string of the new character state OR "Incorrect Guess"</returns>
        public string Guess(char guess, string answer, char[] state, int reward) {
            if (answer.IndexOf(guess) != -1)
            {
                var countOfLetterInstances = 0;
                // loop through word and check
                for (var i = 0; i < answer.Length; i++)
                {
                    if (answer[i] == guess)
                    {
                        state[i] = guess;
                        countOfLetterInstances++;
                    }
                }
                var earnedMoney = countOfLetterInstances * reward;
                AddRoundMoney(earnedMoney);
                Console.WriteLine($"{Name} added ${earnedMoney} to Round Money");
                return string.Join(" ", state);
            }
            else
            {
                return "Incorrect guess";
            }
        }

        /// <summary>
        /// Check to see if attempted answer is the solution to the puzzle.
        /// </summary>
        /// <param name="guessAnswer"></param>
        /// <param name="answer"></param>
        /// <returns>Returns True or False whether or not the puzzle for the round has been solved</returns>
        public Boolean Solve(string guessAnswer, string answer) {
            return guessAnswer.ToLower() == answer.ToLower();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>A random number between 0 and 14</returns>
        public int Spin() {
            Random random = new Random();
            return random.Next(0, 14);
        }

        /// <summary>
        /// Adds to the sum of money earned by winning a round.
        /// </summary>
        /// <param name="value"></param>
        public void AddMoneyToBank(int value) {
            this.Bank += value;
        }

        /// <summary>
        /// Adds a number to the sum earned in a round
        /// </summary>
        /// <param name="value"></param>
        public void AddRoundMoney(int value) {
            this.RoundMoney += value;
        }

        /// <summary>
        /// Sets the money earned in the round to 0.
        /// </summary>
        public void ResetRoundMoney() {
            this.RoundMoney = 0;
        }

    }
}
