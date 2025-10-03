using System;
using System.Diagnostics;
using System.Threading;

namespace MindfulnessApp
{
    abstract class Activity
    {
        private string _name;
        private string _description;
        private int _durationSeconds;

        protected Activity(string name, string description)
        {
            _name = name;
            _description = description;
        }

        protected int DurationSeconds
        {
            get => _durationSeconds;
            private set => _durationSeconds = value;
        }

        public void Run()
        {
            ShowStartingMessage();
            PrepareToBegin();
            var sw = Stopwatch.StartNew();
            RunActivity(sw);
            sw.Stop();
            ShowEndingMessage();

            Logger.LogActivity(_name, _durationSeconds);
        }

        protected void ShowStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"=== {_name} ===\n");
            Console.WriteLine(_description + "\n");
            Console.Write("Enter duration in seconds: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int seconds) && seconds > 0)
                {
                    DurationSeconds = seconds;
                    break;
                }
                Console.Write("Invalid input. Enter a positive number: ");
            }
        }

        protected void PrepareToBegin()
        {
            Console.WriteLine("\nGet ready...");
            PauseWithSpinner(4);
        }

        protected void ShowEndingMessage()
        {
            Console.WriteLine("\nWell done!");
            PauseWithSpinner(2);
            Console.WriteLine($"You completed {_name} for {DurationSeconds} seconds.");
            PauseWithSpinner(2);
            Console.WriteLine("\nPress Enter to return to the menu...");
            Console.ReadLine();
        }

        protected void PauseWithSpinner(int seconds)
        {
            char[] spinner = { '|', '/', '-', '\\' };
            var sw = Stopwatch.StartNew();
            int i = 0;
            while (sw.Elapsed.TotalSeconds < seconds)
            {
                Console.Write(spinner[i++ % spinner.Length]);
                Thread.Sleep(200);
                Console.Write('\b');
            }
            sw.Stop();
        }

        protected void Countdown(int seconds)
        {
            for (int i = seconds; i >= 1; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        protected abstract void RunActivity(Stopwatch stopwatch);

        protected string GetName() => _name;
    }
}
