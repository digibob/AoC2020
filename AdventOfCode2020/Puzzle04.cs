using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020
{
    class Puzzle04
    {
        struct Document
        {
            public Dictionary<string, string> fields;

            public bool IsValid()
            {
                return fields.ContainsKey("byr")
                    && fields.ContainsKey("iyr")
                    && fields.ContainsKey("eyr")
                    && fields.ContainsKey("hgt")
                    && fields.ContainsKey("hcl")
                    && fields.ContainsKey("ecl")
                    && fields.ContainsKey("pid");
            }
        }

        public Puzzle04(string[] lines)
        {
            Dictionary<string, string> fields = new Dictionary<string, string>();

            foreach (string line in lines)
            {
                if (line.Length == 0)
                {
                    documents.Add(new Document { fields = fields });

                    fields = new Dictionary<string, string>();
                }
                else
                {
                    foreach (string entry in line.Split(' '))
                    {
                        string[] kv = entry.Split(':');
                        fields.Add(kv[0], kv[1]);
                    }
                }
            }

            documents.Add(new Document { fields = fields });
        }

        public void Run()
        {
            RunPart1();
            RunPart2();
        }

        void RunPart1()
        {
            int count = documents.Count(x =>
            {
                return x.IsValid();
            });

            Console.WriteLine("{0}", count);
        }
        void RunPart2()
        {
            int count = documents.Count(x =>
            {
                if (!x.IsValid())
                {
                    return false;
                }

                int birthYear = int.Parse(x.fields["byr"]);
                if (birthYear < 1920 || birthYear > 2002)
                {
                    return false;
                }

                int issueYear = int.Parse(x.fields["iyr"]);
                if (issueYear < 2010 || issueYear > 2020)
                {
                    return false;
                }

                int expirationYear = int.Parse(x.fields["eyr"]);
                if (expirationYear < 2020 || expirationYear > 2030)
                {
                    return false;
                }

                string heightString = x.fields["hgt"];
                if (heightString.EndsWith("cm"))
                {
                    int heightInCM = int.Parse(heightString.Substring(0, heightString.Length - 2));
                    if (heightInCM < 150 || heightInCM > 193)
                    {
                        return false;
                    }
                }
                else if (heightString.EndsWith("in"))
                {
                    int heightInInches = int.Parse(heightString.Substring(0, heightString.Length - 2));
                    if (heightInInches < 59 || heightInInches > 76)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

                string hairColourString = x.fields["hcl"];
                if (hairColourString.Length != 7 || !hairColourString.StartsWith("#"))
                {
                    return false;
                }
                if (hairColourString.Count(c =>
                {
                    return (c >= '0' && c <= '9')
                    || (c >= 'a' && c <= 'f');
                }) != 6)
                {
                    return false;
                }

                string[] validEyeColours = { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
                if (!validEyeColours.Contains(x.fields["ecl"]))
                {
                    return false;
                }

                string passportId = x.fields["pid"];
                if (passportId.Length != 9)
                {
                    return false;
                }

                if (passportId.Count(c =>
                {
                    return (c >= '0' && c <= '9');
                }) != 9)
                {
                    return false;
                }

                return true;
            });

            Console.WriteLine("{0}", count);
        }

        private List<Document> documents = new List<Document>();
    }
}
