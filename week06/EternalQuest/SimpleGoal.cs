namespace EternalQuestApp
{
    public class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
            _completed = false;
        }

        public override int RecordEvent()
        {
            if (_completed) return 0;
            _completed = true;
            return PointsPerEvent;
        }

        public override bool IsComplete() => _completed;

        public override string DisplayString()
        {
            var mark = _completed ? "[X]" : "[ ]";
            return $"{mark} (Simple) {Name} - {Description}";
        }

        public override GoalDTO ToDTO() => new GoalDTO
        {
            GoalType = nameof(SimpleGoal),
            Name = Name,
            Description = Description,
            PointsPerEvent = PointsPerEvent,
            Completed = _completed
        };

        public static SimpleGoal FromDTO(GoalDTO dto)
        {
            var g = new SimpleGoal(dto.Name, dto.Description, dto.PointsPerEvent);
            g._completed = dto.Completed;
            return g;
        }
    }
}
