using System;
using System.IO;

namespace AoC2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();
            Console.WriteLine("Day 1:");
            Day1();

            Console.WriteLine();
            Console.WriteLine("Day 2:");
            Day2();

            Console.WriteLine();
            Console.WriteLine("Day 3:");
            Day3();
        }

        /// <summary>
        /// Day 3
        /// </summary>
        private static void Day3()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day3.txt");
            //string[] inputs = File.ReadAllLines("Inputs/Day3Test.txt");

            PowerConsumption pc = new PowerConsumption();
            pc.EpsilonGammaRateCalculator(inputs);

            int output = pc.Consumption;
            if (output != 3687446)
            {
                Console.WriteLine($"ERROR: DAY 3 PART 1 IS BROKEN! Expected: {3687446}");
                Console.Beep();
            }
            Console.WriteLine("Output: ");
            Console.WriteLine(output);

            Console.WriteLine();
            Console.WriteLine("Beginning Part 2...");

            pc.OxygenC02RatingCalculator(inputs);

            output = pc.LifeSuportRating;
            if (output != 4406844)
            {
                Console.WriteLine($"ERROR: DAY 3 PART 1 IS BROKEN! Expected: {4406844}");
                Console.Beep();
            }
            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        /// <summary>
        /// Day 2
        /// </summary>
        private static void Day2()
        {
            Console.WriteLine("Parsing Input...");
            string[] inputs = File.ReadAllLines("Inputs/Day2.txt");

            var commands = GridMovement.ParseInstructions(inputs);
            var position = GridMovement.TraverseGrid(commands);

            int output = position.x * -position.y;
            if (output != 1989014)
            {
                Console.WriteLine($"ERROR: DAY 2 PART 1 IS BROKEN! Expected: {1989014}");
                Console.Beep();
            }
            Console.WriteLine("Output: ");
            Console.WriteLine(output);

            Console.WriteLine();
            Console.WriteLine("Beginning Part 2...");
            Submarine sub = new Submarine(0, 0, 0);

            sub.MoveSub(GridMovement.ParseInstructions(inputs));
            output = sub.HorizontalPosition * sub.Depth;
            if (output != 2006917119)
            {
                Console.WriteLine($"ERROR: DAY 2 PART 2 IS BROKEN! Expected: {2006917119}");
                Console.Beep();
            }
            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }

        /// <summary>
        /// Day 1
        /// </summary>
            private static void Day1()
        {
            Console.WriteLine("Parsing Input...");
            string[] rawInputs = File.ReadAllLines("Inputs/Day1.txt");
            //string[] rawInputs = File.ReadAllLines("Inputs/Day1Test.txt");
            int[] inputs = Array.ConvertAll(rawInputs, int.Parse);

            int output = DepthMeasurement.CountDepthIncreases(inputs, 1);
            if(output != 1475)
            {
                Console.WriteLine($"ERROR: DAY 1 PART 1 IS BROKEN! Expected: {1475}");
                Console.Beep();
            }
            Console.WriteLine("Output: ");
            Console.WriteLine(output);

            Console.WriteLine();
            Console.WriteLine("Beginning Part 2...");
            output = DepthMeasurement.CountDepthIncreases(inputs, 3);
            if (output != 1516)
            {
                Console.WriteLine($"ERROR: DAY 1 PART 1 IS BROKEN! Expected: {1475}");
                Console.Beep();
            }
            Console.WriteLine("Output: ");
            Console.WriteLine(output);
        }
    }
}
