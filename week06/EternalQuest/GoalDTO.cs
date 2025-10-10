namespace EternalQuestApp
{
    public class GoalDTO
    {
        public string GoalType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PointsPerEvent { get; set; }
        public bool Completed { get; set; }
        public int CurrentCount { get; set; }
        public int TargetCount { get; set; }
        public int BonusOnComplete { get; set; }
    }
}
