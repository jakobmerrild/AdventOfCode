using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Day14
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Day14.Properties.Resources.Input;
            int time = 2503;
            var max = 0;
            var scores = new Dictionary<Reindeer, int>();
            foreach (var line in input.Split('\n'))
            {
                var tokens = line.Split(' ');
                var r = new Reindeer
                {
                    Speed = int.Parse(tokens[3]),
                    Runtime = int.Parse(tokens[6]),
                    RuntimeMax = int.Parse(tokens[6]),
                    Waittime = int.Parse(tokens[13]),
                    WaittimeMax = int.Parse(tokens[13])
                };
                scores.Add(r, 0);
                if (max < r.Run(time))
                {
                    max = r.Run(time);
                }
            }
            for (int i = 0; i < time; i++)
            {
                foreach (var reindeer in scores.Keys)
                {
                    if (reindeer.Runtime > 0)
                    {
                        reindeer.Distance += reindeer.Speed;
                        reindeer.Runtime--;
                    }
                    else if (reindeer.Waittime > 0)
                    {
                        reindeer.Waittime--;
                    }
                    else
                    {
                        reindeer.Runtime = reindeer.RuntimeMax - 1;
                        reindeer.Distance += reindeer.Speed;
                        reindeer.Waittime = reindeer.WaittimeMax;
                    }
                }
                var leadDistance = scores.Max(kvp => kvp.Key.Distance);
                var leadReindeer = scores.Select(kvp => kvp.Key).Where(x => x.Distance == leadDistance).ToList();
                foreach (var reindeer in leadReindeer)
                {
                    scores[reindeer]++;
                }
            }
            Console.WriteLine(max);
            Console.WriteLine(scores.Max(kvp => kvp.Value));
            Console.ReadKey();
        }
    }

    class Reindeer
    {
        public int Speed { get; set; }
        public int Runtime { get; set; }
        public int RuntimeMax { get; set; }
        public int Waittime { get; set; }
        public int WaittimeMax { get; set; }
        public int Distance { get; set; }

        public int Run(int seconds)
        {
            int remainder = seconds%(RuntimeMax + WaittimeMax);
            if (remainder > RuntimeMax)
            {
                return (seconds/(RuntimeMax + WaittimeMax) + 1)*Speed*RuntimeMax;
            }
            return seconds/(RuntimeMax + WaittimeMax)*Speed*RuntimeMax + remainder*Speed;
        }
    }
}
