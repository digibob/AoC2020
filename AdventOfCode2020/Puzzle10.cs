using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    class Puzzle10
    {
        public Puzzle10(string[] lines)
        {
            sortedNumbers = lines.Select(x => int.Parse(x)).OrderBy(x => x).ToArray();
        }

        public void Run()
        {
            RunTest1();
            RunTest2();
        }

        private void RunTest1()
        {
            int num1Gaps = 0;
            int num3Gaps = 1;

            int last = 0;
            foreach (int number in sortedNumbers)
            {
                int diff = number - last;
                switch (diff)
                {
                    case 1:
                        num1Gaps++;
                        break;
                    case 3:
                        num3Gaps++;
                        break;
                }

                last = number;
            }

            Console.WriteLine("{0}", num1Gaps * num3Gaps);
        }

        private void RunTest2()
        {
            List<int> numbers = sortedNumbers.ToList();
            numbers.Insert(0, 0);
            numbers.Add(sortedNumbers.Last() + 3);

            long[] values = numbers.Select(n => 0L).ToArray();
            values[0] = 1;

            for (int index1 = 0; index1 < numbers.Count; index1++)
            {
                for (int index2 = index1 + 1; index2 < numbers.Count; index2++)
                {
                    if ((numbers[index2] - numbers[index1]) <= 3)
                    {
                        values[index2] += values[index1];
                    }
                }
            }

            Console.WriteLine("{0}", values.Last());
        }

        private int[] sortedNumbers;
    }
}
