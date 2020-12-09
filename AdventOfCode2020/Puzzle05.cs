using System;
using System.Collections.Generic;

namespace AdventOfCode2020
{
    class Puzzle05
    {
        public Puzzle05(string[] lines)
        {
            this.lines = lines;
        }

        public void Run()
        {
            RunPart1();
            RunPart2();
        }

        private void RunPart1()
        {
            int highId = 0;

            foreach (string line in lines)
            {
                int id = CalcBoardingPassId(line);
                highId = Math.Max(highId, id);
            }

            Console.WriteLine("{0}", highId);
        }

        private void RunPart2()
        {
            HashSet<int> takenIds = new HashSet<int>();

            foreach (string line in lines)
            {
                takenIds.Add(CalcBoardingPassId(line));
            }

            for (int row = 1; row < 127; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    int id = (row * 8) + col;

                    if(!takenIds.Contains(id) && takenIds.Contains(id - 1) && takenIds.Contains(id + 1))
                    {
                        Console.WriteLine("{0}", id);
                    }
                }
            }
        }

        private static int CalcBoardingPassId(string line)
        {
            int minCol = 0;
            int maxCol = 7;
            int numCol = 8;

            int minRow = 0;
            int maxRow = 127;
            int numRow = 128;

            for (int index = 0; index < 7; index++)
            {
                if (line[index] == 'F')
                {
                    maxRow -= numRow / 2;
                    numRow /= 2;
                }
                else
                {
                    minRow += numRow / 2;
                    numRow /= 2;
                }
            }

            for (int index = 7; index < 10; index++)
            {
                if (line[index] == 'L')
                {
                    maxCol -= numCol / 2;
                    numCol /= 2;
                }
                else
                {
                    minCol += numCol / 2;
                    numCol /= 2;
                }
            }

            return (minRow * 8) + minCol;
        }

        private readonly string[] lines;
    }
}
