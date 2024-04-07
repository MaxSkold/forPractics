using System;
using System.Linq;

namespace practic1
{
    internal class Dice 
    {
        int[] resultOfAttemps;

        /// <summary>
        /// Changeable number of throw attempts
        /// </summary>
        public int AttempsCount { get; set; }

        /// <summary>
        /// Getting the results of throws
        /// </summary>
        public int[] ResultOfAttemps { get => resultOfAttemps; } 

        public void StartOfAttemps() //Roll the dice AttempsCount-times
        {
            resultOfAttemps = new int[AttempsCount];
            Random random = new Random(); 

            resultOfAttemps = Enumerable.Range(0, AttempsCount).Select(_ => random.Next(1, 7)).ToArray();
        }

        public void OutpuResults() 
        {
            int counter = 1;
            foreach (var i in ResultOfAttemps)
                Console.WriteLine($"{counter++}:\t{i}");            
        }

        public void Histogram()
        {
            char division = '#';

            var counts = ResultOfAttemps.GroupBy(x => x).Select(x => new { Number = x.Key, Count = x.Count() }).OrderBy(x => x.Number);

            foreach (var item in counts)
            {
                string level = new string(division, item.Count);
                Console.WriteLine($"{item.Number}| {level}");
            }
        }
    }
    
    internal class Program
    {
        static void Main()
        {
            Dice dice = new Dice();

            Console.WriteLine("There is one 6-sided dice in front of you.");

            while (true)
            {
                Console.Write("How many times do you want to leave her? Limit: 100\n-> ");
                dice.AttempsCount = Convert.ToInt32(Console.ReadLine());

                if (dice.AttempsCount > 100)
                {
                    Console.WriteLine("You have exceeded the limit...");
                    continue;
                }
                else break;
            }

            dice.StartOfAttemps();

            Console.WriteLine("Here are your results:");
            dice.OutpuResults();

            Console.WriteLine("\nThe results are in the form of a histogram:\n" +
                "-------------------------------------------");
            dice.Histogram();

            Console.ReadKey();
        }
    }
}
