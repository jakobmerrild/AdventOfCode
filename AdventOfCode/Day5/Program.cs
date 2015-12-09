using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var vowelPattern = new Regex(@"(.*?[aeiou].*?){3,}");
            var badPattern = new Regex(@"ab|cd|pq|xy");
            var seqPattern = new Regex(@"(\w)\1");

            var pairPattern = new Regex(@"(.{2,}).*?\1");
            var spacePattern = new Regex(@"(.).\1");
            var input = Properties.Resources.Input;
            var arr = input.Split('\n');

            var tests = new[] { @"qjhvhtzxzqqjkmpb", @"xxyxx", @"uurcxstgmygtbstg", @"ieodomkazucvgmuy", @"aaa" };
            for (int i = 0; i < tests.Length; ++i)
            {
                Console.WriteLine(pairPattern.IsMatch(tests[i]) && spacePattern.IsMatch(tests[i]));
            }

            int sum = arr.Count(s => vowelPattern.IsMatch(s) && !badPattern.IsMatch(s) && seqPattern.IsMatch(s));
            int newSum = arr.Count(s => pairPattern.IsMatch(s) && spacePattern.IsMatch(s));
            Console.WriteLine(@"Number of nice words: {0}", sum);
            Console.WriteLine(@"Number of new nice words: {0}", newSum);
            Console.ReadKey();
        }
    }
}
