using System;
using System.Linq;

namespace EternalQuestApp
{
    class Program
    {
        static UserState state = new UserState();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Eternal Quest!");
            bool done = false;
            while (!done)
            {
                ShowMainMenu();
                var choice = Console.ReadLine()?.Trim();
                Console.WriteLine();
                switch (choice)
                {
                    case "1": CreateGoalMenu(); break;
                    case "2": ListGoals(); break;
                    case "3": RecordEventMenu(); break;
                    case "4": ShowScoreAndProfile(); break;
                    case "5": SaveToFile(); break;
                    case "6": LoadFromFile(); break;
                    case "7": RemoveGoalMenu(); break;
                    case "0": done = true; break;
                    default: Console.WriteLine("Unknown option. Try again."); break;
                }
                Console.WriteLine();
            }
            Console.WriteLine("Goodbye - keep going on your quest!");
        }

        static void ShowMainMenu()
        {
            Console.WriteLine("=== Main Menu ===");
            Console.WriteLine("1) Create a new goal");
            Console.WriteLine("2) Show goals");
            Console.WriteLine("3) Record an event for a goal");
            Console.WriteLine("4) Show score / profile");
            Console.WriteLine("5) Save goals & score");
            Console.WriteLine("6) Load goals & score");
            Console.WriteLine("7) Remove a goal");
            Console.WriteLine("0) Exit");
            Console.Write("Choice: ");
        }

        static void CreateGoalMenu()
        {
            Console.WriteLine("Choose goal type:");
            Console.WriteLine("1) Simple goal (one-time)");
            Console.WriteLine("2) Eternal goal (repeatable)");
            Console.WriteLine("3) Checklist goal (complete N times)");
            Console.WriteLine("4) Negative goal (lose points) - extra");
            Console.Write("Choice: ");
            var c = Console.ReadLine()?.Trim();
            Console.Write("Name: ");
            var name = Console.ReadLine() ?? "";
            Console.Write("Description: ");
            var desc = Console.ReadLine() ?? "";

            switch (c)
            {
                case "1":
                    int pts = ReadInt("Points on completion: ");
                    state.AddGoal(new SimpleGoal(name, desc, pts));
                    Console.WriteLine("Simple goal created.");
                    break;
                case "2":
                    int epts = ReadInt("Points per recording: ");
                    state.AddGoal(new EternalGoal(name, desc, epts));
                    Console.WriteLine("Eternal goal created.");
                    break;
                case "3":
                    int ppe = ReadInt("Points per recording: ");
                    int target = ReadInt("Number of times to complete: ");
                    int bonus = ReadInt("Bonus on completion: ");
                    state.AddGoal(new ChecklistGoal(name, desc, ppe, target, bonus));
                    Console.WriteLine("Checklist goal created.");
                    break;
                case "4":
                    int npts = ReadInt("Points to subtract each time (enter positive): ");
                    state.AddGoal(new NegativeGoal(name, desc, -Math.Abs(npts)));
                    Console.WriteLine("Negative goal created.");
                    break;
                default:
                    Console.WriteLine("Unknown choice; cancelled.");
                    break;
            }
        }

        static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int val)) return val;
                Console.WriteLine("Invalid number, try again.");
            }
        }

        static void ListGoals()
        {
            Console.WriteLine("=== Goals ===");
            if (!state.Goals.Any())
            {
                Console.WriteLine("No goals yet.");
                return;
            }
            for (int i = 0; i < state.Goals.Count; i++)
            {
                Console.WriteLine($"{i + 1}) {state.Goals[i].DisplayString()}");
            }
        }

        static void RecordEventMenu()
        {
            if (!state.Goals.Any())
            {
                Console.WriteLine("No goals to record.");
                return;
            }
            ListGoals();
            int idx = ReadInt("Goal number (0 cancel): ") - 1;
            if (idx < 0 || idx >= state.Goals.Count) return;
            int pts = state.RecordGoalEvent(idx);
            Console.WriteLine(pts >= 0 ? $"You gained {pts} pts!" : $"You lost {-pts} pts!");
        }

        static void ShowScoreAndProfile()
        {
            Console.WriteLine($"Score: {state.Score}");
            Console.WriteLine($"Level: {state.Level}");
            Console.WriteLine("Badges: " + (state.Badges.Any() ? string.Join(", ", state.Badges) : "None"));
        }

        static void SaveToFile()
        {
            Console.Write("Filename (default: save.json): ");
            var path = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(path)) path = "save.json";
            state.SaveToFile(path);
            Console.WriteLine("Saved.");
        }

        static void LoadFromFile()
        {
            Console.Write("Filename (default: save.json): ");
            var path = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(path)) path = "save.json";
            state.LoadFromFile(path);
            Console.WriteLine("Loaded.");
        }

        static void RemoveGoalMenu()
        {
            ListGoals();
            int idx = ReadInt("Goal number to remove (0 cancel): ") - 1;
            if (idx >= 0 && idx < state.Goals.Count)
            {
                var g = state.Goals[idx];
                state.RemoveGoal(g.Id);
                Console.WriteLine($"Removed: {g.Name}");
            }
        }
    }
}
