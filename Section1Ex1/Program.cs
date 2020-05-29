using System;
using System.Collections.Generic;
using System.Threading;

namespace Section1Ex1
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw1 = new StopWatch();
            bool doRun = true;

            while (doRun)
            {
                try
                {
                    var action = (ListOptions()).ToLower();
                    if (action == "start") sw1.Start();
                    else if (action == "stop") sw1.Stop();
                    else if (action == "duration") sw1.ReportDuration();
                    else if (action == "quit") doRun = false;
                    else Console.WriteLine(">> Invalid Selection - try again");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        static string ListOptions()
        {
            int min = int.MaxValue;
            int max = 0;
            int idx = 0;

            string[] options = new string[] { "Start", "Stop", "Show Elapsed Time", "Quit" };
            Console.WriteLine("\n>> Please select stopwatch option:");
            foreach (var opt in options)
            {
                Console.WriteLine("{0,3}. {1}", ++idx, opt);
                max = Math.Max(max, idx);
                min = Math.Min(min, idx);
            }

            int sel = InputInteger("Input option number", min, max);
            return (sel == 3) ? "Duration" : options[sel-1];
        }


        public static int InputInteger(string text, int? min, int? max)
        {
            bool ok = false;
            int num = 0;
            string range;

            // Number range display
            if (min.HasValue && max.HasValue) { range = " (" + min + "-" + max + ")"; }
            else if (max.HasValue) { range = " (<=" + max + ")"; }
            else if (min.HasValue) { range = " (>=" + min + ")"; }
            else range = "";

            if (!min.HasValue) { min = int.MinValue; }
            if (!max.HasValue) { max = int.MaxValue; }

            if (string.IsNullOrEmpty(text)) { text = "Input an integer"; }
            while (!ok)
            {
                Console.Write("{0}{1}: ", text, range);
                string numstr = Console.ReadLine();
                ok = int.TryParse(numstr, out num);
                ok = (ok && num >= min && num <= max);
                if (!ok) Console.WriteLine("Invalid input - please try again");
            }
            return num;
        }
    }

}
