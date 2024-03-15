using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedraPaperTisores
{
    internal class PlayerPPT
    {
        private string name;
        private int score;

        public PlayerPPT(string name)
        {
            this.name = name;
            this.score = 0;
        }
        public string Greeting()
        {
            return "Hello! my name is " + name;
        }
        public string Play()
        {
            int result;
            string output = "";
            Random rollDice = new Random();
            result = rollDice.Next(1, 4);
            switch (result)
            {
                case 1:
                    output = "Pedra";
                    break;
                case 2:
                    output = "Paper";
                    break;
                case 3:
                    output = "Tisora";
                    break;
                default:
                    break;
            }
            return output;
        }
        public void IncreaseScore()
        {
            score++;
        }
        public string ShowScore()
        {
            return (name + " had " + score + " wins!!!");
        }
        public string ShowName()
        {
            return name;
        }

    }
}

