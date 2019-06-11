using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetUfa1.Exceptions;

namespace DotNetUfa1
{
    internal class DebugExample
    {
        private readonly Dictionary<int, string> numbers = new Dictionary<int, string>
        {
            {1, "one"},
            {2, "two"},
            {3, "three"},
            {4, "four"},
            {5, "five"},
            {6, "six"},
            {7, "seven"},
            {8, "eight"},
            {9, "nine"}
        };

        public double GetMaxValue()
        {
            var pairs = this.numbers
                .Where(p => p.Key > 6)
                .Where(p => p.Value.Length > 4)
                .ToArray();

            int maxValue = 0;
            foreach (var pair in pairs)
            {
                maxValue = Math.Max(maxValue, pair.Key);

                if (pair.Key == 8)
                {
                    Task.Factory.StartNew(() => throw new InvalidValueException(), TaskCreationOptions.LongRunning);
                }
            }

            return maxValue;
        }
    }
}