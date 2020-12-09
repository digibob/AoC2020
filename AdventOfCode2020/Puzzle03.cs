using System;

namespace AdventOfCode2020
{
    class Puzzle03
    {
        public Puzzle03(string[] lines)
        {
            this.lines = lines;
        }

        public void Run()
        {
            RunPart1();
            RunPart2();
        }

        public long CheckSlope(int xs, int ys)
        {
            int w = lines[0].Length;
            int h = lines.Length;

            int treeCount = 0;
            int x = 0;
            for (int y = ys; y < h; y += ys)
            {
                x = (x + xs) % w;

                if (lines[y][x] == '#')
                {
                    treeCount++;
                }
            }

            return treeCount;
        }

        private void RunPart1()
        {
            Console.WriteLine("{0}", CheckSlope(3, 1));
        }
        private void RunPart2()
        {
            long result = CheckSlope(1, 1)
                * CheckSlope(3, 1)
                * CheckSlope(5, 1)
                * CheckSlope(7, 1)
                * CheckSlope(1, 2);

            Console.WriteLine("{0}", result);
        }

        private string[] lines;
    }
}
