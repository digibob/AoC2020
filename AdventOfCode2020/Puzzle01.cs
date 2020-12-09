using System;
using System.Linq;

namespace AdventOfCode2020
{
    class Puzzle01
    {
        public Puzzle01(string[] lines)
        {
            numbers = lines.Select(x => int.Parse(x)).ToArray();
        }

        public void Run()
        {
            RunPart1();
            RunPart2();
        }

        private void RunPart1()
        {
            for (int index1 = 0; index1 < numbers.Length; index1++)
            {
                for (int index2 = index1 + 1; index2 < numbers.Length; index2++)
                {
                    if (numbers[index1] + numbers[index2] == 2020)
                    {
                        Console.WriteLine("{0}", numbers[index1] * numbers[index2]);
                        return;
                    }
                }
            }
        }

        private void RunPart2()
        {
            for (int index1 = 0; index1 < numbers.Length; index1++)
            {
                for (int index2 = index1 + 1; index2 < numbers.Length; index2++)
                {
                    for (int index3 = index2 + 1; index3 < numbers.Length; index3++)
                    {
                        if (numbers[index1] + numbers[index2] + numbers[index3] == 2020)
                        {
                            Console.WriteLine("{0}", numbers[index1] * numbers[index2] * numbers[index3]);
                            return;
                        }
                    }
                }
            }
        }

        private int[] numbers;
    }
}
