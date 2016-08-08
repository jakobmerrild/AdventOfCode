using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            const string input = @"bgvyzdsv";
            int suffix = 1;
            while (true)
            {
                using (var md5 = MD5.Create())
                {
                    var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(input + suffix));
                    //First 5 digits in the hexadecimal representation are 0 when the first 20 bits are 0
/*                    if (hash[0] == 0 && hash[1] == 0 && (hash[2] & 240) == 0)
                        break;*/
                    //First 6 digits in the hexadecimal representation are 0 when the first 24 bits are 0
                    if (hash[0] == 0 && hash[1] == 0 && hash[2] == 0)
                        break;
                }
                ++suffix;
            }
            Console.WriteLine("Answer: {0}", suffix);
            Console.ReadKey();
        }
    }
}
