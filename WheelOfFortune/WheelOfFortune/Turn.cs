using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    class Turn
    {
        public string Answer { get; private set; }
        public Player Player { get; private set; }
        public char[] CharacterState { get; private set; }
        private bool IsPlaying { get; set; }
        public HashSet<char> PreviousGuesses { get; private set; }
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

        public Boolean Start()
        {
            var solved = false;


            Console.WriteLine("Type in a letter to guess. Type 'solve' to guess the answer. Type 'exit' quit.");
            Console.WriteLine(DisplayCharacterState(this.CharacterState));



            while (IsPlaying && !solved)
            {

                Console.WriteLine("Spinning the wheel...");
                var reward = this._wheel.values[Player.Spin()];
                if (reward.GetType() == typeof(int))
                {
                    Console.WriteLine($"${reward} (per letter)");
                    var guess = Console.ReadLine();

                    if (guess == "exit")
                    {
                        IsPlaying = false;
                        break;
                    }

                    if (guess.ToLower() == "solve")
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

                }
                else if ((string)reward == "Lose a Turn")
                {
                    Console.WriteLine("Lose a Turn");
                    IsPlaying = false;
                }
            }

            }
            

            return solved;
        }

        public string DisplayCharacterState(char[] characterState)
        {
            return string.Join(" ", characterState);
        }
    }
}
