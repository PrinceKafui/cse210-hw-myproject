using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace EternalQuestApp
{
    public class UserState
    {
        public List<Goal> Goals { get; private set; } = new List<Goal>();
        public int Score { get; private set; }
        private HashSet<string> badges = new HashSet<string>();

        public int Level => Math.Max(1, (Score / 1000) + 1);
        public IEnumerable<string> Badges => badges;

        public void AddGoal(Goal g) => Goals.Add(g);
        public void RemoveGoal(Guid id) => Goals.RemoveAll(x => x.Id == id);

        public int RecordGoalEvent(int index)
        {
            var g = Goals[index];
            int pts = g.RecordEvent();
            Score += pts;
            CheckBadges(g, pts);
            return pts;
        }

        private void CheckBadges(Goal g, int pts)
        {
            if (Score >= 5000) badges.Add("Elder Knight");
            if (Score >= 2000) badges.Add("Adventurer");
            if (Score >= 500) badges.Add("Novice");
            if (g.IsComplete()) badges.Add("Finisher");
        }

        public void SaveToFile(string path)
        {
            var wrapper = new
            {
                Score,
                Badges = badges,
                Goals = Goals.Select(g => g.ToDTO()).ToList()
            };
            File.WriteAllText(path, JsonSerializer.Serialize(wrapper, new JsonSerializerOptions { WriteIndented = true }));
        }

        public void LoadFromFile(string path)
        {
            if (!File.Exists(path)) return;
            var text = File.ReadAllText(path);
            var wrapper = JsonSerializer.Deserialize<SaveWrapper>(text);
            Score = wrapper.Score;
            badges = new HashSet<string>(wrapper.Badges ?? new List<string>());
            Goals.Clear();

            foreach (var dto in wrapper.Goals)
            {
                Goal g = dto.GoalType switch
                {
                    nameof(SimpleGoal) => SimpleGoal.FromDTO(dto),
                    nameof(EternalGoal) => EternalGoal.FromDTO(dto),
                    nameof(ChecklistGoal) => ChecklistGoal.FromDTO(dto),
                    nameof(NegativeGoal) => NegativeGoal.FromDTO(dto),
                    _ => null
                };
                if (g != null) Goals.Add(g);
            }
        }

        private class SaveWrapper
        {
            public int Score { get; set; }
            public List<string> Badges { get; set; }
            public List<GoalDTO> Goals { get; set; }
        }
    }
}
