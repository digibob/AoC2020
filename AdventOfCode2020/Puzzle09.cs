using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Puzzle09
    {
        public Puzzle09(string[] lines)
        {
            input = lines.Select(l => Int64.Parse(l)).ToArray();
        }

        public void Run()
        {
            RunTest1();
            RunTest2();
        }

        bool FindSum(Int64 value, IEnumerable<Int64> numbers)
        {
            foreach (Int64 number in numbers)
            {
                Int64 remainder = value - number;
                if (remainder != number && numbers.Contains(remainder))
                {
                    return true;
                }
            }

            return false;
        }

        private void RunTest1()
        {
            Queue<Int64> availableNumbers = new Queue<Int64>();

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
            Int64 valueToFind = 756008079;

            for (int startIndex = 0; startIndex < input.Length; startIndex++)
            {
                Int64 value = 0;

                for (int endIndex = startIndex; endIndex < input.Length; endIndex++)
                {
                    value += input[endIndex];

                    if (value == valueToFind)
                    {
                        IEnumerable<Int64> range = input
                            .Skip(startIndex)
                            .Take(endIndex - startIndex);

                        Int64 minValue = range.Min();
                        Int64 maxValue = range.Max();

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

        private Int64[] input;
    }
}
