using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Day12
{
    class Program
    {
        static void Main(string[] args)
        {

            JObject root = JObject.Parse(Day12.Properties.Resources.Input);
            Console.WriteLine(SumObjects(root));
            Console.WriteLine(SumObjectsNoRed(root));
            Console.ReadKey();

        }
        
        static int SumTokens(JToken token)
        {
            if (token.Type == JTokenType.Object)
            {
                return SumObjects(token.ToObject<JObject>());
            }
            if (token.Type == JTokenType.Array)
            {
                int sum = 0;
                foreach (var child in token)
                {
                    sum += SumTokens(child);
                }
                return sum;
            }
            if (token.Type == JTokenType.Integer)
            {
                return token.ToObject<int>();
            }
            return 0;

        }

        private static int SumObjects(JObject obj)
        {
            int sum = 0;
            foreach (var kvp in obj)
            {
                sum += SumTokens(kvp.Value);
            }
            return sum;
        }

        private static int SumObjectsNoRed(JObject obj)
        {
            int sum = 0;
            foreach (var kvp in obj)
            {
                if (kvp.Value.Type == JTokenType.String && kvp.Value.ToObject<string>() == "red")
                {
                    return 0;
                }
                sum += SumTokensNoRed(kvp.Value);
            }
            return sum;
        }

        private static int SumTokensNoRed(JToken token)
        {
            if (token.Type == JTokenType.Object)
            {
                return SumObjectsNoRed(token.ToObject<JObject>());
            }
            if (token.Type == JTokenType.Array)
            {
                int sum = 0;
                foreach (var child in token)
                {
                    sum += SumTokensNoRed(child);
                }
                return sum;
            }
            if (token.Type == JTokenType.Integer)
            {
                return token.ToObject<int>();
            }
            return 0;
        }
    }
}
