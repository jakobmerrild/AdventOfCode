using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Properties.Resources.Input;
            var arr = input.ToCharArray();
            int sum = 0;
            int basement = -1;
            for (int i = 0; i < arr.Length; ++i)
            {
                switch (arr[i])
                {
                    case '(':
                        sum += 1;
                        break;
                    case ')':
                        sum -= 1;
                        break;
                    default:
                        throw new Exception("Illegal character.");
                }
                if (sum < 0 && basement < 0)
                    basement = i + 1;
            }
            Console.WriteLine(@"Final floor: {0}", sum);
            Console.WriteLine(@"First time entering basement: {0}", basement);
            Console.ReadKey();
        }
    }
}
