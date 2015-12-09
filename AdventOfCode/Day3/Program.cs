using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Properties.Resources.Input;
            var arr = input.ToCharArray();
            var currentPos = new Tuple<int, int>(0, 0);
            var roboPos = new Tuple<int, int>(0, 0);
            var visitedLocations = new HashSet<Tuple<int, int>>();
            visitedLocations.Add(currentPos);
            for (int i = 0; i < arr.Length; ++i)
            {
                Tuple<int, int> tmp = i % 2 == 0 ? currentPos : roboPos;
                switch (arr[i])
                {
                    case '>':
                        tmp = new Tuple<int, int>(tmp.Item1 + 1, tmp.Item2);
                        break;
                    case '^':
                        tmp = new Tuple<int, int>(tmp.Item1, tmp.Item2 + 1);
                        break;
                    case '<':
                        tmp = new Tuple<int, int>(tmp.Item1 - 1, tmp.Item2);
                        break;
                    case 'v':
                        tmp = new Tuple<int, int>(tmp.Item1, tmp.Item2 - 1);
                        break;
                    default:
                        throw new Exception("Illegal character.");
                }                   
                visitedLocations.Add(tmp);
                if (i%2 == 0)
                    currentPos = tmp;
                else
                    roboPos = tmp;
            }
            Console.WriteLine(@"Number of visited locations: {0}", visitedLocations.Count);
            Console.ReadKey();
        }
    }
}
