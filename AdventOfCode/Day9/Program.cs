using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day9
{
    class Program
    {
        private static Dictionary<string, >
        static void Main(string[] args)
        {
            Dictionary<Tuple<string, string>, int> edges = new Dictionary<Tuple<string, string>, int>();
            HashSet<string> vertices = new HashSet<string>();
            var input = Properties.Resources.Input;
            var arr = input.Replace("\r", "").Split('\n');
            foreach (var s in arr)
            {
                var split1 = s.Split('=');
                var split2 = split1[0].Split(new[] {"to"}, StringSplitOptions.None);
                vertices.Add(split2[0].Trim());
                vertices.Add(split2[1].Trim());
                edges.Add(new Tuple<string, string>(split2[0].Trim(), split2[1].Trim()), int.Parse(split1[1].Trim()));
                edges.Add(new Tuple<string, string>(split2[1].Trim(), split2[0].Trim()), int.Parse(split1[1].Trim()));
            }
            
        }
    }
}
