using System;

namespace EternalQuestApp
{
    public abstract class Goal
    {
        private string _name;
        private string _description;
        private int _pointsPerEvent;

        public Guid Id { get; private set; } = Guid.NewGuid();

        public string Name => _name;
        public string Description => _description;
        public int PointsPerEvent => _pointsPerEvent;

        protected Goal(string name, string description, int pointsPerEvent)
        {
            _name = name;
            _description = description;
            _pointsPerEvent = pointsPerEvent;
        }

        public abstract int RecordEvent();
        public abstract bool IsComplete();
        public abstract string DisplayString();
        public abstract GoalDTO ToDTO();
    }
}
