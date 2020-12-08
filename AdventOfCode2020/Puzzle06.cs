using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Puzzle06
    {
        struct Group
        {
            public string[] entries;
        }

        public Puzzle06(string[] lines)
        {
            List<string> entries = new List<string>();

            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    groups.Add(new Group { entries = entries.ToArray() });
                    entries.Clear();
                }
                else
                {
                    entries.Add(line);
                }
            }

            groups.Add(new Group { entries = entries.ToArray() });
        }

        public void Run()
        {
            RunTest1();
            RunTest2();
        }

        private void RunTest1()
        {
            int totalQuestionsAnswered = groups.Sum(group =>
            {
                HashSet<char> questionsAnswered = new HashSet<char>();

                foreach (string entry in group.entries)
                {
                    foreach (char c in entry)
                    {
                        questionsAnswered.Add(c);
                    }
                }

                return questionsAnswered.Count;
            });

            Console.WriteLine("{0}", totalQuestionsAnswered);
        }

        private void RunTest2()
        {
            int totalQuestionsAnswered = groups.Sum(group =>
            {
                bool[] questionsFailed = new bool[26];

                foreach (string entry in group.entries)
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        if (!entry.Contains(c))
                        {
                            questionsFailed[c - 'a'] = true;
                        }
                    }
                }

                return questionsFailed.Count(b => b == false);
            });

            Console.WriteLine("{0}", totalQuestionsAnswered);
        }

        private List<Group> groups = new List<Group>();
    }
}
