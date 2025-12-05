using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _targetCount;
        private int _bonusPoints;

        // Constructor for new
        public ChecklistGoal(string title, string description, int pointsPerEvent, int targetCount, int bonus)
            : base(title, description, pointsPerEvent)
        {
            _targetCount = targetCount;
            _bonusPoints = bonus;
            _timesCompleted = 0;
        }

        // Constructor for loading from file
        public ChecklistGoal(string title, string description, int pointsPerEvent, int timesCompleted, int targetCount, int bonus)
            : base(title, description, pointsPerEvent)
        {
            _timesCompleted = timesCompleted;
            _targetCount = targetCount;
            _bonusPoints = bonus;
        }

        public override int RecordEvent()
        {
            if (_timesCompleted >= _targetCount)
            {
                // Already finished
                return 0;
            }

            _timesCompleted++;
            int awarded = GetPoints();

            if (_timesCompleted == _targetCount)
            {
                // final completion bonus
                awarded += _bonusPoints;
            }

            return awarded;
        }

        public override string GetDetailsString()
        {
            string status = _timesCompleted >= _targetCount ? "[X]" : "[ ]";
            return $"{status} {GetTitle()} ({GetDescription()}) -- Completed {_timesCompleted}/{_targetCount}";
        }

        public override string GetStringRepresentation()
        {
            // ChecklistGoal|title|desc|points|timesCompleted|targetCount|bonus
            return $"ChecklistGoal|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}|{_timesCompleted}|{_targetCount}|{_bonusPoints}";
        }

        private string Escape(string s) => s.Replace("|", "/|");
    }
}
