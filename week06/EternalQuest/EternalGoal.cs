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
            // always add points; never completes
            return GetPoints();
        }

        // Default details from base class are fine; include something clear
        public override string GetDetailsString()
        {
            return $"[∞] {GetTitle()} ({GetDescription()})";
        }

        public override string GetStringRepresentation()
        {
            // EternalGoal|title|desc|points
            return $"EternalGoal|{Escape(GetTitle())}|{Escape(GetDescription())}|{GetPoints()}";
        }

        private string Escape(string s) => s.Replace("|", "/|");
    }
}
