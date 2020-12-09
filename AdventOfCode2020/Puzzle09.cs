using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Puzzle09
    {
        public Puzzle09(string[] lines)
        {
            input = lines.Select(l => long.Parse(l)).ToArray();
        }

        public void Run()
        {
            RunTest1();
            RunTest2();
        }

        bool FindSum(long value, IEnumerable<long> numbers)
        {
            foreach (long number in numbers)
            {
                long remainder = value - number;
                if (remainder != number && numbers.Contains(remainder))
                {
                    return true;
                }
            }

            return false;
        }

        private void RunTest1()
        {
            Queue<long> availableNumbers = new Queue<long>();

            for (int index = 0; index < 25; index++)
            {
                availableNumbers.Enqueue(input[index]);
            }

            for (int index = 25; index < input.Length; index++)
            {
                if (!FindSum(input[index], availableNumbers))
                {
                    Console.WriteLine("{0}", input[index]);
                    return;
                }

                availableNumbers.Dequeue();
                availableNumbers.Enqueue(input[index]);
            }
        }
        private void RunTest2()
        {
            long valueToFind = 756008079;

            for (int startIndex = 0; startIndex < input.Length; startIndex++)
            {
                long value = 0;

                for (int endIndex = startIndex; endIndex < input.Length; endIndex++)
                {
                    value += input[endIndex];

                    if (value == valueToFind)
                    {
                        IEnumerable<long> range = input
                            .Skip(startIndex)
                            .Take(endIndex - startIndex);

                        long minValue = range.Min();
                        long maxValue = range.Max();

                        Console.WriteLine("{0}", minValue + maxValue);
                        return;
                    }
                    else if (value > valueToFind)
                    {
                        break;
                    }
                }
            }
        }

        private long[] input;
    }
}
