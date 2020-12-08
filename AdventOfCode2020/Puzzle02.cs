using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Puzzle02
    {
        struct Entry
        {
            public Entry(string text)
            {
                string[] split = text.Split(new char[] { ' ', ':', '-' });

                min = int.Parse(split[0]);
                max = int.Parse(split[1]);
                letter = split[2][0];
                password = split[4];
            }

            public char letter;
            public int min;
            public int max;
            public string password;
        }

        public Puzzle02(string[] lines)
        {
            entries = lines.Select(x => new Entry(x)).ToArray();
        }

        public void Run()
        {
            RunPart1();
            RunPart2();
        }

        public void RunPart1()
        {
            int count = entries.Count(x =>
            {
                int charCount = x.password.Count(c => c == x.letter);

                return charCount >= x.min && charCount <= x.max;
            });

            Console.WriteLine("{0}", count);
        }
        public void RunPart2()
        {
            int count = entries.Count(x =>
            {
                return (x.password[x.min - 1] == x.letter) ^ (x.password[x.max - 1] == x.letter);
            });

            Console.WriteLine("{0}", count);
        }

        private Entry[] entries;
    }
}
