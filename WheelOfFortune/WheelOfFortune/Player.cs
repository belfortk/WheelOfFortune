using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    public class Player
    {
        public string Name { get; set; }
        public int Bank { get; private set; }
        public int RoundMoney { get; private set; }

        public Player(string name)
        {
            this.Name = name;
            this.Bank = 0;
            this.RoundMoney = 0;
        }

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

        public Boolean Solve(string guessAnswer, string answer) {
            return guessAnswer.ToLower() == answer.ToLower();
        }


        public int Spin() {
            Random random = new Random();
            return random.Next(0, 4);
        }

        public void AddMoneyToBank(int value) {
            this.Bank += value;
        }

        public void AddRoundMoney(int value) {
            this.RoundMoney += value;
        }


        public void ResetRoundMoney() {
            this.RoundMoney = 0;
        }

    }
}
