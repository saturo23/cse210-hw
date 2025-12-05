// ChecklistGoal.cs
// A goal that requires N completions. Awards points each time and a bonus when target reached.

using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _timesCompleted;
        private int _targetCount;
        private int _bonusPoints;

        // Constructor for new checklist goal
        public ChecklistGoal(string title, string description, int pointsPerEvent, int targetCount, int bonus)
            : base(title, description, pointsPerEvent)
        {
            _timesCompleted = 0;
            _targetCount = targetCount;
            _bonusPoints = bonus;
        }

        // Constructor for loading from file (saved timesCompleted included)
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
                Console.WriteLine("This checklist goal is already finished. No points awarded.");
                return 0;
            }

            _timesCompleted++;
            int awarded = GetPoints();

            if (_timesCompleted == _targetCount)
            {
                awarded += _bonusPoints;
                Console.WriteLine($"You completed the checklist! You earned {GetPoints()} + bonus { _bonusPoints } = {awarded} points.");
            }
            else
            {
                Console.WriteLine($"Progress recorded ({_timesCompleted}/{_targetCount}). You earned {GetPoints()} points.");
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
    }
}
