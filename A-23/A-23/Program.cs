using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_23
{
    delegate int SpinDelegate();

    class Game
    {
        private string name;
        private int energyLevel = 1;
        private int winningProbability = 100;
        private int luckyNumber;

        public Game(string name, int luckyNumber)
        {
            this.name = name;
            this.luckyNumber = luckyNumber;
        }

        public int Spin()
        {
            Random random = new Random();
            int energyChange = random.Next(-3, 11);
            int probabilityChange = random.Next(-60, 101);

            energyLevel += energyChange;
            winningProbability += probabilityChange;

            return energyLevel;
        }

        public void Play(SpinDelegate spinDelegate)
        {
            for (int i = 0; i < 5; i++)
            {
                spinDelegate();
            }

            Console.WriteLine($"\n{name}'s Game Results:");
            Console.WriteLine($"Energy Level: {energyLevel}");
            Console.WriteLine($"Winning Probability: {winningProbability}");

            if (energyLevel >= 4 && winningProbability > 60)
            {
                Console.WriteLine("Winner!");
            }
            else if (energyLevel >= 1 && winningProbability > 50)
            {
                Console.WriteLine("Runner Up!");
            }
            else
            {
                Console.WriteLine("Loser!");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter Your Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Your Lucky Number from 1 to 10: ");
            int luckyNumber = int.Parse(Console.ReadLine());

            Game userGame = new Game(name, luckyNumber);

            SpinDelegate spinDelegate = userGame.Spin;
            userGame.Play(spinDelegate);
        }
    }
}
