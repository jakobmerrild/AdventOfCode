using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day6
{
    class Program
    {
        
        static void Main(string[] args)
        {

            int[][] lights = new int[1000][];
            for(int i = 0; i < lights.Length; ++i)
                lights[i] = new int[1000];

            var input = Properties.Resources.Input.Replace(@"\r", "");
            var arr = input.Split('\n');
            var pattern = new Regex(@"(?<instruction>turn (on|off)|toggle) (?<x1>\d+),(?<y1>\d+) through (?<x2>\d+),(?<y2>\d+)");
            for (int i = 0; i < arr.Length; ++i)
            {
                var match = pattern.Match(arr[i]);
                int x1 = int.Parse(match.Groups["x1"].Value),
                    y1 = int.Parse(match.Groups["y1"].Value),
                    x2 = int.Parse(match.Groups["x2"].Value),
                    y2 = int.Parse(match.Groups["y2"].Value);

                switch (match.Groups["instruction"].Value)
                {
                    case "turn on":
                        for (int j = x1; j <= x2; ++j)
                            for (int h = y1; h <= y2; ++h)
                                lights[j][h] += 1;
                        break;
                    case "turn off":
                        for (int j = x1; j <= x2; ++j)
                            for (int h = y1; h <= y2; ++h)
                                lights[j][h] = Math.Max(0, lights[j][h]-1);
                        break;
                    case "toggle":
                        for (int j = x1; j <= x2; ++j)
                            for (int h = y1; h <= y2; ++h)
                                lights[j][h] += 2;
                        break;
                    default:
                        throw new Exception("Invalid input.");
                }
            }
            int sum = 0;
            for (int i = 0; i < lights.Length; ++i)
                for (int j = 0; j < lights[i].Length; ++j)
                    sum += lights[i][j];

            Console.WriteLine(@"Number of switched on lights: {0}", sum);
            Console.ReadKey();
        }
    }
}
