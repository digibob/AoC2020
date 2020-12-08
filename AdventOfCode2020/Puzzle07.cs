using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Puzzle07
    {
        public Puzzle07(string[] lines)
        {
            rules = lines.Select(l =>
            {
                string trimmedLine = l.Remove(l.Length - 1, 1);
                string[] split1 = trimmedLine.Split(new string[] { " bags contain " }, StringSplitOptions.RemoveEmptyEntries);
                string[] split2 = split1[1].Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

                Tuple<string, int>[] outputs = split2
                    .Where(s => s != "no other bags")
                    .Select(s =>
                {
                    string[] split = s.Split(' ');
                    return new Tuple<string, int>(string.Format("{0} {1}", split[1], split[2]), int.Parse(split[0]));
                }).ToArray();

                return new { input = split1[0], outputs = outputs };
            }).ToDictionary(x => x.input, x => x.outputs);
        }

        public void Run()
        {
            RunTest1();
            RunTest2();
        }

        private bool CheckForBagRecursively(string ruleName, string bagToCheckFor)
        {
            Tuple<string, int>[] outputs = rules[ruleName];
            return ruleName == bagToCheckFor || outputs.Any(o => CheckForBagRecursively(o.Item1, bagToCheckFor));
        }

        private void RunTest1()
        {
            int count = rules.Count(kv => CheckForBagRecursively(kv.Key, "shiny gold")) - 1;

            Console.WriteLine("{0}", count);
        }

        private int CountBagsResursive(string ruleName)
        {
            Tuple<string, int>[] outputs = rules[ruleName];
            return outputs.Sum(o => CountBagsResursive(o.Item1) * o.Item2) + 1;
        }

        private void RunTest2()
        {
            Tuple<string, int>[] outputs = rules["shiny gold"];

            int count = CountBagsResursive("shiny gold") - 1;

            Console.WriteLine("{0}", count);
        }

        private readonly Dictionary<string, Tuple<string, int>[]> rules;
    }
}
