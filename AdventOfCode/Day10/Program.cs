using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Day10.Properties.Resources.Input;
            for (int i = 0; i < 50; i++)
            {
                var sb = new StringBuilder();
                int j = 0;
                while (j < input.Length)
                {
                    int k = 0;
                    var c = input[j];
                    while (j < input.Length && input[j] == c)
                    {
                        k++;
                        j++;
                    }
                    sb.Append(k).Append(c);
                }
                input = sb.ToString();
            }
            Console.WriteLine(input.Length);
            Console.ReadKey();
        }
    }
}
