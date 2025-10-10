namespace EternalQuestApp
{
    public class EternalGoal : Goal
    {
        private int _times;

        public EternalGoal(string name, string description, int pts)
            : base(name, description, pts) { }

        public override int RecordEvent()
        {
            _times++;
            return PointsPerEvent;
        }

        public override bool IsComplete() => false;

        public override string DisplayString() =>
            $"[∞] (Eternal) {Name} - {Description} ({_times} times)";

        public override GoalDTO ToDTO() => new GoalDTO
        {
            GoalType = nameof(EternalGoal),
            Name = Name,
            Description = Description,
            PointsPerEvent = PointsPerEvent,
            CurrentCount = _times
        };

        public static EternalGoal FromDTO(GoalDTO dto)
        {
            var g = new EternalGoal(dto.Name, dto.Description, dto.PointsPerEvent);
            g._times = dto.CurrentCount;
            return g;
        }
    }
}
