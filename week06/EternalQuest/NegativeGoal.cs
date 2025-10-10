namespace EternalQuestApp
{
    public class NegativeGoal : Goal
    {
        private int _times;

        public NegativeGoal(string name, string description, int negativePts)
            : base(name, description, negativePts) { }

        public override int RecordEvent()
        {
            _times++;
            return PointsPerEvent;
        }

        public override bool IsComplete() => false;

        public override string DisplayString() =>
            $"[!] (Negative) {Name} - {Description} ({_times} times)";

        public override GoalDTO ToDTO() => new GoalDTO
        {
            GoalType = nameof(NegativeGoal),
            Name = Name,
            Description = Description,
            PointsPerEvent = PointsPerEvent,
            CurrentCount = _times
        };

        public static NegativeGoal FromDTO(GoalDTO dto)
        {
            var g = new NegativeGoal(dto.Name, dto.Description, dto.PointsPerEvent);
            g._times = dto.CurrentCount;
            return g;
        }
    }
}
