using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day16
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Day16.Properties.Resources.Input;
            var lines = input.Split('\n');

            var checkList = new Dictionary<string, int>
            {
                { "children", 3},
                { "cats", 7 },
                { "samoyeds", 2 },
                { "pomeranians", 3 },
                { "akitas", 0 },
                { "vizslas", 0 },
                { "goldfish", 5 },
                { "trees", 3 },
                { "cars", 2 },
                { "perfumes", 1 }
            };
            int correctSue = 0;
            for (int i = 0; i < lines.Length; ++i)
            {
                var tokens = lines[i].Split(' ');
                bool correct = true;
                for (int j = 2; j < tokens.Length; j += 2)
                {
                    var key = tokens[j].Trim(':');
                    var value = int.Parse(tokens[j + 1].Trim(','));
                    if (key == "cats" || key == "trees")
                    {
                        if (checkList[key] < value) continue;
                        correct = false;
                        break;
                    }
                    if (key == "pomeranians" || key == "goldfish")
                    {
                        if (checkList[key] > value) continue;
                        correct = false;
                        break;
                    }
                    if (checkList[key] == value) continue;
                    correct = false;
                    break;
                }
                if (!correct) continue;
                correctSue = i + 1;
                break;
            }
            Console.WriteLine(correctSue);
            Console.ReadKey();
        }
    }

    class Sue
    {
        public Dictionary<string, int> Memories { get; set; }
    }
}
