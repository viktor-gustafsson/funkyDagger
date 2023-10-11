using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ServiceUtils
{
    public static class MarqueeService
    {
        static int Sleep { get; set; }
        public static void Marquee(string input,int sleep = 25)
        {
            Sleep = sleep;
            foreach (char c in input)
            {
                Console.Write(c);
                Thread.Sleep(MarqueeService.Sleep);
            }
            Console.WriteLine();
        }
    }
}
