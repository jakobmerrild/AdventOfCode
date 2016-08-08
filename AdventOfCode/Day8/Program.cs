using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"\\(\\|x[0-9a-f]{2}|"")");
            var regex2 = new Regex(@"\\|""");
            var input = Properties.Resources.Input;
            var arr = input.Replace("\r", "").Split('\n');//.Select(x => x.Trim('"')).ToArray();
            var sum = 0;
            var sum2 = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                var s = arr[i];
                var length = s.Length;
                s = regex.Replace(s.Trim('"'), "1");
                sum += length - s.Length;
                var length2 = regex2.Replace(arr[i], "22").Length + 2;
                sum2 += length2 - length;
            }
            Console.WriteLine(@"Sum: {0}", sum);
            Console.WriteLine(@"Sum2: {0}", sum2);
            Console.ReadKey();
        }
    }
}
