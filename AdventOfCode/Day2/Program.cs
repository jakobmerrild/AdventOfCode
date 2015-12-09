using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Properties.Resources.Input;
            var arr = input.Split('\n');
            var paper = 0;
            var ribbon = 0;
            for (int i = 0; i < arr.Length; ++i)
            {
                var dims = arr[i].Split('x').Select(int.Parse).ToArray();
                var sides = new[]{ dims[0]*dims[1], dims[0]*dims[2], dims[1]*dims[2]};
                paper += 2*sides.Sum() + sides.Min();
                var volume = dims.Aggregate(1, (x, y) => x*y);
                var perimeters = new[] {dims[0] + dims[1], dims[0] + dims[2], dims[1] + dims[2]}.Select(x => 2*x);
                ribbon += perimeters.Min() + volume;

            }
            Console.WriteLine(@"Paper needed: {0}", paper);
            Console.WriteLine(@"Ribbon needed: {0}", ribbon);
            Console.ReadKey();
        }
    }
}
