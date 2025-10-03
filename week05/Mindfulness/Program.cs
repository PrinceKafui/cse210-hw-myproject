using System;

namespace MindfulnessApp
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Welcome to the Mindfulness App ===");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("\nChoose an option: ");

                string choice = Console.ReadLine();
                Activity activity = choice switch
                {
                    "1" => new BreathingActivity(),
                    "2" => new ReflectionActivity(),
                    "3" => new ListingActivity(),
                    "4" => null,
                    _ => null
                };

                if (choice == "4") break;

                if (activity != null)
                    activity.Run();
                else
                {
                    Console.WriteLine("Invalid choice. Press Enter...");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("Goodbye, Stay mindful!!!");
        }
    }
}
