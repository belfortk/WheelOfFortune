using System;
using System.Collections.Generic;

namespace WheelOfFortune
{
    class Program
    {
        static void Main(string[] args)
        {
            var answer = "hello";
            char[] state = new char[answer.Length];
            for (var i = 0; i < state.Length; i++) {
                state[i] = '_';
            }

            HashSet<char> previousGuesses = new HashSet<char>();
            Console.WriteLine("Welcome to Wheel of Fortune");
            var isPlaying = true;
            Console.WriteLine("Type in a letter to guess. Type 'solve' to guess the answer. Type 'exit' quit.");

            Console.WriteLine(string.Join(" ", state));

            while (isPlaying) {
                var guess = Console.ReadLine();
                
                if (guess == "exit") {
                    isPlaying = false;
                    break;
                }

                if (guess.ToLower() == "solve") {
                    if (AttemptSolve(answer))
                    {
                        Console.WriteLine("You win!");
                        isPlaying = false;
                        break;
                    }
                    else {
                        Console.WriteLine("Incorrect guess");
                        Console.WriteLine("Enter another guess or type 'solve'.");
                    }

                }
                else if (guess.Length > 1) {
                    Console.WriteLine("Please only enter 1 character at a time.");
                }

                else if (string.IsNullOrWhiteSpace(guess)) {
                    Console.WriteLine("Please enter a real guess."); 
                }
                else
                {
                    char formattedGuess = Convert.ToChar(guess);
                    if (previousGuesses.Add(formattedGuess))
                    {
                        var result = AttemptGuess(formattedGuess, answer, state);
                        //Console.WriteLine(state);
                        //Console.WriteLine($"answer: {answer}");
                        //Console.WriteLine($"result: {result}");
                        //Console.WriteLine(string.Join("", state));
                        Console.WriteLine(result);
                        if (string.Join("", state) == answer)
                        {
                            Console.WriteLine("You Win!");
                     
                            isPlaying = false;
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("you already guessed that");
                    }
                }

            }

        }
      
        public static Boolean checkPreviousGuess(HashSet<char> previousGuesses, char currentGuess){
            return true;
        }

        public static string AttemptGuess(char guess, string answer, char[] state) {
            if (answer.IndexOf(guess) != -1)
            {
                // loop through word and check
                for (var i = 0; i < answer.Length; i++)
                {
                    if (answer[i] == guess)
                    {
                        state[i] = guess;
                    }
                }
                return string.Join(" ", state);
            }
            else {
                return "Incorrect guess";
            }
     
        }

        public static Boolean AttemptSolve(string answer) {
            Console.WriteLine("Please enter your guess");
            var guess = Console.ReadLine();
            return guess.ToLower() == answer.ToLower();
        }

        public static void DisplayState(string state) {
            Console.WriteLine(state);
        }
    }
}
