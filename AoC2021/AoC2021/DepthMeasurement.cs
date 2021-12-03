using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2021
{
    public static class DepthMeasurement
    {
        public static int CountDepthIncreases(int[] depthReadings, int windowSize)
        {
            int previousValue = 0;
            int currentValue = 0;

            int increaseCount = 0;

            if (windowSize == 1)
            {
                previousValue = depthReadings[0];
                currentValue = depthReadings[1];
            }
            else
            {
                for (int a = 0; a < windowSize; a++)
                {
                    previousValue += depthReadings[a];
                }
                currentValue = previousValue - depthReadings[0] + depthReadings[windowSize];
            }

            if (currentValue > previousValue)
            {
                increaseCount++;
            }

            for(int i = windowSize+1; i < depthReadings.Length; i++)
            {
                previousValue = currentValue;
                currentValue = currentValue - depthReadings[i - windowSize] + depthReadings[i];

                if (currentValue > previousValue)
                {
                    increaseCount++;
                }
            }

            return increaseCount;
        }
    }
}
