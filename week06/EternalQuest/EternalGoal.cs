// EternalGoal.cs
// A goal that never completes. Each time you record it you gain points.

using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public EternalGoal(string title, string description, int points)
            : base(title, description, points)
        {
        }

        public override int RecordEvent()
        {
            Console.WriteLine($"You recorded '{GetTitle()}'. You earned {GetPoints()} points.");
            return GetPoints();
        }

        public override string GetDetailsString()
        {
            // Use infinity symbol to hint "never completes"
            return $"[∞] {GetTitle()} ({GetDescription()})";
        }

        public override string GetStringRepresentation()
        {
            // EternalGoal|title|desc|points
            return $"EternalGoal|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}";
        }
    }
}
