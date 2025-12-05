using System;

namespace EternalQuest
{
    public class SimpleGoal : Goal
    {
        private bool _isComplete;

        // Constructor for creating a new SimpleGoal
        public SimpleGoal(string title, string description, int points)
            : base(title, description, points)
        {
            _isComplete = false;
        }

        // Constructor used when loading from file (includes saved completion state)
        public SimpleGoal(string title, string description, int points, bool isComplete)
            : base(title, description, points)
        {
            _isComplete = isComplete;
        }

        public override int RecordEvent()
        {
            if (_isComplete)
            {
                Console.WriteLine("This goal is already complete. No points awarded.");
                return 0; // already done
            }

            _isComplete = true;
            Console.WriteLine($"Goal complete! You earned {GetPoints()} points.");
            return GetPoints();
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
    }
}
