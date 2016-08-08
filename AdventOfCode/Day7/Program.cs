using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day7
{
    internal class Program
    {         
        private static Dictionary<string, ushort> memoization = new Dictionary<string, ushort>();
        private static void Main(string[] args)
        {
            var input = Properties.Resources.Input.Replace("\r", "");
            
            var arr = input.Split('\n');
            var sum = 0;
            var map = new Dictionary<string, string>();
            foreach (var s in arr)
            {
                var split = s.Split(new[] {"->"}, StringSplitOptions.None);
                map.Add(split[1].Trim(), split[0].Trim());
            }
            var result = Solve("a", map);

            Console.WriteLine(@"a:{0}", result);
            map["b"] = result.ToString();
            memoization = new Dictionary<string, ushort>();
            result = Solve("a", map);
            Console.WriteLine(@"a:{0}", result);
            Console.ReadKey();
        }
        public static ushort Solve(string id, Dictionary<string, string> map)
        {
            if (memoization.ContainsKey(id))
            {
                return memoization[id];
            }
            ushort result;
            if (ushort.TryParse(id, out result))
            {
                return result;
            }
            var value = map[id];
            var split = value.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
            switch (split.Length)
            {
                case 1:
                    result = Solve(split[0], map);
                    break;
                case 3:
                    var _1 = split[0];
                    var _2 = split[2];
                    switch (split[1])
                    {
                        case "OR": 
                            result = (ushort) (Solve(_1, map) | Solve(_2, map));
                            break;
                        case "AND":
                            result = (ushort) (Solve(_1, map) & Solve(_2, map));
                            break;
                        case "LSHIFT":
                            result = (ushort) (Solve(_1, map) << Solve(_2, map));
                            break;
                        case "RSHIFT":
                            result = (ushort) (Solve(_1, map) >> Solve(_2, map));
                            break;
                        default:
                            throw new Exception();
                    }
                    break;
                case 2:
                    result = (ushort) ~Solve(split[1], map);
                    break;
                default:
                    throw new Exception();
            }
            memoization.Add(id, result);
            return result;

        }
    }
}
