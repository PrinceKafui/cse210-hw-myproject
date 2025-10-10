namespace EternalQuestApp
{
    public class ChecklistGoal : Goal
    {
        private int _count;
        private int _target;
        private int _bonus;
        private bool _done;

        public ChecklistGoal(string name, string description, int pts, int target, int bonus)
            : base(name, description, pts)
        {
            _target = target;
            _bonus = bonus;
        }

        public override int RecordEvent()
        {
            if (_done) return 0;
            _count++;
            int pts = PointsPerEvent;
            if (_count >= _target)
            {
                _done = true;
                pts += _bonus;
            }
            return pts;
        }

        public override bool IsComplete() => _done;

        public override string DisplayString()
        {
            var mark = _done ? "[X]" : "[ ]";
            return $"{mark} (Checklist) {Name} - {Description} ({_count}/{_target})";
        }

        public override GoalDTO ToDTO() => new GoalDTO
        {
            GoalType = nameof(ChecklistGoal),
            Name = Name,
            Description = Description,
            PointsPerEvent = PointsPerEvent,
            CurrentCount = _count,
            TargetCount = _target,
            BonusOnComplete = _bonus,
            Completed = _done
        };

        public static ChecklistGoal FromDTO(GoalDTO dto)
        {
            var g = new ChecklistGoal(dto.Name, dto.Description, dto.PointsPerEvent, dto.TargetCount, dto.BonusOnComplete);
            g._count = dto.CurrentCount;
            g._done = dto.Completed;
            return g;
        }
    }
}
