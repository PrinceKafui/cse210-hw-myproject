using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace MindfulnessApp
{
    class ListingActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "List people you appreciate:",
            "List personal strengths:",
            "List good things that happened today:",
            "List ways you've helped others:"
        };

        public ListingActivity() : base(
            "Listing Activity",
            "List positive things in your life to increase gratitude.")
        { }

        protected override void RunActivity(Stopwatch stopwatch)
        {
            var rnd = new Random();
            string prompt = _prompts[rnd.Next(_prompts.Count)];
            Console.WriteLine("\n" + prompt);
            Console.WriteLine("\nGet ready...");
            Countdown(3);

            List<string> items = new();
            var cts = new CancellationTokenSource();

            while (stopwatch.Elapsed.TotalSeconds < DurationSeconds)
            {
                int remainingMs = Math.Max(0, DurationSeconds * 1000 - (int)stopwatch.ElapsedMilliseconds);
                if (remainingMs <= 0) break;

                string line = ReadLineWithTimeout(remainingMs, cts.Token);
                if (!string.IsNullOrWhiteSpace(line))
                    items.Add(line.Trim());
            }

            Console.WriteLine($"\nYou listed {items.Count} items:");
            foreach (var i in items) Console.WriteLine($"- {i}");
        }

        private string ReadLineWithTimeout(int timeoutMs, CancellationToken token)
        {
            var readTask = Task.Run(Console.ReadLine, token);
            return readTask.Wait(timeoutMs) ? readTask.Result : null;
        }
    }
}
