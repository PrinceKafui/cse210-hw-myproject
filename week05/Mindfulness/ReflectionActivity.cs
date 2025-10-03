using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MindfulnessApp
{
    class ReflectionActivity : Activity
    {
        private List<string> _prompts = new List<string>
        {
            "Think of a time when you stood up for someone.",
            "Think of a time you accomplished something difficult.",
            "Think of a time you helped someone in need.",
            "Think of a time you made a big positive change."
        };

        private List<string> _questions = new List<string>
        {
            "Why was this experience meaningful?",
            "What did you learn from it?",
            "How did you feel after it?",
            "What can you apply from it today?",
            "What strength did you discover?"
        };

        public ReflectionActivity() : base(
            "Reflection Activity",
            "Reflect on moments of strength and resilience to build self-awareness.")
        { }

        protected override void RunActivity(Stopwatch stopwatch)
        {
            var rnd = new Random();
            Console.WriteLine("\nPrompt: " + _prompts[rnd.Next(_prompts.Count)]);
            Console.WriteLine("\nPress Enter when ready...");
            Console.ReadLine();

            while (stopwatch.Elapsed.TotalSeconds < DurationSeconds)
            {
                string q = _questions[rnd.Next(_questions.Count)];
                Console.WriteLine("\n" + q);
                PauseWithSpinner(5);
            }
        }
    }
}
