using System;
using System.IO;

namespace MindfulnessApp
{
    static class Logger
    {
        private static readonly string logPath = "activity_log.txt";

        public static void LogActivity(string name, int duration)
        {
            string line = $"{DateTime.Now:G} - {name} ({duration}s)";
            File.AppendAllText(logPath, line + Environment.NewLine);
        }
    }
}
