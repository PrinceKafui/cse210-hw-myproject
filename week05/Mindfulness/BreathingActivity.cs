using System;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    class BreathingActivity : Activity
    {
        public BreathingActivity() : base(
            "Breathing Activity",
            "This activity helps you relax by guiding your breathing. Focus and clear your mind.")
        { }

        protected override void RunActivity(Stopwatch stopwatch)
        {
            Console.WriteLine("\nFollow the breathing prompts...\n");

            bool inhale = true;
            int cycleTime = 6; 

            while (stopwatch.Elapsed.TotalSeconds < DurationSeconds)
            {
                string phase = inhale ? "Breathe in" : "Breathe out";
                VisualBreath(phase, cycleTime);
                inhale = !inhale;
            }
        }

    
        private void VisualBreath(string message, int seconds)
        {
            int half = seconds * 1000 / 2;
            int step = 200;

            Console.WriteLine($"\n{message}...");
            for (int i = 1; i <= half; i += step)
            {
                int length = (i * 20) / half; 
                Console.Write("\r" + new string('*', length));
                Thread.Sleep(step);
            }

            for (int i = half; i >= step; i -= step)
            {
                int length = (i * 20) / half;
                Console.Write("\r" + new string('*', length) + " ");
                Thread.Sleep(step);
            }

            Console.Write("\r                    \r"); 
        }
    }
}
