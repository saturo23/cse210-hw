using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        // Constructor used when creating new goal
        public SimpleGoal(string title, string description, int points)
            : base(title, description, points)
        {
            _isComplete = false;
        }

        // Constructor used when loading from file
        public SimpleGoal(string title, string description, int points, bool isComplete)
            : base(title, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                // already completed, no points
                return 0;
            }
            else
            {
                _isComplete = true;
                return GetPoints();
            }
        }

        public override string GetDetailsString()
        {
            string check = _isComplete ? "[X]" : "[ ]";
            return $"{check} {GetTitle()} ({GetDescription()})";
        }

        public override string GetStringRepresentation()
        {
            // SimpleGoal|title|desc|points|isComplete
            return $"SimpleGoal|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}|{_isComplete}";
        }

        private string Escape(string s) => s.Replace("|", "/|");
    }
}
