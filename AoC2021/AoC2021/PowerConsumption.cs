using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public class PowerConsumption
    {
        public int EpsilonRate { get; private set; }
        public int GammaRate { get; private set; }
        public int OxygenRating { get; private set; }
        public int C02Rating { get; private set; }
        public int Consumption { get { return this.EpsilonRate * this.GammaRate; } }
        public int LifeSuportRating { get { return this.OxygenRating * this.C02Rating; } }

        private int[] bitCounters;
        
        public void OxygenC02RatingCalculator(string[] inputs)
        {
            string oxyRate = CalculateOxygenC02(inputs.ToList(), 0, true);
            this.OxygenRating = Convert.ToInt32(oxyRate, 2);

            string co2Rate = CalculateOxygenC02(inputs.ToList(), 0, false);
            this.C02Rating = Convert.ToInt32(co2Rate, 2);
        }

        private string CalculateOxygenC02(List<string> inputs, int index, bool isOxygen)
        {
            if (inputs.Count == 1 || index >= inputs[0].Length)
                return inputs[0];

            int zeroes = 0;
            int ones = 0;

            foreach (string input in inputs)
            {
                if (input[index] == '1')
                {
                    ones++;
                }
                else
                {
                    zeroes++;
                }
            }

            int target = isOxygen
                ? ones >= zeroes ? '1' : '0'
                : zeroes <= ones ? '0' : '1';
            List<string> remainingInputs = new List<string>();

            foreach(string input in inputs)
            {
                if(input[index] == target)
                {
                    remainingInputs.Add(input);
                }
            }

            inputs.Clear();

            return this.CalculateOxygenC02(remainingInputs, ++index, isOxygen);
        }

        public void EpsilonGammaRateCalculator(string[] inputs)
        {
            this.CountBits(inputs);

            char[] gammaRateValues = new char[inputs[0].Length];
            char[] epsilonRateValues = new char[inputs[0].Length];
            int minMajority = inputs.Length / 2;

            for (int i = 0; i < bitCounters.Length; i++)
            {
                if (bitCounters[i] >= minMajority)
                {
                    gammaRateValues[i] = '1';
                    epsilonRateValues[i] = '0';
                }
                else
                {
                    gammaRateValues[i] = '0';
                    epsilonRateValues[i] = '1';
                }
            }

            this.GammaRate = Convert.ToInt32(new string(gammaRateValues), 2);
            this.EpsilonRate = Convert.ToInt32(new string(epsilonRateValues), 2);
        }

        private void CountBits(string[] inputs)
        {
            bitCounters = new int[inputs[0].Length];

            foreach (string input in inputs)
            {
                char[] values = input.ToCharArray();
                for (int i = 0; i < input.Length; i++)
                {
                    if (values[i] == '1')
                    {
                        bitCounters[i]++;
                    }
                }
            }
        }
    }
}
