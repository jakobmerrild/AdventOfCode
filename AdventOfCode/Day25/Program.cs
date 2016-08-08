using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day25
{
    class Program
    {
        static void Main(string[] args)
        {
            long size = 4000;
            long[,] matrix = new long[size,size];
            long prev = 20151125;
            long multiplier = 252533;
            long divider = 33554393;
            long limit = Limit(3010, 3019); //calculate limit based on row/column
            for (long i = 1; i < limit; i++)
            {
                prev = prev*multiplier%divider;
            }
            Console.WriteLine("The code is {0}", prev);
            Console.ReadKey();
        }

        static long Limit(long row, long column)
        {
            var sum = row*(row - 1)/2 + 1;
            for (long i = 1; i < column; i++)
            {
                sum += i + row;
            }
            return sum;
        }
    }
}
