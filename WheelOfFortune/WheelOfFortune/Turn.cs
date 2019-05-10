using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    /// <summary>
    /// Contains the main game engine loop.
    /// The logic for a user's turn lives in a disgustingly untestable while loop.
    /// </summary>
    class Turn
    {
        /// <values>
        /// Get the answer to the puzzle
        /// </values>
        public string Answer { get; private set; }

        /// <values>
        /// Gets the current Player whose turn it is.
        /// </values>
        public Player Player { get; private set; }

        /// <values>
        /// Gets the state of the Puzzle.
        /// </values>
        public char[] CharacterState { get; private set; }

        /// <values>
        /// Flag for ending a Player's turn.
        /// </values>
        private bool IsPlaying { get; set; }

        /// <values>
        /// Gets the previous guess.
        /// </values>
        public HashSet<char> PreviousGuesses { get; private set; }

        /// <values>
        /// Gets the wheel of prizes
        /// </values>
        private Wheel _wheel;
        public Turn(string answer, char[] characterState, Player player, HashSet<char> previousGuesses, Wheel wheel)
        {
            this.Answer = answer;
            this.Player = player;
            this.CharacterState = characterState;
            this.PreviousGuesses = previousGuesses;
            this.IsPlaying = true;
            this._wheel = wheel;
        }

        /// <values>
        /// Starts the loop for a Player's turn.
        /// Loop runs until the Player either solves the puzzle, spins the wheel to "Lose Turn" or guesses incorrectly.
        /// Also handles for passing turn and exiting program.
        /// </values>
        public Boolean Start()
        {
            var solved = false;


            Console.WriteLine("Type in a letter to guess. Type '!solve' to guess the answer.");
            Console.WriteLine("Type '!pass' quit. Type '!exit' to quit.");
            Console.WriteLine(DisplayCharacterState(this.CharacterState));



            while (IsPlaying && !solved)
            {

                Console.WriteLine("Spinning the wheel...");
                System.Threading.Thread.Sleep(2000);
                var reward = this._wheel.values[Player.Spin()];
                if (reward.GetType() == typeof(int))
                {
                    Console.WriteLine($"${reward} (per letter)");
                    System.Threading.Thread.Sleep(1000);

                    var guess = Console.ReadLine();

                    if (guess == "!pass")
                    {
                        IsPlaying = false;
                        break;
                    }

                    if (guess == "!exit") {
                        System.Environment.Exit(1);
                    }

                    if (guess.ToLower() == "!solve")
                    {
                        Console.WriteLine("Ok, please enter your solution.");
                        var attempt = Console.ReadLine();
                        if (this.Player.Solve(attempt, this.Answer))
                        {
                            solved = true;
                            Console.WriteLine("You correctly solved the puzzle!");
                            IsPlaying = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect guess");
                            IsPlaying = false;
                            break;
                        }

                    }
                    else if (guess.Length > 1)
                    {
                        Console.WriteLine("Please only enter 1 character at a time.");
                    }

                    else if (string.IsNullOrWhiteSpace(guess))
                    {
                        Console.WriteLine("Please enter a real guess. 1 alphabetic character.");
                    }
                    else
                    {
                        char formattedGuess = Convert.ToChar(guess.ToLower());
                        if (this.PreviousGuesses.Add(formattedGuess))
                        {
                            var result = this.Player.Guess(formattedGuess, this.Answer, this.CharacterState, (int)reward);
                            Console.WriteLine(result);
                            if (string.Join("", this.CharacterState) == this.Answer)
                            {
                                Console.WriteLine("You have solved the puzzle!");
                                solved = true;
                                IsPlaying = false;
                                break;
                            }
                            else if (result == "Incorrect guess")
                            {
                                IsPlaying = false;
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("This has already been guessed.");
                            IsPlaying = false;
                            break;
                        }
                    }
                }
                else
            {
                if ((string)reward == "Bankrupt")
                {
                    Console.WriteLine("Bankrupt");
                    Player.ResetRoundMoney();
                    System.Threading.Thread.Sleep(1000);

                    }
                    else if ((string)reward == "Lose a Turn")
                {
                    Console.WriteLine("Lose a Turn");
                    IsPlaying = false;
                    System.Threading.Thread.Sleep(1000);

                    }
                }

            }
            return solved;
        }

        /// <summary>
        /// Returns formatted state of guessed characters.
        /// <example>
        /// ['m', 'i', 'c', 'r', '_', 's', 'o', 'f', '_t'] => "m i c r _ s o f t"
        /// </example>
        /// </summary>
        /// <param name="characterState"></param>
        /// <returns></returns>
        public string DisplayCharacterState(char[] characterState)
        {
            return string.Join(" ", characterState);
        }
    }
}
