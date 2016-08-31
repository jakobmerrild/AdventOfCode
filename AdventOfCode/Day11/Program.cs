using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day11
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = @"hepxcrrq";
            input = "hepxxyzz";
            input = Increment(input);
            while (!(CheckThreeStraight(input) && CheckNoIOL(input) && CheckTwoPairs(input)))
            {
                input = Increment(input);
            }
            Console.WriteLine(input);
            Console.WriteLine(CheckThreeStraight("hepxxwvv"));
            Console.ReadKey();

            

        }

        private static string Increment(string input)
        {
            if (input == "zzzzzzzz")
            {
                return "aaaaaaaa";
            }
            if (input[input.Length - 1] == 'z')
            {
                return Increment(input.Substring(0, input.Length - 1)) + "a";
            }
            return input.Substring(0, input.Length - 1) + (char)(input[input.Length - 1] + 1);
        }

        static bool CheckThreeStraight(string input)
        {
            for (int i = 0; i < input.Length - 2; i++)
            {
                if (input[i] == (char)(input[i + 1] - 1) && input[i] == (char)(input[i + 2] - 2))
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckNoIOL(string input)
        {
            return !(input.Contains('i') || input.Contains('o') || input.Contains('l'));
        }

        static bool CheckTwoPairs(string input)
        {
            for (int i = 0; i < input.Length-2; i++)
            {
                if (input[i] == input[i + 1] && CheckPair(input.Substring(i + 2)))
                {
                    return true;
                }
            }
            return false;
        }

        static bool CheckPair(string input)
        {
            for (int i = 0; i < input.Length - 1; i++)
            {
                if (input[i] == input[i + 1])
                {
                    return true;
                }
            }
            return false;
        }
    }
}
