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

        public string Guess(char guess, string answer, char[] state) {
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
            return random.Next(0, 16);
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
